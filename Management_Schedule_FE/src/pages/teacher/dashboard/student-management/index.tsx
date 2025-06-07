"use client"

import { useEffect, useState } from "react"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
  SelectGroup,
  SelectLabel,
} from "@/components/ui/select"
import { Avatar, AvatarImage, AvatarFallback } from "@/components/ui/avatar"
import {
  DropdownMenu,
  DropdownMenuItem,
  DropdownMenuContent,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu"
import { MoreHorizontal } from "lucide-react"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { Badge } from "@/components/ui/badge"
import TeacherLayout from "@/components/features/guest/TeacherLayout"
import { Classes } from "@/hooks/api/classes/use-add-classes"
import useSWR from "swr"
import { useAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { showErrorToast } from "@/components/common/toast/toast"
import { Student } from "@/hooks/api/students/Student"

export default function StudentManagementPage() {
  const [user] = useAtom(userInfoAtom)
  const teacherId: string | undefined = user?.nameid

  const [classes, setClasses] = useState<Classes[]>([])
  const [students, setStudents] = useState<Student[]>([])
  const [selectClassId, setSelectClassId] = useState<number | null>(null)
  const fetcher = async (url: string): Promise<Classes[]> => {
    const response = await axios.get(url)
    return response.data.data
  }
  const { data, error, isLoading } = useSWR(
    teacherId
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Teacher.GET_CLASS_BY_TEACHER_ID(teacherId)}`
      : null,
    fetcher,
  )

  if (error) {
    showErrorToast(error.message)
  }

  if (isLoading) {
  }

  const fetchDataStudent = async (idClass: number) => {
    const response = await axios.get(
      idClass
        ? `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(idClass)}`
        : "",
    )
    setStudents(response.data.data)
  }

  const handleSelectClass = async (value: string) => {
    debugger
    const id = +value
    setSelectClassId(id)
    if (!id) return
    try {
      const response = await axios.get(
        `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(id)}`,
      )
      setStudents(response.data.data)
    } catch (err) {
      console.error("Lỗi gọi API:", err)
    }
  }

  useEffect(() => {
    if (data && data.length > 0) {
      setClasses(data)
      const firstId = data[0].classID
      setSelectClassId(firstId)
      handleSelectClass(firstId.toString())
    }
  }, [data])
  console.log(students)

  function formatDate(isoDateString: string): string {
  if (!isoDateString) return "Không có dữ liệu";
  
  const date = new Date(isoDateString);
  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0'); 
  const year = date.getFullYear();

  return `${day}/${month}/${year}`; 
}

  return (
    <TeacherLayout>
      <div className="flex justify-between items-end mb-6">
        <h1 className="text-2xl font-bold">Quản lý học viên</h1>
        <Select onValueChange={handleSelectClass}>
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder="Select a Class" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Các lớp học của bạn</SelectLabel>
              {classes &&
                Array.isArray(classes) &&
                classes.map((c) => (
                  <SelectItem key={c.classID} value={c.classID.toString()}>
                    {c.className}
                  </SelectItem>
                ))}
            </SelectGroup>
          </SelectContent>
        </Select>
      </div>

      <div className="border rounded-lg overflow-hidden">
        <Table>
          <TableHeader>
            <TableRow className="bg-gray-100">
              <TableHead className="w-[50px]">STT</TableHead>
              <TableHead>Họ và tên</TableHead>
              <TableHead>Avatar</TableHead>
              <TableHead>Số điện thoại</TableHead>
              <TableHead>Email</TableHead>
              <TableHead>Ngày đăng kí</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {students &&
              Array.isArray(students) &&
              students.map((student,index) => (
                <TableRow key={student.studentID}>
                  <TableCell className="font-medium">
                    {index+1}
                  </TableCell>
                  <TableCell>{student.fullName}</TableCell>
                  <TableCell>
                    <div className="flex items-center space-x-3">
                      <Avatar>
                        <AvatarImage
                          src={student.avatarUrl || "/placeholder.svg"}
                          alt={student.fullName}
                        />
                        <AvatarFallback>NA</AvatarFallback>
                      </Avatar>
                    </div>
                  </TableCell>
                  <TableCell className="font-medium">{student.phoneNumber}</TableCell>
                  <TableCell className="text-sm text-gray-500">{student.email}</TableCell>
                  <TableCell className="text-sm text-gray-500">{formatDate(student.enrollmentDate)}</TableCell>
                  {/* <TableCell>
                    <Badge
                      variant={
                        student.status === 1
                          ? "default"
                          : student.status === 0
                            ? "secondary"
                            : "outline"
                      }
                      className={
                        student.status === 1
                          ? "bg-green-100 text-green-800 hover:bg-green-100"
                          : student.status === 0
                            ? "bg-gray-100 text-gray-800 hover:bg-gray-100"
                            : "bg-yellow-100 text-yellow-800 hover:bg-yellow-100"
                      }
                    >
                      {student.status === 1
                        ? "Đang học"
                        : student.status === 0
                          ? "Tạm dừng"
                          : "Chờ xử lý"}
                    </Badge>
                  </TableCell> */}
                  {/* <TableCell className="text-right">
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
                        <DropdownMenuItem className="text-red-600">
                          Xóa học viên
                        </DropdownMenuItem>
                      </DropdownMenuContent>
                    </DropdownMenu>
                  </TableCell> */}
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </div>

      {/* Pagination */}
      <div className="flex items-center justify-between mt-4">
        <div className="text-sm text-gray-500">
          Hiển thị 1-5 của 125 học viên
        </div>
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
