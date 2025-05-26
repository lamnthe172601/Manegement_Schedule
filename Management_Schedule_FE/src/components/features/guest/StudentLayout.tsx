import { Calendar, Settings, User, BookOpenCheck, LogOut } from "lucide-react"
import DashboardLayout from "./layout"


export default function StudentLayout({ children }: { children: React.ReactNode }) {
    const sidebarItems = [
        { icon: User, label: "Trang cá nhân", href: "/student/dashboard/profile" },
        { icon: BookOpenCheck, label: "Khóa học của tôi", href: "/student/dashboard/my-courses" },
        { icon: Calendar, label: "Lịch học", href: "/student/dashboard/schedule" },
        { icon: Settings, label: "Cài đặt", href: "/student/dashboard/settings" },
        { icon: LogOut, label: "Đăng xuất", href: "/logout" },
    ]

    return (
        <DashboardLayout sidebarItems={sidebarItems} userName="SV. Trần Thị B">
            {children}
        </DashboardLayout>
    )
}
