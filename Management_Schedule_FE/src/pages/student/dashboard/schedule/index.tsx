import StudentLayout from "@/components/features/guest/StudentLayout"
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogDescription,
  DialogFooter,
} from "@/components/ui/dialog"
import {
  Calendar,
  dateFnsLocalizer,
  Event as RBCEvent,
  View,
} from "react-big-calendar"
import "react-big-calendar/lib/css/react-big-calendar.css"
import format from "date-fns/format"
import parse from "date-fns/parse"
import startOfWeek from "date-fns/startOfWeek"
import getDay from "date-fns/getDay"
import vi from "date-fns/locale/vi"
import "react-big-calendar/lib/css/react-big-calendar.css"
import { Schedule } from "@/hooks/api/schedule/use-get-schedules"
import { Endpoints } from "@/lib/endpoints"
import { userInfoAtom } from "@/stores/auth"
import axios from "axios"
import { useAtom } from "jotai/react"
import { useEffect, useState } from "react"
import useSWR from "swr"
import {
  showErrorToast,
  showSuccessToast,
} from "@/components/common/toast/toast"
import { useDeleteScheduele } from "@/hooks/api/schedule/use-delete-scheduele"
import { mutate } from "swr"
import { Button } from "@/components/ui/button"
import { Textarea } from "@/components/ui/textarea"
interface Event extends RBCEvent {
  resource: Schedule
}

const locales = { vi }

const localizer = dateFnsLocalizer({
  format,
  parse,
  startOfWeek,
  getDay,
  locales,
})
function Page() {
  const [schedules, setSchedules] = useState<Schedule[]>([])
  const [user] = useAtom(userInfoAtom)

  const [currentDate, setCurrentDate] = useState<Date>(new Date())
  const [events, setEvents] = useState<Event[]>([])

  const [dateRange, setDateRange] = useState<{ start: Date; end: Date } | null>(
    null,
  )
  const [selectedEvent, setSelectedEvent] = useState<Schedule | null>(null)
  const [openDialog, setOpenDialog] = useState(false)


  // Dialog hủy lịch
  const [openCancelDialog, setOpenCancelDialog] = useState(false)
  const [cancelReason, setCancelReason] = useState("")
  const [selectedScheduleID, setSelectedScheduleID] = useState<number | null>(
    null,
  )

  const { deleteScheduele } = useDeleteScheduele()
  const studentId: string | undefined = user?.nameid
  const fetcher = async (url: string): Promise<Schedule[]> => {
    const response = await axios.get(url)
    return response.data.data
  }

  // lấy danh sách lịch học của sinh viên
  const { data, error, isLoading } = useSWR(
    studentId
      ? `${Endpoints.baseApiURL.URL}/${Endpoints.Schedule.GET_SCHEDULE_BY_STUDENT_ID(studentId)}`
      : null,
    fetcher,
  )

  useEffect(() => {
    if (data) {
      setSchedules(data)
    }
  }, [data])
  // Chuyển đổi dữ liệu lịch thành event để hiển thị trên calendar
  const convertToEvents = (schedules: Schedule[]): Event[] => {
    return schedules.map((s) => {
      const dateStr = s.date.slice(0, 10) // YYYY-MM-DD
      const start = new Date(`${dateStr}T${s.startTime}`)
      const end = new Date(`${dateStr}T${s.endTime}`)

      return {
        title: `${s.className} - ${s.teacherName}`,
        start,
        end,
        resource: s,
      }
    })
  }

  // Cập nhật event khi data hoặc dateRange thay đổi
  useEffect(() => {
    if (!dateRange) {
      setEvents(convertToEvents(schedules))
      return
    }

    // Lọc lịch theo khoảng dateRange
    const filtered = schedules.filter((s) => {
      if (!s.date) return false
      const scheduleDate = new Date(s.date)
      return (
        !isNaN(scheduleDate.getTime()) &&
        scheduleDate >= dateRange.start &&
        scheduleDate <= dateRange.end
      )
    })

    setEvents(convertToEvents(filtered))
  }, [schedules, dateRange])

  // Xử lý thay đổi khoảng ngày khi user thay đổi view hoặc navigate calendar
  const handleRangeChange = (range: Date[] | { start: Date; end: Date }) => {
    let start: Date | null = null
    let end: Date | null = null

    if (Array.isArray(range)) {
      start = range[0]
      end = range[range.length - 1]
    } else if ("start" in range && "end" in range) {
      start = range.start
      end = range.end
    }

    if (start && end) setDateRange({ start, end })
  }

  // Xử lý chuyển ngày hoặc view
  const handleNavigate = (date: Date, view: View) => {
    setCurrentDate(date)

    let start: Date
    let end: Date

    if (view === "month") {
      start = new Date(date.getFullYear(), date.getMonth(), 1)
      end = new Date(date.getFullYear(), date.getMonth() + 1, 0)
    } else if (view === "week") {
      start = startOfWeek(date, { weekStartsOn: 1 })
      end = new Date(start)
      end.setDate(end.getDate() + 6)
    } else {
      // day view
      start = new Date(date)
      end = new Date(date)
    }

    setDateRange({ start, end })
  }

  // Khi user chọn 1 event
  const handleSelectEvent = (event: Event) => {
    setSelectedEvent(event.resource)
    setOpenDialog(true)
  }

  // Mở dialog hủy lịch
  const handleOpenCancel = (scheduleID: number) => {
    setSelectedScheduleID(scheduleID)
    setCancelReason("")
    setOpenCancelDialog(true)
  }

  // Xử lý hủy lịch
  const handleCancel = async (statusPick: number) => {
    if (!selectedScheduleID || !cancelReason.trim()) return

    const newStatus = statusPick == 1 ? 3 : 1
    console.log(statusPick)

    try {
      const result = await deleteScheduele({
        id: selectedScheduleID,
        data: { status: newStatus, notes: cancelReason },
      })

      if (result.status === "success") {
        const message =
          statusPick === 1
            ? "Hủy lịch học thành công"
            : "Khôi phục lịch học thành công"

        showSuccessToast(message)
        mutate(Endpoints.Schedule.GET_ALL)
        setOpenDialog(false)
      } else {
        const message =
          statusPick === 1
            ? "Hủy lịch học thành công"
            : "Khôi phục lịch học thành công"
        showErrorToast(message)
      }
    } catch (err: any) {
      showErrorToast(err.message || "Lỗi khi hủy lịch")
    } finally {
      setOpenCancelDialog(false)
      setCancelReason("")
      setSelectedScheduleID(null)
    }
  }

  if (error) {
    return (
      <div className="p-6 max-w-6xl mx-auto">Lỗi tải lịch: {error.message}</div>
    )
  }

  if (isLoading) {
    return <div className="p-6 max-w-6xl mx-auto">Đang tải lịch...</div>
  }
  return (
    <StudentLayout>
      <div className="p-6 max-w-6xl mx-auto">
        <h1 className="text-2xl font-bold mb-2">📅 Lịch học</h1>
        <h2 className="text-lg font-medium mb-4">
          {`📆 ${currentDate.toLocaleDateString("vi-VN", {
            year: "numeric",
            month: "long",
          })}`}
        </h2>
        

        <Calendar
          localizer={localizer}
          events={events}
          startAccessor="start"
          endAccessor="end"
          style={{ height: 600 }}
          popup
          messages={{
            week: "Tuần",
            day: "Ngày",
            month: "Tháng",
            today: "Hôm nay",
            previous: "Trước",
            next: "Tiếp",
          }}
          views={["week", "day", "month"]}
          defaultView="month"
          onRangeChange={handleRangeChange}
          onNavigate={handleNavigate}
          onSelectEvent={handleSelectEvent}
          date={currentDate}
        />

        {/* Dialog chi tiết lịch dạy */}
        <Dialog open={openDialog} onOpenChange={setOpenDialog}>
          <DialogContent>
            <DialogHeader>
              <DialogTitle>📘 Chi tiết lịch học</DialogTitle>
              {selectedEvent && (
                <DialogDescription className="space-y-2 text-sm">
                  <p>
                    <strong>Lớp học:</strong> {selectedEvent.className}
                  </p>
                  <p>
                    <strong>Khóa học:</strong> {selectedEvent.courseName}
                  </p>

                  <div className="mb-2 flex flex-row item-center">
                    <p>
                      <strong>Giáo viên:</strong>
                    </p>
                    <div className="flex justify-between items-center">
                      <span>
                        {selectedEvent.teacherName || "Chưa có giáo viên"}
                      </span>
                    </div>
                  </div>
                  <p>
                    <strong>Ca học:</strong> {selectedEvent.studySessionName}
                  </p>
                  <p>
                    <strong>Phòng:</strong> {selectedEvent.room}
                  </p>
                  <p>
                    <strong>Ngày:</strong>{" "}
                    {new Date(selectedEvent.date).toLocaleDateString("vi-VN")}
                  </p>
                  <p>
                    <strong>Thời gian:</strong> {selectedEvent.startTime} -{" "}
                    {selectedEvent.endTime}
                  </p>

                  <div className="flex flex-col items-center mt-4 space-y-2">
                    {selectedEvent.status === 1 && (
                      <Button
                        className="bg-red-500 hover:bg-red-600 text-white"
                        onClick={() =>
                          handleOpenCancel(selectedEvent.scheduleID)
                        }
                      >
                        Hủy lịch học
                      </Button>
                    )}

                    {selectedEvent.status === 3 && (
                      <Button
                        className="bg-green-500 hover:bg-green-600 text-white"
                        onClick={() =>
                          handleOpenCancel(selectedEvent.scheduleID)
                        }
                      >
                        Khôi phục lịch học
                      </Button>
                    )}
                  </div>

                  {/* Dialog hủy lịch */}
                  <Dialog
                    open={openCancelDialog}
                    onOpenChange={setOpenCancelDialog}
                  >
                    <DialogContent>
                      <DialogTitle>
                        {selectedEvent.status === 1
                          ? "🗑️ Lý do hủy lịch học"
                          : "♻️ Lý do khôi phục lịch học"}
                      </DialogTitle>
                      <Textarea
                        placeholder="Nhập lý do hủy lịch học"
                        value={cancelReason}
                        onChange={(e) => setCancelReason(e.target.value)}
                        rows={4}
                        className="mb-4"
                      />
                      <DialogFooter className="flex gap-4 justify-end">
                        <Button
                          variant="outline"
                          onClick={() => setOpenCancelDialog(false)}
                        >
                          Hủy
                        </Button>
                        <Button
                          disabled={!cancelReason.trim()}
                          onClick={() => handleCancel(selectedEvent.status)}
                          className={
                            selectedEvent.status === 1
                              ? "bg-red-500 text-white"
                              : "bg-green-500 text-white"
                          }
                        >
                          {selectedEvent.status === 1
                            ? "Xác nhận hủy"
                            : "Xác nhận khôi phục"}
                        </Button>
                      </DialogFooter>
                    </DialogContent>
                  </Dialog>
                </DialogDescription>
              )}
            </DialogHeader>
          </DialogContent>
        </Dialog>
      </div>
    </StudentLayout>
  )
}

export default Page
