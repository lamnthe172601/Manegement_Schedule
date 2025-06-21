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
import { useState } from 'react'

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
  const [previewUrl, setPreviewUrl] = useState<string | null>(null)
  const [thumbnailFile, setThumbnailFile] = useState<File | null>(null);

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
      duration: '1',
      level: '1',
    },
  })

  const onSubmit = async (values: z.infer<typeof courseSchema>) => {
    try {
      const formData = new FormData();

      formData.append("CourseName", values.courseName);
      formData.append("Description", values.description);
      formData.append("Price", values.price);
      formData.append("IsSelling", values.isSelling.toString());
      formData.append("IsComingSoon", values.isComingSoon.toString());
      formData.append("IsPro", values.isPro.toString());
      formData.append("IsCompletable", values.isCompletable.toString());
      formData.append("DiscountPercent", values.discountPercent);
      formData.append("Duration", values.duration);
      formData.append("Level", values.level);


      if (thumbnailFile) {
        formData.append("ThumbnailFile", thumbnailFile); // 👈 Đây là file thực tế
      }

      console.log("FormData contents:");
      for (const [key, value] of formData.entries()) {
        console.log(`${key}:`, value);
      }
      await addCourse(formData);

      showSuccessToast("Thêm khóa học thành công!");
      router.push("/admin/manage-course");
    } catch (error: any) {
      const detailError =
        error?.response?.data?.errors?.detail || error?.response?.data?.message || '❌ Cập nhật giáo viên thất bại!';
      showErrorToast(detailError);
    }
  };


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
        <div>
          <label className="block text-sm font-medium text-gray-700 mb-2">Thumbnail</label>
          {previewUrl && (
            <img
              src={previewUrl}
              alt="Thumbnail preview"
              className="w-32 h-48 object-cover rounded mb-2"
            />
          )}
          <Input
            type="file"
            accept="image/*"
            onChange={(e) => {
              const file = e.target.files?.[0];
              if (file) {
                const objectUrl = URL.createObjectURL(file);
                setPreviewUrl(objectUrl);
                setThumbnailFile(file);
                form.setValue("thumbnailUrl", file.name); // ✅ Đánh dấu trường thumbnailUrl đã có giá trị
              }
            }}
          />


          <FormMessage>{form.formState.errors.thumbnailUrl?.message}</FormMessage>
        </div>



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
    </Form >
  )
}
