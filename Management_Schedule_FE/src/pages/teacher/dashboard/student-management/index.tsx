"use client"

import { useEffect, useState } from "react"
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
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
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

  // Pagination state
  const [currentPage, setCurrentPage] = useState(1)
  const pageSize = 5

  const fetcher = async (url: string): Promise<Classes[]> => {
    const response = await axios.get(url)
    return response.data.data
  }
  const { data, error, isLoading } = useSWR(
    teacherId
      ? `${Endpoints.baseApiURL.URL}${Endpoints.Teacher.GET_CLASS_BY_TEACHER_ID(teacherId)}`
      : null,
    fetcher
  )

  useEffect(() => {
    if (error) showErrorToast(error.message)
  }, [error])

  useEffect(() => {
    if (data && data.length) {
      setClasses(data)
      const firstId = data[0].classID
      setSelectClassId(firstId)
      fetchStudents(firstId)
    }
  }, [data])

  async function fetchStudents(idClass: number) {
    try {
      const response = await axios.get(
        `${Endpoints.baseApiURL.URL}${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(idClass)}`
      )
      setStudents(response.data.data)
      setCurrentPage(1)
    } catch (err) {
      console.error("Lỗi gọi API:", err)
    }
  }

  const handleSelectClass = (value: string) => {
    const id = +value
    setSelectClassId(id)
    if (id) fetchStudents(id)
  }

  const totalPages = Math.ceil(students.length / pageSize)
  const paginatedStudents = students.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  )

  const formatDate = (iso: string) => {
    if (!iso) return "Không có dữ liệu"
    const d = new Date(iso)
    const day = String(d.getDate()).padStart(2, "0")
    const month = String(d.getMonth() + 1).padStart(2, "0")
    const year = d.getFullYear()
    return `${day}/${month}/${year}`
  }

  return (
    <TeacherLayout>
      <div className="flex justify-between items-end mb-6">
        <h1 className="text-2xl font-bold">Quản lý học viên</h1>
        <Select onValueChange={handleSelectClass}>
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder="Chọn lớp" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Các lớp học</SelectLabel>
              {classes.map((c) => (
                <SelectItem key={c.classID} value={String(c.classID)}>
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
              <TableHead>STT</TableHead>
              <TableHead>Họ và tên</TableHead>
              <TableHead>Avatar</TableHead>
              <TableHead>SĐT</TableHead>
              <TableHead>Email</TableHead>
              <TableHead>Ngày đăng ký</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {paginatedStudents.map((student, idx) => (
              <TableRow key={student.studentID}>
                <TableCell>{(currentPage - 1) * pageSize + idx + 1}</TableCell>
                <TableCell>{student.fullName}</TableCell>
                <TableCell>
                  <Avatar>
                    <AvatarImage
                      src={student.avatarUrl || "/placeholder.svg"}
                      alt={student.fullName}
                    />
                    <AvatarFallback>NA</AvatarFallback>
                  </Avatar>
                </TableCell>
                <TableCell>{student.phoneNumber}</TableCell>
                <TableCell>{student.email}</TableCell>
                <TableCell>{formatDate(student.enrollmentDate)}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>

      {/* Pagination Controls */}
      <div className="flex items-center justify-between mt-4">
        <div className="text-sm text-gray-500">
          Hiển thị {(currentPage - 1) * pageSize + 1} -{' '}
          {Math.min(currentPage * pageSize, students.length)} của {students.length} học viên
        </div>
        <div className="flex items-center space-x-2">
          <Button
            size="sm"
            variant="outline"
            disabled={currentPage === 1}
            onClick={() => setCurrentPage(currentPage - 1)}
          >
            Trước
          </Button>
          {[...Array(totalPages)].map((_, i) => (
            <Button
              key={i}
              size="sm"
              variant={i + 1 === currentPage ? 'ghost' : 'outline'}
              onClick={() => setCurrentPage(i + 1)}
            >
              {i + 1}
            </Button>
          ))}
          <Button
            size="sm"
            variant="outline"
            disabled={currentPage === totalPages}
            onClick={() => setCurrentPage(currentPage + 1)}
          >
            Sau
          </Button>
        </div>
      </div>
    </TeacherLayout>
  )
}