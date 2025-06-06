import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useEditCourse = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const editCourse = async ({ id, data }: { id: string; data: FormData }) => {
    setLoading(true)
    try {
      const response = await axios.put(`/Course/${id}`, data, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      return response.data
    } finally {
      setLoading(false)
    }
  }

  return { editCourse, loading }
}
