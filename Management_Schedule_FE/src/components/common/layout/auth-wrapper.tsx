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
const fakeUser = {
  name: "Demo User",
  role: "admin",
}
const AuthWrapper = ({ children }: AuthWrapperProps) => {
  const router = useRouter();
  const userData = fakeUser;
  const noLayoutRoutes = ["/login", "/register"];
  const isNoLayoutPage = noLayoutRoutes.includes(router.pathname);

  if (isNoLayoutPage) {
    return <>{children}</>;
  }

  // const userData = useAtomValue(userInfoAtom);
  // useEffect(() => {
  //   const token = localStorage.getItem(Constants.API_TOKEN_KEY);
  //   const isLoginPage = router.pathname === "/login";
  //   const isRegisterPage = router.pathname === "/register";
  //   if (!token) {
  //     if (!isLoginPage && !isRegisterPage) {
  //       router.replace("/login");
  //     }
  //     return;
  //   }

  //   try {
  //     const { exp } = jwtDecode<{ exp: number }>(token);
  //     if (Date.now() >= exp * 1000) {
  //       localStorage.removeItem(Constants.API_TOKEN_KEY);
  //       if (!isLoginPage && !isRegisterPage) {
  //         router.replace("/login");
  //       }
  //     } else {
  //       if (isLoginPage || isRegisterPage) {
  //         router.replace("/dashboard");
  //       }
  //     }
  //   } catch {
  //     logout();
  //   }
  // }, [router.pathname]);

  return (
    <>
      {userData.role ? (
        <>
          <AppShell>{children}</AppShell>
        </>
      ) : (
        <>
          <LayoutGuest >{children}</LayoutGuest>
        </>
      )}
    </>
  );
};

export default AuthWrapper;
