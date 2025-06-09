// components/layouts/DashboardLayout.tsx
"use client"

import React, { useState, useEffect } from "react"
import Link from "next/link"
import { usePathname } from "next/navigation"
import { Bell, ChevronLeft, Search } from "lucide-react"
import { Input } from "@/components/ui/input"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Lock } from "lucide-react"
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuItem,
  DropdownMenuContent,
  DropdownMenuSeparator,
} from "@radix-ui/react-dropdown-menu"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
  DialogOverlay,
} from "@/components/ui/dialog"
import { Button } from "@/components/ui/button"
import { LogOut } from "lucide-react"
import { logout } from "@/lib/utils"
type SidebarItem = {
  icon: React.ElementType
  label: string
  href: string
}

export default function DashboardLayout({
  children,
  sidebarItems,
  backHref = "/",
  userName = "Người dùng",
  avatarUrl,
}: {
  children: React.ReactNode
  sidebarItems: SidebarItem[]
  backHref?: string
  userName?: string
  avatarUrl?: string
}) {
  const pathname = usePathname()
  const [searchQuery, setSearchQuery] = useState("")
  
  return (
    <div className="flex min-h-screen bg-zinc-50">
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
        <DropdownMenu>
          <DropdownMenuTrigger asChild>
            <div className="px-4 py-4 border-b cursor-pointer">
              <div className="flex items-center space-x-3">
                <Avatar className="h-10 w-10">
                  <AvatarImage src={avatarUrl} alt="User" />
                  <AvatarFallback>NA</AvatarFallback>
                </Avatar>
                <div>
                  <p className="text-sm font-medium">{userName}</p>
                  <p className="text-xs text-gray-500">Sửa hồ sơ</p>
                </div>
              </div>
            </div>
          </DropdownMenuTrigger>

          <DropdownMenuContent
            className="w-56 bg-white shadow-lg rounded-xl border border-gray-200 py-2"
            align="center"
            sideOffset={-6}
          >
            <DropdownMenuSeparator />

            <DropdownMenuSeparator />
            <DropdownMenuItem
              onClick={() => logout()}
              className="px-4 py-1 text-sm text-red-600 hover:bg-red-50 cursor-pointer flex flex-row"
            >
              <LogOut className="mr-2 h-4 w-4" />
              <p>Đăng xuất</p>
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>

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

        <main className="p-2 relative z-[0]">{children}</main>
      </div>
      
    </div>
  )
}
