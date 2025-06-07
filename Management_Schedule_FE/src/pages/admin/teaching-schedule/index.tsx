'use client';

import { useEffect, useState } from 'react';
import { Calendar, dateFnsLocalizer, Event as RBCEvent, View } from 'react-big-calendar';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import format from 'date-fns/format';
import parse from 'date-fns/parse';
import startOfWeek from 'date-fns/startOfWeek';
import getDay from 'date-fns/getDay';
import vi from 'date-fns/locale/vi';
import 'react-big-calendar/lib/css/react-big-calendar.css';

import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogDescription,
    DialogFooter,
} from '@/components/ui/dialog';

import { showErrorToast, showSuccessToast } from '@/components/common/toast/toast';
import { Button } from '@/components/ui/button';
import { Textarea } from '@/components/ui/textarea';
import { mutate } from 'swr';

import { useDeleteScheduele } from '@/hooks/api/schedule/use-delete-scheduele';
import useGetSchedule, { Schedule } from '@/hooks/api/schedule/use-get-schedules';
import { Endpoints } from '@/lib/endpoints';

interface Teacher {
    teacherID: number;
    fullName: string;
}

interface Event extends RBCEvent {
    resource: Schedule;
}

const locales = { vi };

const localizer = dateFnsLocalizer({
    format,
    parse,
    startOfWeek,
    getDay,
    locales,
});

export default function SchedulePage() {
    const { data: schedules = [], error, isLoading } = useGetSchedule();
    const { deleteScheduele } = useDeleteScheduele();

    const [events, setEvents] = useState<Event[]>([]);
    const [selectedEvent, setSelectedEvent] = useState<Schedule | null>(null);
    const [openDialog, setOpenDialog] = useState(false);

    const [dateRange, setDateRange] = useState<{ start: Date; end: Date } | null>(null);
    const [currentDate, setCurrentDate] = useState<Date>(new Date());

    const [teachers, setTeachers] = useState<Teacher[]>([]);
    const [selectedTeacherID, setSelectedTeacherID] = useState<number | null>(null);
    const [note, setNote] = useState('');
    const [isSaving, setIsSaving] = useState(false);
    const [isEditingTeacher, setIsEditingTeacher] = useState(false);

    // Dialog hủy lịch
    const [openCancelDialog, setOpenCancelDialog] = useState(false);
    const [cancelReason, setCancelReason] = useState('');
    const [selectedScheduleID, setSelectedScheduleID] = useState<number | null>(null);

    // Chuyển đổi dữ liệu lịch thành event để hiển thị trên calendar
    const convertToEvents = (schedules: Schedule[]): Event[] => {
        return schedules.map((s) => {
            const dateStr = s.date.slice(0, 10); // YYYY-MM-DD
            const start = new Date(`${dateStr}T${s.startTime}`);
            const end = new Date(`${dateStr}T${s.endTime}`);

            return {
                title: `${s.className} - ${s.teacherName}`,
                start,
                end,
                resource: s,
            };
        });
    };

    // Cập nhật event khi data hoặc dateRange thay đổi
    useEffect(() => {
        if (!dateRange) {
            setEvents(convertToEvents(schedules));
            return;
        }

        // Lọc lịch theo khoảng dateRange
        const filtered = schedules.filter((s) => {
            if (!s.date) return false;
            const scheduleDate = new Date(s.date);
            return (
                !isNaN(scheduleDate.getTime()) &&
                scheduleDate >= dateRange.start &&
                scheduleDate <= dateRange.end
            );
        });

        setEvents(convertToEvents(filtered));
    }, [schedules, dateRange]);

    // Khi mở dialog chi tiết sự kiện, tải danh sách giáo viên
    useEffect(() => {
        if (!openDialog || !selectedEvent) return;

        const fetchTeachers = async () => {
            try {
                const res = await fetch('http://localhost:5163/api/Teacher/details');
                if (!res.ok) throw new Error('Lỗi tải danh sách giáo viên');
                const data = await res.json();
                setTeachers(data.data || []);
            } catch (err) {
                console.error('Lỗi khi lấy danh sách giáo viên:', err);
                setTeachers([]);
            }
        };

        fetchTeachers();
        setSelectedTeacherID(selectedEvent.teacherID);
        setNote(selectedEvent.notes || '');
        setIsEditingTeacher(false);
    }, [openDialog, selectedEvent]);

    // Xử lý cập nhật giáo viên cho lịch
    const handleUpdateTeacher = async () => {
        if (!selectedEvent || selectedTeacherID === null) return;

        setIsSaving(true);
        try {
            const res = await fetch('http://localhost:5163/api/Schedule/assign-teacher', {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({
                    scheduleID: selectedEvent.scheduleID,
                    teacherID: selectedTeacherID,
                    notes: note,
                }),
            });

            const result = await res.json();

            if (res.ok && result.status === 'success') {
                showSuccessToast('✅ Cập nhật giáo viên thành công!');
                setOpenDialog(false);
                // Refresh lại lịch
                setDateRange((prev) => (prev ? { ...prev } : null));
            } else {
                const errorMessage = result?.errors?.detail || result?.message || '❌ Cập nhật giáo viên thất bại!';
                showErrorToast(errorMessage);
            }
        } catch (error: any) {
            const detailError =
                error?.response?.data?.errors?.detail || error?.response?.data?.message || '❌ Cập nhật giáo viên thất bại!';
            showErrorToast(detailError);
        } finally {
            setIsSaving(false);
        }
    };

    // Xử lý thay đổi khoảng ngày khi user thay đổi view hoặc navigate calendar
    const handleRangeChange = (range: Date[] | { start: Date; end: Date }) => {
        let start: Date | null = null;
        let end: Date | null = null;

        if (Array.isArray(range)) {
            start = range[0];
            end = range[range.length - 1];
        } else if ('start' in range && 'end' in range) {
            start = range.start;
            end = range.end;
        }

        if (start && end) setDateRange({ start, end });
    };

    // Xử lý chuyển ngày hoặc view
    const handleNavigate = (date: Date, view: View) => {
        setCurrentDate(date);

        let start: Date;
        let end: Date;

        if (view === 'month') {
            start = new Date(date.getFullYear(), date.getMonth(), 1);
            end = new Date(date.getFullYear(), date.getMonth() + 1, 0);
        } else if (view === 'week') {
            start = startOfWeek(date, { weekStartsOn: 1 });
            end = new Date(start);
            end.setDate(end.getDate() + 6);
        } else {
            // day view
            start = new Date(date);
            end = new Date(date);
        }

        setDateRange({ start, end });
    };

    // Khi user chọn 1 event
    const handleSelectEvent = (event: Event) => {
        setSelectedEvent(event.resource);
        setOpenDialog(true);
    };

    // Mở dialog hủy lịch
    const handleOpenCancel = (scheduleID: number) => {
        setSelectedScheduleID(scheduleID);
        setCancelReason('');
        setOpenCancelDialog(true);
    };

    // Xử lý hủy lịch
    const handleCancel = async (statusPick: number) => {

        if (!selectedScheduleID || !cancelReason.trim()) return;

        const newStatus = statusPick == 1 ? 3 : 1
        console.log(statusPick)

        try {
            const result = await deleteScheduele({
                id: selectedScheduleID,
                data: { status: newStatus, notes: cancelReason },
            });

            if (result.status === 'success') {
                const message =
                    statusPick === 1
                        ? 'Hủy lịch học thành công'
                        : 'Khôi phục lịch học thành công';

                showSuccessToast(message);
                mutate(Endpoints.Schedule.GET_ALL);
                setOpenDialog(false);


            } else {
                const message =
                    statusPick === 1
                        ? 'Hủy lịch học thành công'
                        : 'Khôi phục lịch học thành công';
                showErrorToast(message);
            }
        } catch (err: any) {
            showErrorToast(err.message || 'Lỗi khi hủy lịch');
        } finally {
            setOpenCancelDialog(false);
            setCancelReason('');
            setSelectedScheduleID(null);
        }
    };


    if (error) {
        return <div className="p-6 max-w-6xl mx-auto">Lỗi tải lịch: {error.message}</div>;
    }

    if (isLoading) {
        return <div className="p-6 max-w-6xl mx-auto">Đang tải lịch...</div>;
    }



    return (
        <div className="p-6 max-w-6xl mx-auto">
            <h1 className="text-2xl font-bold mb-2">📅 Lịch dạy giáo viên</h1>
            <h2 className="text-lg font-medium mb-4">
                {`📆 ${currentDate.toLocaleDateString('vi-VN', {
                    year: 'numeric',
                    month: 'long',
                })}`}
            </h2>
            <div className="flex gap-4 mt-4 max-w-6xl mx-auto">
                <p className='font-bold'> Chú thích:</p>
                <div className="flex items-center gap-2">
                    <div className="w-5 h-5 rounded" style={{ backgroundColor: '#3182CE' }}></div>
                    <span>Hoạt động</span>
                </div>
                <div className="flex items-center gap-2">
                    <div className="w-5 h-5 rounded" style={{ backgroundColor: '#FFD700' }}></div>
                    <span>Đã hoàn thành</span>
                </div>
                <div className="flex items-center gap-2">
                    <div className="w-5 h-5 rounded" style={{ backgroundColor: '#E53E3E' }}></div>
                    <span>Đã hủy</span>
                </div>
            </div>


            <Calendar
                localizer={localizer}
                events={events}
                startAccessor="start"
                endAccessor="end"
                style={{ height: 600 }}
                popup
                messages={{
                    week: 'Tuần',
                    day: 'Ngày',
                    month: 'Tháng',
                    today: 'Hôm nay',
                    previous: 'Trước',
                    next: 'Tiếp',
                }}
                views={['week', 'day', 'month']}
                defaultView="month"
                onRangeChange={handleRangeChange}
                onNavigate={handleNavigate}
                onSelectEvent={handleSelectEvent}
                eventPropGetter={(event:any) => {
                    let backgroundColor = '#3182CE'; // màu mặc định (xanh dương)

                    if (event.resource.status === 1) {
                        backgroundColor = '#3182CE'; // Hoạt động - xanh dương
                    } else if (event.resource.status === 2) {
                        backgroundColor = '#38A169'; // Đã hoàn thành - xanh lá
                    } else if (event.resource.status === 3) {
                        backgroundColor = '#E53E3E'; // Đã hủy - đỏ
                    }

                    return {
                        style: {
                            backgroundColor,
                            color: 'white',
                            borderRadius: '6px',
                            padding: '2px 4px',
                        },
                    };
                }
                }
                date={currentDate}
            />

            {/* Dialog chi tiết lịch dạy */}
            <Dialog open={openDialog} onOpenChange={setOpenDialog}>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>📘 Chi tiết lịch dạy</DialogTitle>
                        {selectedEvent && (
                            <DialogDescription className="space-y-2 text-sm">
                                <p>
                                    <strong>Lớp học:</strong> {selectedEvent.className}
                                </p>
                                <p>
                                    <strong>Khóa học:</strong> {selectedEvent.courseName}
                                </p>

                                <div className="mb-4">
                                    <p>
                                        <strong>Giáo viên:</strong>
                                    </p>
                                    {!isEditingTeacher ? (
                                        <div className="flex justify-between items-center">
                                            <span>{selectedEvent.teacherName || 'Chưa có giáo viên'}</span>
                                            {selectedEvent.status !== 2 && (
                                                <button
                                                    className="text-blue-500 underline ml-4"
                                                    onClick={() => setIsEditingTeacher(true)}
                                                >
                                                    Sửa
                                                </button>
                                            )}
                                        </div>
                                    ) : (
                                        <div>
                                            <select
                                                value={selectedTeacherID ?? ''}
                                                onChange={(e) => setSelectedTeacherID(Number(e.target.value))}
                                                className="border px-2 py-1 rounded w-full mt-1"
                                            >
                                                <option value="">-- Chọn giáo viên --</option>
                                                {teachers.map((t) => (
                                                    <option key={t.teacherID} value={t.teacherID}>
                                                        {t.fullName}
                                                    </option>
                                                ))}
                                            </select>

                                            <div className="mt-2">
                                                <label htmlFor="note" className="block mb-1 font-medium">
                                                    Ghi chú
                                                </label>
                                                <Textarea
                                                    id="note"
                                                    value={note}
                                                    onChange={(e) => setNote(e.target.value)}
                                                    rows={3}
                                                    placeholder="Nhập ghi chú nếu có..."
                                                />
                                            </div>

                                            <div className="mt-2 flex gap-2">
                                                <Button
                                                    onClick={handleUpdateTeacher}
                                                    disabled={isSaving || selectedTeacherID === null}
                                                    className="bg-blue-500 text-white px-4 py-1 rounded"
                                                >
                                                    {isSaving ? 'Đang lưu...' : 'Lưu'}
                                                </Button>
                                                <button
                                                    onClick={() => {
                                                        setIsEditingTeacher(false);
                                                        setSelectedTeacherID(selectedEvent.teacherID);
                                                        setNote(selectedEvent.notes || '');
                                                    }}
                                                    className="text-gray-500 underline"
                                                >
                                                    Hủy
                                                </button>
                                            </div>
                                        </div>
                                    )}
                                </div>

                                <p>
                                    <strong>Ghi chú:</strong> {selectedEvent.notes}
                                </p>
                                <p>
                                    <strong>Phòng:</strong> {selectedEvent.room}
                                </p>
                                <p>
                                    <strong>Ngày:</strong> {new Date(selectedEvent.date).toLocaleDateString('vi-VN')}
                                </p>
                                <p>
                                    <strong>Trạng thái:</strong>{' '}
                                    {selectedEvent.status === 1 && (
                                        <Button variant="default" className="bg-blue-500 hover:bg-blue-600 text-white">
                                            Hoạt động
                                        </Button>
                                    )}

                                    {selectedEvent.status === 2 && (
                                        <Button variant="outline" className="bg-green-500 hover:bg-green-600 text-white">
                                            Đã hoàn thành
                                        </Button>
                                    )}

                                    {selectedEvent.status === 3 && (
                                        <Button variant="destructive" className="text-white">
                                            Đã hủy
                                        </Button>
                                    )}
                                </p>
                                <p>
                                    <strong>Thời gian:</strong> {selectedEvent.startTime} - {selectedEvent.endTime}
                                </p>

                                <div className="flex flex-col items-center mt-4 space-y-2">
                                    {selectedEvent.status === 1 && (
                                        <Button
                                            className="bg-red-500 hover:bg-red-600 text-white"
                                            onClick={() => handleOpenCancel(selectedEvent.scheduleID)}
                                        >
                                            Hủy lịch học
                                        </Button>
                                    )}

                                    {selectedEvent.status === 3 && (
                                        <Button
                                            className="bg-green-500 hover:bg-green-600 text-white"
                                            onClick={() => handleOpenCancel(selectedEvent.scheduleID)}
                                        >
                                            Khôi phục lịch học
                                        </Button>
                                    )}
                                </div>

                                {/* Dialog hủy lịch */}
                                <Dialog open={openCancelDialog} onOpenChange={setOpenCancelDialog}>
                                    <DialogContent>
                                        <DialogTitle>
                                            {selectedEvent.status === 1
                                                ? '🗑️ Lý do hủy lịch học'
                                                : '♻️ Lý do khôi phục lịch học'}
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
                                                        ? 'bg-red-500 text-white'
                                                        : 'bg-green-500 text-white'
                                                }
                                            >
                                                {selectedEvent.status === 1
                                                    ? 'Xác nhận hủy'
                                                    : 'Xác nhận khôi phục'}
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
    );
}
