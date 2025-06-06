export interface Enrollment{
    enrollmentID: number,
    studentID: number,
    studentName: string,
    classID: number,
    className: string,
    courseName: string,
    enrollmentDate: string,
    totalTuitionDue:number,
    tuitionPaid: number,
    remainingAmount: number,
    status: number,
    createdAt: Date,
    modifiedAt: Date
}