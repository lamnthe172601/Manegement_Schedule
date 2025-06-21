import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Clock, Users, Calendar, User } from "lucide-react"
import { Button } from "@/components/ui/button"
import useGetClass from "@/hooks/api/classes/use-get-class"
import { format } from "date-fns"
import { showErrorToast, showSuccessToast } from "@/components/common/toast/toast"
import { useAxios } from "@/hooks/api/use-axios"
import { AxiosError } from "axios"
import { useAtomValue } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { useRouter } from "next/router"
export default function CoursesPage() {
  const { data, error, isLoading } = useGetClass()
  const userData = useAtomValue(userInfoAtom) // dùng userData làm check đăng nhập

  console.log("userData", userData)
  console.log(data)
  const axios = useAxios()
  if (isLoading) return <div>Đang tải lớp học...</div>
  if (error) return <div>Đã xảy ra lỗi khi tải lớp học.</div>
  const handleEnroll = async (classID: number) => {
    try {
      const response = await axios.post("/Enrollment", { classID }) // đã có baseURL nên không cần full URL

      if (response) {
        showSuccessToast("Đăng ký thành công!")

      }
    } catch (error: any) {
      const axiosError = error as AxiosError<any>

      if (axiosError.response) {
        const message = axiosError.response.data?.errors?.detail || "Đăng ký thất bại"
        showErrorToast(message)
      } else {
        showErrorToast("Lỗi kết nối đến máy chủ!")
      }
    }
  }
  const router = useRouter()
  const viewDetail = (id: number) => {
    router.push(`/user/khoa-hoc/chi-tiet-khoa-hoc/${id}`)
  }

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="mb-10">
        <h2 className="text-lg font-semibold flex items-center mb-4">
          <Badge className="bg-blue-500 text-white mr-2">Lớp học</Badge>
          Danh sách các lớp đang hoạt động
        </h2>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
          {data?.map((cls) => (
            <Card key={cls.classID} className="overflow-hidden border-0 shadow-md relative">
              <CardContent className="p-0">
                <div className="bg-pink-500 text-white p-6 text-center">
                  <h3 className="font-bold text-xl mb-1">{cls.className}</h3>
                  <p className="text-sm opacity-90">{cls.courseName}</p>
                </div>

                <div className="p-4 space-y-2 text-sm text-gray-700">
                  <div className="flex items-center">
                    <Clock className="w-4 h-4 mr-2" />
                    Thời lượng: {cls.duration} buổi
                  </div>
                  <div className="flex items-center">
                    <Users className="w-4 h-4 mr-2" />
                    {cls.enrolledStudents}/{cls.maxStudents} học viên
                  </div>
                  <div className="flex items-center">
                    <Calendar className="w-4 h-4 mr-2" />
                    Bắt đầu từ: {format(new Date(cls.startDate), "dd/MM/yyyy")}
                  </div>
                  <div className="flex items-center">
                    <User className="w-4 h-4 mr-2" />
                    Giáo viên: {cls.isHaveTeacher ? cls.teacherName : "Chưa xếp"}
                  </div>

                </div>

                <div className="flex justify-center mt-4 mb-4">
                  {cls.status === 1 ? (
                    <div className="flex flex-col space-y-2 w-full px-4">
                      <Button variant="outline" onClick={()=>viewDetail(cls.classID)}>Xem chi tiết</Button>
                      {userData?.role === "Student" && <Button onClick={() => handleEnroll(cls.classID)}>Mua khóa học</Button>}
                    </div>
                  ) : (
                    <span className="text-yellow-600 font-semibold">Lớp chưa hoạt động</span>
                  )}
                </div>

              </CardContent>
            </Card>
          ))}
        </div>
      </div>
    </div>
  )
}
