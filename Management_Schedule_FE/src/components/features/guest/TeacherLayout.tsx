import { Calendar, Settings, User, Users, Wallet, LogOut } from "lucide-react"
import DashboardLayout from "./layout"
import { useAtomValue } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";
export default function TeacherLayout({ children }: { children: React.ReactNode }) {
    const sidebarItems = [
        { icon: User, label: "Trang cá nhân", href: "profile" },
        { icon: Users, label: "Quản lý học viên", href: "student-management" },
        { icon: Calendar, label: "Lịch giảng", href: "schedule-page" },
        { icon: Wallet, label: "Tiền lương", href: "salary" },
        { icon: Settings, label: "Cài đặt", href: "setting-profile" },
        { icon: LogOut, label: "Đăng xuất", href: "/logout" },
    ]
    const userData = useAtomValue(userInfoAtom);
    return (
        <DashboardLayout sidebarItems={sidebarItems} userName={userData?.fullName || ""}>
            {children}
        </DashboardLayout>
    )
}
