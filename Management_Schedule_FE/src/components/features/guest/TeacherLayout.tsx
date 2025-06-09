import { Calendar, Settings, User, Users } from "lucide-react"
import DashboardLayout from "./layout"
import { useAtomValue } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { UserProfile } from "@/hooks/api/user/use-get-users"
import { useState, useEffect } from "react"
import axios from "axios"
import { showErrorToast } from "@/components/common/toast/toast"
import useSWR from "swr"
import { Endpoints } from "@/lib/endpoints"
export default function TeacherLayout({
  children,
}: {
  children: React.ReactNode
}) {
  const sidebarItems = [
    { icon: User, label: "Trang cá nhân", href: "profile" },
    { icon: Users, label: "Quản lý học viên", href: "student-management" },
    { icon: Calendar, label: "Lịch giảng", href: "schedule-page" },
    { icon: Settings, label: "Cài đặt", href: "setting-profile" },
  ]
  const userData = useAtomValue(userInfoAtom)
  const [userInfo, setUserInfo] = useState<UserProfile | null>(null)
  const email: string | undefined = userData?.email
  const fetcher = async (url: string): Promise<UserProfile> => {
    const response = await axios.get(url)
    return response.data.data
  }

  const { data, error, isLoading } = useSWR(
    email
      ? `${Endpoints.baseApiURL.URL}${Endpoints.Users.GETUSERBYEMAIL(email)}`
      : null,
    fetcher,
  )
  if (error) {
    showErrorToast(`${error.message}`)
  }

  if (isLoading) {
    ;<div>dang tai du lieu .....</div>
  }

  useEffect(() => {
    if (data) {
      setUserInfo(data)
    }
  }, [data])
  return (
    <DashboardLayout
      sidebarItems={sidebarItems}
      userName={userData?.fullName || ""}
      avatarUrl={userData?.avatarUrl || ""}
    >
      {children}
    </DashboardLayout>
  )
}
