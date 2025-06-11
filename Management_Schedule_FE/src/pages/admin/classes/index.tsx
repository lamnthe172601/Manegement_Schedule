'use client';

import { showErrorToast, showSuccessToast } from '@/components/common/toast/toast';
import { Button } from '@/components/ui/button';
import { Dialog, DialogContent, DialogDescription, DialogFooter, DialogHeader, DialogTitle } from '@/components/ui/dialog';
import { Table, TableBody, TableCell, TableHead, TableHeader, TableRow } from '@/components/ui/table';
import { useAddClasses } from '@/hooks/api/classes/use-add-classes';
import { useAddSchedule } from '@/hooks/api/schedule/use-add-schedule';
import { useEffect, useState } from 'react';
import { format } from "date-fns"
import { Input } from '@/components/ui/input';
import { Label } from "@/components/ui/label"
import { useAxios } from '@/hooks/api/use-axios';
interface Course {
    courseID: number;
    courseName: string;
}
interface Teacher {
    teacherID: number;
    fullName: string;
}

interface ClassItem {
    classID: number;
    className: string;
    courseID: number;
    courseName: string;
    teacherName: string;
    maxStudents: number;
    enrolledStudents: number;
    totalSlots: number;
    startDate: string;
    endDate: string | null;
    status: number;
    note: string;
    isHaveSchedule: number,
    isHaveTeacher: boolean
}

interface ClassInput {
    className: string;
    courseID: number;
    maxStudents: number;
    startDate: string;
    endDate: string | null;
    status: number;
}

const daysOfWeek = ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday'];

export default function ClassPage() {
    const axios = useAxios();
    const [classes, setClasses] = useState<ClassItem[]>([]);
    const [courses, setCourses] = useState<Course[]>([]);
    const [formVisible, setFormVisible] = useState(false);
    const [formData, setFormData] = useState<ClassInput>({
        className: '',
        courseID: 0,
        maxStudents: 0,
        startDate: '',
        endDate: '',
        status: 1,
    });
    const [scheduleModalVisible, setScheduleModalVisible] = useState(false);
    const [loading, setLoading] = useState(false);
    const [message, setMessage] = useState('');
    const { addClasses } = useAddClasses()
    const { addSchedule } = useAddSchedule()
    const [openDialog, setOpenDialog] = useState(false);
    const [selectedClassID, setSelectedClassID] = useState(null);
    const [teacherList, setTeacherList] = useState<Teacher[]>([]);
    console.log("teacherList", teacherList)

    const [selectedTeacherID, setSelectedTeacherID] = useState("");
    const [scheduleData, setScheduleData] = useState({
        classID: 0,
        startDate: formData.startDate,
        room: 'P001',
        daysOfWeekSessions: daysOfWeek.reduce((acc, day) => {
            acc[day] = 0; // 0 nghĩa là chưa chọn slot nào cho ngày đó
            return acc;
        }, {} as Record<string, number>)
    });


    const fetchClasses = async () => {
        try {
            const res = await axios.get('/Class');
            if (res.data.status === 'success') setClasses(res.data.data);
        } catch (err) {
            console.error('Fetch class error:', err);
        }
    };

    const fetchCourses = async () => {
        try {
            const res = await axios.get('/Course');
            if (res.data.status === 'success') setCourses(res.data.data);
        } catch (err) {
            console.error('Fetch course error:', err);
        }
    };

    const fetchTeacher = async () => {
        try {
            const res = await axios.get('/Teacher/details');
            console.log(res.data);
            if (res.data.status === 'success') setTeacherList(res.data.data);
        } catch (err) {
            console.error('Fetch teacher error:', err);
        }
    };
    useEffect(() => {
        fetchClasses();
        fetchCourses();
        fetchTeacher();
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
        const { name, value } = e.target;
        setFormData(prev => ({
            ...prev,
            [name]: ['maxStudents', 'status', 'courseID'].includes(name) ? Number(value) : value
        }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        setMessage('');

        const payload = {
            ...formData,
            endDate: formData.endDate === '' ? null : formData.endDate
        };

        try {

            const result = await addClasses({ data: payload })
            if (result.status === 'success') {
                setMessage('✅ Thêm lớp học thành công!');
                setFormVisible(false);
                fetchClasses();
                setFormData({
                    className: '',
                    courseID: 0,
                    maxStudents: 0,
                    startDate: '',
                    endDate: '',
                    status: 1
                });
            } else {
                setMessage('❌ Thêm thất bại.');
            }
        } catch (err) {
            console.error('Submit error:', err);
            setMessage('❌ Đã xảy ra lỗi.');
        } finally {
            setLoading(false);
        }
    };

    const openScheduleModal = (classID: number, startDate: string) => {
        console.log(startDate)
        setScheduleData(prev => ({
            ...prev,
            classID,
            startDate,
            room: 'Room 01',
            daysOfWeekSessions: daysOfWeek.reduce((acc, day) => {
                acc[day] = 0; // sửa từ Array(5).fill(0) thành 0
                return acc;
            }, {} as Record<string, number>)
        }));
        setScheduleModalVisible(true);
    };



    const handleSlotChange = (day: string, slotIndex: number) => {
        setScheduleData(prev => {
            const currentSlot = prev.daysOfWeekSessions[day];
            return {
                ...prev,
                daysOfWeekSessions: {
                    ...prev.daysOfWeekSessions,
                    [day]: currentSlot === slotIndex ? 0 : slotIndex, // Nếu bấm lại slot đã chọn thì bỏ chọn
                }
            };
        });
    };





    const handleScheduleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        setLoading(true);
        console.log("scheduleData", scheduleData);
        console.log("scheduleData.daysOfWeekSessions", scheduleData.daysOfWeekSessions);

        try {
            const result = await addSchedule({ data: scheduleData })
            console.log(result)
            if (result.status === 'success') {
                showSuccessToast('✅ Tạo lịch học thành công!');

                setScheduleModalVisible(false);
                fetchClasses();
            } else {
                const errorMessage = result?.errors?.detail || result?.message || '❌ Tạo lịch học thất bại!';
                showErrorToast(errorMessage);
            }

        } catch (error) {
            const err = error as { response?: { data?: { errors?: { detail?: string }, message?: string } } };
            const detailError = err?.response?.data?.errors?.detail || err?.response?.data?.message || '❌ Lỗi khi tạo lịch học.';
            showErrorToast(detailError);
        } finally {
            setLoading(false);
        }
    };


    const handleOpenAssignDialog = (classID: any) => {
        setSelectedClassID(classID);
        fetchTeacher();
        setOpenDialog(true);
    };

    const handleCloseDialog = () => {
        setOpenDialog(false);
        setSelectedTeacherID("");
    };
    const handleAssignTeacher = async () => {
        console.log("classID, teacherID:", selectedClassID, parseInt(selectedTeacherID));

        try {
            const res = await fetch("http://localhost:5163/api/Schedule/assign-teacher-to-class", {
                method: "PUT",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    classID: selectedClassID,
                    teacherID: parseInt(selectedTeacherID)
                })
            });

            const data = await res.json();

            if (res.ok) {
                showSuccessToast("Gán giảng viên thành công!");
                handleCloseDialog();
                fetchClasses();
            } else {
                const errorDetail = data?.errors?.detail || "Gán giảng viên thất bại.";
                showErrorToast(errorDetail); // ✅ hiển thị lỗi chi tiết từ server
                console.error("Lỗi chi tiết từ server:", errorDetail);
            }
        } catch (error) {
            console.error("Lỗi khi gán giảng viên:", error);
            showErrorToast("Lỗi kết nối đến máy chủ.");
        }
    };

    const handleCreateMakeupSchedule = (cls: any) => {
        console.log(cls)
        setMakeupData({
            classID: cls.classID,
            teacherID: cls.teacherId,
            studySessionId: 0,
            room: "",
            status: 1,
            notes: "",
            date: new Date().toISOString().split("T")[0],
        });
        setMakeupModalVisible(true);
    };


    const [makeupModalVisible, setMakeupModalVisible] = useState(false);
    const [makeupData, setMakeupData] = useState({
        classID: 0,
        teacherID: 0,
        studySessionId: 0,
        room: "",
        status: 1,
        notes: "",
        date: new Date().toISOString().split("T")[0], // yyyy-MM-dd
    });

    const handleMakeupSubmit = async (e) => {
        e.preventDefault();
        console.log(makeupData)
        try {
            const res = await axios.post("/Schedule/makeup", (makeupData),
            );

            if (res) {
                showSuccessToast("Tạo lịch học bù thành công!");
                setMakeupModalVisible(false);
                fetchClasses();
                // refresh lớp học nếu cần
            } else {
                showErrorToast("Tạo lịch học bù thất bại.");
            }
        } catch (error: any) {
            const detailError =
                error?.response?.data?.errors?.detail || error?.response?.data?.message || '❌ Cập nhật giáo viên thất bại!';
            showErrorToast(detailError);
            console.error("detailError", detailError);
            console.error("Lỗi tạo lịch học bù:", error);
        }
    };
    const [editForm, setEditForm] = useState(
        {
            id: '',
            className: '',
            courseID: 0,
            maxStudents: 0,
            startDate: '',
            endDate: '',
            status: 1,

        });
    const [editDialogOpen, setEditDialogOpen] = useState(false)

    const handleOpenEditForm = (cls: any) => {
        console.log(cls);
        setEditDialogOpen(true);
        setEditForm({
            id: cls.classID,
            className: cls.className,
            courseID: cls.courseID,
            maxStudents: cls.maxStudents,
            startDate: cls.startDate,
            endDate: cls.endDate,
            status: cls.status,
        });
    };


    const handleUpdateClass = async () => {
        const updatedData = {
            className: editForm.className,
            maxStudents: editForm.maxStudents,
            startDate: editForm.startDate,
            endDate: editForm.endDate,
            status: editForm.status,
        };

        console.log(updatedData);

        try {
            const response = await axios.put(`/Class/${editForm.id}`, updatedData, {
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            if (response) {
                showSuccessToast("Cập nhật khóa học thành công!");
                setEditDialogOpen(false);
            }
            fetchClasses();


        } catch (error) {
            showErrorToast("Cập nhật khóa học thất bại!");
        }
    };






    return (
        <div className=" mx-auto">
            <h1 className="text-2xl font-bold mb-4">Quản lý lớp học</h1>

            <button
                onClick={() => setFormVisible(prev => !prev)}
                className="mb-4 bg-green-600 text-white px-4 py-2 rounded hover:bg-green-700"
            >
                {formVisible ? 'Đóng form' : '➕ Thêm lớp học mới'}
            </button>

            {formVisible && (
                <form onSubmit={handleSubmit} className="space-y-4 border p-4 rounded-lg shadow-md bg-white mb-6">
                    <div>
                        <label className="block font-medium">Tên lớp</label>
                        <input
                            type="text"
                            name="className"
                            value={formData.className}
                            onChange={handleChange}
                            required
                            className="w-full border p-2 rounded"
                        />
                    </div>

                    <div>
                        <label className="block font-medium">Khóa học</label>
                        <select
                            name="courseID"
                            value={formData.courseID}
                            onChange={handleChange}
                            required
                            className="w-full border p-2 rounded"
                        >
                            <option value={0}>-- Chọn khóa học --</option>
                            {courses.map(course => (
                                <option key={course.courseID} value={course.courseID}>
                                    {course.courseName}
                                </option>
                            ))}
                        </select>
                    </div>

                    <div>
                        <label className="block font-medium">Số lượng học sinh tối đa</label>
                        <input
                            type="number"
                            name="maxStudents"
                            value={formData.maxStudents}
                            onChange={handleChange}
                            required
                            className="w-full border p-2 rounded"
                        />
                    </div>

                    <div>
                        <label className="block font-medium">Ngày bắt đầu</label>
                        <input
                            type="date"
                            name="startDate"
                            value={formData.startDate}
                            onChange={handleChange}
                            required
                            className="w-full border p-2 rounded"
                        />
                    </div>

                    <div>
                        <label className="block font-medium">Ngày kết thúc (có thể bỏ trống)</label>
                        <input
                            type="date"
                            name="endDate"
                            value={formData.endDate ?? ''}
                            onChange={handleChange}
                            className="w-full border p-2 rounded"
                        />
                    </div>

                    <div>
                        <label className="block font-medium">Trạng thái</label>
                        <select
                            name="status"
                            value={formData.status}
                            onChange={handleChange}
                            className="w-full border p-2 rounded"
                        >
                            <option value={1}>Đang học</option>
                            <option value={0}>Kết thúc</option>
                        </select>
                    </div>

                    <button
                        type="submit"
                        disabled={loading}
                        className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
                    >
                        {loading ? 'Đang xử lý...' : 'Thêm lớp học'}
                    </button>

                    {message && <p className="mt-2">{message}</p>}
                </form>
            )}

            <Table>
                <TableHeader>
                    <TableRow>
                        <TableHead>Tên lớp</TableHead>
                        <TableHead>Khóa học</TableHead>
                        <TableHead>Số lượng học sinh</TableHead>
                        <TableHead>Ngày bắt đầu</TableHead>
                        <TableHead>Ngày kết thúc</TableHead>
                        <TableHead>Trạng thái</TableHead>
                        <TableHead>Hành động</TableHead>
                        <TableHead>Note</TableHead>
                        <TableHead>Giảng viên</TableHead>
                    </TableRow>
                </TableHeader>
                <TableBody>
                    {classes.map((cls) => (
                        <TableRow key={cls.classID}>
                            <TableCell>{cls.className}</TableCell>
                            <TableCell>{cls.courseName}</TableCell>
                            <TableCell>{cls.enrolledStudents}/{cls.maxStudents}</TableCell>
                            <TableCell>{cls.startDate ? format(new Date(cls.startDate), 'dd/MM/yyyy') : ''}</TableCell>
                            <TableCell>{cls.endDate ? format(new Date(cls.endDate), 'dd/MM/yyyy') : ''}</TableCell>
                            <TableCell>
                                {cls.status === 1 ? (
                                    <span className="text-green-600 font-semibold">Đang học</span>
                                ) : (
                                    <span className="text-red-600 font-semibold">Kết thúc</span>
                                )}
                            </TableCell>
                            {/* 0 là chưa tạo lịch  1 chưa đủ 2 là bổ sung lịch dậy bù 3.Tạo lịch đủ  */}


                            <TableCell>
                                {cls.isHaveSchedule === 0 && (
                                    <button
                                        onClick={() => openScheduleModal(cls.classID, cls.startDate)}
                                        className="bg-purple-600 text-white px-3 py-1 rounded hover:bg-purple-700"
                                    >
                                        Tạo lịch học
                                    </button>
                                )}

                                {cls.isHaveSchedule === 1 && (
                                    <div className="text-yellow-600 font-semibold">Lịch chưa đủ</div>
                                )}

                                {(cls.isHaveSchedule === 2) && (
                                    <button
                                        onClick={() => handleCreateMakeupSchedule(cls)}
                                        className="bg-purple-600 text-white px-3 py-1 rounded hover:bg-purple-700"
                                    >
                                        Tạo lịch học bù
                                    </button>
                                )}

                                {cls.isHaveSchedule === 3 && (
                                    <div className="text-green-600 font-semibold">Đã có lịch đầy đủ</div>
                                )}
                            </TableCell>

                            <TableCell>{cls.note}</TableCell>
                            <TableCell>
                                {cls.isHaveTeacher ? <>
                                    {cls?.teacherName ?? ''}
                                </> : <>
                                    {cls.isHaveSchedule ? <>
                                        <Button onClick={() => handleOpenAssignDialog(cls.classID)}>Thêm giảng viên</Button>
                                    </> : <>
                                        -----
                                    </>}

                                </>}
                            </TableCell>

                            <Button
                                onClick={() => handleOpenEditForm(cls)}
                                className="bg-yellow-500 text-white px-3 py-1 rounded hover:bg-yellow-600"
                            >
                                ✏️ Sửa
                            </Button>



                        </TableRow>
                    ))}
                </TableBody>
            </Table>
            <Dialog open={makeupModalVisible} onOpenChange={setMakeupModalVisible}>
                <DialogContent className="max-w-xl">
                    <DialogHeader>
                        <DialogTitle>Tạo lịch học bù cho lớp #{makeupData.classID}</DialogTitle>
                        <DialogDescription>
                            Chọn thông tin buổi học bù và xác nhận tạo lịch.
                        </DialogDescription>
                    </DialogHeader>

                    <form onSubmit={handleMakeupSubmit} className="space-y-4 mt-4">

                        {/* Ngày học bù */}
                        <div>
                            <label className="block mb-1 font-medium">Ngày học bù:</label>
                            <input
                                type="date"
                                value={makeupData.date}
                                onChange={(e) => setMakeupData(prev => ({ ...prev, date: e.target.value }))}
                                required
                                className="w-full border p-2 rounded"
                            />
                        </div>

                        {/* Ca học */}
                        <div>
                            <label className="block mb-1 font-medium">Ca học:</label>
                            <select
                                value={makeupData.studySessionId}
                                onChange={(e) => setMakeupData(prev => ({ ...prev, studySessionId: Number(e.target.value) }))}
                                required
                                className="w-full border p-2 rounded"
                            >
                                <option value={0}>-- Chọn ca học --</option>
                                <option value={1}>Ca 1 (7:30 - 9:30)</option>
                                <option value={2}>Ca 2 (9:45 - 11:45)</option>
                                <option value={3}>Ca 3 (13:00 - 15:00)</option>
                                <option value={4}>Ca 4 (15:15 - 17:15)</option>
                                <option value={5}>Ca 5 (18:00 - 20:00)</option>
                            </select>
                        </div>

                        {/* Phòng học */}
                        <div>
                            <label className="block mb-1 font-medium">Phòng học:</label>
                            <select
                                value={makeupData.room}
                                onChange={(e) => setMakeupData(prev => ({ ...prev, room: e.target.value }))}
                                required
                                className="w-full border p-2 rounded"
                            >
                                <option value="">-- Chọn phòng học --</option>
                                <option value="Room 01">Room 01</option>
                                <option value="Room 02">Room 02</option>
                                <option value="Room 03">Room 03</option>
                            </select>
                        </div>

                        {/* Ghi chú */}
                        <div>
                            <label className="block mb-1 font-medium">Ghi chú:</label>
                            <textarea
                                value={makeupData.notes}
                                onChange={(e) => setMakeupData(prev => ({ ...prev, notes: e.target.value }))}
                                rows={3}
                                className="w-full border p-2 rounded"
                            />
                        </div>

                        {/* Buttons */}
                        <div className="flex justify-end gap-3">
                            <button
                                type="button"
                                onClick={() => setMakeupModalVisible(false)}
                                className="px-4 py-2 rounded border border-gray-400 hover:bg-gray-200"
                            >
                                Hủy
                            </button>
                            <button
                                type="submit"
                                className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
                            >
                                Tạo lịch học bù
                            </button>
                        </div>
                    </form>
                </DialogContent>
            </Dialog>


            <Dialog open={scheduleModalVisible} onOpenChange={setScheduleModalVisible}>
                <DialogContent className="max-w-4xl max-h-[90vh] overflow-auto">
                    <DialogHeader>
                        <DialogTitle>Tạo lịch học cho lớp #{scheduleData.classID}</DialogTitle>
                        <DialogDescription>
                            Vui lòng chọn phòng và các ca học theo ngày trong tuần.
                        </DialogDescription>
                    </DialogHeader>

                    <form onSubmit={handleScheduleSubmit} className="space-y-4 mt-4">

                        {/* Phòng học */}
                        <div>
                            <label className="block font-medium mb-1">Phòng học:</label>
                            <select
                                name="Room"
                                value={scheduleData.room}
                                onChange={e => setScheduleData(prev => ({ ...prev, room: e.target.value }))}
                                required
                                className="w-full border p-2 rounded"
                            >
                                <option value={0}>-- Chọn phòng học --</option>
                                <option value="Room 01">-- Room 01 --</option>
                                <option value="Room 02">-- Room 02 --</option>
                                <option value="Room 03">-- Room 03 --</option>
                            </select>
                        </div>

                        {/* Bảng chọn ca học */}
                        <div>
                            <label className="block font-medium mb-2">Chọn ca học trong tuần:</label>
                            <div className="overflow-auto max-h-[300px] border rounded p-2 bg-gray-50">
                                <table className="w-full border-collapse border border-gray-300 text-center">
                                    <thead>
                                        <tr>
                                            <th className="border border-gray-300 px-2 py-1">Ngày</th>
                                            {[1, 2, 3, 4, 5].map((_, i) => (
                                                <th key={i} className="border border-gray-300 px-2 py-1">
                                                    Ca {i + 1}
                                                </th>
                                            ))}
                                        </tr>
                                    </thead>
                                    <tbody>
                                        {daysOfWeek.map(day => (
                                            <tr key={day}>
                                                <td className="border border-gray-300 px-2 py-1 font-medium">{day}</td>
                                                {[1, 2, 3, 4, 5].map(idx => (
                                                    <td key={idx} className="border border-gray-300 px-2 py-1">
                                                        <input
                                                            type="checkbox"
                                                            name={`slot-${day}`}
                                                            checked={scheduleData.daysOfWeekSessions[day] === idx}
                                                            onChange={() => handleSlotChange(day, idx)}
                                                        />
                                                    </td>
                                                ))}
                                            </tr>
                                        ))}
                                    </tbody>
                                </table>
                            </div>
                        </div>

                        {/* Buttons */}
                        <div className="flex justify-end gap-3">
                            <button
                                type="button"
                                onClick={() => setScheduleModalVisible(false)}
                                className="px-4 py-2 rounded border border-gray-400 hover:bg-gray-200"
                            >
                                Hủy
                            </button>
                            <button
                                type="submit"
                                disabled={loading}
                                className="bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-700"
                            >
                                {loading ? 'Đang xử lý...' : 'Tạo lịch học'}
                            </button>
                        </div>
                    </form>
                </DialogContent>
            </Dialog>

            <Dialog open={openDialog} onOpenChange={setOpenDialog}>
                <DialogContent className="max-w-xl">
                    <DialogHeader>
                        <select
                            value={selectedTeacherID}
                            onChange={(e) => setSelectedTeacherID(e.target.value)}
                            className="w-full p-2 border border-gray-300 rounded mt-3"
                        >
                            <option value="">-- Chọn giảng viên --</option>
                            {teacherList.map((teacher) => (
                                <option key={teacher.teacherID} value={teacher.teacherID}>
                                    {teacher.fullName}
                                </option>
                            ))}
                        </select>
                    </DialogHeader>

                    <DialogFooter>
                        <Button variant="outline" onClick={() => setOpenDialog(false)}>
                            Hủy
                        </Button>
                        <Button onClick={handleAssignTeacher} disabled={!selectedTeacherID}>Gán</Button>
                    </DialogFooter>
                </DialogContent>

            </Dialog>

            <Dialog open={editDialogOpen} onOpenChange={setEditDialogOpen}>
                <DialogContent className="sm:max-w-[500px]">
                    <DialogHeader>
                        <DialogTitle>Cập nhật lớp học</DialogTitle>
                    </DialogHeader>

                    <div className="grid gap-4 py-4">
                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="className" className="text-right">
                                Tên lớp
                            </Label>
                            <Input
                                id="className"
                                value={editForm.className}
                                onChange={(e) =>
                                    setEditForm({ ...editForm, className: e.target.value })
                                }
                                className="col-span-3"
                            />
                        </div>

                        <div className="grid grid-cols-4 items-center gap-4">
                            <Label htmlFor="maxStudents" className="text-right">
                                Số lượng tối đa
                            </Label>
                            <Input
                                type="number"
                                id="maxStudents"
                                value={editForm.maxStudents}
                                onChange={(e) =>
                                    setEditForm({
                                        ...editForm,
                                        maxStudents: Number(e.target.value),
                                    })
                                }
                                className="col-span-3"
                            />
                        </div>
                    </div>

                    <DialogFooter>
                        <Button variant="secondary" onClick={() => setEditDialogOpen(false)}>
                            Hủy
                        </Button>
                        <Button onClick={handleUpdateClass}>Lưu</Button>
                    </DialogFooter>
                </DialogContent>
            </Dialog>

        </div>
    );
}
