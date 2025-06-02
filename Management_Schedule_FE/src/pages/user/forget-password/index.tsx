'use client';

import React, { useState } from 'react';
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
import { Input } from '@/components/ui/input';
import {
    Form,
    FormControl,
    FormField,
    FormItem,
    FormLabel,
    FormMessage,
} from '@/components/ui/form';
import { z } from 'zod';
import { useForm } from 'react-hook-form';
import { zodResolver } from '@hookform/resolvers/zod';
import { useRouter } from 'next/navigation';
import { useForgetPassword } from '@/hooks/api/user/use-forgetpassword-user'; // nếu có hook này
import { Endpoints } from '@/lib/endpoints';
import { useResetPassword } from '@/hooks/api/user/use-reset-password';

const otpSchema = z.object({
    otp: z
        .string()
        .length(6, { message: 'OTP phải gồm đúng 6 kí tự .' }),
});

const passwordSchema = z
    .object({
        password: z.string().min(6, { message: 'Password phải ít nhất 6 ký tự.' }),
        confirmpassword: z
            .string()
            .min(6, { message: 'Confirm password phải ít nhất 6 ký tự.' }),
    })
    .refine((data) => data.password === data.confirmpassword, {
        message: 'Mật khẩu xác nhận không khớp.',
        path: ['confirmpassword'],
    });

export default function ResetPasswordFlow() {
    const router = useRouter();

    const [step, setStep] = useState<1 | 2 | 3>(1);
    const [email, setEmail] = useState('');
    const [otp, setOtp] = useState('');
    const { forgetPassword } = useForgetPassword();
    const { resetPassword } = useResetPassword()

    // --- Form for OTP ---
    const otpForm = useForm<z.infer<typeof otpSchema>>({
        resolver: zodResolver(otpSchema),
        defaultValues: { otp: '' },
    });

    // --- Form for New Password ---
    const passwordForm = useForm<z.infer<typeof passwordSchema>>({
        resolver: zodResolver(passwordSchema),
        defaultValues: { password: '', confirmpassword: '' },
    });

    // Step 1: Gửi email lấy mã OTP
    async function handleSendEmail(e: React.FormEvent) {
        e.preventDefault();
        try {
            const response = await forgetPassword(email);
            console.log("response handleSendEmail", response)
            setOtp(response.data.otp)
            showSuccessToast('Mã OTP đã được gửi đến email của bạn.');
            setStep(2);
        } catch (error: any) {
            showErrorToast(
                error?.response?.data?.message ||
                error?.message ||
                'Có lỗi xảy ra, vui lòng thử lại sau',
            );
        }
    }

    // Step 2: Xác nhận OTP
    async function handleVerifyOtp(values: z.infer<typeof otpSchema>) {
        try {

            console.log("values", values)
            console.log("otp: ", otp)

            if (otp == values.otp) {
                showSuccessToast('Mã OTP đã được xác thực.');
                setStep(3);
            } else {
                showErrorToast('Mã OTP không đúng. Vui lòng nhập lại.');
            }


        } catch (error: any) {
            showErrorToast(
                error?.response?.data?.message ||
                error?.message ||
                'Có lỗi xảy ra, vui lòng thử lại sau',
            );
        }
    }

    // Step 3: Đặt mật khẩu mới
    async function handleResetPassword(values: z.infer<typeof passwordSchema>) {
        console.log("values resetPassword", values)
        try {
            // Gọi API đặt lại mật khẩu, ví dụ:
            const response = await resetPassword({
                email,
                password: values.password,
                confirmPassword: values.confirmpassword
            });
            console.log("response resetPassword", response)

            showSuccessToast('Đặt lại mật khẩu thành công!');
            router.push('/login');
        } catch (error: any) {
            showErrorToast(
                error?.response?.data?.message ||
                error?.message ||
                'Có lỗi xảy ra, vui lòng thử lại sau',
            );
        }
    }

    return (
        <div className="flex items-center justify-center h-screen bg-gray-100">
            <Card className="w-full max-w-sm">
                {step === 1 && (
                    <>
                        <CardHeader>
                            <CardTitle>Reset Password</CardTitle>
                            <CardDescription>Nhập email để lấy lại mật khẩu</CardDescription>
                        </CardHeader>
                        <CardContent>
                            <form onSubmit={handleSendEmail} className="space-y-4">
                                <label htmlFor="email" className="block mb-2 font-semibold">
                                    Địa chỉ email
                                </label>
                                <input
                                    id="email"
                                    type="email"
                                    placeholder="Nhập địa chỉ email của bạn"
                                    value={email}
                                    onChange={(e) => setEmail(e.target.value)}
                                    className="w-full p-2 border border-gray-300 rounded"
                                    required
                                />
                                <button
                                    type="submit"
                                    className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
                                >
                                    Gửi
                                </button>
                            </form>
                        </CardContent>
                    </>
                )}

                {step === 2 && (
                    <>
                        <CardHeader className="text-center">
                            <CardTitle>Nhập OTP</CardTitle>
                            <CardDescription>Nhập mã OTP để đổi mật khẩu</CardDescription>
                        </CardHeader>
                        <CardContent>
                            <Form {...otpForm}>
                                <form
                                    onSubmit={otpForm.handleSubmit(handleVerifyOtp)}
                                    className="space-y-4"
                                >
                                    <FormField
                                        control={otpForm.control}
                                        name="otp"
                                        render={({ field }) => (
                                            <FormItem>
                                                <FormLabel>Nhập OTP</FormLabel>
                                                <FormControl>
                                                    <Input type="text" placeholder="Nhập 6 chữ số" {...field} />
                                                </FormControl>
                                                <FormMessage />
                                            </FormItem>
                                        )}
                                    />
                                    <button
                                        type="submit"
                                        className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
                                    >
                                        Xác nhận OTP
                                    </button>
                                </form>
                            </Form>
                        </CardContent>
                    </>
                )}

                {step === 3 && (
                    <>
                        <CardHeader>
                            <CardTitle>Đặt lại mật khẩu</CardTitle>
                            <CardDescription>Nhập mật khẩu mới</CardDescription>
                        </CardHeader>
                        <CardContent>
                            <Form {...passwordForm}>
                                <form
                                    onSubmit={passwordForm.handleSubmit(handleResetPassword)}
                                    className="space-y-4"
                                >
                                    <FormField
                                        control={passwordForm.control}
                                        name="password"
                                        render={({ field }) => (
                                            <FormItem>
                                                <FormLabel>Mật khẩu mới</FormLabel>
                                                <FormControl>
                                                    <Input
                                                        type="password"
                                                        placeholder="Nhập mật khẩu mới"
                                                        {...field}
                                                    />
                                                </FormControl>
                                                <FormMessage />
                                            </FormItem>
                                        )}
                                    />
                                    <FormField
                                        control={passwordForm.control}
                                        name="confirmpassword"
                                        render={({ field }) => (
                                            <FormItem>
                                                <FormLabel>Xác nhận mật khẩu</FormLabel>
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
                    </>
                )}
            </Card>
        </div>
    );
}
