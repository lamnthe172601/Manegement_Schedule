

"use client"


import StudentLayout from "@/components/features/guest/StudentLayout"


export default function DashboardLayout({ children }: { children: React.ReactNode }) {
    return <StudentLayout>{children}</StudentLayout>
}
