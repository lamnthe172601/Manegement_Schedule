"use client"
import { useEffect, useState } from "react"
import useSWR from "swr"
import axios from "axios"
import { Endpoints } from "@/lib/endpoints"
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
import { useAxios } from "@/hooks/api/use-axios"

const fetcher = (url: string) =>
  axios.get(url).then((res) => res.data.data)

function Page() {
  const axiox = useAxios()
  const [selectedClassId, setSelectedClassId] = useState<number | null>(null)
  const [selectedEnrollmentId, setSelectedEnrollmentId] = useState<number | null>(null)
  const [isDialogOpen, setIsDialogOpen] = useState(false)


  const {
    data: classes = [],
    error: classError,
  } = useSWR<ClassList[]>(
    `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_ALL_BASIC}`,
    fetcher
  )


  useEffect(() => {
    if (classes.length > 0 && !selectedClassId) {
      setSelectedClassId(classes[0].classID)
    }
  }, [classes])


  const {
    data: students = [],
    error: studentError,
    mutate: mutateStudents,
  } = useSWR<Student[]>(
    selectedClassId
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Classes.GET_STUDENT_BY_CLASS_ID(selectedClassId)}`
      : null,
    fetcher
  )

  if (classError || studentError) {
    showErrorToast(classError?.message || studentError?.message)
  }

  const handleSelectClass = (value: string) => {
    const id = parseInt(value)
    if (!isNaN(id)) {
      setSelectedClassId(id)
    }
  }

  const handleOpenDialog = (enrollmentId: number) => {
    setSelectedEnrollmentId(enrollmentId)
    setIsDialogOpen(true)
  }

  const handleUpdateStatus = async () => {
    if (selectedEnrollmentId) {
      try {
        await axiox.patch(
          `${Endpoints.baseApiURL.URL}/${Endpoints.Enrollment.UPDATE_STATUS_ENROLL(selectedEnrollmentId)}`,
          { status: 1 }
        )
        setIsDialogOpen(false)
        mutateStudents() // Refresh student list
      } catch (err: any) {
        showErrorToast(err.message)
      }
    }
  }

  return (
    <div>
      <div className="flex justify-between items-end mb-6">
        <h1 className="text-2xl font-bold">Quản lý học viên</h1>
        <Select onValueChange={handleSelectClass} value={selectedClassId?.toString()}>
          <SelectTrigger className="w-[180px]">
            <SelectValue placeholder="Select a Class" />
          </SelectTrigger>
          <SelectContent>
            <SelectGroup>
              <SelectLabel>Các lớp học của bạn</SelectLabel>
              {classes.map((c) => (
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
            {students.map((student, index) => (
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
                <TableCell>{student.phoneNumber}</TableCell>
                <TableCell className="text-sm text-gray-500">
                  {student.email}
                </TableCell>
                <TableCell className="text-sm text-gray-500">
                  {format(new Date(student.enrollmentDate), "dd/MM/yyyy")}
                </TableCell>
                <TableCell>
                  <Button
                    onClick={() => handleOpenDialog(student.enrollmentID)}
                    variant={student.status === 1 ? "outline" : "secondary"}
                  >
                    {student.status === 1 ? "đã đăng kí" : "chưa đăng kí"}
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
              <Button onClick={() => setIsDialogOpen(false)} variant="secondary">
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
