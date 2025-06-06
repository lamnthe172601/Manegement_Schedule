import StudentLayout from "@/components/features/guest/StudentLayout"
import {
  Table,
  TableRow,
  TableCell,
  TableHeader,
  TableHead,
  TableBody,
} from "@/components/ui/table"
import { Schedule } from "@/hooks/api/schedule/use-get-schedules";
import { Endpoints } from "@/lib/endpoints";
import { userInfoAtom } from "@/stores/auth";
import axios from "axios";
import { useAtom } from "jotai/react";
import { useEffect, useState } from "react"
import useSWR from "swr";
function Page() {
  const[schedules,setSchedules] = useState<Schedule[]>([]);
   const [user] = useAtom(userInfoAtom);
   const studentId: string | undefined = user?.nameid;
   const fetcher =  async (url:string):Promise<Schedule[]> => {
        const response = await axios.get(url);
        return response.data.data;
   }
  const {data, error, isLoading} = useSWR(
    studentId ? `${Endpoints.baseApiURL.URL}/${Endpoints.Schedule.GET_SCHEDULE_BY_STUDENT_ID(studentId)}` : null,fetcher
  )

  useEffect(()=>{
    if(data){
      setSchedules(data);
    }
  },[data])
  return (
    <StudentLayout>
      <div>
        <h1 className="font-extrabold text-3xl">Lịch học</h1>
        <Table className="mx-auto w-250 border-l-1 border-l-transparent hover:border-l-gray-50 transition-colors duration-300">
          <TableHeader className="bg-[#3B9643]">
            <TableRow className="h-[60px]">
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Tên lớp
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Lịch học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Phòng học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Giờ học
              </TableHead>
              <TableHead className="text-white text-center font-extrabold border border-gray-50">
                Giảng viên
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody className="bg-[#AACEBF]">
            {schedules &&  Array.isArray(schedules) && schedules.map((s)=>(
              <TableRow key={s.scheduleID} className="h-[60px]">
                <TableCell className="text-black text-center border border-gray-50">{s.className}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.startTime}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.room}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.startTime}</TableCell>
                <TableCell className="text-black text-center border border-gray-50">{s.teacherName}</TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </div>
    </StudentLayout>
  )
}

export default Page
