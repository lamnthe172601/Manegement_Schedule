import React from "react"
import { useRouter } from "next/router"
import { Button } from "@/components/ui/button"
import { Input } from "@/components/ui/input"
import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectItem,
  SelectValue,
} from "@/components/ui/select"
import { z } from "zod"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
} from "@/components/ui/form"
import { useAddUser } from "@/hooks/api/user/use-add-user"
import {
  showErrorToast,
  showSuccessToast,
} from "@/components/common/toast/toast"

const formSchema = z.object({
  FullName: z.string().min(1, "Vui lòng nhập tên"),
  Email: z.string().email("Email không hợp lệ"),
  Password: z.string(),
  Phone: z
    .string()
    .regex(/^\d{10}$/, "Số điện thoại phải gồm đúng 10 chữ số"),
  Role: z.union([z.literal(2), z.literal(3)]),
  Gender: z.enum(["F", "M"]),
});



const AddUser = () => {
  const router = useRouter()
  const { addUser, loading } = useAddUser()

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      FullName: "",
      Password: "",
      Email: "",
      Phone: "",
      Role: 2,
      Gender: "F"
    },
  })

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    console.log("data", values)
    await addUser({ data: values })
      .then(() => {
        showSuccessToast("Thêm hội viên thành công!")
        router.push("/admin/users")
      })
      .catch(() => {
        showErrorToast("Thêm hội viên thất bại!")
      })
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="w-full max-w-xl mx-auto py-8 space-y-5"
      >
        <h2 className="text-2xl font-bold mb-2">Thêm hội viên</h2>

        <FormField
          control={form.control}
          name="FullName"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Họ và tên</FormLabel>
              <FormControl>
                <Input placeholder="Nhập họ và tên" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="Email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input placeholder="Nhập email" type="email" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="Phone"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Số điện thoại</FormLabel>
              <FormControl>
                <Input placeholder="Nhập số điện thoại" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="Password"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Mật khẩu</FormLabel>
              <FormControl>
                <Input placeholder="Nhập mật khẩu" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="Role"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Vai trò</FormLabel>
              <FormControl>
                <Select
                  value={String(field.value)}
                  onValueChange={(value) => field.onChange(Number(value))}
                >

                  <SelectTrigger>
                    <SelectValue placeholder="Chọn vai trò" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="2">Teacher</SelectItem>
                    <SelectItem value="3">Học sinh</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="Gender"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Vai trò</FormLabel>
              <FormControl>
                <Select
                  value={field.value}
                  onValueChange={(value) => {
                    console.log("onValueChange:", value);
                    field.onChange(value);
                  }}
                >

                  <SelectTrigger>
                    <SelectValue placeholder="Chọn giới tính" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="M">Nam </SelectItem>
                    <SelectItem value="F">Nữ </SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        {/* Nếu muốn thêm AvatarUrl input (optional), có thể thêm form field ở đây */}

        <div className="flex gap-3 justify-end pt-2">
          <Button
            type="submit"
            disabled={form.formState.isSubmitting || loading}
          >
            {form.formState.isSubmitting || loading
              ? "Đang lưu..."
              : "Thêm hội viên"}
          </Button>
          <Button
            type="button"
            variant="outline"
            onClick={() => router.push("/admin/users")}
          >
            Quay lại
          </Button>
        </div>
      </form>
    </Form>
  )
}
export default AddUser