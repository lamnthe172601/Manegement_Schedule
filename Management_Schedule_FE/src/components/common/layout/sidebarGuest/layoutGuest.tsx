import type React from "react"
import type { Metadata } from "next"
import { Inter } from "next/font/google"
import { ThemeProvider } from "next-themes"
import Header from "./header"
import Footer from "./footer"

const inter = Inter({ subsets: ["latin"] })

export const metadata: Metadata = {
  title: "Landmaster Learning System",
  description: "Hệ thống học tiếng Anh giao tiếp toàn diện cho người bắt đầu",
}

export default function LayoutGuest ({
  children,
}: Readonly<{
  children: React.ReactNode
}>) {
  return (
    <html lang="vi">
      <body className={inter.className}>
        <ThemeProvider attribute="class" defaultTheme="light">
          <div className="flex flex-col min-h-screen">
            <Header />
            <main className="flex-1">{children}</main>
            <Footer />
          </div>
        </ThemeProvider>
      </body>
    </html>
  )
}
