import * as React from "react";
import {
  AudioWaveform,
  Bot,
  Command,
  Frame,
  GalleryVerticalEnd,
  Map,
  PieChart,
  SquareTerminal,
  BookOpen,
  CalendarCheck2,
  CalendarClock,
  DollarSign
} from "lucide-react";

import { NavMain } from "@/components/common/layout/sidebar/nav-main";
import { NavUser } from "@/components/common/layout/sidebar/nav-user";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarRail,
} from "@/components/ui/sidebar";
import Image from "next/image";
import { useAtomValue } from "jotai/react";
import { userInfoAtom } from "@/stores/auth";

const data = {
  teams: [
    {
      name: "Acme Inc",
      logo: GalleryVerticalEnd,
      plan: "Enterprise",
    },
    {
      name: "Acme Corp.",
      logo: AudioWaveform,
      plan: "Startup",
    },
    {
      name: "Evil Corp.",
      logo: Command,
      plan: "Free",
    },
  ],

  navMain: [
    {
      name: "Dashboard",
      url: "/admin/dashboards",
      icon: SquareTerminal,
      title: "Dashboard",
      role: ["admin", "staff", "member"],
    },
    {
      name: "Users",
      url: "/admin/users",
      icon: Bot,
      title: "Quản lý người dùng",
      role: ["admin"],
    },
    {
      name: "Teachers",
      url: "/admin/teachers",
      icon: Bot,
      title: "Quản lý giáo viên",
      role: ["admin"],
    },
    {
      name: "Students",
      url: "/admin/students",
      icon: Bot,
      title: "Quản lý học sinh",
      role: ["admin"],
    },
    {
      name: "Courses",
      url: "/admin/manage-course",
      icon: BookOpen,
      title: "Quản Lý Khóa Học",
      role: ["admin", "staff", "member"],
    },
    {
      name: "Teaching Schedule",
      url: "/admin/teaching-schedule",
      icon: CalendarCheck2,
      title: "Quản lý lịch giảng dạy",
      role: ["admin", "staff", "member"],
    },
    {
      name: "Learning Schedule",
      url: "/admin/learning-schedule",
      icon: CalendarClock,
      title: "Quản lý lịch học",
      role: ["admin", "staff", "member"],
    },
    {
      name: "Fees & Salary",
      url: "/finance",
      icon: DollarSign,
      title: "Quản lý học phí, tiền lương",
      role: ["admin", "staff", "member"],
    },
  ],

  projects: [
    {
      name: "Design Engineering",
      url: "#",
      icon: Frame,
    },
    {
      name: "Sales & Marketing",
      url: "#",
      icon: PieChart,
    },
    {
      name: "Travel",
      url: "#",
      icon: Map,
    },
  ],
};

export function AppSidebar({ ...props }: React.ComponentProps<typeof Sidebar>) {
  const userData = useAtomValue(userInfoAtom);
  const user = {
    name: userData?.full_name || "Nguyễn Văn A",
    email: userData?.email || "default@example.com",
    avatar: "https://picsum.photos/200",
  };

  return (
    <Sidebar collapsible="icon" {...props}>
      <SidebarHeader>
        <Image
          src="/lms_logo.png"
          alt="Sidebar Logo"
          width={200}
          height={200}
        />
      </SidebarHeader>
      <SidebarContent>
        <NavMain items={data.navMain} />
      </SidebarContent>
      <SidebarFooter>
        <NavUser user={user} />
      </SidebarFooter>
      <SidebarRail />
    </Sidebar>
  );
}