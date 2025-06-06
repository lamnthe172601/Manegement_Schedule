import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useAddCourse = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const addCourse = async (data: FormData) => {
    setLoading(true)
    try {
      const response = await axios.post(`/Course`, data, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      return response.data
    } finally {
      setLoading(false)
    }
  }

  return { addCourse, loading }
}
