import { Endpoints } from "@/lib/endpoints"
import { axiosFetcher } from "@/lib/utils"
import useSWR from "swr"

export interface User {
  userID: number
  email: string
  passwordHash: string
  role: number // 1: admin, 2: teacher, 3: student
  fullName: string
  gender: "M" | "F"
  dateOfBirth: Date
  address: string
  phone: string
  introduction: string
  avatarUrl: string
  status: number
  createdAt: Date
  modifiedAt: Date
}
export interface JwtUser {
  nameid: string // userID dưới dạng string hoặc email tùy bạn mapping ở backend
  email: string
  fullName: string
  gender: "M" | "F"
  phone: string
  role: string
  avatarUrl: string
  dateOfBirth: string
}

export interface UserProfile {
  userID: number
  email: string
  passwordHash: string
  role: number // 1: admin, 2: teacher, 3: student
  fullName: string
  dateOfBirth: string
  address: string
  phone: string
  introduction: string
  avatarUrl: string
  status: number
  createdAt: Date
  modifiedAt: Date
  gender: string
  note:string
}



const useGetUsers = () => {
  const { data, error, isLoading } = useSWR<User[]>(
    Endpoints.Users.GET_ALL,
    axiosFetcher,
  )
  return { data, error, isLoading }
}

export default useGetUsers
