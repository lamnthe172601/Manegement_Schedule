'use client';

import {
    showErrorToast,
    showSuccessToast,
} from '@/components/common/toast/toast';
import {
    Card,
    CardContent,
    CardDescription,
    CardHeader,
    CardTitle,
} from '@/components/ui/card';
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';
import { z } from 'zod';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'next/navigation'; // ✅ correct for App Router
import React from 'react';
import axios from 'axios';
import { Endpoints } from '@/lib/endpoints';

const formSchema = z
    .object({
        password: z.string().min(6, {
            message: 'Password must be at least 6 characters.',
        }),
        confirmpassword: z.string().min(6, {
            message: 'Confirm password must be at least 6 characters.',
        }),
    })
    .refine((data) => data.password === data.confirmpassword, {
        message: 'Passwords do not match.',
        path: ['confirmpassword'],
    });

export default function ResetPassword() {
    const router = useRouter();
    const form = useForm<z.infer<typeof formSchema>>({
        resolver: zodResolver(formSchema),
        defaultValues: {
            password: '',
            confirmpassword: '',
        },
    });

    async function onSubmit(values: z.infer<typeof formSchema>) {
        try {
            console.log(values);
            // Example POST request
            // const response = await axios.post(`${Endpoints.Users.RESET_PASSWORD}`, values);
            showSuccessToast('Password reset successfully!');
            router.push('/login'); // or wherever you want to go
        } catch (error: any) {
            showErrorToast(
                error?.response?.data?.message ||
                error?.message ||
                "Có lỗi xảy ra, vui lòng thử lại sau",
            );
        }
    }

    return (
        <div className="flex items-center justify-center h-screen bg-gray-100">
            <Card className="w-full max-w-sm">
                <CardHeader>
                    <CardTitle>Reset password</CardTitle>
                    <CardDescription>Vui lòng nhập mật khẩu mới của bạn</CardDescription>
                </CardHeader>
                <CardContent>
                    <Form {...form}>
                        <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-4">
                            <FormField
                                control={form.control}
                                name="password"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Password</FormLabel>
                                        <FormControl>
                                            <Input
                                                type="password"
                                                placeholder="New password"
                                                {...field}
                                            />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <FormField
                                control={form.control}
                                name="confirmpassword"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Confirm Password</FormLabel>
                                        <FormControl>
                                            <Input
                                                type="password"
                                                placeholder="Nhập lại mật khẩu"
                                                {...field}
                                            />
                                        </FormControl>
                                        <FormMessage />
                                    </FormItem>
                                )}
                            />
                            <button
                                type="submit"
                                className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
                            >
                                Đặt lại mật khẩu
                            </button>
                        </form>
                    </Form>
                </CardContent>
            </Card>
        </div>
    );
}
