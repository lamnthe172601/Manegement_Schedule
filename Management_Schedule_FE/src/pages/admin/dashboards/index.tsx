import React from "react";
import useSWR from "swr";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Tabs, TabsList, TabsTrigger, TabsContent } from "@/components/ui/tabs";
import { Skeleton } from "@/components/ui/skeleton";
import { Endpoints } from "@/lib/endpoints";
import { axiosFetcher } from "@/lib/utils";


const Dashboard = () => {
  // Báo cáo tổng quan
  const { data: dashboardData, isLoading: loadingDashboard } = useSWR(
    Endpoints.Report.Dashboard,
    axiosFetcher
  );
  console.log("dashboardData", dashboardData)
  // Thống kê trạng thái lịch học
  const { data: scheduleStatus, isLoading: loadingScheduleStatus } = useSWR(
    Endpoints.Report.ScheduleStatusStatistics,
    axiosFetcher
  );
  // Top giáo viên
  const { data: topTeachers, isLoading: loadingTopTeachers } = useSWR(
    `${Endpoints.Report.TopTeachers}?top=5`,
    axiosFetcher
  );
  // Phân bố học viên theo lớp
  const { data: studentDistribution, isLoading: loadingStudentDistribution } = useSWR(
    Endpoints.Report.StudentDistributionByClass,
    axiosFetcher
  );

  return (
    <div className="max-w-6xl mx-auto py-8">
      <h1 className="text-3xl font-bold mb-6">Trang tổng quan trung tâm</h1>
      <Tabs defaultValue="dashboard" className="w-full">
        <TabsList className="mb-4">
          <TabsTrigger value="dashboard">Tổng quan</TabsTrigger>
          <TabsTrigger value="schedule">Thống kê lịch học</TabsTrigger>
          <TabsTrigger value="top-teachers">Top giáo viên</TabsTrigger>
          <TabsTrigger value="student-distribution">Phân bố học viên theo lớp</TabsTrigger>
        </TabsList>
        <TabsContent value="dashboard">
          <Card>
            <CardHeader>
              <CardTitle>Thống kê tổng quan</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingDashboard ? (
                <Skeleton className="h-32 w-full" />
              ) : dashboardData ? (
                <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
                  <div className="bg-blue-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalUsers}</div>
                    <div className="text-sm">Tổng người dùng</div>
                  </div>
                  <div className="bg-green-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalTeachers}</div>
                    <div className="text-sm">Tổng giáo viên</div>
                  </div>
                  <div className="bg-yellow-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalStudents}</div>
                    <div className="text-sm">Tổng học viên</div>
                  </div>
                  <div className="bg-purple-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalClasses}</div>
                    <div className="text-sm">Tổng lớp học</div>
                  </div>
                  <div className="bg-pink-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalCourses}</div>
                    <div className="text-sm">Tổng khóa học</div>
                  </div>
                  <div className="bg-orange-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalSchedules}</div>
                    <div className="text-sm">Tổng lịch học</div>
                  </div>
                  <div className="bg-teal-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalActiveClasses}</div>
                    <div className="text-sm">Lớp đang hoạt động</div>
                  </div>
                  <div className="bg-indigo-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalActiveStudents}</div>
                    <div className="text-sm">Học viên đang học</div>
                  </div>
                  <div className="bg-gray-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{dashboardData.totalActiveTeachers}</div>
                    <div className="text-sm">Giáo viên đang dạy</div>
                  </div>
                </div>
              ) : (
                <div className="text-center text-red-500">Không có dữ liệu</div>
              )}
            </CardContent>
          </Card>
        </TabsContent>
        <TabsContent value="schedule">
          <Card>
            <CardHeader>
              <CardTitle>Thống kê trạng thái lịch học</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingScheduleStatus ? (
                <Skeleton className="h-32 w-full" />
              ) : scheduleStatus ? (
                <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
                  <div className="bg-blue-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{scheduleStatus.totalSchedules}</div>
                    <div className="text-sm">Tổng lịch học</div>
                  </div>
                  <div className="bg-green-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{scheduleStatus.completedSchedules}</div>
                    <div className="text-sm">Đã hoàn thành</div>
                  </div>
                  <div className="bg-yellow-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{scheduleStatus.cancelledSchedules}</div>
                    <div className="text-sm">Đã hủy</div>
                  </div>
                  <div className="bg-purple-100 rounded p-4 text-center">
                    <div className="text-2xl font-bold">{scheduleStatus.pendingSchedules}</div>
                    <div className="text-sm">Chờ diễn ra</div>
                  </div>
                </div>
              ) : (
                <div className="text-center text-red-500">Không có dữ liệu</div>
              )}
            </CardContent>
          </Card>
        </TabsContent>
        <TabsContent value="top-teachers">
          <Card>
            <CardHeader>
              <CardTitle>Top giáo viên nhiều buổi dạy nhất</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingTopTeachers ? (
                <Skeleton className="h-32 w-full" />
              ) : Array.isArray(topTeachers) && topTeachers.length > 0 ? (
                <div className="overflow-x-auto">
                  <table className="min-w-full text-sm">
                    <thead>
                      <tr className="bg-gray-100">
                        <th className="py-2 px-4 text-left">STT</th>
                        <th className="py-2 px-4 text-left">Tên giáo viên</th>
                        <th className="py-2 px-4 text-left">Số buổi dạy</th>
                      </tr>
                    </thead>
                    <tbody>
                      {topTeachers.map((teacher: any, idx: number) => (
                        <tr key={teacher.teacherID} className="border-b">
                          <td className="py-2 px-4">{idx + 1}</td>
                          <td className="py-2 px-4">{teacher.teacherName}</td>
                          <td className="py-2 px-4">{teacher.totalSessions}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ) : (
                <div className="text-center text-red-500">Không có dữ liệu</div>
              )}
            </CardContent>
          </Card>
        </TabsContent>
        <TabsContent value="student-distribution">
          <Card>
            <CardHeader>
              <CardTitle>Phân bố học viên theo lớp</CardTitle>
            </CardHeader>
            <CardContent>
              {loadingStudentDistribution ? (
                <Skeleton className="h-32 w-full" />
              ) : Array.isArray(studentDistribution) && studentDistribution.length > 0 ? (
                <div className="overflow-x-auto">
                  <table className="min-w-full text-sm">
                    <thead>
                      <tr className="bg-gray-100">
                        <th className="py-2 px-4 text-left">STT</th>
                        <th className="py-2 px-4 text-left">Tên lớp</th>
                        <th className="py-2 px-4 text-left">Số học viên</th>
                      </tr>
                    </thead>
                    <tbody>
                      {studentDistribution.map((cls: any, idx: number) => (
                        <tr key={cls.classID} className="border-b">
                          <td className="py-2 px-4">{idx + 1}</td>
                          <td className="py-2 px-4">{cls.className}</td>
                          <td className="py-2 px-4">{cls.studentCount}</td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </div>
              ) : (
                <div className="text-center text-red-500">Không có dữ liệu</div>
              )}
            </CardContent>
          </Card>
        </TabsContent>
      </Tabs>
    </div>
  );
};

export default Dashboard;
