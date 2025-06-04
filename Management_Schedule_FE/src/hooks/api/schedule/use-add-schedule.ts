import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useAddSchedule = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)
  const addSchedule = async ({ data }: { data: any }) => {
    try {
      setLoading(true)
      const response = await axios.post(`Schedule/auto-generate`, data)
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }
  return { addSchedule, loading }
}
