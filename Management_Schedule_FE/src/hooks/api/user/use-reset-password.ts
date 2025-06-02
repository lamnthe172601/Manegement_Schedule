import { useAxios } from "@/hooks/api/use-axios"
import { Endpoints } from "@/lib/endpoints"
import { useState } from "react"

export const useResetPassword = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)
  const resetPassword = async (data: any) => {
    console.log(data)
    // return data
    try {
      setLoading(true)
      const response = await axios.post(
        `${Endpoints.Users.RESET_PASSWORD}`,
        data,
      )
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }
  return { resetPassword, loading }
}
