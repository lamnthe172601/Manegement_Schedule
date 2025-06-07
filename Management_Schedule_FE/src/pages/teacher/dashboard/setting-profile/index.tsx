import StudentLayout from "@/components/features/guest/StudentLayout"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Bell, Shield, User } from "lucide-react"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog"
import { useState, useEffect } from "react"
import useSWR from "swr"
import { useAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { Constants } from "@/lib/constants"
import { mutate } from "swr"
import { UserProfile } from "@/hooks/api/user/use-get-users"
import { any, date } from "zod"
import {
  showErrorToast,
  showSuccessToast,
} from "@/components/common/toast/toast"
import TeacherLayout from "@/components/features/guest/TeacherLayout"
export default function Page() {
  const [user] = useAtom(userInfoAtom)
  const [inputValue, setInputValue] = useState<string | null>("")
  const [userInfo, setUserInfo] = useState<UserProfile | null>(null)
  const [avatarFile, setAvatarFile] = useState<File | null>(null)
  const [avatarPreview, setAvatarPreview] = useState<string | null>(null)

  const [token, setToken] = useState("")
  const [activeField, setActiveField] = useState<keyof UserProfile | null>(null)
  const closePopup = () => setActiveField(null)
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
  console.log(data)
  if (error) {
    showErrorToast(error.message)
  }

  useEffect(() => {
    if (data) {
      console.log(data)
      setUserInfo(data)
    }
  }, [data])

  const openPopup = (field: keyof UserProfile) => {
    setActiveField(field)
    if (!userInfo) return
    if (field === "fullName") setInputValue(userInfo?.fullName || "")
    if (field === "address") setInputValue(userInfo?.address || "")
    if (field === "avatarUrl") setInputValue(userInfo?.avatarUrl || "")
    if (field === "dateOfBirth") setInputValue(userInfo?.dateOfBirth || "")
    if (field === "phone") setInputValue(userInfo?.phone || "")
  }

  const handleSubmit = async (field: keyof UserProfile, value: string) => {
    const updatedUser = {
      ...userInfo,
      [field as keyof UserProfile]: value,
    }
    const formData = new FormData()
    for (const key in updatedUser) {
      if (updatedUser.hasOwnProperty(key)) {
        const k = key as keyof UserProfile
        const val = updatedUser[k]
        if (val !== undefined && val !== null) {
          if (k === "avatarUrl" && avatarFile) {
            formData.append(k, avatarFile)
          } else {
            formData.append(k, String(val))
          }
        }
      }
    }
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
        console.log(userInfo)
        setUserInfo(response.data.data)
        showSuccessToast(response.data.message)
      }
    } catch (error: any) {
      showErrorToast(error?.response?.data?.message || "Lỗi cập nhật")
    }
  }
  return (
    <TeacherLayout>
      <h1 className="text-2xl font-bold mb-6">Cài đặt</h1>

      <div className="flex">

        {/* Settings Content */}
        <div className="flex-1">
          <div className="bg-white rounded-lg border p-6">
            <h2 className="text-lg font-medium mb-6">Thông tin cá nhân</h2>

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
              <p className="text-sm">{userInfo?.dateOfBirth}</p>
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

          {["fullName", "address", "dateOfBirth", "phone"].includes(
            activeField ?? "",
          ) && (
            <input
              type="text"
              value={inputValue ?? ""}
              onChange={(e) => setInputValue(e.target.value)}
              className="w-full border p-2 rounded"
            />
          )}
          {activeField === "avatarUrl" && (
            <div className="space-y-2">
              <input
                type="file"
                accept="image/*"
                onChange={(e) => {
                  const file = e.target.files?.[0]
                  console.log(file)
                  if (file) {
                    setAvatarFile(file)
                    setInputValue(file.name)
                    setAvatarPreview(URL.createObjectURL(file))
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
                  alt="Avatar preview"
                  className="w-24 h-24 rounded-full object-cover border-blue-400 shadow-md border-2"
                />
              )}
            </div>
          )}

          <div className="flex justify-end mt-4">
            <button
              onClick={() => {
                if (activeField === "avatarUrl" && avatarFile) {
                  handleSubmit(activeField, avatarFile.name)
                } else {
                  activeField && handleSubmit(activeField, inputValue!)
                }
              }}
              className="px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
            >
              Lưu thay đổi
            </button>
          </div>
        </DialogContent>
      </Dialog>
    </TeacherLayout>
  )
}
