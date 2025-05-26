'use client'

import { useRouter } from 'next/router'
import { useForm } from 'react-hook-form'
import { z } from 'zod'
import { zodResolver } from '@hookform/resolvers/zod'
import { Button } from '@/components/ui/button'
import { Input } from '@/components/ui/input'
import {
  Select,
  SelectTrigger,
  SelectContent,
  SelectItem,
  SelectValue,
} from '@/components/ui/select'
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormControl,
  FormMessage,
} from '@/components/ui/form'
import {
  showSuccessToast,
  showErrorToast,
} from '@/components/common/toast/toast'

const courseSchema = z.object({
  name: z.string().min(1, 'Vui lòng nhập tên khóa học'),
  price: z
    .string()
    .min(1, 'Vui lòng nhập giá')
    .refine((val) => !isNaN(Number(val)), 'Giá không hợp lệ'),
  image: z.string().min(1, 'Vui lòng chọn ảnh'),
  code: z.string().min(1, 'Vui lòng nhập mã tài'),
  discount: z.string().default('0'),
  type: z.enum(['normal', 'pro']),
})

export default function AddCourse() {
  const router = useRouter()

  const form = useForm({
    resolver: zodResolver(courseSchema),
    defaultValues: {
      name: '',
      price: '',
      image: '',
      code: '',
      discount: '0',
      type: 'normal',
    },
  })

  const onSubmit = async (values: z.infer<typeof courseSchema>) => {
    try {
      // Bạn nên thay bằng API thực sự tại đây
    //   await addCourse(values)
      showSuccessToast('Thêm khóa học thành công!')
      router.push('/admin/manage-course')
    } catch (error) {
      showErrorToast(`Thêm khóa học thất bại!,${error}`)
    }
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="w-full max-w-xl mx-auto py-8 space-y-5"
      >
        <h2 className="text-2xl font-bold mb-2">Thêm Khóa học</h2>

        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Tên khóa học</FormLabel>
              <FormControl>
                <Input placeholder="Nhập tên khóa học" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="price"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Giá</FormLabel>
              <FormControl>
                <Input type="number" placeholder="Nhập giá" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="image"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Ảnh</FormLabel>
              <FormControl>
                <Input placeholder="URL ảnh hoặc tên file" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="discount"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Giảm giá</FormLabel>
              <FormControl>
                <Input placeholder="Nhập phần trăm giảm giá" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="code"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Mã tài</FormLabel>
              <FormControl>
                <Input placeholder="Nhập mã tài" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <FormField
          control={form.control}
          name="type"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Loại</FormLabel>
              <FormControl>
                <Select value={field.value} onValueChange={field.onChange}>
                  <SelectTrigger>
                    <SelectValue placeholder="Chọn loại" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="normal">Bình thường</SelectItem>
                    <SelectItem value="pro">Pro</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        <div className="flex justify-end gap-3 pt-4">
          <Button type="submit">Thêm khóa học</Button>
          <Button variant="outline" type="button" onClick={() => router.push('/admin/manage-course')}>
            Quay lại
          </Button>
        </div>
      </form>
    </Form>
  )
}
