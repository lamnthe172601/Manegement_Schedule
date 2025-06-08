import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useAddUser = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const addUser = async ({ data }: { data: any }) => {
    try {
      setLoading(true)

      const formData = new FormData()
      for (const key in data) {
        formData.append(key, data[key])
      }

      const response = await axios.post(`User/by-admin`, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }

  return { addUser, loading }
}
