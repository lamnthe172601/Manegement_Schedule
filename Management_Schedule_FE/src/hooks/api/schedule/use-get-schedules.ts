import { Endpoints } from "@/lib/endpoints"
import { axiosFetcher } from "@/lib/utils"
import useSWR from "swr"

export interface Schedule {
  scheduleID: number
  teacherID: number
  date: string
  startTime: string
  endTime: string
  className: string
  courseName: string
  teacherName: string
  room: string
  notes: string
  status: number
  studySessionName:string
}
const useGetSchedule = () => {
  const { data, error, isLoading } = useSWR<Schedule[]>(
    Endpoints.Schedule.GET_ALL,
    axiosFetcher,
  )
  return { data, error, isLoading }
}

export default useGetSchedule
