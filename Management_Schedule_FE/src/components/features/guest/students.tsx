import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from "@/components/ui/table";

const students = [
  {
    id: 1,
    name: "Nguyễn Văn A",
    avatar: "/avatars/user1.jpg",
    course: "Giao tiếp cơ bản",
  },
  {
    id: 2,
    name: "Trần Thị B",
    avatar: "/avatars/user2.jpg",
    course: "Phát âm chuẩn Mỹ",
  },
  {
    id: 3,
    name: "Lê Văn C",
    avatar: "/avatars/user3.jpg",
    course: "Giao tiếp nâng cao",
  },
];

export default function StudentListPage() {
  return (
    <div className="container mx-auto py-8">
      <h1 className="text-3xl font-bold mb-6">Danh sách học viên</h1>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Học viên</TableHead>
            <TableHead>Khóa học đang học</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {students.map((student) => (
            <TableRow key={student.id}>
              <TableCell className="flex items-center gap-4">
                <Avatar>
                  <AvatarImage src={student.avatar} />
                  <AvatarFallback>{student.name.split(' ')[0][0]}</AvatarFallback>
                </Avatar>
                <span>{student.name}</span>
              </TableCell>
              <TableCell>{student.course}</TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
}
