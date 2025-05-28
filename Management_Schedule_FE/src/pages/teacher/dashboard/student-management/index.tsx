"use client"

import { useState } from "react"
import { Search, Filter, MoreHorizontal, Download, Plus, ChevronDown } from "lucide-react"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import {
    DropdownMenu,
    DropdownMenuContent,
    DropdownMenuItem,
    DropdownMenuLabel,
    DropdownMenuSeparator,
    DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"
import TeacherLayout from "@/components/features/guest/TeacherLayout"

export default function StudentManagementPage() {
    const [searchQuery, setSearchQuery] = useState("")

    // Mock student data
    const students = [
        {
            id: 1,
            name: "Nguyễn Thị Hương",
            email: "huong.nguyen@example.com",
            phone: "0912345678",
            course: "Tiếng Anh Giao Tiếp Cơ Bản",
            status: "active",
            progress: 75,
            lastActive: "Hôm nay",
            avatar: "/placeholder.svg?height=40&width=40",
        },
        {
            id: 2,
            name: "Trần Văn Bình",
            email: "binh.tran@example.com",
            phone: "0923456789",
            course: "Tiếng Anh Thương Mại",
            status: "active",
            progress: 45,
            lastActive: "Hôm qua",
            avatar: "/placeholder.svg?height=40&width=40",
        },
        {
            id: 3,
            name: "Lê Thị Minh",
            email: "minh.le@example.com",
            phone: "0934567890",
            course: "Tiếng Anh Giao Tiếp Nâng Cao",
            status: "inactive",
            progress: 20,
            lastActive: "3 ngày trước",
            avatar: "/placeholder.svg?height=40&width=40",
        },
        {
            id: 4,
            name: "Phạm Văn Đức",
            email: "duc.pham@example.com",
            phone: "0945678901",
            course: "Tiếng Anh Thương Mại",
            status: "active",
            progress: 90,
            lastActive: "Hôm nay",
            avatar: "/placeholder.svg?height=40&width=40",
        },
        {
            id: 5,
            name: "Hoàng Thị Lan",
            email: "lan.hoang@example.com",
            phone: "0956789012",
            course: "Tiếng Anh Giao Tiếp Cơ Bản",
            status: "pending",
            progress: 10,
            lastActive: "1 tuần trước",
            avatar: "/placeholder.svg?height=40&width=40",
        },
    ]

    // Summary statistics
    const stats = [
        { title: "Tổng số học viên", value: "125", description: "12 học viên mới trong tháng này" },
        { title: "Học viên đang hoạt động", value: "98", description: "78% tổng số học viên" },
        { title: "Tỷ lệ hoàn thành", value: "65%", description: "Tăng 5% so với tháng trước" },
        { title: "Điểm trung bình", value: "8.2", description: "Dựa trên 45 bài kiểm tra" },
    ]

    return (
        <TeacherLayout>
            <div className="flex justify-between items-center mb-6">
                <h1 className="text-2xl font-bold">Quản lý học viên</h1>
                <Button className="bg-green-600 hover:bg-green-700">
                    <Plus className="h-4 w-4 mr-2" />
                    Thêm học viên
                </Button>
            </div>

            {/* Statistics Cards */}
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
                {stats.map((stat, index) => (
                    <Card key={index}>
                        <CardHeader className="pb-2">
                            <CardTitle className="text-sm font-medium text-gray-500">{stat.title}</CardTitle>
                        </CardHeader>
                        <CardContent>
                            <div className="text-2xl font-bold">{stat.value}</div>
                            <CardDescription>{stat.description}</CardDescription>
                        </CardContent>
                    </Card>
                ))}
            </div>

            {/* Filters and Search */}
            <div className="flex flex-col md:flex-row justify-between items-start md:items-center mb-6 gap-4">
                <div className="flex items-center space-x-2 w-full md:w-auto">
                    <div className="relative w-full md:w-80">
                        <Search className="absolute left-3 top-1/2 h-4 w-4 -translate-y-1/2 text-gray-500" />
                        <Input
                            type="search"
                            placeholder="Tìm kiếm học viên..."
                            className="pl-10"
                            value={searchQuery}
                            onChange={(e) => setSearchQuery(e.target.value)}
                        />
                    </div>
                    <Button variant="outline" className="flex items-center">
                        <Filter className="h-4 w-4 mr-2" />
                        Lọc
                        <ChevronDown className="h-4 w-4 ml-2" />
                    </Button>
                </div>

                <div className="flex items-center space-x-2 w-full md:w-auto">
                    <Select defaultValue="all">
                        <SelectTrigger className="w-full md:w-40">
                            <SelectValue placeholder="Khóa học" />
                        </SelectTrigger>
                        <SelectContent>
                            <SelectItem value="all">Tất cả khóa học</SelectItem>
                            <SelectItem value="basic">Tiếng Anh Cơ Bản</SelectItem>
                            <SelectItem value="business">Tiếng Anh Thương Mại</SelectItem>
                            <SelectItem value="advanced">Tiếng Anh Nâng Cao</SelectItem>
                        </SelectContent>
                    </Select>

                    <Select defaultValue="all">
                        <SelectTrigger className="w-full md:w-40">
                            <SelectValue placeholder="Trạng thái" />
                        </SelectTrigger>
                        <SelectContent>
                            <SelectItem value="all">Tất cả trạng thái</SelectItem>
                            <SelectItem value="active">Đang học</SelectItem>
                            <SelectItem value="inactive">Tạm dừng</SelectItem>
                            <SelectItem value="pending">Chờ xử lý</SelectItem>
                        </SelectContent>
                    </Select>

                    <Button variant="outline">
                        <Download className="h-4 w-4 mr-2" />
                        Xuất
                    </Button>
                </div>
            </div>

            {/* Students Table */}
            <div className="border rounded-lg overflow-hidden">
                <Table>
                    <TableHeader>
                        <TableRow className="bg-gray-100">
                            <TableHead className="w-[50px]">ID</TableHead>
                            <TableHead>Học viên</TableHead>
                            <TableHead>Khóa học</TableHead>
                            <TableHead>Trạng thái</TableHead>
                            <TableHead>Tiến độ</TableHead>
                            <TableHead>Hoạt động gần đây</TableHead>
                            <TableHead className="text-right">Thao tác</TableHead>
                        </TableRow>
                    </TableHeader>
                    <TableBody>
                        {students.map((student) => (
                            <TableRow key={student.id}>
                                <TableCell className="font-medium">{student.id}</TableCell>
                                <TableCell>
                                    <div className="flex items-center space-x-3">
                                        <Avatar>
                                            <AvatarImage src={student.avatar || "/placeholder.svg"} alt={student.name} />
                                            <AvatarFallback>{student.name.charAt(0)}</AvatarFallback>
                                        </Avatar>
                                        <div>
                                            <div className="font-medium">{student.name}</div>
                                            <div className="text-sm text-gray-500">{student.email}</div>
                                        </div>
                                    </div>
                                </TableCell>
                                <TableCell>{student.course}</TableCell>
                                <TableCell>
                                    <Badge
                                        variant={
                                            student.status === "active" ? "default" : student.status === "inactive" ? "secondary" : "outline"
                                        }
                                        className={
                                            student.status === "active"
                                                ? "bg-green-100 text-green-800 hover:bg-green-100"
                                                : student.status === "inactive"
                                                    ? "bg-gray-100 text-gray-800 hover:bg-gray-100"
                                                    : "bg-yellow-100 text-yellow-800 hover:bg-yellow-100"
                                        }
                                    >
                                        {student.status === "active"
                                            ? "Đang học"
                                            : student.status === "inactive"
                                                ? "Tạm dừng"
                                                : "Chờ xử lý"}
                                    </Badge>
                                </TableCell>
                                <TableCell>
                                    <div className="flex items-center space-x-2">
                                        <div className="w-full bg-gray-200 rounded-full h-2.5">
                                            <div className="bg-green-600 h-2.5 rounded-full" style={{ width: `${student.progress}%` }}></div>
                                        </div>
                                        <span className="text-sm">{student.progress}%</span>
                                    </div>
                                </TableCell>
                                <TableCell>{student.lastActive}</TableCell>
                                <TableCell className="text-right">
                                    <DropdownMenu>
                                        <DropdownMenuTrigger asChild>
                                            <Button variant="ghost" size="icon">
                                                <MoreHorizontal className="h-4 w-4" />
                                                <span className="sr-only">Mở menu</span>
                                            </Button>
                                        </DropdownMenuTrigger>
                                        <DropdownMenuContent align="end">
                                            <DropdownMenuLabel>Thao tác</DropdownMenuLabel>
                                            <DropdownMenuItem>Xem chi tiết</DropdownMenuItem>
                                            <DropdownMenuItem>Chỉnh sửa</DropdownMenuItem>
                                            <DropdownMenuSeparator />
                                            <DropdownMenuItem>Gửi tin nhắn</DropdownMenuItem>
                                            <DropdownMenuItem>Xem lịch sử học tập</DropdownMenuItem>
                                            <DropdownMenuSeparator />
                                            <DropdownMenuItem className="text-red-600">Xóa học viên</DropdownMenuItem>
                                        </DropdownMenuContent>
                                    </DropdownMenu>
                                </TableCell>
                            </TableRow>
                        ))}
                    </TableBody>
                </Table>
            </div>

            {/* Pagination */}
            <div className="flex items-center justify-between mt-4">
                <div className="text-sm text-gray-500">Hiển thị 1-5 của 125 học viên</div>
                <div className="flex items-center space-x-2">
                    <Button variant="outline" size="sm" disabled>
                        Trước
                    </Button>
                    <Button variant="outline" size="sm" className="bg-gray-100">
                        1
                    </Button>
                    <Button variant="outline" size="sm">
                        2
                    </Button>
                    <Button variant="outline" size="sm">
                        3
                    </Button>
                    <Button variant="outline" size="sm">
                        Sau
                    </Button>
                </div>
            </div>
        </TeacherLayout>
    )
}
