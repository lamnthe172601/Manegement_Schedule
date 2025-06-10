import { cn } from "@/lib/utils"
import { Button } from "@/components/ui/button"
import { GoogleLogin } from "@react-oauth/google"
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card"
import { Input } from "@/components/ui/input"
import { useLogin } from "@/hooks/api/auth/use-login"
import { useLoginGoogle } from "@/hooks/api/auth/use-login-google"
import { z } from "zod"
import { zodResolver } from "@hookform/resolvers/zod"
import { useForm } from "react-hook-form"
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form"
import { Constants } from "@/lib/constants"
import { useRouter } from "next/router"
import { showErrorToast } from "@/components/common/toast/toast"
import { PasswordInput } from "@/components/ui/password-input"
import { Loader2 } from "lucide-react"
import { useSetAtom } from "jotai/react"
import { userInfoAtom } from "@/stores/auth"
import Link from "next/link"
import { JwtUser } from "@/hooks/api/user/use-get-users"
import { jwtDecode } from "jwt-decode"

const formSchema = z.object({
  email: z.string().email("Email không hợp lệ"),
  password: z.string().min(6, "Mật khẩu phải có ít nhất 6 ký tự"),
})

export function LoginForm({
  className,
  ...props
}: React.ComponentProps<"div">) {
  const { login } = useLogin()
  const { loginGoogle } = useLoginGoogle()
  const router = useRouter()
  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
  })

  const setUserAtom = useSetAtom(userInfoAtom)

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      const response = await login(values.email, values.password)
      console.log("response", response)

      const token = response?.data

      // Kiểm tra token hợp lệ (phải là chuỗi JWT)
      if (typeof token === "string" && token.length > 0) {
        localStorage.setItem(Constants.API_TOKEN_KEY, token)

        const user = jwtDecode<JwtUser>(token)
        setUserAtom(user)

        if (user.role === "Admin") {
          router.push("/admin/dashboards")
        } else {
          router.push("/")
        }
      } else {
        const message =
          typeof response?.data?.message === "string"
            ? response.data.message
            : response?.message || "Đăng nhập thất bại"
        showErrorToast(message)
      }
    } catch (error: any) {
      const errorMessage =
        error?.response?.data?.message ||
        error?.message ||
        "Có lỗi xảy ra, vui lòng thử lại sau"
      showErrorToast(errorMessage)
    }
  }


  const handleLoginGoogle = async (credentialReponse: any) => {
    try {
      debugger
      const credential = credentialReponse.credential

      if (!credential) {
        showErrorToast("Không thể xác thực tài khoản Googlge của bạn")
      }

      const response = await loginGoogle(credential)
      const token = response.data
      if (!token || typeof token !== "string") {
        showErrorToast("Token không hợp lệ")
      }
      console.log("token login with google", token)
      localStorage.setItem(Constants.API_TOKEN_KEY, token)

      //lấy ra role của user
      const user = jwtDecode<JwtUser>(token)
      console.log("Decoded user:", user)
      setUserAtom(user)

      router.push("/")
    } catch (error: any) {
      showErrorToast(
        error?.response?.data?.message ||
        error?.message ||
        "Có lỗi xảy ra, vui lòng thử lại sau",
      )
    }
  }

  return (
    <div className={cn("flex flex-col gap-6", className)} {...props}>
      <Card>
        <CardHeader>
          <div className="flex items-start justify-between">
            <Button variant="ghost" onClick={() => window.history.back()}>
              ← Quay lại
            </Button>
          </div>
          <CardTitle>Đăng nhập tài khoản</CardTitle>
          <CardDescription>Nhập email của bạn để đăng nhập</CardDescription>
        </CardHeader>
        <CardContent>
          <Form {...form}>
            <form onSubmit={form.handleSubmit(onSubmit)}>
              <div className="flex flex-col gap-3">
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
                <div className="flex flex-col gap-2">
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
                <GoogleLogin onSuccess={handleLoginGoogle} />
              </div>
              <div className="mt-4 text-center text-sm">
                Bạn chưa có tài khoản?{" "}
                <Link href="/register" className="underline underline-offset-4">
                  Đăng ký ngay
                </Link>
              </div>
              <div className="mt-4 text-center text-sm">
                Bạn quên mật khẩu sao ?{" "}
                <Link href="/user/forget-password" className="underline underline-offset-4">
                  Lấy lại ngay
                </Link>
              </div>
            </form>
          </Form>
        </CardContent>
      </Card>
    </div>
  )
}
