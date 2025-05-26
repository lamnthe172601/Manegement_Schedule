// components/layouts/DashboardLayout.tsx
"use client"

import React, { useState } from "react"
import Link from "next/link"
import { usePathname } from "next/navigation"
import { Bell, ChevronLeft, Search } from "lucide-react"
import { Input } from "@/components/ui/input"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"

type SidebarItem = {
    icon: React.ElementType,
    label: string,
    href: string
}

export default function DashboardLayout({
    children,
    sidebarItems,
    backHref = "/",
    userName = "Người dùng",
}: {
    children: React.ReactNode
    sidebarItems: SidebarItem[]
    backHref?: string
    userName?: string
}) {
    const pathname = usePathname()
    const [searchQuery, setSearchQuery] = useState("")

    return (
        <div className="flex min-h-screen bg-gray-50">
            {/* Sidebar */}
            <div className="w-64 border-r bg-white">
                {/* Sidebar Header */}
                <div className="border-b py-4 px-4">
                    <Link href={backHref} className="flex items-center">
                        <ChevronLeft className="h-5 w-5 mr-2 text-green-600" />
                        <span className="text-sm font-medium">QUAY LẠI</span>
                    </Link>
                </div>

                {/* User Profile */}
                <div className="px-4 py-4 border-b">
                    <div className="flex items-center space-x-3">
                        <Avatar className="h-10 w-10">
                            <AvatarImage src="/placeholder.svg?height=40&width=40" alt="User" />
                            <AvatarFallback>NA</AvatarFallback>
                        </Avatar>
                        <div>
                            <p className="text-sm font-medium">{userName}</p>
                            <p className="text-xs text-gray-500">Sửa hồ sơ</p>
                        </div>
                    </div>
                </div>

                {/* Navigation Menu */}
                <nav className="py-4">
                    <ul className="space-y-1">
                        {sidebarItems.map((item) => {
                            const isActive = pathname === item.href
                            const Icon = item.icon
                            return (
                                <li key={item.href}>
                                    <Link
                                        href={item.href}
                                        className={`flex items-center px-4 py-2 text-sm ${isActive ? "bg-green-50 text-green-600 font-medium" : "text-gray-700 hover:bg-gray-100"}`}
                                    >
                                        <Icon className="h-5 w-5 mr-3" />
                                        {item.label}
                                    </Link>
                                </li>
                            )
                        })}
                    </ul>
                </nav>
            </div>

            {/* Main Content */}
            <div className="flex-1">
                <header className="flex items-center justify-between border-b bg-white px-6 py-3">
                    <div className="relative w-full max-w-md">
                        <Search className="absolute left-3 top-1/2 h-4 w-4 -translate-y-1/2 text-gray-400" />
                        <Input
                            type="search"
                            placeholder="Tìm kiếm..."
                            className="pl-10 w-full"
                            value={searchQuery}
                            onChange={(e) => setSearchQuery(e.target.value)}
                        />
                    </div>
                    <button className="ml-4 text-gray-500 hover:text-gray-700">
                        <Bell className="h-5 w-5" />
                    </button>
                </header>

                <main className="p-6">{children}</main>
            </div>
        </div>
    )
}
