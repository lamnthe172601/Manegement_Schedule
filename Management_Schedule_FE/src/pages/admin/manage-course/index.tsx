import React from "react"
import {
  Table,
  TableHeader,
  TableBody,
  TableHead,
  TableRow,
  TableCell,
} from "@/components/ui/table"
import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationLink,
  PaginationPrevious,
  PaginationNext,
} from "@/components/ui/pagination"
import { Card, CardHeader, CardTitle, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Skeleton } from "@/components/ui/skeleton"
import { Alert, AlertTitle, AlertDescription } from "@/components/ui/alert"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectItem,
  SelectValue,
  SelectGroup,
  SelectLabel,
} from "@/components/ui/select"
import {
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
} from "@/components/ui/dropdown-menu"
import {
  MoreHorizontalIcon,
  PlusIcon,
  ChevronUpIcon,
  ChevronDownIcon,
  MinusIcon,
} from "lucide-react"
import { Button } from "@/components/ui/button"
import Link from "next/link"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
} from "@/components/ui/dialog"

import { mutate } from "swr"
import useGetCourses, { Course } from "@/hooks/api/course/use-get-course"
import { Slider } from "@/components/ui/slider"
import { Checkbox } from "@/components/ui/checkbox"
import { useEditCourse } from "@/hooks/api/course/use-edit-course"
import { showErrorToast, showSuccessToast } from "@/components/common/toast/toast"
import { Endpoints } from "@/lib/endpoints"
const PAGE_SIZE = 5

const SORTABLE_COLUMNS = [
  { key: "courseName", label: "Tên" },
  { key: "price", label: "Price" },
  { key: "discountPercent", label: "(%)" },
  { key: "duration", label: "Số lượng (slot)" },
]

const SORT_ICONS = {
  asc: <ChevronDownIcon className="size-4 inline ml-1" />,
  desc: <ChevronUpIcon className="size-4 inline ml-1" />,
  none: <MinusIcon className="size-4 inline ml-1" />,
}

const CoursePage = () => {
  const { data, error, isLoading } = useGetCourses()
  const [page, setPage] = React.useState(1)
  const [search, setSearch] = React.useState("")
  const [priceRange, setPriceRange] = React.useState<[number, number]>([0, 10000000])
  const [discountRange, setDiscountRange] = React.useState<[number, number]>([0, 100])
  const [sorts, setSorts] = React.useState(
    [] as { key: string; direction: "asc" | "desc" | "none" }[]
  )
  const [viewDialogOpen, setViewDialogOpen] = React.useState(false)
  const [courseToView, setCourseToView] = React.useState<Course | null>(null)
  const [deleteDialogOpen, setDeleteDialogOpen] = React.useState(false)
  const [courseToDelete, setCourseToDelete] = React.useState<Course | null>(null)
  const { editCourse, loading } = useEditCourse()
  const [editForm, setEditForm] = React.useState<Partial<Course>>({})
  const [editDialogOpen, setEditDialogOpen] = React.useState(false)
  const [courseToEdit, setCourseToEdit] = React.useState<Course | null>(null)
  const [previewUrl, setPreviewUrl] = React.useState<string | null>(null)

  const filtered = (data || []).filter((course) =>
    course.courseName.toLowerCase().includes(search.toLowerCase())
  ).filter((course) => {
    const price = course.price || 0
    const discount = course.discountPercent || 0
    return (
      price >= priceRange[0] &&
      price <= priceRange[1] &&
      discount >= discountRange[0] &&
      discount <= discountRange[1]
    )
  })


  // Sort
  const sorted = React.useMemo(() => {
    if (!filtered.length || sorts.length === 0) return filtered
    return [...filtered].sort((a: any, b: any) => {
      for (const sort of sorts) {
        if (sort.direction === "none") continue
        let aValue: any = a[sort.key]
        let bValue: any = b[sort.key]
        if (sort.key === "status") {
          aValue = aValue ? 1 : 0
          bValue = bValue ? 1 : 0
        }
        if (aValue < bValue) return sort.direction === "asc" ? -1 : 1
        if (aValue > bValue) return sort.direction === "asc" ? 1 : -1
      }
      return 0
    })
  }, [filtered, sorts])

  const total = sorted.length
  const totalPages = Math.ceil(total / PAGE_SIZE)
  const paginated = sorted.slice((page - 1) * PAGE_SIZE, page * PAGE_SIZE)

  console.log(paginated, total, totalPages)

  const handleSort = (key: string) => {
    setSorts((prev) => {
      const existing = prev.find((s) => s.key === key)
      let direction: "asc" | "desc" | "none" = "asc"
      if (existing) {
        if (existing.direction === "asc") direction = "desc"
        else if (existing.direction === "desc") direction = "none"
        else direction = "asc"
        if (direction === "none") return prev.filter((s) => s.key !== key)
        return prev.map((s) => (s.key === key ? { ...s, direction } : s))
      }
      return [...prev, { key, direction }]
    })
  }
  React.useEffect(() => {
    if (courseToEdit) {
      if (courseToEdit?.thumbnailUrl) {
        setPreviewUrl(typeof courseToEdit.thumbnailUrl === "string" ? courseToEdit.thumbnailUrl : null);
      }
      setEditForm({
        courseID: courseToEdit.courseID,
        courseName: courseToEdit.courseName,
        price: courseToEdit.price,
        description: courseToEdit.description,
        discountPercent: courseToEdit.discountPercent,
        duration: courseToEdit.duration,
        createdAt: courseToEdit.createdAt,
        thumbnailUrl: courseToEdit.thumbnailUrl,
        isSelling: courseToEdit.isSelling,
        isComingSoon: courseToEdit.isComingSoon,
        isPro: courseToEdit.isPro,
        isCompletable: courseToEdit.isCompletable,
        level: courseToEdit.level,
      });
    }
  }, [courseToEdit]);



  const convertToFormData = (data: Partial<Course>) => {
    const formData = new FormData();

    for (const key in data) {
      const value = data[key as keyof Course];

      if (key === "thumbnailUrl") {
        if (typeof value === "object" && value instanceof File) {
          formData.append("ThumbnailFile", value); // đổi tên thành "ThumbnailFile"
        } else if (typeof value === "string") {
          formData.append("thumbnailUrl", value);
        }
      } else if (value !== undefined && value !== null) {
        formData.append(key, value.toString());
      }
    }

    return formData;
  };



  const handleSaveEdit = async () => {
    if (!editForm.courseID) return;

    try {
      const formData = convertToFormData(editForm);

      await editCourse({ id: editForm.courseID.toString(), data: formData }); // API hỗ trợ FormData
      showSuccessToast("Cập nhật khóa học thành công!");
      setEditDialogOpen(false);
      setCourseToEdit(null);
      setEditForm({});
      setPreviewUrl(null);

      mutate(Endpoints.Courses.GET_ALL);
    } catch (err) {
      console.error(err);
      showErrorToast("Cập nhật khóa học thất bại!");
    }
  };

  const handleEditChange = (field: keyof Course, value: any) => {
    setEditForm((prev) => ({
      ...prev,
      [field]: value,
    }));
  };

  console.log("editForm", editForm)
  return (
    <Card>
      <CardHeader>
        <div className="flex items-center justify-between">
          <CardTitle>Danh sách khóa học</CardTitle>
          <Link href="/admin/manage-course/add">
            <Button>
              <PlusIcon className="mr-2" />
              Thêm khóa học
            </Button>
          </Link>
        </div>
      </CardHeader>
      <CardContent>
        <div className="flex flex-col gap-6 mb-6">
          {/* Tìm kiếm */}
          <div>
            <Label htmlFor="search" className="block mb-1 font-medium text-sm">Tìm kiếm</Label>
            <Input
              id="search"
              placeholder="Tìm theo tên khóa học..."
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              className="mt-1"
            />
          </div>

          {/* Bộ lọc */}
          <div className="grid grid-cols-1 md:grid-cols-2 gap-6">
            {/* Lọc giá */}
            <div>
              <Label className="block mb-1 font-medium text-sm">Khoảng giá (VND)</Label>
              <Slider
                min={0}
                max={10000000}
                step={100000}
                value={priceRange}
                onValueChange={(value) => setPriceRange([value[0], value[1]])}
              />
              <div className="flex justify-between mt-2">
                <Input
                  className="w-30 border-2"
                  value={`${priceRange[0].toLocaleString()}đ `}
                  disabled
                  readOnly
                />
                <Input
                  className="w-30 border-2"
                  value={`${priceRange[1].toLocaleString()}đ `}
                  disabled
                  readOnly
                />
              </div>
            </div>

            {/* Lọc giảm giá */}
            <div>
              <Label className="block mb-1 font-medium text-sm">Giảm giá (%)</Label>
              <Slider
                min={0}
                max={100}
                step={5}
                value={discountRange}
                onValueChange={(value) => setDiscountRange([value[0], value[1]])}
              />
              <div className="flex justify-between mt-2">
                <Input
                  className="w-20 border-2"
                  value={`${discountRange[0]}%  `}
                  disabled
                  readOnly
                />
                <Input
                  className="w-20 border-2"
                  value={`${discountRange[1]}% `}
                  disabled
                  readOnly
                />
              </div>

            </div>
          </div>
        </div>


        {isLoading ? (
          <div className="space-y-2">
            {[...Array(PAGE_SIZE)].map((_, i) => (
              <Skeleton key={i} className="h-10 w-full" />
            ))}
          </div>
        ) : error ? (
          <Alert variant="destructive">
            <AlertTitle>Lỗi</AlertTitle>
            <AlertDescription>
              Không thể tải danh sách khóa học.
            </AlertDescription>
          </Alert>
        ) : (
          <>
            <Table>
              <TableHeader>
                <TableRow>
                  <TableHead>STT</TableHead>
                  {SORTABLE_COLUMNS.map((col) => {
                    const sort = sorts.find((s) => s.key === col.key)
                    const icon = sort
                      ? SORT_ICONS[sort.direction]
                      : SORT_ICONS.none
                    return (
                      <TableHead
                        key={col.key}
                        className="cursor-pointer select-none align-center items-center"
                        onClick={() => handleSort(col.key)}
                      >
                        {col.label} {icon}
                      </TableHead>
                    )
                  })}
                  {/* <TableHead>Ngày tạo</TableHead> */}
                  <TableHead>Hình ảnh</TableHead>
                  <TableHead>Trạng thái</TableHead>
                  <TableHead>Tình trạng</TableHead>
                  <TableHead>Hành động</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {paginated.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={8} className="text-center">
                      Không có khóa học nào.
                    </TableCell>
                  </TableRow>
                ) : (
                  paginated.map((course, idx) => (
                    <TableRow key={course.courseID}>
                      <TableCell>{(page - 1) * PAGE_SIZE + idx + 1}</TableCell>
                      <TableCell>{course.courseName}</TableCell>
                      <TableCell>{course.price.toLocaleString("vi-VN")}đ</TableCell>
                      <TableCell>{course.discountPercent}%</TableCell>
                      <TableCell>{course.duration}</TableCell>
                      {/* <TableCell>{new Date(course.createdAt).toLocaleDateString("vi-VN")}</TableCell> */}
                      <TableCell>
                        <img
                          src={course.thumbnailUrl}
                          alt="Thumbnail preview"
                          className="w-32 h-32 object-cover rounded mb-2"
                        />
                      </TableCell>
                      <TableCell>
                        {course.isSelling ? (
                          <Badge className="bg-green-600">Có bán </Badge>
                        ) : (
                          <Badge variant="destructive">Không bán</Badge>
                        )}
                      </TableCell>
                      <TableCell>
                        {course.isComingSoon ? (
                          <Badge className="bg-green-600">Săp ra mắt </Badge>
                        ) : (
                          <Badge variant="destructive">Ra mắt</Badge>
                        )}
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
                                setCourseToView(course)
                                setViewDialogOpen(true)
                              }}
                            >
                              Chi tiết
                            </DropdownMenuItem>

                            <DropdownMenuItem
                              onClick={() => {
                                setCourseToEdit(course)
                                setEditDialogOpen(true)
                              }}
                            >
                              Chỉnh sửa
                            </DropdownMenuItem>

                          </DropdownMenuContent>
                        </DropdownMenu>
                      </TableCell>
                    </TableRow>
                  ))
                )}
              </TableBody>
            </Table>

            {totalPages > 1 && (
              <Pagination className="mt-4">
                <PaginationContent>
                  <PaginationItem>
                    <PaginationPrevious
                      href="#"
                      onClick={(e) => {
                        e.preventDefault()
                        setPage((p) => Math.max(1, p - 1))
                      }}
                      aria-disabled={page === 1}
                    />
                  </PaginationItem>
                  {Array.from({ length: totalPages }).map((_, i) => (
                    <PaginationItem key={i}>
                      <PaginationLink
                        href="#"
                        isActive={page === i + 1}
                        onClick={(e) => {
                          e.preventDefault()
                          setPage(i + 1)
                        }}
                      >
                        {i + 1}
                      </PaginationLink>
                    </PaginationItem>
                  ))}
                  <PaginationItem>
                    <PaginationNext
                      href="#"
                      onClick={(e) => {
                        e.preventDefault()
                        setPage((p) => Math.min(totalPages, p + 1))
                      }}
                      aria-disabled={page === totalPages}
                    />
                  </PaginationItem>
                </PaginationContent>
              </Pagination>
            )}
          </>
        )}
      </CardContent>

      <Dialog open={viewDialogOpen} onOpenChange={setViewDialogOpen}>
        <DialogContent className="max-w-xl">
          <DialogHeader>
            <DialogTitle>Chi tiết khóa học</DialogTitle>
          </DialogHeader>
          {courseToView && (
            <div className="space-y-3">
              {courseToView.thumbnailUrl && (
                <img
                  src={courseToView.thumbnailUrl}
                  alt={courseToView.courseName}
                  className="w-full h-auto rounded-md"
                />
              )}
              <div><strong>Tên:</strong> {courseToView.courseName}</div>
              <div><strong>Mô tả:</strong> {courseToView.description || "Không có"}</div>
              <div><strong>Giá:</strong> {courseToView.price.toLocaleString()} VND</div>
              <div><strong>Giảm giá:</strong> {courseToView.discountPercent}%</div>
              <div><strong>Thời lượng:</strong> {courseToView.duration} giờ</div>
              <div><strong>Cấp độ:</strong> {courseToView.level}</div>
              <div><strong>Trạng thái:</strong> {courseToView.isComingSoon ? "Sắp ra mắt" : "Đã phát hành"}</div>
              <div><strong>Đang bán:</strong> {courseToView.isSelling ? "Có" : "Không"}</div>
              <div><strong>Dành cho Pro:</strong> {courseToView.isPro ? "Có" : "Không"}</div>
              <div><strong>Hoàn thành được:</strong> {courseToView.isCompletable ? "Có" : "Không"}</div>
              <div><strong>Ngày tạo:</strong> {new Date(courseToView.createdAt).toLocaleString("vi-VN", { hour12: false })}</div>
              <div><strong>Ngày cập nhật:</strong> {new Date(courseToView.modifiedAt).toLocaleString("vi-VN", { hour12: false })}</div>

            </div>
          )}
          <DialogFooter>
            <Button onClick={() => setViewDialogOpen(false)}>Đóng</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
      {/* Form chỉnh sửa: */}
      <Dialog open={editDialogOpen} onOpenChange={setEditDialogOpen}>
        <DialogContent className="max-h-[90vh] overflow-auto px-4">
          <DialogHeader>
            <DialogTitle>Chỉnh sửa khóa học</DialogTitle>
          </DialogHeader>
          {courseToEdit && (
            <div className="space-y-4">
              <div>
                <Label>Tên khóa học</Label>
                <Input
                  value={editForm.courseName || ""}
                  onChange={(e) => handleEditChange("courseName", e.target.value)}
                />
              </div>

              <div>
                <Label>Giá (VND)</Label>
                <Input
                  type="number"
                  value={editForm.price ?? ""}
                  onChange={(e) => handleEditChange("price", Number(e.target.value))}
                />
              </div>

              <div>
                <Label>Phần trăm giảm giá (%)</Label>
                <Input
                  type="number"
                  value={editForm.discountPercent ?? ""}
                  onChange={(e) => handleEditChange("discountPercent", Number(e.target.value))}
                />
              </div>

              <div>
                <Label>Thời lượng</Label>
                <Input
                  value={editForm.duration || ""}
                  onChange={(e) => handleEditChange("duration", e.target.value)}
                />
              </div>

              <div>
                <Label>Thumbnail</Label>
                {previewUrl && (
                  <img
                    src={previewUrl}
                    alt="Thumbnail preview"
                    className="w-32 h-32 object-cover rounded mb-2"
                  />
                )}
                <Input
                  type="file"
                  accept="image/*"
                  onChange={(e) => {
                    const file = e.target.files?.[0];
                    if (file) {
                      handleEditChange("thumbnailUrl", file);
                      setPreviewUrl(URL.createObjectURL(file));
                    }
                  }}
                />
              </div>




              <div>
                <Label>Mô tả</Label>
                <Input
                  value={editForm.description || ""}
                  onChange={(e) => handleEditChange("description", e.target.value)}
                />
              </div>

              <div className="flex items-center space-x-2">
                <Checkbox
                  id="isComingSoon"
                  checked={editForm.isComingSoon ?? false}
                  onCheckedChange={(checked) => handleEditChange("isComingSoon", checked)}
                />
                <Label htmlFor="isComingSoon">Sắp ra mắt</Label>
              </div>

              <div className="flex items-center space-x-2">
                <Checkbox
                  id="isSelling"
                  checked={editForm.isSelling ?? false}
                  onCheckedChange={(checked) => handleEditChange("isSelling", checked)}
                />
                <Label htmlFor="isSelling">Đang mở bán</Label>
              </div>

              <div className="flex items-center space-x-2">
                <Checkbox
                  id="isPro"
                  checked={editForm.isPro ?? false}
                  onCheckedChange={(checked) => handleEditChange("isPro", checked)}
                />
                <Label htmlFor="isPro">Khóa VIP</Label>
              </div>

              <div className="flex items-center space-x-2">
                <Checkbox
                  id="isCompletable"
                  checked={editForm.isCompletable ?? false}
                  onCheckedChange={(checked) => handleEditChange("isCompletable", checked)}
                />
                <Label htmlFor="isCompletable">Có thể hoàn thành</Label>
              </div>

              <div className="mb-4">
                <Select
                  value={editForm.level?.toString() || ""}
                  onValueChange={(value) => handleEditChange("level", value)}
                >
                  <SelectTrigger className="w-[180px]">
                    <SelectValue placeholder="Chọn trình độ" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectGroup>
                      <SelectLabel>Trình độ</SelectLabel>
                      {[1, 2, 3, 4, 5].map((level) => (
                        <SelectItem key={level} value={level.toString()}>
                          {level}
                        </SelectItem>
                      ))}
                    </SelectGroup>
                  </SelectContent>
                </Select>
                <Label className="block text-sm font-medium text-gray-700 mb-1">Trình độ</Label>
              </div>

            </div>
          )}

          <DialogFooter>
            <Button variant="outline" onClick={() => setEditDialogOpen(false)}>
              Hủy
            </Button>
            <Button onClick={handleSaveEdit} disabled={loading}>
              Lưu thay đổi
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      <Dialog open={deleteDialogOpen} onOpenChange={setDeleteDialogOpen}>
        <DialogContent className="max-w-md">
          <DialogHeader>
            <DialogTitle>Xóa khóa học</DialogTitle>
          </DialogHeader>
          <p>Bạn có chắc chắn muốn xóa khóa học {courseToDelete?.courseName} không?</p>
          <DialogFooter className="flex justify-end space-x-2">
            <Button variant="outline" onClick={() => setDeleteDialogOpen(false)}>Hủy</Button>
            <Button
              variant="destructive"
              onClick={async () => {
                if (!courseToDelete) return;
                try {
                  // Call your delete API here
                  // await deleteCourse(courseToDelete.courseID);
                  showSuccessToast("Xóa khóa học thành công!");
                  setDeleteDialogOpen(false);
                  setCourseToDelete(null);
                  // Optionally refresh course list here
                } catch {
                  showErrorToast("Xóa khóa học thất bại!");
                }
              }}
            >
              Xóa
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>


    </Card>
  )
}


export default CoursePage
