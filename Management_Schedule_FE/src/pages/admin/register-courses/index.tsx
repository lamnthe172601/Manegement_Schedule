"use client"
import { Endpoints } from "@/lib/endpoints"
import axios from "axios"
import { useEffect, useState } from "react"
import useSWR from "swr"
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
  SelectGroup,
  SelectLabel,
} from "@/components/ui/select"
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table"
import { Avatar, AvatarImage, AvatarFallback } from "@/components/ui/avatar"
import { Button } from "react-day-picker"
import { Student } from "@/hooks/api/students/Student"
import { ClassList } from "@/hooks/api/classes/use-get-class"
import format from "date-fns/format"
import { showErrorToast } from "@/components/common/toast/toast"
function Page() {
  const [classes, setClasses] = useState<ClassList[]>([])
  const [students, setStudents] = useState<Student[]>([])
  const [selectedId, setSelectedId] = useState<number | null>(null)
  const fetcher = async (url: string) => {
    const response = await axios.get(url)
    return response.data.data
  }

  const { data, error, isLoading } = useSWR(
    `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_ALL_BASIC}`,
    fetcher,
  )

  if(error){
    showErrorToast(error.message);
  }

  useEffect(() => {
    if (data) {
      setClasses(data)
    }
  }, data)

  const handleSelectClass = async (value: string) => {
    setSelectedId(+value)
    const response = await axios.get(
      selectedId ? `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(selectedId)}`:'',
    )
    setStudents(response.data.data)
  }

  return (
    <div>
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
              <TableHead>Trạng thái</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {students &&
              Array.isArray(students) &&
              students.map((student, index) => (
                <TableRow key={student.studentID}>
                  <TableCell className="font-medium">{index + 1}</TableCell>
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
                  <TableCell className="font-medium">
                    {student.phoneNumber}
                  </TableCell>
                  <TableCell className="text-sm text-gray-500">
                    {student.email}
                  </TableCell>
                  <TableCell className="text-sm text-gray-500">
                    {/* {format(new Date(student.enrollmentDate), 'dd/MM/yyyy')} */}
                  </TableCell>
                  <TableCell >
                    <Button className={student.status == 1 ? 'bg-gray-100' : 'bg-black-100'}>{student.status == 1 ? 'đã đăng kí' : 'chưa đăng kí' }</Button>
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
      </div>
    </div>
  )
}

export default Page
