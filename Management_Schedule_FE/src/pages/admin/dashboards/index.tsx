import React from "react";
import useSWR from "swr";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Tabs, TabsList, TabsTrigger, TabsContent } from "@/components/ui/tabs";
import { Skeleton } from "@/components/ui/skeleton";
import { Endpoints } from "@/lib/endpoints";
import { axiosFetcher } from "@/lib/utils";

const teacherId = "1"; // Thay bằng id thực tế hoặc lấy từ context
const classId = "1";   // Thay bằng id thực tế hoặc lấy từ context
const room = "A101";   // Thay bằng room thực tế hoặc lấy từ context

const Dashboard = () => {
  const { data: teacherReport, isLoading: loadingTeacher } = useSWR(
    [Endpoints.Report.Teacher, teacherId],
    ([url, id]) => axiosFetcher(`${url}/${id}`)
  );
  const { data: classReport, isLoading: loadingClass } = useSWR(
    [Endpoints.Report.Class, classId],
    ([url, id]) => axiosFetcher(`${url}/${id}`)
  );
  const { data: roomReport, isLoading: loadingRoom } = useSWR(
    [Endpoints.Report.Room, room],
    ([url, r]) => axiosFetcher(`${url}/${r}`)
  );
  const { data: dailyReport, isLoading: loadingDaily } = useSWR(
    Endpoints.Report.Daily,
    axiosFetcher
  );
  const { data: teacherStats, isLoading: loadingTeacherStats } = useSWR(
    [Endpoints.Report.TeacherStatistics, teacherId],
    ([url, id]) => axiosFetcher(`${url}/${id}/statistics`)
  );
  const { data: roomStats, isLoading: loadingRoomStats } = useSWR(
    [Endpoints.Report.RoomStatistics, room],
    ([url, r]) => axiosFetcher(`${url}/${r}/statistics`)
  );

  return (
    <div className="max-w-6xl mx-auto py-8">
      <h1 className="text-3xl font-bold mb-6">Báo cáo tổng quan</h1>
      <Tabs defaultValue="daily" className="w-full">
        <TabsList className="mb-4">
          <TabsTrigger value="daily">Báo cáo ngày</TabsTrigger>
          <TabsTrigger value="teacher">Theo giáo viên</TabsTrigger>
          <TabsTrigger value="class">Theo lớp</TabsTrigger>
          <TabsTrigger value="room">Theo phòng</TabsTrigger>
        </TabsList>
        <TabsContent value="daily">
          <Card>
            <CardHeader>
              <CardTitle>Báo cáo ngày</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingDaily ? (
                <Skeleton className="h-20 w-full" />
              ) : (
                <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(dailyReport, null, 2)}</pre>
              )}
            </CardContent>
          </Card>
        </TabsContent>
        <TabsContent value="teacher">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <Card>
              <CardHeader>
                <CardTitle>Báo cáo giáo viên</CardTitle>
              </CardHeader>
              <CardContent>
                {loadingTeacher ? (
                  <Skeleton className="h-20 w-full" />
                ) : (
                  <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(teacherReport, null, 2)}</pre>
                )}
              </CardContent>
            </Card>
            <Card>
              <CardHeader>
                <CardTitle>Thống kê giáo viên</CardTitle>
              </CardHeader>
              <CardContent>
                {loadingTeacherStats ? (
                  <Skeleton className="h-20 w-full" />
                ) : (
                  <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(teacherStats, null, 2)}</pre>
                )}
              </CardContent>
            </Card>
          </div>
        </TabsContent>
        <TabsContent value="class">
          <Card>
            <CardHeader>
              <CardTitle>Báo cáo lớp</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingClass ? (
                <Skeleton className="h-20 w-full" />
              ) : (
                <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(classReport, null, 2)}</pre>
              )}
            </CardContent>
          </Card>
        </TabsContent>
        <TabsContent value="room">
          <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
            <Card>
              <CardHeader>
                <CardTitle>Báo cáo phòng</CardTitle>
              </CardHeader>
              <CardContent>
                {loadingRoom ? (
                  <Skeleton className="h-20 w-full" />
                ) : (
                  <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(roomReport, null, 2)}</pre>
                )}
              </CardContent>
            </Card>
            <Card>
              <CardHeader>
                <CardTitle>Thống kê phòng</CardTitle>
              </CardHeader>
              <CardContent>
                {loadingRoomStats ? (
                  <Skeleton className="h-20 w-full" />
                ) : (
                  <pre className="text-sm bg-muted p-4 rounded">{JSON.stringify(roomStats, null, 2)}</pre>
                )}
              </CardContent>
            </Card>
          </div>
        </TabsContent>
      </Tabs>
    </div>
  );
};

export default Dashboard;
