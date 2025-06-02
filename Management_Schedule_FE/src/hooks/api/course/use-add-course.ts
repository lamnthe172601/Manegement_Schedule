import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"
import { Course } from "./use-get-course"

export const useAddCourse = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const addCourse = async ({ data }: { data: any }) => {
    try {
      setLoading(true)
      const response = await axios.post<Course>(`Course`, data)
      return response.data
    } catch (error: any) {
      // Kiểm tra xem lỗi có response.data không (axios error)
      if (error.response && error.response.data) {
        const errData = error.response.data
        let message = errData.message || "Lỗi không xác định"
        if (errData.errors) {
          // Gom các lỗi thành chuỗi
          const errorDetails = Object.entries(errData.errors)
            .map(([key, val]) => `${key}:-${val}`)
            .join(" | ")
          message += " | " + errorDetails
        }

        throw new Error(message)
      }
      throw error
    } finally {
      setLoading(false)
    }
  }

  return { addCourse, loading }
}
