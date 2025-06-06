"use client"
import TeacherLayout from "@/components/features/guest/TeacherLayout"
import React from "react"
import { Button } from "@/components/ui/button"
import Image from "next/image"
import { useState } from "react"
import { Camera, UserRound } from "lucide-react"
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar"
function Page() {
  return (
    <TeacherLayout>
      <div className="h-100 w-full relative ">
        <Image
          src="/anhbia.jpg"
          alt="anh bia student"
          layout="fill"
          objectFit="cover"
          className="rounded-ee-3xl rounded-es-3xl relative"
        />
        <Avatar className="h-50 w-50 mr-4 rounded-full absolute top-60 left-10">
          <AvatarImage src="/teacher.jpg" alt="avatar" />
          <AvatarFallback>NA</AvatarFallback>
        </Avatar>
        <h1 className="absolute top-100 left-60 font-bold text-xl">
          Phạm Ngọc Tùng Lâm
        </h1>
        <Button className="absolute top-85 right-10 p-[20px]">
          <Camera size={20} /> Chỉnh sửa ảnh bìa
        </Button>
      </div>
      <div className="flex flex-row mt-[100px] mx-[20px]">
        <div className="flex-1 mr-[10px]">
          <div className="rounded-xl border-gray-200 border-[2] mb-[10px]">
            <h2 className="font-semibold p-2">Giới thiệu</h2>
            <h3 className="p-2 flex flex-row">
              <UserRound size={20} /> Thành viên của Wonderland từ NaN tháng
              trước
            </h3>
          </div>
          <div className="rounded-xl border-gray-200 border-[2]">
            <h2 className="font-semibold p-2">Hoạt động gần đây</h2>
            <h3 className="p-2 flex flex-row">Chưa có hoạt động gần đây</h3>
          </div>
        </div>
        <div className="flex-1 flex-1 rounded-xl border-gray-200 border-[2]">
          <h2 className="p-2 font-semibold">Các khóa học đã tham gia</h2>
          <div className="flex flex-row">
            <Image
              src="/anh1.webp"
              width={200}
              height={100}
              alt="khao hoc"
              className="p-2 rounded-2xl"
            />
            <div>
              <h2 className="font-semibold p-2">Kiến thức nhập môn IT</h2>
              <h3 className="p-2 flex flex-row">
                Để có cái nhìn tổng quan hơn về ngành IT - Lập trình web các bạn
                nên xem các videos tại khóa này trước nhé
              </h3>
            </div>
          </div>
        </div>
      </div>
    </TeacherLayout>
  )
}

export default Page
