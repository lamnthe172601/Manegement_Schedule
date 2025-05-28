import { useAxios } from "@/hooks/api/use-axios"
import { Endpoints } from "@/lib/endpoints"
import { useState } from "react"

export const useLogin = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const login = async (email: string, password: string) => {
    console.log("🟡 gọi login với", email, password)
    try {
      setLoading(true)
      const response = await axios.post(Endpoints.Auth.LOGIN, {
        email,
        passwordHash: password,
      })
      console.log("🟢 response.data trong useLogin:", response.data)
      return response.data
    } catch (error: any) {
      console.error("🔴 Lỗi trong useLogin:", error?.response?.data || error)
      throw error
    } finally {
      console.log("🔵 Kết thúc login")
      setLoading(false)
    }
  }

  return { login, loading }
}
