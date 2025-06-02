import { useAxios } from "@/hooks/api/use-axios"
import { Endpoints } from "@/lib/endpoints"
import { useState } from "react"

export const useForgetPassword = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)
  const forgetPassword = async (email: string) => {
    console.log(email)
    // return data
    try {
      setLoading(true)
      const response = await axios.post(`${Endpoints.Auth.SENDOTP}`, { email })
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }
  return { forgetPassword, loading }
}
