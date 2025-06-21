"use client"

import type React from "react"
import { Inter } from "next/font/google"
import { ThemeProvider } from "next-themes"
import { usePathname } from "next/navigation"
import Header from "./header"
import Footer from "./footer"

const inter = Inter({ subsets: ["latin"] })

export default function LayoutGuest({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  const pathname = usePathname()

  // ✅ Ẩn Header nếu path bắt đầu bằng 
  const noLayoutPages = ["/login", "/register", "/teacher/dashboard", "/student/dashboard", "/user/forget-password", "/user/enter-otp", "/user/reset-password"]

  const shouldHideAllLayout = pathname
    ? noLayoutPages.some(page => pathname.startsWith(page))
    : false;
  return (
    <ThemeProvider attribute="class" defaultTheme="light">
      <div className={`${inter.className} flex flex-col min-h-screen relative`}>
        {!shouldHideAllLayout && <Header />}
        <main className="flex-1">{children}</main>
        <Footer />
      </div>
    </ThemeProvider>
  )
}
