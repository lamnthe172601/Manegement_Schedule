import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import { Bell, Shield, User } from "lucide-react"
import TeacherLayout from "@/components/features/guest/TeacherLayout"

export default function SettingsPage() {
    return (
        <TeacherLayout>
            <h1 className="text-2xl font-bold mb-6">Cài đặt</h1>

            <div className="flex">
                {/* Settings Navigation */}
                <div className="w-64 pr-8">
                    <nav>
                        <ul className="space-y-1">
                            <li>
                                <a href="#" className="flex items-center px-3 py-2 text-sm text-green-600 bg-green-50 rounded-md">
                                    <User className="h-4 w-4 mr-2" />
                                    Cài đặt tài khoản
                                </a>
                            </li>
                            <li>
                                <a href="#" className="flex items-center px-3 py-2 text-sm text-gray-700 hover:bg-gray-100 rounded-md">
                                    <Shield className="h-4 w-4 mr-2" />
                                    Bảo mật và đăng nhập
                                </a>
                            </li>
                            <li>
                                <a href="#" className="flex items-center px-3 py-2 text-sm text-gray-700 hover:bg-gray-100 rounded-md">
                                    <Bell className="h-4 w-4 mr-2" />
                                    Cài đặt thông báo
                                </a>
                            </li>
                        </ul>
                    </nav>
                </div>

                {/* Settings Content */}
                <div className="flex-1">
                    <div className="bg-white rounded-lg border p-6">
                        <h2 className="text-lg font-medium mb-6">Thông tin cá nhân</h2>

                        {/* Name */}
                        <div className="mb-6">
                            <div className="flex items-center justify-between mb-2">
                                <h3 className="text-sm font-medium text-gray-700">Họ tên</h3>
                                <Button variant="ghost" size="sm" className="text-xs text-gray-500 hover:text-gray-700">
                                    Chỉnh sửa
                                </Button>
                            </div>
                            <p className="text-sm">Nguyễn Văn A</p>
                            <p className="text-xs text-gray-500 mt-1">
                                Tên của bạn xuất hiện trên trang cá nhân và bên cạnh các bình luận của bạn.
                            </p>
                        </div>

                        {/* Address */}
                        <div className="mb-6">
                            <div className="flex items-center justify-between mb-2">
                                <h3 className="text-sm font-medium text-gray-700">Địa chỉ</h3>
                                <Button variant="ghost" size="sm" className="text-xs text-gray-500 hover:text-gray-700">
                                    Chỉnh sửa
                                </Button>
                            </div>
                            <p className="text-sm">Việt long</p>
                            <p className="text-xs text-gray-500 mt-1">Địa chỉ của bạn.</p>
                        </div>

                        {/* Avatar */}
                        <div className="mb-6">
                            <div className="flex items-center justify-between mb-2">
                                <h3 className="text-sm font-medium text-gray-700">Avatar</h3>
                                <Button variant="ghost" size="sm" className="text-xs text-gray-500 hover:text-gray-700">
                                    Chỉnh sửa
                                </Button>
                            </div>
                            <div className="flex items-start">
                                <Avatar className="h-16 w-16 mr-4">
                                    <AvatarImage src="/placeholder.svg?height=64&width=64" alt="User" />
                                    <AvatarFallback>NA</AvatarFallback>
                                </Avatar>
                                <p className="text-xs text-gray-500">Nên là ảnh vuông, chấp nhận các tệp: JPG, PNG hoặc GIF.</p>
                            </div>
                        </div>

                        {/* Email */}
                        <div className="mb-6">
                            <h3 className="text-sm font-medium text-gray-700 mb-2">Email</h3>
                            <p className="text-sm">a1@gmail.com</p>
                            <p className="text-xs text-gray-500 mt-1">Email để liên kết với Wonderland.</p>
                        </div>

                        {/* Birth Date */}
                        <div className="mb-6">
                            <div className="flex items-center justify-between mb-2">
                                <h3 className="text-sm font-medium text-gray-700">Ngày sinh</h3>
                                <Button variant="ghost" size="sm" className="text-xs text-gray-500 hover:text-gray-700">
                                    Chỉnh sửa
                                </Button>
                            </div>
                            <p className="text-sm">2010-12-31T17:00:00.000Z</p>
                        </div>

                        {/* Phone */}
                        <div>
                            <div className="flex items-center justify-between mb-2">
                                <h3 className="text-sm font-medium text-gray-700">Số điện thoại</h3>
                                <Button variant="ghost" size="sm" className="text-xs text-gray-500 hover:text-gray-700">
                                    Chỉnh sửa
                                </Button>
                            </div>
                            <p className="text-sm text-gray-400">Chưa cập nhật</p>
                        </div>
                    </div>
                </div>
            </div>
        </TeacherLayout>
    )
}
