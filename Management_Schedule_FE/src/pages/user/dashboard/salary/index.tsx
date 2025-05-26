"use client"

import { useState } from "react"
import { Calendar, Download, ArrowUp, ArrowDown, DollarSign, FileText } from "lucide-react"
import { Button } from "@/components/ui/button"
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table"
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs"
import { Badge } from "@/components/ui/badge"

import TeacherLayout from "@/components/features/guest/TeacherLayout"

export default function SalaryPage() {
    const [period, setPeriod] = useState("current-month")

    // Mock salary data
    const salaryStats = [
        { title: "Tổng thu nhập", value: "12.500.000 đ", change: "+8%", trend: "up" },
        { title: "Số giờ giảng dạy", value: "48 giờ", change: "+4 giờ", trend: "up" },
        { title: "Thu nhập trung bình/giờ", value: "260.000 đ", change: "+5%", trend: "up" },
        { title: "Thanh toán tiếp theo", value: "15/06/2023", change: "Còn 12 ngày", trend: "neutral" },
    ]

    // Mock payment history
    const paymentHistory = [
        {
            id: "INV-2023-05",
            period: "Tháng 5, 2023",
            date: "31/05/2023",
            amount: "12.500.000 đ",
            hours: 48,
            status: "paid",
        },
        {
            id: "INV-2023-04",
            period: "Tháng 4, 2023",
            date: "30/04/2023",
            amount: "11.700.000 đ",
            hours: 45,
            status: "paid",
        },
        {
            id: "INV-2023-03",
            period: "Tháng 3, 2023",
            date: "31/03/2023",
            amount: "10.400.000 đ",
            hours: 40,
            status: "paid",
        },
        {
            id: "INV-2023-02",
            period: "Tháng 2, 2023",
            date: "28/02/2023",
            amount: "9.100.000 đ",
            hours: 35,
            status: "paid",
        },
        {
            id: "INV-2023-01",
            period: "Tháng 1, 2023",
            date: "31/01/2023",
            amount: "10.400.000 đ",
            hours: 40,
            status: "paid",
        },
    ]

    // Mock earnings breakdown
    const earningsBreakdown = [
        { course: "Tiếng Anh Giao Tiếp Cơ Bản", hours: 20, rate: "250.000 đ", total: "5.000.000 đ" },
        { course: "Tiếng Anh Thương Mại", hours: 15, rate: "280.000 đ", total: "4.200.000 đ" },
        { course: "Tiếng Anh Giao Tiếp Nâng Cao", hours: 13, rate: "300.000 đ", total: "3.900.000 đ" },
    ]

    return (
        <TeacherLayout>
            <div className="flex justify-between items-center mb-6">
                <h1 className="text-2xl font-bold">Tiền lương</h1>
                <div className="flex items-center space-x-2">
                    <Select defaultValue={period} onValueChange={setPeriod}>
                        <SelectTrigger className="w-[180px]">
                            <SelectValue placeholder="Chọn kỳ lương" />
                        </SelectTrigger>
                        <SelectContent>
                            <SelectItem value="current-month">Tháng hiện tại</SelectItem>
                            <SelectItem value="last-month">Tháng trước</SelectItem>
                            <SelectItem value="last-3-months">3 tháng gần đây</SelectItem>
                            <SelectItem value="last-6-months">6 tháng gần đây</SelectItem>
                            <SelectItem value="custom">Tùy chỉnh...</SelectItem>
                        </SelectContent>
                    </Select>
                    <Button variant="outline">
                        <Calendar className="h-4 w-4 mr-2" />
                        Chọn ngày
                    </Button>
                    <Button variant="outline">
                        <Download className="h-4 w-4 mr-2" />
                        Xuất báo cáo
                    </Button>
                </div>
            </div>

            {/* Salary Statistics */}
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 mb-6">
                {salaryStats.map((stat, index) => (
                    <Card key={index}>
                        <CardHeader className="pb-2">
                            <CardTitle className="text-sm font-medium text-gray-500">{stat.title}</CardTitle>
                        </CardHeader>
                        <CardContent>
                            <div className="flex items-center">
                                <div className="text-2xl font-bold mr-2">{stat.value}</div>
                                <Badge
                                    variant="outline"
                                    className={`flex items-center ${stat.trend === "up"
                                        ? "bg-green-100 text-green-800"
                                        : stat.trend === "down"
                                            ? "bg-red-100 text-red-800"
                                            : "bg-gray-100 text-gray-800"
                                        }`}
                                >
                                    {stat.trend === "up" ? (
                                        <ArrowUp className="h-3 w-3 mr-1" />
                                    ) : stat.trend === "down" ? (
                                        <ArrowDown className="h-3 w-3 mr-1" />
                                    ) : null}
                                    {stat.change}
                                </Badge>
                            </div>
                            <CardDescription>So với kỳ trước</CardDescription>
                        </CardContent>
                    </Card>
                ))}
            </div>

            {/* Tabs for different views */}
            <Tabs defaultValue="overview" className="mb-6">
                <TabsList className="mb-4">
                    <TabsTrigger value="overview">Tổng quan</TabsTrigger>
                    <TabsTrigger value="history">Lịch sử thanh toán</TabsTrigger>
                    <TabsTrigger value="breakdown">Chi tiết thu nhập</TabsTrigger>
                </TabsList>

                {/* Overview Tab */}
                <TabsContent value="overview">
                    <div className="grid grid-cols-1 md:grid-cols-3 gap-6">
                        {/* Current Month Earnings */}
                        <Card className="md:col-span-2">
                            <CardHeader>
                                <CardTitle>Thu nhập tháng 5, 2023</CardTitle>
                                <CardDescription>Chi tiết thu nhập trong tháng hiện tại</CardDescription>
                            </CardHeader>
                            <CardContent>
                                <div className="space-y-4">
                                    <div className="flex justify-between items-center pb-2 border-b">
                                        <div className="font-medium">Tổng số giờ giảng dạy</div>
                                        <div className="font-bold">48 giờ</div>
                                    </div>
                                    <div className="flex justify-between items-center pb-2 border-b">
                                        <div className="font-medium">Mức lương cơ bản</div>
                                        <div className="font-bold">9.600.000 đ</div>
                                    </div>
                                    <div className="flex justify-between items-center pb-2 border-b">
                                        <div className="font-medium">Phụ cấp</div>
                                        <div className="font-bold">1.500.000 đ</div>
                                    </div>
                                    <div className="flex justify-between items-center pb-2 border-b">
                                        <div className="font-medium">Thưởng</div>
                                        <div className="font-bold">1.400.000 đ</div>
                                    </div>
                                    <div className="flex justify-between items-center pt-2">
                                        <div className="font-medium text-lg">Tổng thu nhập</div>
                                        <div className="font-bold text-lg text-green-600">12.500.000 đ</div>
                                    </div>
                                </div>
                            </CardContent>
                        </Card>

                        {/* Payment Status */}
                        <Card>
                            <CardHeader>
                                <CardTitle>Trạng thái thanh toán</CardTitle>
                                <CardDescription>Kỳ lương tháng 5, 2023</CardDescription>
                            </CardHeader>
                            <CardContent>
                                <div className="flex flex-col items-center justify-center h-48 space-y-4">
                                    <div className="w-16 h-16 rounded-full bg-green-100 flex items-center justify-center">
                                        <DollarSign className="h-8 w-8 text-green-600" />
                                    </div>
                                    <div className="text-center">
                                        <div className="font-bold text-lg">Đã thanh toán</div>
                                        <div className="text-sm text-gray-500">Ngày 31/05/2023</div>
                                    </div>
                                    <Button variant="outline" className="mt-4">
                                        <FileText className="h-4 w-4 mr-2" />
                                        Xem phiếu lương
                                    </Button>
                                </div>
                            </CardContent>
                        </Card>
                    </div>
                </TabsContent>

                {/* Payment History Tab */}
                <TabsContent value="history">
                    <Card>
                        <CardHeader>
                            <CardTitle>Lịch sử thanh toán</CardTitle>
                            <CardDescription>Lịch sử thanh toán lương của bạn</CardDescription>
                        </CardHeader>
                        <CardContent>
                            <Table>
                                <TableHeader>
                                    <TableRow className="bg-gray-100">
                                        <TableHead>Mã phiếu</TableHead>
                                        <TableHead>Kỳ lương</TableHead>
                                        <TableHead>Ngày thanh toán</TableHead>
                                        <TableHead>Số giờ</TableHead>
                                        <TableHead>Số tiền</TableHead>
                                        <TableHead>Trạng thái</TableHead>
                                        <TableHead className="text-right">Thao tác</TableHead>
                                    </TableRow>
                                </TableHeader>
                                <TableBody>
                                    {paymentHistory.map((payment) => (
                                        <TableRow key={payment.id}>
                                            <TableCell className="font-medium">{payment.id}</TableCell>
                                            <TableCell>{payment.period}</TableCell>
                                            <TableCell>{payment.date}</TableCell>
                                            <TableCell>{payment.hours} giờ</TableCell>
                                            <TableCell className="font-medium">{payment.amount}</TableCell>
                                            <TableCell>
                                                <Badge
                                                    variant="outline"
                                                    className={
                                                        payment.status === "paid"
                                                            ? "bg-green-100 text-green-800"
                                                            : payment.status === "pending"
                                                                ? "bg-yellow-100 text-yellow-800"
                                                                : "bg-red-100 text-red-800"
                                                    }
                                                >
                                                    {payment.status === "paid"
                                                        ? "Đã thanh toán"
                                                        : payment.status === "pending"
                                                            ? "Đang xử lý"
                                                            : "Chưa thanh toán"}
                                                </Badge>
                                            </TableCell>
                                            <TableCell className="text-right">
                                                <Button variant="ghost" size="sm">
                                                    <FileText className="h-4 w-4 mr-2" />
                                                    Chi tiết
                                                </Button>
                                            </TableCell>
                                        </TableRow>
                                    ))}
                                </TableBody>
                            </Table>
                        </CardContent>
                    </Card>
                </TabsContent>

                {/* Earnings Breakdown Tab */}
                <TabsContent value="breakdown">
                    <Card>
                        <CardHeader>
                            <CardTitle>Chi tiết thu nhập theo khóa học</CardTitle>
                            <CardDescription>Tháng 5, 2023</CardDescription>
                        </CardHeader>
                        <CardContent>
                            <Table>
                                <TableHeader>
                                    <TableRow className="bg-gray-100">
                                        <TableHead>Khóa học</TableHead>
                                        <TableHead>Số giờ</TableHead>
                                        <TableHead>Đơn giá</TableHead>
                                        <TableHead className="text-right">Thành tiền</TableHead>
                                    </TableRow>
                                </TableHeader>
                                <TableBody>
                                    {earningsBreakdown.map((item, index) => (
                                        <TableRow key={index}>
                                            <TableCell className="font-medium">{item.course}</TableCell>
                                            <TableCell>{item.hours} giờ</TableCell>
                                            <TableCell>{item.rate}/giờ</TableCell>
                                            <TableCell className="text-right font-bold">{item.total}</TableCell>
                                        </TableRow>
                                    ))}
                                    <TableRow>
                                        <TableCell colSpan={3} className="text-right font-medium">
                                            Tổng cơ bản
                                        </TableCell>
                                        <TableCell className="text-right font-bold">9.600.000 đ</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={3} className="text-right font-medium">
                                            Phụ cấp
                                        </TableCell>
                                        <TableCell className="text-right font-bold">1.500.000 đ</TableCell>
                                    </TableRow>
                                    <TableRow>
                                        <TableCell colSpan={3} className="text-right font-medium">
                                            Thưởng
                                        </TableCell>
                                        <TableCell className="text-right font-bold">1.400.000 đ</TableCell>
                                    </TableRow>
                                    <TableRow className="bg-gray-50">
                                        <TableCell colSpan={3} className="text-right font-medium text-lg">
                                            Tổng thu nhập
                                        </TableCell>
                                        <TableCell className="text-right font-bold text-lg text-green-600">12.500.000 đ</TableCell>
                                    </TableRow>
                                </TableBody>
                            </Table>
                        </CardContent>
                    </Card>
                </TabsContent>
            </Tabs>
        </TeacherLayout>
    )
}
