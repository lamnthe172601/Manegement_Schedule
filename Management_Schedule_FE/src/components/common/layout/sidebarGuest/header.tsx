import Link from "next/link";
import Image from "next/image";
import { usePathname } from "next/navigation";
import { ShoppingCart, User } from "lucide-react";
import { Button } from "@/components/ui/button";

export default function Header() {
  const pathname = usePathname();

  const navItems = [
    { href: "/", label: "TRANG CHỦ" },
    { href: "/guest/team-page", label: "ĐỘI NGŨ ĐÀO TẠO" },
    { href: "/guest/khoa-hoc", label: "KHÓA HỌC" },
    { href: "/guest/student", label: "Học viên" },
  ];

  return (
    <div>
      <header className="bg-white border-b fixed top-0 left-0 right-0 z-50">
        <div className="container mx-auto px-4 py-2">
          <div className="flex items-center justify-between">
            <Link href="/" className="mr-8">
              <Image src="/lms_logo.png" alt="Sidebar Logo" width={100} height={100} />
            </Link>
            <nav className="hidden md:flex space-x-9 ml-6">
              {navItems.map((item) => {
                const isActive = pathname===(item.href);
                return (
                  <Link
                    key={item.href}
                    href={item.href}
                    className={`text-sm font-bold hover:text-blue-500 ${isActive ? "text-blue-500" : "text-gray-700"
                      }`}
                  >
                    {item.label}
                  </Link>
                );
              })}
            </nav>
            <div className="flex items-center space-x-4">
              <button aria-label="User Profile" className="text-gray-500 hover:text-gray-700">
                <User size={20} />
              </button>
              <button aria-label="Shopping Cart" className="text-gray-500 hover:text-gray-700">
                <ShoppingCart size={20} />
              </button>
            </div>
          </div>
        </div>
      </header>
      <section className="relative bg-gradient-to-r from-blue-600 to-blue-400 text-white">
        <div className="absolute inset-0 overflow-hidden">
          <div className="absolute inset-0 bg-blue-500 opacity-90"></div>
          <div className="absolute inset-0 bg-[url('/pattern.svg')] bg-repeat opacity-10"></div>
        </div>
        <div className="container mx-auto px-4 py-16 md:py-24 relative z-10">
          <div className="flex flex-col md:flex-row items-center">
            <div className="md:w-1/2 mb-10 md:mb-0 md:pr-10">
              <h1 className="text-3xl md:text-4xl lg:text-5xl font-bold mb-6 leading-tight">
                ENGLISH LEARNING SYSTEM
              </h1>
              <p className="text-lg md:text-xl mb-8 opacity-90">
                Hệ thống học tiếng Anh giao tiếp toàn diện cho người bắt đầu. Phương pháp học hiệu quả, nội dung chất
                lượng, giảng viên chuyên nghiệp.
              </p>
              <div className="flex flex-col sm:flex-row gap-4">
                <Button size="lg" className="bg-white font-bold text-blue-600 hover:bg-gray-100">
                  Bắt đầu học ngay
                </Button>
                <Button size="lg" variant="outline" className="border-white  font-bold text-blue-600 hover:bg-white/10">
                  Tìm hiểu thêm
                </Button>
              </div>
            </div>
            <div className="md:w-1/2 flex justify-center">
              <div className="relative w-full max-w-md h-[300px] md:h-[400px]">
                <Image src="/anh1.webp" alt="Landmaster Learning"
                  fill className="object-contain" priority />
              </div>
            </div>
          </div>
        </div>
        <div
          className="absolute bottom-0 left-0 right-0 h-16 bg-white"
          style={{ clipPath: "polygon(0 100%, 100% 100%, 100% 0)" }}
        ></div>
      </section>
    </div>

  );
}
