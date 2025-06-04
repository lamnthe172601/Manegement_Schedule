import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useAddClasses = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)
  const addClasses = async ({ data }: { data: any }) => {
    try {
      setLoading(true)
      const response = await axios.post(`Classes`, data)
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }
  return { addClasses, loading }
}
