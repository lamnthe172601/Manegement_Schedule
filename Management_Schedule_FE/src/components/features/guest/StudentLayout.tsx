import { Calendar, Settings, User, BookOpenCheck, LogOut } from "lucide-react"
import DashboardLayout from "./layout"
import { useAtomValue } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";
import { useState, useEffect } from "react";
import { UserProfile } from "@/hooks/api/user/use-get-users";
import useSWR from "swr";
import axios from "axios";
import { Endpoints } from "@/lib/endpoints";
import { showErrorToast } from "@/components/common/toast/toast";

export default function StudentLayout({ children }: { children: React.ReactNode }) {
    const sidebarItems = [
        { icon: User, label: "Trang cá nhân", href: "/student/dashboard/profile" },
        { icon: BookOpenCheck, label: "Khóa học của tôi", href: "/student/dashboard/my-course" },
        { icon: Calendar, label: "Lịch học", href: "/student/dashboard/schedule" },
        { icon: Settings, label: "Cài đặt", href: "/student/dashboard/my-settings" },
    ]
    const userData = useAtomValue(userInfoAtom);
    const [userInfo, setUserInfo] = useState<UserProfile|null>(null);
    const email: string | undefined = userData?.email
    const fetcher = async (url: string): Promise<UserProfile> => {
    const response = await axios.get(url)
    return response.data.data
  }

  const { data, error, isLoading } = useSWR(
    email
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Users.GETUSERBYEMAIL(email)}`
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
        <DashboardLayout sidebarItems={sidebarItems} userName={userInfo?.fullName || ""} avatarUrl={userInfo?.avatarUrl || ""}>
            {children}
        </DashboardLayout>
    )
}
