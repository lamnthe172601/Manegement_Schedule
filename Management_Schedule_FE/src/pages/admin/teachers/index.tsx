"use client"
import { Button } from "@/components/ui/button"
import React from "react"
import {
  Table,
  TableBody,
  TableHeader,
  TableRow,
  TableHead,
  TableCell,
} from "@/components/ui/table"
const TeacherPage = () => {
  const teachers = [
    {
      id:1,
      name: "Na",
      avartar: "",
      gender: "",
      address: "Hà Nội",
      email: "n@gmail.com",
      phone: "0359784111",
      birthday: "14/11/2003",
      salary: "s1",
      reward: "",
    },
    {
      id:2,
      name: "gv1",
      avartar: "",
      gender: "Nữ",
      address: "fpt hà nội",
      email: "s4@gmail.com",
      phone: "0335500390",
      birthday: "14/11/2003",
      salary: "s1",
      reward: "",
    },
    {
      id:3,
      name: "Gv33",
      avartar: "",
      gender: "Nữ",
      address: "Ninh Bình",
      email: "lampnt@fpt.edu.vn",
      phone: "0123456789",
      birthday: "14/11/2003",
      salary: "",
      reward: "",
    },
  ]
  return (
    <div className="overflow-hidden">
        <h2 className="text-center font-black text-2xl mb-4">Danh sách giáo viên</h2>
      <Button className="border-gray-200 border-1 bg-[#F9F9F9] text-black text-sm hover:bg-gray-100">Xuất Excel</Button>
      <Table className="w-full mt-2">
        <TableHeader className="bg-[#344E64]">
          <TableRow className="hover:bg-transparent ">
            <TableHead className="border border-gray-50 text-center">
              <input type="checkbox"></input>
            </TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Tên giáo viên</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Ảnh</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Giới tính</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Địa chỉ</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Email</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Số điện thoại</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Ngày sinh</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Lương</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50">Thưởng</TableHead>
            <TableHead className="text-white text-center font-extrabold border border-gray-50"></TableHead>
          </TableRow>
        </TableHeader>
        <TableBody className="bg-[#A9BBC0]">
          {teachers.map((t) => (
            <TableRow className="hover:bg-transparent" key={t.id}>
              <TableCell className="border border-gray-50 text-center">
                <input type="checkbox"></input>
              </TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.name}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.avartar}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.gender}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.address}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.email}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.phone}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.birthday}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.salary}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">{t.reward}</TableCell>
              <TableCell className="border border-gray-50 text-center font-medium">

              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  )
}

export default TeacherPage
