import { cn } from "@/lib/utils";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { Input } from "@/components/ui/input";
import { useLogin } from "@/hooks/api/auth/use-login";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Constants } from "@/lib/constants";
import { useRouter } from "next/router";
import { showErrorToast } from "@/components/common/toast/toast";
import { PasswordInput } from "@/components/ui/password-input";
import { Loader2 } from "lucide-react";
import { useSetAtom } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";
import Link from "next/link";

import { jwtDecode } from "jwt-decode";

const formSchema = z.object({
  email: z.string().email("Email không hợp lệ"),
  password: z.string().min(6, "Mật khẩu phải có ít nhất 6 ký tự"),
});
export interface JwtUser {
  nameid: string;
  unique_name?: string;
  email: string;
  fullName: string;
  gender: "M" | "F";
  phone: string;
  role: string;
  [key: string]: any;  // cho phép thêm các trường khác
}

export function LoginForm({
  className,
  ...props
}: React.ComponentProps<"div">) {
  const { login } = useLogin();
  const router = useRouter();
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
  });

  const setUserAtom = useSetAtom(userInfoAtom);

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      const response = await login(values.email, values.password);
      console.log("response", response);
      if (response.status === 'success') {
        const token = response.data;
        console.log("token", token);
        localStorage.setItem(Constants.API_TOKEN_KEY, token);

        // Decode token để lấy thông tin user (payload)
        const user = jwtDecode<JwtUser>(token);
        console.log("Decoded user:", user);
        setUserAtom(user);
        if (user.role === "Admin") {
          router.push("/admin/dashboards");
        } else {
          router.push("/")
        }
        // Lưu thông tin user vào atom (localStorage



      } else {
        showErrorToast(response.message || "Đăng nhập thất bại");
      }
    } catch (error: any) {
      showErrorToast(
        error?.response?.data?.message ||
        error?.message ||
        "Có lỗi xảy ra, vui lòng thử lại sau",
      );
    }
  };

  return (
    <div className={cn("flex flex-col gap-6", className)} {...props}>
      <Card>
        <CardHeader>
          <CardTitle>Đăng nhập tài khoản</CardTitle>
          <CardDescription>Nhập email của bạn để đăng nhập</CardDescription>
        </CardHeader>
        <CardContent>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)}>
              <div className="flex flex-col gap-6">
                <div className="grid gap-3">
                  <FormField
                    control={form.control}
                    name="email"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Địa chỉ email</FormLabel>
                        <FormControl>
                          <Input
                            placeholder="Nhập địa chỉ email của bạn"
                            type="email"
                            {...field}
                          />
                        </FormControl>

                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <div className="grid gap-3">
                  <FormField
                    control={form.control}
                    name="password"
                    render={({ field }) => (
                      <FormItem>
                        <FormLabel>Mật khẩu</FormLabel>
                        <FormControl>
                          <PasswordInput
                            placeholder="Nhập mật khẩu của bạn"
                            {...field}
                          />
                        </FormControl>

                        <FormMessage />
                      </FormItem>
                    )}
                  />
                </div>
                <div className="flex flex-col gap-3">
                  <Button
                    type="submit"
                    className="w-full cursor-pointer"
                    disabled={form.formState.isSubmitting}
                  >
                    {form.formState.isSubmitting ? (
                      <Loader2 className="animate-spin" />
                    ) : null}
                    Đăng nhập
                  </Button>
                </div>
              </div>
              <div className="mt-4 text-center text-sm">
                Bạn chưa có tài khoản?{" "}
                <Link href="/register" className="underline underline-offset-4">
                  Đăng ký ngay
                </Link>
              </div>
              <div className="mt-4 text-center text-sm">
                Hay bạn quên mật khẩu ?{" "}
                <Link href="user/forget-password" className="">
                  Lấy lại mật khẩu
                </Link>
              </div>
            </form>
          </Form>
        </CardContent>
      </Card>
    </div>
  );
}
