import { useRouter } from "next/router";
import { useEffect, ReactNode, useState } from "react";
import { useAtomValue } from "jotai/react";
import AppShell from "@/components/common/layout/sidebar/dashboard";
import LayoutGuest from "./sidebarGuest/layoutGuest";
import { userInfoAtom } from "@/stores/auth";

interface AuthWrapperProps {
  children: ReactNode;
}

const AuthWrapper = ({ children }: AuthWrapperProps) => {
  const router = useRouter();
  const userData = useAtomValue(userInfoAtom);
  const role = userData?.role;

  const noLayoutRoutes = ["/login", "/register"];
  const isNoLayoutPage = noLayoutRoutes.includes(router.pathname);

  const [allowRender, setAllowRender] = useState(false);

  useEffect(() => {
    // Chưa đăng nhập mà không phải trang public -> redirect /login
    if (!role && !isNoLayoutPage) {
      router.replace("/login");
      return;
    }

    // Không phải admin mà vào admin -> redirect /
    if (role && role !== "admin" && router.pathname.startsWith("/admin")) {
      router.replace("/");
      return;
    }

    // Nếu là admin, và vào / hoặc /admin/* => redirect về /dashboard
    if (role === "admin" && ["/", "/admin", "/admin/dashboard"].includes(router.pathname)) {
      router.replace("/dashboard");
      return;
    }

    // Trường hợp hợp lệ -> cho render
    setAllowRender(true);
  }, [role, router.pathname, isNoLayoutPage, router]);

  // Nếu chưa cho phép render thì không render gì cả
  if (!allowRender && !isNoLayoutPage) return null;

  // Trang không có layout
  if (isNoLayoutPage) return <>{children}</>;

  // Trang có layout tùy theo role
  return role === "admin" ? (
    <AppShell>{children}</AppShell>
  ) : (
    <LayoutGuest>{children}</LayoutGuest>
  );
};

export default AuthWrapper;
