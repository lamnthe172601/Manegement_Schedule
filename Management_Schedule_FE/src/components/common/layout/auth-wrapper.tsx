import { useRouter } from "next/router";
import { useEffect, ReactNode } from "react";
import { jwtDecode } from "jwt-decode";
import { Constants } from "@/lib/constants";
import AppShell from "@/components/common/layout/sidebar/dashboard";
import { useAtomValue } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";
import { logout } from "@/lib/utils";
import LayoutGuest from "./sidebarGuest/layoutGuest";

interface AuthWrapperProps {
  children: ReactNode;
}

const AuthWrapper = ({ children }: AuthWrapperProps) => {
  const router = useRouter();
  const userData = useAtomValue(userInfoAtom);

  // Danh sách route không cần login vẫn xem được
  const publicPages = [
    "/login",
    "/register",
    "/user/forget-password",
    "/user/enter-otp",
    "/user/reset-password",
    "/user/team-page",   // Thêm các trang public khác nếu cần
    "/user/khoa-hoc",
    "/user/student",
    "/",
  ];

  useEffect(() => {
    const token = localStorage.getItem(Constants.API_TOKEN_KEY);

    // Nếu chưa đăng nhập và truy cập trang không public thì redirect về trang chủ
    if (!token) {
      if (!publicPages.includes(router.pathname)) {
        router.replace("/");
      }
      return;
    }

    try {
      const { exp } = jwtDecode<{ exp: number }>(token);
      if (Date.now() >= exp * 1000) {
        localStorage.removeItem(Constants.API_TOKEN_KEY);
        if (!["/login", "/register"].includes(router.pathname)) {
          router.replace("/login");
        }
      } else {
        if (["/login", "/register"].includes(router.pathname)) {
          router.replace("/dashboard");
        }
      }
    } catch {
      logout();
    }
  }, [router.pathname]);

  return (
    <>
      {userData?.role === "Admin" ? (
        <>
          <AppShell>{children}</AppShell>
        </>
      ) : (
        <>
          <LayoutGuest>{children}</LayoutGuest>
        </>
      )}
    </>
  );
};

export default AuthWrapper;
