

'use client';

import { useEffect, useState } from 'react';
import { Calendar, dateFnsLocalizer, Event as RBCEvent, View } from 'react-big-calendar';
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
} from "@/components/ui/dialog";

interface Schedule {
    scheduleID: number;
    date: string;
    startTime: string;
    endTime: string;
    className: string;
    courseName: string;
    teacherName: string;
    room: string;
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
    const [schedules, setSchedules] = useState<Schedule[]>([]);
    const [events, setEvents] = useState<Event[]>([]);
    const [selectedEvent, setSelectedEvent] = useState<Schedule | null>(null);
    const [openDialog, setOpenDialog] = useState(false);
    const [dateRange, setDateRange] = useState<{ start: Date, end: Date } | null>(null);
    const [currentDate, setCurrentDate] = useState<Date>(new Date());

    // Lấy dữ liệu lịch từ API khi thay đổi range
    useEffect(() => {
        if (!dateRange) return;

        const fetchSchedules = async () => {
            try {
                const res = await fetch('http://localhost:5163/api/Schedule');
                if (!res.ok) throw new Error('Lỗi kết nối API');
                const data = await res.json();

                if (data.status === 'success') {
                    const filtered = data.data.filter((s: Schedule) => {
                        if (!s.date) return false;
                        const scheduleDate = new Date(s.date);
                        return !isNaN(scheduleDate.getTime()) &&
                            scheduleDate >= dateRange.start &&
                            scheduleDate <= dateRange.end;
                    });
                    setSchedules(filtered);
                } else {
                    console.error('API trả về lỗi:', data);
                    setSchedules([]);
                }
            } catch (error) {
                console.error('Lỗi khi tải lịch dạy:', error);
                setSchedules([]);
            }
        };

        fetchSchedules();
    }, [dateRange]);

    // Chuyển đổi sang event để hiển thị
    useEffect(() => {
        const parsedEvents: Event[] = schedules.map(s => {
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

        setEvents(parsedEvents);
    }, [schedules]);

    // Xử lý khi lịch thay đổi (range)
    const handleRangeChange = (range: any) => {
        let start: Date | null = null;
        let end: Date | null = null;

        if (Array.isArray(range)) {
            start = range[0];
            end = range[range.length - 1];
        } else if (range.start && range.end) {
            start = range.start;
            end = range.end;
        }

        if (start && end) {
            setDateRange({ start, end });
        }
    };

    // Xử lý khi chuyển ngày hoặc view
    const handleNavigate = (date: Date, view: View) => {
        setCurrentDate(date);

        let start: Date = new Date(date);
        let end: Date = new Date(date);

        if (view === 'month') {
            start = new Date(date.getFullYear(), date.getMonth(), 1);
            end = new Date(date.getFullYear(), date.getMonth() + 1, 0);
        } else if (view === 'week') {
            start = startOfWeek(date, { weekStartsOn: 1 });
            end = new Date(start);
            end.setDate(end.getDate() + 6);
        } else if (view === 'day') {
            start = new Date(date);
            end = new Date(date);
        }

        setDateRange({ start, end });
    };

    const handleSelectEvent = (event: Event) => {
        setSelectedEvent(event.resource);
        setOpenDialog(true);
    };

    return (
        <div className="p-6 max-w-6xl mx-auto">
            <h1 className="text-2xl font-bold mb-2">📅 Lịch dạy giáo viên</h1>
            <h2 className="text-lg font-medium mb-4">
                {`📆 ${currentDate.toLocaleDateString('vi-VN', {
                    year: 'numeric',
                    month: 'long',
                })}`}
            </h2>

            <Calendar
                localizer={localizer}
                events={events}
                startAccessor="start"
                endAccessor="end"
                style={{ height: 600 }}
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
                eventPropGetter={() => ({
                    style: {
                        backgroundColor: '#3182CE',
                        color: 'white',
                        borderRadius: '6px',
                        padding: '2px 4px',
                    },
                })}
                date={currentDate}  // <-- Thêm dòng này
            />


            <Dialog open={openDialog} onOpenChange={setOpenDialog}>
                <DialogContent>
                    <DialogHeader>
                        <DialogTitle>📘 Chi tiết lịch dạy</DialogTitle>
                        {selectedEvent && (
                            <DialogDescription className="space-y-2 text-sm">
                                <p><strong>Lớp học:</strong> {selectedEvent.className}</p>
                                <p><strong>Khóa học:</strong> {selectedEvent.courseName}</p>
                                <p><strong>Giáo viên:</strong> {selectedEvent.teacherName}</p>
                                <p><strong>Phòng:</strong> {selectedEvent.room}</p>
                                <p><strong>Ngày:</strong> {new Date(selectedEvent.date).toLocaleDateString('vi-VN')}</p>
                                <p><strong>Thời gian:</strong> {selectedEvent.startTime} - {selectedEvent.endTime}</p>
                            </DialogDescription>
                        )}
                    </DialogHeader>
                </DialogContent>
            </Dialog>
        </div>
    );
}
