import { Dialog, DialogContent, DialogHeader, DialogTitle, DialogFooter } from "@/components/ui/dialog"
import { Input } from "@/components/ui/input"
import { Button } from "@/components/ui/button"
import { Label } from "@/components/ui/label"
import React from "react"
import { User } from "@/hooks/api/user/use-get-users"
import { Textarea } from "@/components/ui/textarea"
import { format } from "date-fns"
import axios from "axios"

type Props = {
    open: boolean
    onOpenChange: (open: boolean) => void
    user: User | null
    onSave: (updatedUser: Partial<User>) => void
}

const UserEditDialog: React.FC<Props> = ({ open, onOpenChange, user, onSave }) => {
    const [formData, setFormData] = React.useState<Partial<User>>({})

    React.useEffect(() => {
        if (user) {
            setFormData({
                userID: user.userID,
                fullName: user.fullName,
                gender: user.gender || "M",
                dateOfBirth: user.dateOfBirth,
                address: user.address,
                phone: user.phone,
                introduction: user.introduction,
                avatarUrl: user.avatarUrl,
                status: user.status,
                role: user.role
            })
        }
    }, [user])
    console.log("formData", formData)

    const handleChange = (field: keyof Partial<User>, value: any) => {
        setFormData((prev) => ({ ...prev, [field]: value }))
    }

    const handleSave = () => {
        if (!formData.userID) return
        const formPayload = new FormData()
        Object.entries(formData).forEach(([key, value]) => {
            formPayload.append(key, value as any)
        })
        axios.put(`/api/user/${formData.userID}`, formPayload, {
            headers: { 'Content-Type': 'multipart/form-data' }
        })
            .then(response => {
                console.log("User updated successfully:", response.data)
                onSave(formData)
            })
            .catch(error => {
                console.error("Error updating user:", error)
            })
    }

    return (
        <Dialog open={open} onOpenChange={onOpenChange}>
            <DialogContent className="max-w-2xl">
                <DialogHeader>
                    <DialogTitle>Chỉnh sửa hội viên</DialogTitle>
                </DialogHeader>
                <div className="grid grid-cols-2 gap-4">
                    <div>
                        <Label>Họ tên</Label>
                        <Input value={formData.fullName || ""} onChange={(e) => handleChange("fullName", e.target.value)} />
                    </div>
                    <div>
                        <Label>Giới tính</Label>
                        <select
                            className="w-full border rounded px-3 py-2"
                            value={formData.gender || ""}
                            onChange={(e) => handleChange("gender", e.target.value)}
                        >
                            <option value="M">Nam</option>
                            <option value="F">Nữ</option>
                        </select>
                    </div>
                    <div>
                        <Label>Ngày sinh</Label>
                        <Input
                            type="date"
                            value={formData.dateOfBirth ? format(formData.dateOfBirth, "yyyy-MM-dd") : ""}
                            onChange={(e) => handleChange("dateOfBirth", e.target.value ? new Date(e.target.value) : undefined)}
                        />
                    </div>
                    <div>
                        <Label>Số điện thoại</Label>
                        <Input value={formData.phone || ""} onChange={(e) => handleChange("phone", e.target.value)} />
                    </div>
                    <div className="col-span-2">
                        <Label>Địa chỉ</Label>
                        <Input value={formData.address || ""} onChange={(e) => handleChange("address", e.target.value)} />
                    </div>
                    <div className="col-span-2">
                        <Label>Giới thiệu</Label>
                        <Textarea value={formData.introduction || ""} onChange={(e) => handleChange("introduction", e.target.value)} />
                    </div>
                    <div className="col-span-2">
                        <Label>Avatar URL</Label>
                        <Input value={formData.avatarUrl || ""} onChange={(e) => handleChange("avatarUrl", e.target.value)} />
                    </div>
                    <div>
                        <Label>Trạng thái</Label>
                        <select
                            className="w-full border rounded px-3 py-2"
                            value={formData.status?.toString() || "0"}
                            onChange={(e) => handleChange("status", Number(e.target.value))}
                        >
                            <option value={0}>Khóa</option>
                            <option value={1}>Hoạt động</option>
                        </select>
                    </div>
                    <div>
                        <Label>Role</Label>
                        <select
                            className="w-full border rounded px-3 py-2"
                            value={formData.role?.toString() || "0"}
                            onChange={(e) => handleChange("role", Number(e.target.value))}
                        >
                            <option value={2}>Teacher</option>
                            <option value={3}>Học sinh</option>
                        </select>
                    </div>
                </div>
                <DialogFooter className="mt-4">
                    <Button variant="outline" onClick={() => onOpenChange(false)}>Hủy</Button>
                    <Button onClick={handleSave}>Lưu</Button>
                </DialogFooter>
            </DialogContent>
        </Dialog>
    )
}

export default UserEditDialog
