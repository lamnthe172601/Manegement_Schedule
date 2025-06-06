import StudentLayout from "@/components/features/guest/StudentLayout"
import {
  Table,
  TableRow,
  TableCell,
  TableHeader,
  TableHead,
  TableBody,
} from "@/components/ui/table"
function Page() {
  const listSchedule = [
    {
      id: 1,
      name: "ASSA",
      schedule: "Thứ 2",
      slot: "Ca 1",
      time: "8h - 10h30",
      teacher: "Na",
    },
    {
      id: 2,
      name: "ASSA",
      schedule: "Thứ 4",
      slot: "Ca 3",
      time: "8h - 10h30",
      teacher: "GV1",
    },
    {
      id: 3,
      name: "ASSA",
      schedule: "Thứ 7",
      slot: "Ca 1",
      time: "8h - 10h30",
      teacher: "GV5",
    },
    {
      id: 4,
      name: "ASSA",
      schedule: "Thứ 3",
      slot: "Ca 1",
      time: "8h - 10h30",
      teacher: "GV2",
    },
    {
      id: 5,
      name: "ASSA",
      schedule: "Thứ 5",
      slot: "Ca 1",
      time: "8h - 10h30",
      teacher: "GV3",
    },
    {
      id: 6,
      name: "ASSA",
      schedule: "Chủ nhật",
      slot: "Ca 1",
      time: "8h - 10h30",
      teacher: "GV4",
    },
  ]
  return (
    <StudentLayout>
      <div>
        <h1 className="font-extrabold text-3xl">Lịch học</h1>
        <Table className="mx-auto w-250 border-l-1 border-l-transparent hover:border-l-gray-50 transition-colors duration-300">
          <TableHeader className="bg-[#3B9643]">
            <TableRow className="h-[60px]">
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Tên lớp
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Lịch học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Ca học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Giờ học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Giảng viên
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody className="bg-[#AACEBF]">
            {listSchedule.map((s) => (
              <TableRow key={s.id} className="h-[60px]">
                <TableCell className="text-black text-center border border-gray-50">{s.name}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.schedule}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.slot}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.time}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.teacher}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </StudentLayout>
  )
}

export default Page
