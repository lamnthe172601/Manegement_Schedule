import AuthWrapper from "@/components/common/layout/auth-wrapper"
import PageMetadata from "@/components/common/seo/page-metadata"
import { Toaster } from "@/components/ui/sonner"
import "@/styles/globals.css"
import { ThemeProvider } from "next-themes"
import type { AppProps } from "next/app"

export default function App({ Component, pageProps }: AppProps) {
  return (
    <>
      <ThemeProvider attribute="class" defaultTheme="system" enableSystem>
        <PageMetadata title={"Library Management System"} description={"Nope"} />
        <AuthWrapper>
          <Toaster />
          <Component {...pageProps} />
        </AuthWrapper>
      </ThemeProvider>
    </>
  )
}
