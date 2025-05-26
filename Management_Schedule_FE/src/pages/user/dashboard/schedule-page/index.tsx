
import TeacherLayout from "@/components/features/guest/TeacherLayout"
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select"

export default function SchedulePage() {
    const scheduleData = [
        { class: "A55A", day: "Thứ 2", session: "Ca 1", time: "8h-10h30", instructor: "Na" },
        { class: "A55A", day: "Thứ 4", session: "Ca 3", time: "15h45-18h15", instructor: "GV1" },
        { class: "A55A", day: "Thứ 7", session: "Ca 4", time: "18h30-21h", instructor: "GV3" },
        { class: "WE", day: "Thứ 3", session: "Ca 1", time: "8h-10h30", instructor: "GV3" },
        { class: "WE", day: "Thứ 5", session: "Ca 3", time: "15h45-18h15", instructor: "GV3" },
        { class: "WE", day: "Chủ Nhật", session: "Ca 2", time: "13h-15h30", instructor: "GV1" },
    ]

    return (
        <TeacherLayout>
            <div>
                <h1 className="text-2xl font-bold mb-6">Lịch giảng</h1>

                {/* Table Header with Filters */}
                <div className="grid grid-cols-5 gap-4 mb-4">
                    <div className="bg-red-600 text-white p-3 rounded-md">
                        <div className="flex items-center justify-between">
                            <span className="font-medium">Tên lớp</span>
                            <span className="text-white opacity-70">▼</span>
                        </div>
                    </div>

                    <div className="bg-red-600 text-white p-3 rounded-md">
                        <div className="flex items-center justify-between">
                            <span className="font-medium">Lịch giảng</span>
                            <span className="text-white opacity-70">▼</span>
                        </div>
                    </div>

                    <div className="bg-red-600 text-white p-3 rounded-md">
                        <Select defaultValue="all">
                            <SelectTrigger className="border-0 bg-transparent text-white font-medium focus:ring-0 focus:ring-offset-0 [&>span]:flex [&>span]:items-center [&>span]:justify-between">
                                <SelectValue placeholder="Ca giảng" />
                            </SelectTrigger>
                            <SelectContent>
                                <SelectItem value="all">Ca giảng</SelectItem>
                                <SelectItem value="ca1">Ca 1</SelectItem>
                                <SelectItem value="ca2">Ca 2</SelectItem>
                                <SelectItem value="ca3">Ca 3</SelectItem>
                                <SelectItem value="ca4">Ca 4</SelectItem>
                            </SelectContent>
                        </Select>
                    </div>

                    <div className="bg-red-600 text-white p-3 rounded-md">
                        <div className="flex items-center justify-between">
                            <span className="font-medium">Giờ giảng</span>
                            <span className="text-white opacity-70">▼</span>
                        </div>
                    </div>

                    <div className="bg-red-600 text-white p-3 rounded-md">
                        <div className="flex items-center justify-between">
                            <span className="font-medium">Giảng viên</span>
                            <span className="text-white opacity-70">▼</span>
                        </div>
                    </div>
                </div>

                {/* Schedule Table */}
                <div className="grid grid-cols-5 gap-4">
                    {scheduleData.map((item, index) => (
                        <>
                            <div key={`class-${index}`} className="bg-red-100 p-3 text-center">
                                {item.class}
                            </div>
                            <div key={`day-${index}`} className="bg-red-100 p-3 text-center">
                                {item.day}
                            </div>
                            <div key={`session-${index}`} className="bg-red-100 p-3 text-center">
                                {item.session}
                            </div>
                            <div key={`time-${index}`} className="bg-red-100 p-3 text-center">
                                {item.time}
                            </div>
                            <div key={`instructor-${index}`} className="bg-red-100 p-3 text-center">
                                {item.instructor}
                            </div>
                        </>
                    ))}
                </div>
            </div>
        </TeacherLayout>

    )
}
