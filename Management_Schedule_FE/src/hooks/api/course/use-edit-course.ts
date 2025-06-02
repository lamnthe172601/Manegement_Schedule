import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"
import { Book } from "@/hooks/api/book/use-get-books"
import { Course } from "./use-get-course"

export const useEditCourse = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const editCourse = async ({ id, data }: { id: string; data: any }) => {
    console.log("data", data)
    try {
      setLoading(true)
      const response = await axios.put<Course>(`Course/${id}`, data)
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }

  return { editCourse, loading }
}
