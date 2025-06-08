import { Calendar, Settings, User, BookOpenCheck, LogOut } from "lucide-react"
import DashboardLayout from "./layout"
import { useAtomValue } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";


export default function StudentLayout({ children }: { children: React.ReactNode }) {
    const sidebarItems = [
        { icon: User, label: "Trang cá nhân", href: "/student/dashboard/profile" },
        { icon: BookOpenCheck, label: "Khóa học của tôi", href: "/student/dashboard/my-course" },
        { icon: Calendar, label: "Lịch học", href: "/student/dashboard/schedule" },
        { icon: Settings, label: "Cài đặt", href: "/student/dashboard/my-settings" },
    ]
    const userData = useAtomValue(userInfoAtom);

    return (
        <DashboardLayout sidebarItems={sidebarItems} userName={userData?.fullName || ""} avatarUrl={userData?.avatarUrl || ""}>
            {children}
        </DashboardLayout>
    )
}
