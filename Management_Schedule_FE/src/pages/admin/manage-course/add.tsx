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
import { useAddCourse } from '@/hooks/api/course/use-add-course'

const courseSchema = z.object({
  courseName: z.string().min(1, 'Vui lòng nhập tên khóa học'),
  description: z.string(),
  price: z.string().min(1, 'Vui lòng nhập giá').refine(val => !isNaN(Number(val)), 'Giá không hợp lệ'),
  thumbnailUrl: z.string().min(1, 'Vui lòng chọn ảnh'),
  isSelling: z.boolean(),
  isComingSoon: z.boolean(),
  isPro: z.boolean(),
  isCompletable: z.boolean(),
  discountPercent: z.string().min(1, "Vui lòng nhập giảm giá").refine(val => !isNaN(Number(val)), "Giảm giá không hợp lệ"),
  duration: z.string().min(1, "Vui lòng nhập thời lượng").refine(val => !isNaN(Number(val)), "Thời lượng không hợp lệ"),
  level: z.string().min(1, "Vui lòng nhập level").refine(val => !isNaN(Number(val)), "Level không hợp lệ"),
})

export default function AddCourse() {
  const router = useRouter()
  const { addCourse } = useAddCourse();
  const form = useForm({
    resolver: zodResolver(courseSchema),
    defaultValues: {
      courseName: '',
      description: '',
      price: '',
      thumbnailUrl: '',
      isSelling: false,
      isComingSoon: false,
      isPro: false,
      isCompletable: false,
      discountPercent: '0',
      duration: '0',
      level: '1',
    },
  })

  const onSubmit = async (values: z.infer<typeof courseSchema>) => {
    const transformedData = {
      ...values,
      price: parseFloat(values.price),
      discountPercent: parseInt(values.discountPercent),
      duration: parseInt(values.duration),
      level: parseInt(values.level),
    }
    console.log("Giá trị form submit:", transformedData)
    try {
      await addCourse({ data: transformedData })
      showSuccessToast('Thêm khóa học thành công!')
      router.push('/admin/manage-course')
    } catch (error) {
      showErrorToast(`Thêm khóa học thất bại!, ${error}`)
    }
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="w-full max-w-xl mx-auto py-8 space-y-5"
      >
        <h2 className="text-2xl font-bold mb-2">Thêm Khóa học</h2>

        {/* Tên khóa học */}
        <FormField
          control={form.control}
          name="courseName"
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

        {/* Mô tả */}
        <FormField
          control={form.control}
          name="description"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Mô tả</FormLabel>
              <FormControl>
                <Input placeholder="Nhập mô tả" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Giá */}
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

        {/* Ảnh */}
        <FormField
          control={form.control}
          name="thumbnailUrl"
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

        {/* Trạng thái Selling */}
        <FormField
          control={form.control}
          name="isSelling"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Selling</FormLabel>
              <FormControl>
                <Select
                  value={field.value ? 'true' : 'false'}
                  onValueChange={(val) => field.onChange(val === 'true')}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Chọn trạng thái" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="true">Có</SelectItem>
                    <SelectItem value="false">Không</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Trạng thái Coming Soon */}
        <FormField
          control={form.control}
          name="isComingSoon"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Coming Soon</FormLabel>
              <FormControl>
                <Select
                  value={field.value ? 'true' : 'false'}
                  onValueChange={(val) => field.onChange(val === 'true')}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Chọn trạng thái" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="true">Có</SelectItem>
                    <SelectItem value="false">Không</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Trạng thái Pro */}
        <FormField
          control={form.control}
          name="isPro"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Pro</FormLabel>
              <FormControl>
                <Select
                  value={field.value ? 'true' : 'false'}
                  onValueChange={(val) => field.onChange(val === 'true')}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Chọn trạng thái" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="true">Có</SelectItem>
                    <SelectItem value="false">Không</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Có thể hoàn thành */}
        <FormField
          control={form.control}
          name="isCompletable"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Có thể hoàn thành</FormLabel>
              <FormControl>
                <Select
                  value={field.value ? 'true' : 'false'}
                  onValueChange={(val) => field.onChange(val === 'true')}
                >
                  <SelectTrigger>
                    <SelectValue placeholder="Chọn trạng thái" />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value="true">Có</SelectItem>
                    <SelectItem value="false">Không</SelectItem>
                  </SelectContent>
                </Select>
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Giảm giá */}
        <FormField
          control={form.control}
          name="discountPercent"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Giảm giá (%)</FormLabel>
              <FormControl>
                <Input type="number" placeholder="Nhập phần trăm giảm giá" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Thời lượng */}
        <FormField
          control={form.control}
          name="duration"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Thời lượng (giờ)</FormLabel>
              <FormControl>
                <Input type="number" placeholder="Nhập thời lượng" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Level */}
        <FormField
          control={form.control}
          name="level"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Level</FormLabel>
              <FormControl>
                <Input type="number" placeholder="Nhập level" {...field} />
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
