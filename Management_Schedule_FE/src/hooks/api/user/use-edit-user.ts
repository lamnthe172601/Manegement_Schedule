// import { useAxios } from "@/hooks/api/use-axios"
// import { useState } from "react"

// export const useEditUser = () => {
//   const axios = useAxios()
//   const [loading, setLoading] = useState(false)
//   const editUser = async ({ email, data }: { email: string; data: any }) => {
//     console.log(data)
//     console.log(email)
//     // return data
//     try {
//       setLoading(true)
//       const response = await axios.put(`User/${email}`, data)
//       return response.data
//     } catch (error) {
//       throw error
//     } finally {
//       setLoading(false)
//     }
//   }
//   return { editUser, loading }
// }
import { useAxios } from "@/hooks/api/use-axios"
import { useState } from "react"

export const useEditUser = () => {
  const axios = useAxios()
  const [loading, setLoading] = useState(false)

  const editUser = async ({ email, data }: { email: string; data: any }) => {
    try {
      setLoading(true)

      const formData = new FormData()
      // Duyệt qua các key trong object `data` và append vào FormData
      for (const key in data) {
        if (data[key] !== undefined && data[key] !== null) {
          // Nếu là file (avatarUrl), cần append đúng kiểu
          if (key === "avatarUrl" && data[key] instanceof File) {
            formData.append(key, data[key])
          } else {
            formData.append(key, data[key])
          }
        }
      }

      const response = await axios.put(`User/${email}`, formData, {
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

  return { editUser, loading }
}
