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
import {
  Dialog,
  DialogTrigger,
  DialogContent,
  DialogHeader,
  DialogFooter,
} from "@/components/ui/dialog"
import { Avatar, AvatarImage, AvatarFallback } from "@/components/ui/avatar"
import { Button } from "@/components/ui/button"
import { Student } from "@/hooks/api/students/Student"
import { ClassList } from "@/hooks/api/classes/use-get-class"
import format from "date-fns/format"
import { showErrorToast } from "@/components/common/toast/toast"
import { debug } from "console"
import { useAxios } from "@/hooks/api/use-axios"
function Page() {
  const axiox = useAxios()
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

  if (error) {
    showErrorToast(error.message)
  }

  useEffect(() => {
    if (data) {
      setClasses(data)
    }
  }, [data])

  useEffect(() => {
    if (data && data.length > 0) {
      setClasses(data)
      const firstId = data[0].classID
      setSelectedId(firstId)
      handleSelectClass(firstId.toString())
    }
  }, [data])

  const handleSelectClass = async (value: string) => {
    debugger
    const id = +value
    setSelectedId(id)
    if (!id) return
    try {
      const response = await axios.get(
        `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(id)}`,
      )
      setStudents(response.data.data)
    } catch (err: any) {
      showErrorToast(err.message)
    }
  }

  const [selectedEnrollmentId, setSelectedEnrollmentId] = useState<
    number | null
  >(null)
  const [isDialogOpen, setIsDialogOpen] = useState(false)

  const handleOpenDialog = async (enrollmentId: number) => {
    debugger
    setSelectedEnrollmentId(enrollmentId)
    setIsDialogOpen(true)
  }

  const handleUpdateStatus = async () => {
    console.log("hehe")
    if (selectedEnrollmentId) {
      const response = await axiox.patch(
        `${Endpoints.baseApiURL.URL}/${Endpoints.Enrollment.UPDATE_STATUS_ENROLL(selectedEnrollmentId)}`,
        { status: 1 },
      )
      console.log(response.data)
      setIsDialogOpen(false)
      setStudents((prev) =>
        prev.map((student) =>
          student.enrollmentID === selectedEnrollmentId
            ? { ...student, status: 1 }
            : student
        )
      );
    }
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
                    {format(new Date(student.enrollmentDate), "dd/MM/yyyy")}
                  </TableCell>
                  <TableCell>
                    <Button
                      onClick={() => handleOpenDialog(student.enrollmentID)}
                      variant={student.status == 1 ? "outline" : "secondary"}
                    >
                      {student.status == 1 ? "đã đăng kí" : "chưa đăng kí"}
                    </Button>
                  </TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
        <Dialog open={isDialogOpen} onOpenChange={setIsDialogOpen}>
          <DialogContent>
            <DialogHeader>Xác nhận cập nhật trạng thái</DialogHeader>
            <p>Bạn có chắc muốn cập nhật trạng thái của sinh viên không?</p>
            <DialogFooter>
              <Button
                onClick={() => setIsDialogOpen(false)}
                variant="secondary"
              >
                Hủy
              </Button>
              <Button onClick={handleUpdateStatus}>Xác nhận</Button>
            </DialogFooter>
          </DialogContent>
        </Dialog>
      </div>
    </div>
  )
}

export default Page
