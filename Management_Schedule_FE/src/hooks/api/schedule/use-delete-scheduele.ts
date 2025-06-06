import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useDeleteScheduele = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)
  const deleteScheduele = async ({ id, data }: { id: number; data: any }) => {
    try {
      setLoading(true)
      const response = await axios.patch(`Schedule/${id}/status`, data)
      return response.data
    } catch (error) {
      throw error
    } finally {
      setLoading(false)
    }
  }
  return { deleteScheduele, loading }
}
