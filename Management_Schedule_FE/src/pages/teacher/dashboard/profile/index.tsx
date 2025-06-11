"use client"
import StudentLayout from "@/components/features/guest/StudentLayout"
import { Button } from "@/components/ui/button"
import Image from "next/image"
import React, { useEffect } from "react"
import { useState } from "react"
import { Camera, UserRound } from "lucide-react"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { useAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import useSWR from "swr"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { showErrorToast } from "@/components/common/toast/toast"
import { UserProfile } from "@/hooks/api/user/use-get-users"
import { CakeIcon, MapPinHouse, Phone, Mail, MarsStroke } from "lucide-react"
import {
  Dialog,
  DialogTrigger,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "@/components/ui/dialog"
import TeacherLayout from "@/components/features/guest/TeacherLayout"
import { ScheduleTeacher } from "@/hooks/api/schedule/use-get-schedules"
function Page() {
  const [schedules, setSchedules] = useState<ScheduleTeacher[]>([])
  const [user] = useAtom(userInfoAtom)
  const [userInfo, SetUserInfo] = useState<UserProfile | null>(null)
  const email: string | undefined = user?.email
  console.log("email", user?.email)
  const fetcher = async (url: string): Promise<UserProfile> => {
    const response = await axios.get(url)
    return response.data.data
  }

  const { data, error, isLoading } = useSWR(
    email
      ? `${Endpoints.baseApiURL.URL}${Endpoints.Users.GETUSERBYEMAIL(email)}`
      : null,
    fetcher,
  )
  console.log("data from swr", data)
  if (error) {
    showErrorToast(`${error.message}`)
  }

  if (isLoading) {
    ;<div>dang tai du lieu .....</div>
  }

  useEffect(() => {
    if (data) {
      SetUserInfo(data)
    }
  }, [data])

  const teacherId: string | undefined = user?.nameid
  useEffect(() => {
    const fetchDataCourse = async () => {
      const response = await axios.get(
        teacherId
          ? `${Endpoints.baseApiURL.URL}${Endpoints.Schedule.GET_SCHEDULE_BY_TEACHER_ID(teacherId)}`
          : "",
      )
      if (response.status == 200) {
        setSchedules(response.data.data)
      }
    }
    fetchDataCourse()
  }, [])

  function formatDate(isoDateString: string): string {
    if (!isoDateString) return "Không có dữ liệu"

    const date = new Date(isoDateString)
    const day = String(date.getDate()).padStart(2, "0")
    const month = String(date.getMonth() + 1).padStart(2, "0")
    const year = date.getFullYear()

    return `${day}/${month}/${year}`
  }

  const [photoCover, setPhotoCover] = useState("null")
  const [open, setOpen] = useState(false)
  const filterSchedule = schedules.filter((s) => {
    const today = new Date().toISOString().split("T")[0]
    const sDate = new Date(s.date).toISOString().split("T")[0]
    return sDate === today
  })

  return (
    <TeacherLayout>
      {userInfo && (
        <div>
          <div className="h-100 w-full relative ">
            <Image
              src="/anh1.webp"
              alt="anh bia student"
              layout="fill"
              objectFit="cover"
              className="rounded-ee-3xl rounded-es-3xl relative"
            />
            <Avatar className="h-50 w-50 mr-4 rounded-full absolute top-60 left-10">
              <AvatarImage
                src={userInfo?.avatarUrl ?? "/teacher.jpg"}
                alt="avatar"
              />
              <AvatarFallback>NA</AvatarFallback>
            </Avatar>
            <h1 className="absolute top-100 left-60 font-bold text-xl">
              {userInfo?.fullName}
            </h1>
            <Button className="absolute top-85 right-10 p-[20px]">
              <Camera size={20} /> Chỉnh sửa ảnh bìa
            </Button>
          </div>
          <div className="flex flex-row mt-[100px] mx-[20px]">
            <div className="flex-1 mr-[10px]">
              <Dialog open={open} onOpenChange={setOpen}>
                <DialogTrigger asChild>
                  <div
                    onClick={() => setOpen(true)}
                    className="rounded-xl border-gray-200 border-[2] cursor-pointer hover:bg-gray-50"
                  >
                    <h2 className="p-2 font-semibold">Thông tin cá nhân</h2>
                    <div className="flex flex-row">
                      <h2 className="font-semibold p-2">Giới thiệu: </h2>
                      <h3 className="p-2 ">
                        {userInfo?.introduction || "Không có giới thiệu."}
                      </h3>
                    </div>
                    <div className="flex flex-row">
                      <h2 className="font-semibold p-2">Email: </h2>
                      <h3 className="p-2">
                        {userInfo?.email || "Chưa cập nhật."}
                      </h3>
                    </div>
                    <div className="flex flex-row">
                      <h2 className="font-semibold p-2">Số điện thoại: </h2>
                      <h3 className="p-2">
                        {userInfo?.phone || "Chưa cập nhật."}
                      </h3>
                    </div>
                    <div className="flex flex-row">
                      <h2 className="font-semibold p-2">
                        Tham gia trung tâm từ:{" "}
                      </h2>
                      <h3 className="p-2">
                        {formatDate(userInfo?.createdAt.toString()) ||
                          "Chưa cập nhật."}
                      </h3>
                    </div>
                  </div>
                </DialogTrigger>
                <DialogContent className="max-w-lg">
                  <DialogHeader>
                    <DialogTitle>Thông tin giới thiệu</DialogTitle>
                  </DialogHeader>
                  <div className="mt-2 whitespace-pre-line flex flex-row gap-2">
                    <CakeIcon size={20} />
                    <span>
                      {formatDate(userInfo?.dateOfBirth) ||
                        "Không có nội dung."}
                    </span>
                  </div>
                  <div className="mt-2 whitespace-pre-line flex flex-row gap-2">
                    <MapPinHouse size={20} />
                    <span>{userInfo?.address || "Không có nội dung."}</span>
                  </div>
                  <div className="mt-2 whitespace-pre-line flex flex-row gap-2">
                    <MarsStroke size={20} />
                    <span>
                      {userInfo?.gender
                        ? userInfo.gender === "M"
                          ? "Male"
                          : "Female"
                        : "Không có nội dung."}
                    </span>
                  </div>
                  <div className="mt-2 whitespace-pre-line flex flex-row gap-2">
                    <Phone size={20} />
                    <span>{userInfo?.phone || "Không có nội dung."}</span>
                  </div>
                  <div className="mt-2 whitespace-pre-line flex flex-row gap-2">
                    <Mail size={20} />
                    <span>{userInfo?.email || "Không có nội dung."}</span>
                  </div>
                </DialogContent>
              </Dialog>
            </div>
            <div className="flex-1 flex-1 rounded-xl border-gray-200 border-[2]">
              <h2 className="p-2 font-semibold">Các lớp học đang dạy</h2>
              {filterSchedule &&
              Array.isArray(filterSchedule) &&
              filterSchedule.length > 0 ? (
                filterSchedule.map((s) => (
                  <div className="flex flex-row" key={s.classID}>
                    <div className="flex flex-row">
                      <h2 className="font-semibold p-2">{s.className}</h2>
                      <h3 className="p-2 flex flex-row">{s.room}</h3>
                      <h3 className="p-2 flex flex-row">
                        {s.studySessionName}
                      </h3>
                      <h3 className="p-2 flex flex-row">
                        {formatDate(s.date)}
                      </h3>
                    </div>
                  </div>
                ))
              ) : (
                <div className="text-center text-gray-500 mt-4">
                  Không có lịch dạy cho ngày hôm nay
                </div>
              )}
            </div>
          </div>
        </div>
      )}
    </TeacherLayout>
  )
}

export default Page
