"use client"

import Link from "next/link"
import Image from "next/image"
import { usePathname } from "next/navigation"
import { LogOut, ShoppingCart, User } from "lucide-react"
import { Button } from "@/components/ui/button"
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,

  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { useAtomValue } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { logout } from "@/lib/utils"

export default function Header() {
  const pathname = usePathname()
  const userData = useAtomValue(userInfoAtom) // dùng userData làm check đăng nhập

  console.log("userData", userData)
  const dashboardLink =
    userData?.role === "Teacher"
      ? "/teacher/dashboard/profile"
      : userData?.role === "Student"
        ? "/student/dashboard/profile"
        : "/"; // default nếu cần

  // Hàm logout (bạn sửa theo logic thực tế)


  const navItems = [
    { href: "/", label: "TRANG CHỦ" },
    { href: "/user/team-page", label: "ĐỘI NGŨ ĐÀO TẠO" },
    { href: "/user/khoa-hoc", label: "KHÓA HỌC" },
    { href: "/user/student", label: "Học viên" },
  ]

  return (
    <div>
      <header className="bg-white border-b fixed top-0 left-0 right-0 z-50">
        <div className="container mx-auto px-4 py-2">
          <div className="flex items-center justify-between">
            <Link href="/" className="mr-8">
              <Image src="/lms_logo.png" alt="Sidebar Logo" width={100} height={100} />
            </Link>
            <nav className="hidden md:flex space-x-9 ml-6">
              {navItems.map((item) => {
                const isActive = pathname === item.href
                return (
                  <Link
                    key={item.href}
                    href={item.href}
                    className={`text-sm font-bold hover:text-blue-500 ${isActive ? "text-blue-500" : "text-gray-700"
                      }`}
                  >
                    {item.label}
                  </Link>
                )
              })}
            </nav>
            <div className="flex items-center space-x-4">
              {/* User Profile Dropdown */}
              {/* <DropdownMenu>
                <DropdownMenuTrigger asChild>
                  <button aria-label="User Profile" className="text-gray-500 hover:text-gray-700">
                    <User size={20} />
                  </button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-56" align="end">
                  {userData ? (
                    <>
                      <DropdownMenuLabel>My Account</DropdownMenuLabel>
                      <DropdownMenuSeparator />
                      <DropdownMenuGroup>
                        <DropdownMenuItem asChild>
                          <Link href="/user/profile">Profile</Link>
                        </DropdownMenuItem>
                        <DropdownMenuItem asChild>
                          <Link href="/teacher/dashboard/profile">Dashboard</Link>
                        </DropdownMenuItem>
                      </DropdownMenuGroup>
                      <DropdownMenuSeparator />
                      <DropdownMenuItem onClick={handleLogout}>
                        <LogOut className="mr-2 h-4 w-4" />
                        <span>Log out</span>
                      </DropdownMenuItem>
                    </>
                  ) : (
                    <>
                      <DropdownMenuLabel>Account</DropdownMenuLabel>
                      <DropdownMenuSeparator />
                      <DropdownMenuItem>
                        <Link href="/login" className="flex items-center">
                          <User className="mr-2 h-4 w-4" />
                          <span>Log in</span>
                        </Link>
                      </DropdownMenuItem>
                      <DropdownMenuItem>
                        <Link href="/register">Register</Link>
                      </DropdownMenuItem>
                    </>
                  )}
                </DropdownMenuContent>
              </DropdownMenu> */}
              <div>
                {userData ? (
                  // Khi đã đăng nhập, hiển thị icon User + tên, có dropdown menu
                  <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                      <button
                        aria-label="User Profile"
                        className="text-gray-500 hover:text-gray-700 flex items-center space-x-2"
                      >
                        <User size={20} />
                        <span>{userData.role}-{userData.fullName}</span>
                      </button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent className="w-56" align="end">
                      <DropdownMenuLabel>My Account</DropdownMenuLabel>
                      <DropdownMenuSeparator />
                      <DropdownMenuGroup>
                        <DropdownMenuItem asChild>
                          <Link href="/user/profile">Profile</Link>
                        </DropdownMenuItem>
                        <DropdownMenuItem asChild>
                          <Link href={dashboardLink}>Dashboard</Link>
                        </DropdownMenuItem>
                      </DropdownMenuGroup>
                      <DropdownMenuSeparator />
                      <DropdownMenuItem onClick={() => logout()}>
                        <LogOut className="mr-2 h-4 w-4" />
                        Log out
                      </DropdownMenuItem>
                    </DropdownMenuContent>
                  </DropdownMenu>
                ) : (
                  // Khi chưa đăng nhập, hiển thị 2 nút đăng nhập và đăng ký
                  <div className="flex space-x-4">
                    <Link
                      href="/login"
                      className="text-gray-700 hover:text-blue-500 font-semibold"
                    >
                      Đăng nhập
                    </Link>
                    <Link
                      href="/register"
                      className="text-gray-700 hover:text-blue-500 font-semibold"
                    >
                      Đăng ký
                    </Link>
                  </div>
                )}
              </div>



              <DropdownMenu>
                <DropdownMenuTrigger asChild>
                  <button aria-label="Shopping Cart" className="text-gray-500 hover:text-gray-700">
                    <ShoppingCart size={20} />
                  </button>
                </DropdownMenuTrigger>
                <DropdownMenuContent className="w-64" align="end">
                  <DropdownMenuLabel>Shopping Cart</DropdownMenuLabel>
                  <DropdownMenuSeparator />
                  <div className="py-2 px-3">
                    {/* Cart is empty state */}
                    <div className="text-center py-4">
                      <ShoppingCart className="mx-auto h-10 w-10 text-gray-400 mb-2" />
                      <p className="text-gray-500">Your cart is empty</p>
                      <Button variant="outline" className="mt-3 w-full">
                        Browse Courses
                      </Button>
                    </div>
                  </div>
                </DropdownMenuContent>
              </DropdownMenu>
            </div>
          </div>
        </div>
      </header>
      <section className="relative bg-gradient-to-r from-blue-600 to-blue-400 text-white">
        <div className="absolute inset-0 overflow-hidden">
          <div className="absolute inset-0 bg-blue-500 opacity-90"></div>
          <div className="absolute inset-0 bg-[url('/pattern.svg')] bg-repeat opacity-10"></div>
        </div>
        <div className="container mx-auto px-4 py-16 md:py-24 relative z-10">
          <div className="flex flex-col md:flex-row items-center">
            <div className="md:w-1/2 mb-10 md:mb-0 md:pr-10">
              <h1 className="text-3xl md:text-4xl lg:text-5xl font-bold mb-6 leading-tight">ENGLISH LEARNING SYSTEM</h1>
              <p className="text-lg md:text-xl mb-8 opacity-90">
                Hệ thống học tiếng Anh giao tiếp toàn diện cho người bắt đầu. Phương pháp học hiệu quả, nội dung chất
                lượng, giảng viên chuyên nghiệp.
              </p>
              <div className="flex flex-col sm:flex-row gap-4">
                <Button size="lg" className="bg-white font-bold text-blue-600 hover:bg-gray-100">
                  Bắt đầu học ngay
                </Button>
                <Button size="lg" variant="outline" className="bg-white font-bold text-blue-600 hover:bg-gray-100">
                  Tìm hiểu thêm
                </Button>
              </div>
            </div>
            <div className="md:w-1/2 flex justify-center">
              <div className="relative w-full max-w-md h-[300px] md:h-[400px]">
                <Image src="/anh1.webp" alt="Landmaster Learning" fill className="object-contain" priority />
              </div>
            </div>
          </div>
        </div>
        <div
          className="absolute bottom-0 left-0 right-0 h-16 bg-white"
          style={{ clipPath: "polygon(0 100%, 100% 100%, 100% 0)" }}
        ></div>
      </section>
    </div>
  )
}
