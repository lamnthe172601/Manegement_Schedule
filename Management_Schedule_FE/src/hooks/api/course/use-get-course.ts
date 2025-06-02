import { Endpoints } from "@/lib/endpoints"
import { axiosFetcher } from "@/lib/utils"
import useSWR from "swr"

export interface Course {
  courseID: number
  courseName: string
  description?: string
  price: number
  thumbnailUrl?: string
  isSelling: boolean
  isComingSoon: boolean
  isPro: boolean
  isCompletable: boolean
  discountPercent: number
  duration: number
  level: number
  createdAt: string
  modifiedAt: string
}

// Hook để lấy danh sách khóa học
const useGetCourses = () => {
  const { data, error, isLoading } = useSWR<Course[]>(
    Endpoints.Courses.GET_ALL,
    axiosFetcher,
  )
  return { data, error, isLoading }
}

export default useGetCourses
