import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import useGetUsers from "@/hooks/api/user/use-get-users";
import { Skeleton } from "@/components/ui/skeleton";

export default function StudentListPage() {
  const { data, error, isLoading } = useGetUsers();

  const teamMembers = data?.filter((user: any) => user.role === 3) || [];

  console.log("teamMembers", teamMembers)
  return (
    <div className="container mx-auto py-10">
      <h1 className="text-3xl font-bold mb-6 text-center">Danh sách học viên</h1>

      <div className="bg-white shadow-lg rounded-lg overflow-hidden border">
        <Table>
          <TableHeader>
            <TableRow className="bg-gray-100">
              <TableHead className="text-base">Học viên</TableHead>
              <TableHead className="text-base">Ngày tham gia trung tâm</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {isLoading ? (
              Array.from({ length: 4 }).map((_, idx) => (
                <TableRow key={idx}>
                  <TableCell>
                    <div className="flex items-center gap-4">
                      <Skeleton className="h-10 w-10 rounded-full" />
                      <Skeleton className="h-4 w-[150px]" />
                    </div>
                  </TableCell>
                  <TableCell>
                    <Skeleton className="h-4 w-[120px]" />
                  </TableCell>
                </TableRow>
              ))
            ) : teamMembers.length > 0 ? (
              teamMembers.map((student: any) => (
                <TableRow
                  key={student.userID}
                  className="hover:bg-gray-50 transition-all duration-200"
                >
                  <TableCell className="flex items-center gap-4 py-4">
                    <Avatar className="h-10 w-10">
                      <AvatarImage src={student.avatar || "/avatars/default.png"} />
                      <AvatarFallback>
                        {student.fullName?.split(" ")[0][0]}
                      </AvatarFallback>
                    </Avatar>
                    <span className="font-medium">{student.fullName}</span>
                  </TableCell>
                  <TableCell className="text-sm text-gray-700">
                    {student.createdAt ? new Date(student.createdAt).toLocaleString() : "Chưa đăng ký"}
                  </TableCell>
                </TableRow>
              ))
            ) : (
              <TableRow>
                <TableCell colSpan={2} className="text-center py-6 text-gray-500">
                  Không có học viên nào được tìm thấy.
                </TableCell>
              </TableRow>
            )}
          </TableBody>
        </Table>
      </div>
    </div>
  );
}
