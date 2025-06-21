import useGetUsers, { User } from "@/hooks/api/user/use-get-users"
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
import { Constants } from "@/lib/constants"
import { Button } from "@/components/ui/button"
import Link from "next/link"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
} from "@/components/ui/dialog"
import { useDeleteUser } from "@/hooks/api/user/use-delete-user"
import {
  showErrorToast,
  showSuccessToast,
} from "@/components/common/toast/toast"
import { useSWRConfig } from "swr"
import { Endpoints } from "@/lib/endpoints"
import UserEditDialog from "./UserEditDialog"
import { useEditUser } from "@/hooks/api/user/use-edit-user"

const PAGE_SIZE = 10

const SORTABLE_COLUMNS = [
  { key: "fullName", label: "Tên" },
  { key: "email", label: "Email" },
  { key: "gender", label: "Giới tính" },
  { key: "createdAt", label: "Ngày tạo" },
  { key: "status", label: "Trạng thái" },
]

const SORT_ICONS = {
  asc: <ChevronDownIcon className="size-4 inline ml-1" />,
  desc: <ChevronUpIcon className="size-4 inline ml-1" />,
  none: <MinusIcon className="size-4 inline ml-1" />,
}

const UserPage = () => {
  const { data, error, isLoading } = useGetUsers()

  const { editUser } = useEditUser()
  const { deleteUser, loading: deleting } = useDeleteUser()
  const [page, setPage] = React.useState(1)
  const [search, setSearch] = React.useState("")
  const [role, setRole] = React.useState("all")
  const [sorts, setSorts] = React.useState(
    [] as { key: string; direction: "asc" | "desc" | "none" }[],
  )
  const [deleteDialogOpen, setDeleteDialogOpen] = React.useState(false)
  const [userToDelete, setUserToDelete] = React.useState<User | null>(null)
  const { mutate } = useSWRConfig()
  const [viewDialogOpen, setViewDialogOpen] = React.useState(false)
  const [editDialogOpen, setEditDialogOpen] = React.useState(false)
  const [userToEdit, setUserToEdit] = React.useState<User | null>(null)

  // Lọc và tìm kiếm
  const filtered = (data || [])
    .filter(user => user.role !== 1)
    .filter((users) => {
      const matchesSearch =
        users.fullName.toLowerCase().includes(search.toLowerCase()) ||
        users.email.toLowerCase().includes(search.toLowerCase())
      const matchesRole = role && role !== "all" ? users.role === Number(role) : true

      return matchesSearch && matchesRole
    })

  // Multi-column sort logic
  const sorted = React.useMemo(() => {
    if (!filtered.length || sorts.length === 0) return filtered
    return [...filtered].sort((a: any, b: any) => {
      for (const sort of sorts) {
        if (sort.direction === "none") continue
        let aValue: any = (a as any)[sort.key]
        let bValue: any = (b as any)[sort.key]
        // Special handling for role and is_active
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

  React.useEffect(() => {
    setPage(1)
  }, [search, role])

  // Toggle sort for a column
  const handleSort = (key: string) => {
    setSorts((prev) => {
      const existing = prev.find((s) => s.key === key)
      let direction: "asc" | "desc" | "none" = "asc"
      if (existing) {
        if (existing.direction === "asc") direction = "desc"
        else if (existing.direction === "desc") direction = "none"
        else direction = "asc"
        // Remove if none, else update
        if (direction === "none") return prev.filter((s) => s.key !== key)
        return prev.map((s) => (s.key === key ? { ...s, direction } : s))
      }
      // Add new sort
      return [...prev, { key, direction }]
    })
  }

  const handleDeleteClick = (user: User) => {
    setUserToDelete(user)
    setDeleteDialogOpen(true)
  }

  const handleConfirmDelete = async () => {
    if (!userToDelete) return
    await deleteUser({ id: userToDelete.userID })
      .then(() => {
        showSuccessToast("Xóa hội viên thành công!")
        setDeleteDialogOpen(false)
        setUserToDelete(null)
        mutate(Endpoints.Users.GET_ALL)
      })
      .catch(() => {
        showErrorToast("Xóa hội viên thất bại!")
        setDeleteDialogOpen(false)
        setUserToDelete(null)
      })
  }
  const handleSaveEdit = async (updatedUser: Partial<User>) => {
    if (!updatedUser.userID) return
    console.log("updatedUser", updatedUser)

    try {
      await editUser({ email: userToEdit?.email?.toString() ?? "", data: updatedUser })
      showSuccessToast("Cập nhật hội viên thành công!")
      mutate(Endpoints.Users.GET_ALL)
      setEditDialogOpen(false)
    } catch (err) {
      console.error(err)
      showErrorToast("Cập nhật hội viên thất bại!")
    }
  }
  console.log("userToEdit", userToEdit)



  return (
    <Card>
      <CardHeader>
        <div className="flex items-center justify-between">
          <CardTitle>Danh sách học viên</CardTitle>
          <Button>
            <PlusIcon />
            <Link href="/admin/users/add">Thêm hội viên</Link>
          </Button>
        </div>
      </CardHeader>
      <CardContent>
        <div className="flex flex-col md:flex-row md:items-end gap-4 mb-6">
          <div className="flex-1">
            <Label htmlFor="search">Tìm kiếm</Label>
            <Input
              id="search"
              placeholder="Tìm theo tên, email, mã hội viên..."
              value={search}
              onChange={(e) => setSearch(e.target.value)}
              className="mt-1"
            />
          </div>
          <div className="w-full md:w-56">
            <Label htmlFor="role">Vai trò</Label>
            <Select value={role} onValueChange={setRole}>
              <SelectTrigger id="role" className="mt-1 w-full">
                <SelectValue placeholder="Tất cả vai trò" />
              </SelectTrigger>
              <SelectContent>
                <SelectItem value="all">Tất cả vai trò</SelectItem>
                <SelectItem value="1">Quản trị viên</SelectItem>
                <SelectItem value="2">Giáo viên</SelectItem>
                <SelectItem value="3">Học viên</SelectItem>

              </SelectContent>
            </Select>
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
              Không thể tải danh sách người dùng.
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
                        className="cursor-pointer select-none"
                        onClick={() => handleSort(col.key)}
                      >
                        {col.label} {icon}
                      </TableHead>
                    )
                  })}
                  <TableHead>Số điện thoại</TableHead>
                  <TableHead>Vai trò</TableHead>
                  <TableHead>Hành động</TableHead>
                </TableRow>
              </TableHeader>
              <TableBody>
                {paginated.length === 0 ? (
                  <TableRow>
                    <TableCell colSpan={8} className="text-center">
                      Không có hội viên nào.
                    </TableCell>
                  </TableRow>
                ) : (
                  paginated.map((user, idx) => (
                    <TableRow key={user.userID}>
                      <TableCell>{(page - 1) * PAGE_SIZE + idx + 1}</TableCell>
                      <TableCell>{user.fullName}</TableCell>
                      <TableCell>{user.email}</TableCell>
                      <TableCell>
                        {user?.gender === "M" ? "Nam" : user?.gender === "F" ? "Nữ" : "-"}
                      </TableCell>

                      <TableCell>
                        {new Date(user.createdAt).toLocaleDateString("vi-VN")}
                      </TableCell>
                      <TableCell>
                        <Badge className={
                          user.status == 1 ? "bg-green-600" : user.status == 2 ? "bg-red-600" : "bg-gray-600"
                        }>{Constants.statusMap[user.status]}</Badge>
                      </TableCell>
                      <TableCell>{user.phone}</TableCell>
                      <TableCell>
                        <Badge>{Constants.roleMap[user.role]}</Badge>
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
                                setUserToEdit(user)
                                setViewDialogOpen(true)
                              }}
                            >
                              Chi tiết
                            </DropdownMenuItem>
                            <DropdownMenuItem onClick={() => {
                              setUserToEdit(user)
                              setEditDialogOpen(true)
                            }}>
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
      <Dialog open={deleteDialogOpen} onOpenChange={setDeleteDialogOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Xác nhận xóa hội viên</DialogTitle>
          </DialogHeader>
          <div>
            Bạn có chắc chắn muốn xóa hội viên <b>{userToDelete?.fullName}</b>{" "}
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
      <Dialog open={viewDialogOpen} onOpenChange={setViewDialogOpen}>
        <DialogContent className="max-w-2xl">
          <div className="grid grid-cols-2 gap-4">
            <div>
              <Label>Họ tên</Label>
              <div className="border rounded px-3 py-2">{userToEdit?.fullName || "-"}</div>
            </div>
            <div>
              <Label>Giới tính</Label>
              <div className="border rounded px-3 py-2">
                {userToEdit?.gender === "M" ? "Nam" : userToEdit?.gender === "F" ? "Nữ" : "-"}
              </div>
            </div>
            <div>
              <Label>Ngày sinh</Label>
              <div className="border rounded px-3 py-2">
                {userToEdit?.dateOfBirth && !isNaN(new Date(userToEdit.dateOfBirth).getTime())
                  ? (new Date(userToEdit.dateOfBirth), "dd/MM/yyyy")
                  : "-"}
              </div>
            </div>
            <div>
              <Label>Số điện thoại</Label>
              <div className="border rounded px-3 py-2">{userToEdit?.phone || "-"}</div>
            </div>
            <div className="col-span-2">
              <Label>Địa chỉ</Label>
              <div className="border rounded px-3 py-2">{userToEdit?.address || "-"}</div>
            </div>
            <div className="col-span-2">
              <Label>Giới thiệu</Label>
              <div className="border rounded px-3 py-2 whitespace-pre-line">
                {userToEdit?.introduction || "-"}
              </div>
            </div>

            <div className="col-span-2">
              <Label>Avatar</Label>
              {userToEdit?.avatarUrl ? (
                <img
                  src={userToEdit.avatarUrl}
                  alt="Avatar"
                  className="w-24 h-24 object-cover rounded-full mb-2"
                />
              ) : (
                <div className="border rounded px-3 py-2">Chưa có avatar</div>
              )}
            </div>

            <div>
              <Label>Trạng thái</Label>
              <div className="border rounded px-3 py-2">
                {userToEdit?.status === 1
                  ? "Hoạt động"
                  : userToEdit?.status === 2
                    ? "Không hoạt động"
                    : userToEdit?.status === 3
                      ? "Khóa"
                      : "-"}
              </div>
            </div>
            <div>
              <Label>Role</Label>
              <div className="border rounded px-3 py-2">
                {userToEdit?.role === 2
                  ? "Teacher"
                  : userToEdit?.role === 3
                    ? "Học sinh"
                    : "-"}
              </div>
            </div>
          </div>

          <DialogFooter className="mt-4">
            <Button variant="outline" onClick={() => setViewDialogOpen(false)}>
              Đóng
            </Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>

      <UserEditDialog
        open={editDialogOpen}
        onOpenChange={setEditDialogOpen}
        user={userToEdit}
        onSave={handleSaveEdit}
      />



    </Card>
  )
}

export default UserPage
