"use client"
import StudentLayout from "@/components/features/guest/StudentLayout"
import { Button } from "@/components/ui/button"
import Image from "next/image"
import { Plus } from "lucide-react"
import { useEffect, useState } from "react"
import { Course } from "@/hooks/api/course/use-get-course"
import useSWR from "swr"
import { useAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { showErrorToast } from "@/components/common/toast/toast"
import { Constants } from "@/lib/constants"
import Link from "next/link"
function Page() {
  const [courses, setCourse] = useState<Course[]>([])
  const [token, setToken] = useState("")
  const [user] = useAtom(userInfoAtom)
  const studentId: string | undefined = user?.nameid
  useEffect(() => {
    const accessToken = localStorage.getItem(Constants.API_TOKEN_KEY)
    if (accessToken) {
      setToken(accessToken)
    }
  }, [])
  const fetcher = async (url: string): Promise<Course[]> => {
    const response = await axios.get(url, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    })
    return response.data.data
  }

  

  const { data, error, isLoading } = useSWR(
    studentId
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_COURSE_BY_STUDENT_ID(studentId)}`
      : null,
    fetcher,
  )

  if (error) {
    showErrorToast(error.message)
  }

  if (isLoading) {
    
  }

  useEffect(() => {
    if (data) {
      console.log(data)
      setCourse(data)
    }
  }, [data])

  return (
    <StudentLayout>
      <div className="mx-5 mt-3">
        <h1 className="font-extrabold text-3xl">Khóa học của tôi</h1>
        <h4 className="mt-2 text-gray-600">
          Bạn đã mua những khóa học nào.
        </h4>
        <div className="grid sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-x-1 gap-y-6 mt-[40px] ">
          {courses &&
            Array.isArray(courses) &&
            courses.map((c) => (
              <div className="relative group cursor-pointer" key={c.courseID}>
                <Image
                  src={c.thumbnailUrl ?? "/courses.png"}
                  alt="khoa hoc"
                  width={300}
                  height={200}
                  className="rounded-xl"
                />
                <h3 className="mt-2 mb-2 font-semibold">{c.courseName}</h3>
                <h4 className="text-gray-600 text-sm">
                  Số ca học {c.level}
                </h4>
                <div className="absolute inset-0 bg-[#00000033] bg-opacity-20 opacity-0 group-hover:opacity-100 transition duration-300 rounded-xl w-[300px] h-[170px]"></div>
                <Button
                  className="absolute top-1/2 left-1/2 transform -translate-x-15 -translate-y-10
                     opacity-0 group-hover:opacity-100 hover:!bg-gray-400 transition duration-300
                     bg-white text-black px-4 py-2 rounded-full"
                >
                  Chi tiết
                </Button>
              </div>
            ))}
          <div className="relative border-dotted border-5 rounded-xl flex flex-col items-center justify-center w-[300px] h-[200px]">
            <Button className="border-2 rounded-4xl bg-[#6A6A6A] mb-[50px]">
              <Plus size={20} />
            </Button>
            {/* sửa thành thẻ link sang trang mua khoá học */}
            <Link href={"/user/khoa-hoc"} className="btn text-[#91AD9C] border-2 rounded-xl border-[#91AD9C] bg-white">
              Thêm khóa học
            </Link>
          </div>
        </div>
      </div>
    </StudentLayout>
  )
}

export default Page
