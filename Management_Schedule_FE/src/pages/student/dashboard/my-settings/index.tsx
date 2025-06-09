import StudentLayout from "@/components/features/guest/StudentLayout"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Bell, Shield, User } from "lucide-react"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
  DialogOverlay,
} from "@/components/ui/dialog"
import { useState, useEffect } from "react"
import useSWR from "swr"
import { useAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { Constants } from "@/lib/constants"
import { UserProfile } from "@/hooks/api/user/use-get-users"
import {
  showErrorToast,
  showSuccessToast,
} from "@/components/common/toast/toast"
import format from "date-fns/format"
import TeacherLayout from "@/components/features/guest/TeacherLayout"

const phoneRegex =
  /^(?:\+84|0)(?:3[2-9]|5[6|8|9]|7[0|6-9]|8[1-5]|9[0-4|6-9])[0-9]{7}$/
export default function Page() {
  const [user] = useAtom(userInfoAtom)
  const [inputValue, setInputValue] = useState<string>("")
  const [userInfo, setUserInfo] = useState<UserProfile | null>(null)
  const [avatarFile, setAvatarFile] = useState<File | null>(null)
  const [avatarPreview, setAvatarPreview] = useState<string | null>(null)
  const [dateError, setDateError] = useState<string | null>(null)
  const [token, setToken] = useState("")
  const [activeField, setActiveField] = useState<keyof UserProfile | null>(null)
  const [phoneError, setPhoneError] = useState<string | null>(null)
  const closePopup = () => setActiveField(null)
  const [openChangePassword, setOpenChangePassword] = useState(false)
  const changePassword = () => {
    setOpenChangePassword(true)
  }

  const handleChangePassword = () => {}
  const email: string | undefined = user?.email
  useEffect(() => {
    const accessToken = localStorage.getItem(Constants.API_TOKEN_KEY)
    if (accessToken) {
      setToken(accessToken)
    }
  }, [])

  const getUserByEmail = async (url: string) => {
    const response = await axios.get(url)
    return response.data.data
  }

  const { data, error, isLoading, mutate } = useSWR(
    email
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Users.GETUSERBYEMAIL(email)}`
      : null,
    getUserByEmail,
  )

  if (error) {
    showErrorToast(error.message)
  }

  useEffect(() => {
    if (data) {
      console.log("data tu api", data)
      setUserInfo(data)
    }
  }, [data])

  const openPopup = (field: keyof UserProfile) => {
    setActiveField(field)
    if (!userInfo) return

    switch (field) {
      case "dateOfBirth": {
        debugger
        let raw = userInfo.dateOfBirth || ""
        if (/^\d{2}\/\d{2}\/\d{4}$/.test(raw)) {
          const [d, m, y] = raw.split("/")
          raw = `${y}-${m}-${d}`
        }
        if (/^\d{4}-\d{2}-\d{2}T/.test(raw)) {
          raw = raw.split("T")[0]
        }
        setInputValue(raw)
        setDateError(null)
        break
      }
      case "phone": {
        setInputValue(userInfo.phone || "")
        setPhoneError(null)
        break
      }
      case "fullName":
        setInputValue(userInfo.fullName || "")
        break
      case "address":
        setInputValue(userInfo.address || "")
        break
      case "avatarUrl":
        setInputValue(userInfo.avatarUrl || "")
        break
    }
  }

  const handlePhoneChange = (value: string) => {
    setInputValue(value)
    if (!value) {
      setPhoneError(null)
      return
    }
    if (!phoneRegex.test(value)) setPhoneError("Số điện thoại không hợp lệ.")
    else setPhoneError(null)
  }
  const todayStr = new Date().toISOString().split("T")[0]

  const handleDateChange = (value: string) => {
    if (!value) {
      setDateError(null)
      setInputValue(value)
      return
    }
    if (value > todayStr) {
      setDateError("Ngày không được sau hôm nay.")
    } else {
      setDateError(null)
      setInputValue(value)
    }
  }

  const handleSubmit = async (field: keyof UserProfile, value: string) => {
    debugger
    if (!value.trim()) {
      showErrorToast("Vui lòng nhập giá trị trước khi lưu.")
      return
    }
    if (field === "dateOfBirth" && dateError) {
      showErrorToast(dateError)
      return
    }
    if (field === "phone" && phoneError) {
      showErrorToast(phoneError)
      return
    }
    console.log("data local", user)
    console.log("data userinfo", userInfo)
    const updatedUser = { ...userInfo, [field]: value }
    const formData = new FormData()
    Object.entries(updatedUser).forEach(([k, v]) => {
      if (v != null) {
        if (k === "avatarUrl" && avatarFile) formData.append(k, avatarFile)
        else formData.append(k, String(v))
      }
    })

    formData.forEach((value, key) => {
      console.log(key, value)
    })

    try {
      const response = await axios.put(
        email
          ? `${Endpoints.baseApiURL.URL}/${Endpoints.Users.UPDATEBYEMAIL(email)}`
          : "",
        formData,
        {
          headers: {
            Authorization: `Bearer ${token}`,
            "Content-Type": "multipart/form-data",
          },
        },
      )
      closePopup()
      if (response.status === 200) {
        mutate()
        setUserInfo(response.data.data)
        showSuccessToast(response.data.message)
      }
    } catch (err: any) {
      showErrorToast(err?.response?.data?.message || "Lỗi cập nhật")
    }
  }
  return (
    <StudentLayout>
      <h1 className="text-2xl font-bold mb-6">Cài đặt</h1>

      <div className="flex">
        {/* Settings Content */}
        <div className="flex-1">
          <div className="bg-white rounded-lg border p-6">
            <div className="flex flex-row justify-between items-center">
              <h2 className="text-lg font-medium mb-6">Thông tin cá nhân</h2>
              <Button
                variant="ghost"
                size="sm"
                className="text-sx font-semibold text-red-500 hover:text-gray-700"
                onClick={() => changePassword()}
              >
                Đổi mật khẩu
              </Button>
            </div>
            {/* Name */}
            <div className="mb-6 space-y-2">
              <div className="flex items-center justify-between mb-2">
                <h3 className="text-sm font-medium text-gray-700">Họ tên</h3>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-xs text-gray-500 hover:text-gray-700"
                  onClick={() => openPopup("fullName")}
                >
                  Chỉnh sửa
                </Button>
              </div>
              <p className="text-sm">{userInfo?.fullName}</p>
              <p className="text-xs text-gray-500 mt-1">
                Tên của bạn xuất hiện trên trang cá nhân và bên cạnh các bình
                luận của bạn.
              </p>
            </div>

            {/* Address */}
            <div className="mb-6 space-y-2">
              <div className="flex items-center justify-between mb-2">
                <h3 className="text-sm font-medium text-gray-700">Địa chỉ</h3>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-xs text-gray-500 hover:text-gray-700"
                  onClick={() => openPopup("address")}
                >
                  Chỉnh sửa
                </Button>
              </div>
              <p className="text-sm">{userInfo?.address}</p>
              <p className="text-xs text-gray-500 mt-1">Địa chỉ của bạn.</p>
            </div>

            {/* Avatar */}
            <div className="mb-6 space-y-2">
              <div className="flex items-center justify-between mb-2">
                <h3 className="text-sm font-medium text-gray-700">Avatar</h3>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-xs text-gray-500 hover:text-gray-700"
                  onClick={() => openPopup("avatarUrl")}
                >
                  Chỉnh sửa
                </Button>
              </div>
              <div className="flex items-start">
                <Avatar className="h-16 w-16 mr-4">
                  <AvatarImage
                    src={
                      userInfo?.avatarUrl ??
                      "/placeholder.svg?height=64&width=64"
                    }
                    alt="User"
                  />
                  <AvatarFallback>NA</AvatarFallback>
                </Avatar>
                <p className="text-xs text-gray-500">
                  Nên là ảnh vuông, chấp nhận các tệp: JPG, PNG hoặc GIF.
                </p>
              </div>
            </div>
            {/* Email */}
            <div className="mb-6 space-y-2">
              <h3 className="text-sm font-medium text-gray-700 mb-2">Email</h3>
              <p className="text-sm">{userInfo?.email}</p>
              <p className="text-xs text-gray-500 mt-1">
                Email để liên kết với Wonderland.
              </p>
            </div>

            {/* Birth Date */}
            <div className="mb-6">
              <div className="flex items-center justify-between mb-2">
                <h3 className="text-sm font-medium text-gray-700">Ngày sinh</h3>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-xs text-gray-500 hover:text-gray-700"
                  onClick={() => openPopup("dateOfBirth")}
                >
                  Chỉnh sửa
                </Button>
              </div>
              <p className="text-sm">
                {userInfo?.dateOfBirth
                  ? format(new Date(userInfo.dateOfBirth), "dd/MM/yyyy")
                  : "Chưa có ngày sinh"}
              </p>
            </div>

            {/* Phone */}
            <div>
              <div className="flex items-center justify-between mb-2">
                <h3 className="text-sm font-medium text-gray-700">
                  Số điện thoại
                </h3>
                <Button
                  variant="ghost"
                  size="sm"
                  className="text-xs text-gray-500 hover:text-gray-700"
                  onClick={() => openPopup("phone")}
                >
                  Chỉnh sửa
                </Button>
              </div>
              <p className="text-sm text-gray-400">
                {userInfo?.phone ?? "Chưa cập nhật"}
              </p>
            </div>
          </div>
        </div>
      </div>
      <Dialog open={!!activeField} onOpenChange={closePopup}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>
              {activeField === "fullName" && "Chỉnh sửa họ tên"}
              {activeField === "address" && "Chỉnh sửa địa chỉ"}
              {activeField === "avatarUrl" && "Cập nhật avatar"}
              {activeField === "dateOfBirth" && "Cập nhật ngày sinh"}
              {activeField === "phone" && "Cập nhật số điện thoại"}
            </DialogTitle>
          </DialogHeader>

          {["fullName", "address"].includes(activeField ?? "") && (
            <input
              type="text"
              required
              value={inputValue ?? ""}
              onChange={(e) => setInputValue(e.target.value)}
              className="w-full border p-2 rounded"
            />
          )}
          {activeField === "phone" && (
            <div className="space-y-1">
              <input
                type="tel"
                required
                value={inputValue}
                onChange={(e) => handlePhoneChange(e.target.value)}
                placeholder="0912345678 hoặc +84912345678"
                className={`w-full border p-2 rounded ${phoneError ? "border-red-500" : ""}`}
              />
              {phoneError && (
                <p className="text-red-500 text-sm">{phoneError}</p>
              )}
            </div>
          )}
          {activeField === "dateOfBirth" && (
            <input
              type="date"
              value={inputValue}
              onChange={(e) => handleDateChange(e.target.value)}
              min="1900-01-01"
              max={todayStr}
              className={`w-full border p-2 rounded ${
                dateError ? "border-red-500" : ""
              }`}
            />
          )}
          {activeField === "avatarUrl" && (
            <div className="space-y-2">
              <input
                type="file"
                accept="image/*"
                required
                onChange={(e) => {
                  const file = e.target.files?.[0]
                  if (file) {
                    setAvatarFile(file)
                    const reader = new FileReader()
                    reader.onloadend = () => {
                      setAvatarPreview(reader.result as string)
                      setInputValue(file.name)
                    }
                    reader.readAsDataURL(file)
                  }
                }}
                className="block w-full text-sm text-gray-700
                 file:mr-4 file:py-2 file:px-4
                 file:rounded-full file:border-0
                 file:text-sm file:font-semibold
                 file:bg-blue-50 file:text-blue-700
                 hover:file:bg-blue-100"
              />
              {avatarPreview && (
                <img
                  src={avatarPreview}
                  alt="Preview"
                  className="w-24 h-24 rounded object-cover"
                />
              )}
            </div>
          )}

          <div className="flex justify-end mt-4">
            <button
              onClick={() => {
                if (!inputValue?.trim()) {
                  showErrorToast("Vui lòng nhập giá trị trước khi lưu.")
                  return
                }
                if (activeField === "dateOfBirth" && dateError) {
                  showErrorToast(dateError)
                  return
                }
                handleSubmit(activeField!, inputValue)
              }}
              className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
            >
              Lưu thay đổi
            </button>
          </div>
        </DialogContent>
      </Dialog>
      <Dialog open={openChangePassword} onOpenChange={setOpenChangePassword}>
        <DialogOverlay className="fixed inset-0 bg-black/50 z-[999]" />
        <DialogContent className="fixed left-1/2 top-1/2 -translate-x-1/2 -translate-y-1/2 bg-white sm:max-w-md z-[1000] rounded-lg shadow-lg p-6">
          <DialogHeader>
            <DialogTitle>Đổi mật khẩu</DialogTitle>
          </DialogHeader>
          <form onSubmit={handleChangePassword}>
            <div className="grid gap-4 py-4">
              <div className="grid gap-2">
                <label className="text-sm font-medium">Mật khẩu cũ</label>
                <input
                  type="password"
                  className="border p-2 rounded"
                  required
                />
              </div>
              <div className="grid gap-2">
                <label className="text-sm font-medium">Mật khẩu mới</label>
                <input
                  type="password"
                  className="border p-2 rounded"
                  required
                />
              </div>
              <div className="grid gap-2">
                <label className="text-sm font-medium">
                  Xác nhận mật khẩu mới
                </label>
                <input
                  type="password"
                  className="border p-2 rounded"
                  required
                />
              </div>
            </div>
            <DialogFooter className="flex justify-end gap-2">
              <Button
                type="button"
                variant="ghost"
                onClick={() => setOpenChangePassword(false)}
              >
                Huỷ
              </Button>
              <Button type="submit">Đổi</Button>
            </DialogFooter>
          </form>
        </DialogContent>
      </Dialog>
    </StudentLayout>
  )
}
