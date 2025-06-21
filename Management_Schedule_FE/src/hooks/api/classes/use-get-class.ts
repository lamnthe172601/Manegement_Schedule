import { Endpoints } from "@/lib/endpoints"
import { axiosFetcher } from "@/lib/utils"
import useSWR from "swr"
interface Class {
  classID: number
  className: string
  courseID: number
  maxStudents: number
  startDate: string // ISO date string, có thể đổi thành Date nếu cần
  endDate: string // ISO date string
  status: number // có thể là enum nếu biết nghĩa các giá trị
  createdAt: string // ISO date string
  modifiedAt: string // ISO date string
  courseName: string
  duration: number // số giờ hoặc số buổi học (tùy bạn định nghĩa)
  isHaveSchedule: boolean
  note: string
  enrolledStudents: number
  teacherName: string
  isHaveTeacher: boolean
}

export interface ClassDetail{
  classID: number,
  className: string,
  courseID: number,
  maxStudents: number,
  startDate: string,
  endDate: string,
  status: number
}

export interface ClassList{
  classID: number
  className: string
}

// Hook để lấy danh sách khóa học
const useGetClass = () => {
  const { data, error, isLoading } = useSWR<Class[]>(
    Endpoints.Classes.GET_ALL,
    axiosFetcher,
  )
  return { data, error, isLoading }
}

export default useGetClass
