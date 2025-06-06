import AuthWrapper from "@/components/common/layout/auth-wrapper"
import PageMetadata from "@/components/common/seo/page-metadata"
import { Toaster } from "@/components/ui/sonner"
import "@/styles/globals.css"
import { ThemeProvider } from "next-themes"
import type { AppProps } from "next/app"
import { GoogleOAuthProvider } from "@react-oauth/google"

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <ThemeProvider attribute="class" defaultTheme="system" enableSystem>
        <PageMetadata title={"Library Management System"} description={"Nope"} />
        <GoogleOAuthProvider clientId="937922958244-4r5cnqjiao6h79otlts9jmmhijc3qk6a.apps.googleusercontent.com">
        <AuthWrapper>
          <Toaster />
          <Component {...pageProps} />
        </AuthWrapper>
        </GoogleOAuthProvider>
      </ThemeProvider>
    </>
  )
}
