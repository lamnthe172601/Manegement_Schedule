import React, { useEffect, useState } from "react";
import { Button } from "@/components/ui/button";
import { Badge } from "@/components/ui/badge";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
} from "@/components/ui/dialog";
import { MoreHorizontalIcon } from "lucide-react";
import { useRouter } from "next/router";
import { showErrorToast, showSuccessToast } from "@/components/common/toast/toast";
import { useDeleteUser } from "@/hooks/api/user/use-delete-user";

interface Course {
  _id: string;
  name: string;
  code: string;
  status: boolean;
  price?: number;
  type?: string;
  discount?: number;
  backgroundImage?: string;
}

const PAGE_SIZE = 10;

const CourseManagement: React.FC = () => {
  const [courses, setCourses] = useState<Course[]>([]);
  const [page, setPage] = useState(1);
  const router = useRouter();
  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
  const [courseToDelete, setCourseToDelete] = useState<Course | null>(null);
  const { deleteUser, loading: deleting } = useDeleteUser()

  useEffect(() => {
    setCourses(dummyData); // Dữ liệu mẫu
  }, []);

  const paginated = courses.slice((page - 1) * PAGE_SIZE, page * PAGE_SIZE);

  const handleDeleteClick = (course: Course) => {
    setCourseToDelete(course)
    setDeleteDialogOpen(true)
  }
  const handleConfirmDelete = async () => {
    if (!courseToDelete) return;

    await deleteUser({ id: courseToDelete._id })
      .then(() => {
        showSuccessToast("Xóa khóa học thành công!")
        setDeleteDialogOpen(false)
        // setCourseToDelete(null)
        // mutate(Endpoints.Users.GET_ALL)
      })
      .catch(() => {
        showErrorToast("Xóa khóa học thất bại!")
        setDeleteDialogOpen(false)
      })
  }
  return (
    <div className="p-4">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-bold">Quản lý khóa học</h2>
        <Button onClick={() => router.push(`/admin/manage-course/add`)}>
          Thêm khóa học
        </Button>
      </div>

      <Table>
        <TableHeader>
          <TableRow>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              #
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Tên khóa học
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Mã khóa học
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Ảnh nền
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Giá
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Loại
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Giảm giá
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Trạng thái
            </TableHead>
            <TableHead className="px-4 py-3 bg-green-600 text-white font-medium text-left">
              Hành động
            </TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {paginated.map((course, index) => (
            <TableRow key={course._id + index}>
              <TableCell>{(page - 1) * PAGE_SIZE + index + 1}</TableCell>
              <TableCell>{course.name}</TableCell>
              <TableCell>{course.code}</TableCell>
              <TableCell>
                {course.backgroundImage ? (
                  <img
                    src={course.backgroundImage}
                    alt={course.name}
                    className="w-16 h-10 object-cover rounded"
                  />
                ) : (
                  "N/A"
                )}
              </TableCell>
              <TableCell>
                {course.price
                  ? course.price.toLocaleString() + " VND"
                  : "N/A"}
              </TableCell>
              <TableCell>{course.type || "N/A"}</TableCell>
              <TableCell>{course.discount ? `${course.discount}%` : "N/A"}</TableCell>
              <TableCell>
                <Badge variant={course.status ? "default" : "destructive"}>
                  {course.status ? "Hiển thị" : "Ẩn"}
                </Badge>
              </TableCell>
              <TableCell>
                <DropdownMenu modal={false}>
                  <DropdownMenuTrigger asChild>
                    <button className="p-2 rounded-full hover:bg-accent">
                      <MoreHorizontalIcon className="size-5" />
                    </button>
                  </DropdownMenuTrigger>
                  <DropdownMenuContent align="end">
                    <DropdownMenuItem
                      onClick={() => {
                        router.push(`/admin/manage-course/${course._id}/view`)
                      }}
                    >
                      Chi tiết
                    </DropdownMenuItem>
                    <DropdownMenuItem
                      onClick={() => {
                        // router.push(`/users/${user._id}/edit`)
                      }}
                    >
                      Chỉnh sửa
                    </DropdownMenuItem>
                    <DropdownMenuItem
                      variant="destructive"
                      onClick={() => handleDeleteClick(course)}
                    >
                      Xóa
                    </DropdownMenuItem>
                  </DropdownMenuContent>
                </DropdownMenu>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>

      <div className="mt-4 flex justify-center">
        <div className="space-x-2">
          <Button
            variant="outline"
            onClick={() => setPage((prev) => Math.max(prev - 1, 1))}
            disabled={page === 1}
          >
            Trước
          </Button>
          <span>Trang {page}</span>
          <Button
            variant="outline"
            onClick={() =>
              setPage((prev) =>
                prev * PAGE_SIZE < courses.length ? prev + 1 : prev
              )
            }
            disabled={page * PAGE_SIZE >= courses.length}
          >
            Sau
          </Button>
        </div>
      </div>

      <Dialog open={deleteDialogOpen} onOpenChange={setDeleteDialogOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Xác nhận xóa hội viên</DialogTitle>
          </DialogHeader>
          <div>
            Bạn có chắc chắn muốn xóa khóa học <b>{courseToDelete?.name}</b>{" "}
            không?
          </div>
          <DialogFooter>
            <Button
              variant="outline"
              onClick={() => setDeleteDialogOpen(false)}
              disabled={deleting}
            >
              Hủy
            </Button>
            <Button
              variant="destructive"
              onClick={handleConfirmDelete}
              disabled={deleting}
            >
              Xóa
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </div>
  );
};

export default CourseManagement;

// ===== Dummy data =====
const dummyData: Course[] = [
  {
    _id: "1",
    name: "Lập trình C cơ bản",
    code: "C101",
    status: true,
    price: 1000000,
    type: "Offline",
    discount: 10,
    backgroundImage: "https://example.com/image1.jpg",
  },
  {
    _id: "2",
    name: "Lập trình JavaScript",
    code: "JS201",
    status: false,
    price: 1500000,
    type: "Online",
    discount: 15,
    backgroundImage: "https://example.com/image2.jpg",
  },
  {
    _id: "3",
    name: "Lập trình Python",
    code: "PY301",
    status: true,
    price: 1200000,
    type: "Offline",
    discount: 5,
    backgroundImage: "https://example.com/image3.jpg",
  },
  {
    _id: "4",
    name: "Lập trình React",
    code: "RE401",
    status: true,
    price: 2000000,
    type: "Online",
    discount: 20,
    backgroundImage: "https://example.com/image4.jpg",
  },
];
