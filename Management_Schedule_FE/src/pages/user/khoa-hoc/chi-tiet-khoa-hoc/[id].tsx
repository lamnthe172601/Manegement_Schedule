import { showErrorToast, showSuccessToast, showWarningToast } from "@/components/common/toast/toast"
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Separator } from "@/components/ui/separator"
import { CourseDetail } from "@/hooks/api/course/use-get-course"
import { Endpoints } from "@/lib/endpoints"
import axios, { AxiosError } from "axios"
import { useRouter } from "next/router"
import { useEffect, useState } from "react"
import useSWR from "swr"
import { ClassDetail } from "@/hooks/api/classes/use-get-class"
import { Constants } from "@/lib/constants"
export default function Page() {
  const [idCourse, setIdCourse] = useState<number>()
  const [idClass, setIdClass] = useState<number>()
  const [course, setCourse] = useState<CourseDetail>()
  const [classes, setClasses] = useState<ClassDetail>()
  const router = useRouter()
  const { id } = router.query

  useEffect(() => {
    if (id) {
      setIdClass(parseInt(id as string))
    }
  }, [id])

  useEffect(() => {
    const fetchClassDetail = async () => {
      try {
        const response = await axios.get(
          idClass
            ? `${Endpoints.baseApiURL.URL}${Endpoints.Classes.GET_CLASS_BY_ID(idClass)}`
            : "not found url",
        )
        if (response.data.status === "success") {
          setClasses(response.data.data)
        }
      } catch (error: any) {
        const errorMessage =
          error.response.data.message ||
          error.message ||
          "không thể lấy dữ liệu"
        showErrorToast(errorMessage)
      }
    }
    fetchClassDetail()
  },[idClass])

  const getDetailCourse = async (url: string) => {
    try {
      const response = await axios.get(url)
      if (response.data.status === "success") {
        return response.data.data
      }
    } catch (error: any) {
      const errorMessage =
        error.response.data.message || error.message || "không thể lấy dữ liệu"
      showErrorToast(errorMessage)
    }
  }

  useEffect(() => {
    if (classes?.courseID) {
      setIdCourse(classes.courseID);
    }
  }, [classes?.courseID]);

  const { data, error, isLoading } = useSWR(
    idCourse
      ? `${Endpoints.baseApiURL.URL}${Endpoints.Courses.GET_BY_ID(idCourse)}`
      : null,
    getDetailCourse,
  )

  useEffect(() => {
    if (data) {
      setCourse(data)
    }
  }, [data])

  if (!id) return <div>Đang lấy ID...</div>

  if (isLoading) {
    return <div>đang lấy dữ liệu...</div>
  }

  if (error) {
    return <div>Có lỗi xảy ra</div>
  }

  const checkLogin = (classID: number) => {
    debugger
    const token = localStorage.getItem(Constants.API_TOKEN_KEY);
    if(!token){
      showWarningToast('PLease login to register class')
      return;
    }
    if(token){
      const registerClass = async () => {
        try {
          const response = await axios.post("/Enrollment", { classID }) 
    
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
      registerClass();
    }

    
  }

  return (
    <div className="max-w-3xl mx-auto p-6 space-y-6">
      {/* Card thông tin lớp học */}
      {classes && (
        <Card className="mb-6">
          <CardHeader>
            <CardTitle className="text-xl font-bold mb-2">Thông tin lớp học</CardTitle>
          </CardHeader>
          <Separator />
          <CardContent className="pt-4 space-y-2">
            <div className="flex flex-wrap gap-4 text-gray-700 text-sm">
              <span><b>Tên lớp:</b> {classes.className}</span>
              <span><b>Số học viên tối đa:</b> {classes.maxStudents}</span>
              <span><b>Trạng thái:</b> {classes.status === 1 ? "Đang hoạt động" : "Chưa hoạt động"}</span>
              <span><b>Ngày bắt đầu:</b> {classes.startDate ? new Date(classes.startDate).toLocaleDateString() : "-"}</span>
              <span><b>Ngày kết thúc:</b> {classes.endDate ? new Date(classes.endDate).toLocaleDateString() : "-"}</span>
              
            </div>
          </CardContent>
        </Card>
      )}
      {/* Card thông tin khoá học */}
      {classes?.courseID && (
        <Card>
          <CardHeader className="flex flex-col lg:flex-row items-start lg:items-center justify-between gap-4">
            <div className="flex flex-col lg:flex-row gap-6 w-full">
              {/* Thumbnail */}
              <div className="w-full max-w-xs flex-shrink-0">
                {course?.thumbnailUrl ? (
                  <img
                    src={course.thumbnailUrl}
                    alt={course.courseName}
                    className="rounded-lg w-full h-48 object-cover border"
                  />
                ) : (
                  <div className="w-full h-48 flex items-center justify-center bg-gray-100 rounded-lg text-gray-400 border">
                    Không có ảnh
                  </div>
                )}
              </div>
              {/* Info */}
              <div className="flex-1 space-y-2">
                <CardTitle className="text-2xl font-bold mb-2">
                  {course?.courseName}
                </CardTitle>
                <p className="text-muted-foreground mb-2">
                  {course?.description}
                </p>
                <div className="flex flex-wrap gap-2 mb-2">
                  {course?.isPro && (
                    <span className="px-2 py-1 bg-purple-100 text-purple-700 rounded text-xs font-semibold">
                      PRO
                    </span>
                  )}
                  {course?.isSelling && (
                    <span className="px-2 py-1 bg-green-100 text-green-700 rounded text-xs font-semibold">
                      Đang mở bán
                    </span>
                  )}
                  {course?.isComingSoon && (
                    <span className="px-2 py-1 bg-yellow-100 text-yellow-700 rounded text-xs font-semibold">
                      Sắp ra mắt
                    </span>
                  )}
                  {course?.isCompletable && (
                    <span className="px-2 py-1 bg-blue-100 text-blue-700 rounded text-xs font-semibold">
                      Có thể hoàn thành
                    </span>
                  )}
                </div>
                <div className="flex items-center gap-4 mb-2">
                  <span className="text-lg font-bold text-primary">
                    {course?.price === 0
                      ? "Miễn phí"
                      : `${course?.price?.toLocaleString("vi-VN")}₫`}
                  </span>
                  {course?.discountPercent && course.discountPercent > 0 && (
                    <span className="text-sm text-red-500 font-semibold">
                      -{course?.discountPercent}%
                    </span>
                  )}
                </div>
                <div className="flex flex-wrap gap-4 text-sm text-gray-600">
                  <span>
                    Thời lượng: <b>{course?.duration ?? 0}</b> buổi
                  </span>
                  <span>
                    Cấp độ: {" "}
                    <b>{course?.level ? course?.level : "Không xác định"}</b>
                  </span>
                </div>
              </div>
            </div>
          </CardHeader>
          <Separator />
          <CardContent className="pt-6">
            {/* Có thể thêm nội dung bài học hoặc các thông tin khác ở đây */}
            <div className="flex justify-between">
              <Button
                className="bg-blue-500"
                size="lg"
                onClick={() => router.replace("/user/khoa-hoc")}
              >
                Back to all
              </Button>
              <Button variant="default" size="lg" onClick={() => checkLogin(classes.classID)}>
                Đăng ký ngay
              </Button>
            </div>
          </CardContent>
        </Card>
      )}
    </div>
  )
}
