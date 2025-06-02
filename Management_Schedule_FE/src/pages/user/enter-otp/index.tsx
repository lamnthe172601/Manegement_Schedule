'use client';

import { showErrorToast, showSuccessToast } from "@/components/common/toast/toast";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { z } from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useRouter } from "next/router";
import React from "react";
import { Endpoints } from "@/lib/endpoints";
import axios from "axios";

// ✅ Zod schema kiểm tra OTP
const otpSchema = z.object({
    otp: z.string()
        .regex(/^\d{6}$/, {
            message: "OTP phải là số và phải gồm đúng 6 số.",
        }),
});

export default function EnterOTP() {
    const router = useRouter();

    const form = useForm<z.infer<typeof otpSchema>>({
        resolver: zodResolver(otpSchema),
        defaultValues: {
            otp: "",
        },
    });

    const handleSubmit = async (values: z.infer<typeof otpSchema>) => {
        console.log("Gửi otp lấy lại mật khẩu:", values.otp);
        try {
            // const response = await axios.post(`${Endpoints.Users.POST_OTP}`, {
            //   otp: values.otp,
            // });
            showSuccessToast("Mã OTP đã được xác thực.");
            setTimeout(() => {
                router.push("/user/reset-password");
            }, 1000);
        } catch (error: any) {
            showErrorToast(
                error?.response?.data?.message ||
                error?.message ||
                "Có lỗi xảy ra, vui lòng thử lại sau"
            );
        }
    };

    return (
        <div className="flex align-center justify-center items-center h-screen bg-gray-100">
            <Card className="w-full max-w-sm">
                <CardHeader className="text-center">
                    <CardTitle>OTP</CardTitle>
                    <CardDescription>Nhập OTP của bạn để đổi mật khẩu</CardDescription>
                </CardHeader>

                <CardContent>
                    <Form {...form}>
                        <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4">
                            <FormField
                                control={form.control}
                                name="otp"
                                render={({ field }) => (
                                    <FormItem>
                                        <FormLabel>Nhập OTP</FormLabel>
                                        <FormControl>
                                            <Input
                                                type="text"
                                                placeholder="Nhập 6 chữ số"
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
                                Verify OTP
                            </button>
                        </form>
                    </Form>
                </CardContent>
            </Card>
        </div>
    );
}
