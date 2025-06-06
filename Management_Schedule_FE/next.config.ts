import type { NextConfig } from "next"

const nextConfig: NextConfig = {
  /* config options here */
  reactStrictMode: true,
  images: {
    domains: [
      "pub-49dfec2518574e5582b9c93461dd9c79.r2.dev", // 👈 thêm domain ở đây
    ],
  },
}

export default nextConfig
