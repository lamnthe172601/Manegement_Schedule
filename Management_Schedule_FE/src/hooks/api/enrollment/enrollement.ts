export interface Enrollment{
    classID: number,
    className: string,
    courseName: string,
    enrollmentID: number,
    studentID: number,
    studentName: string,
    enrollmentDate: string,
    totalTuitionDue:number,
    tuitionPaid: number,
    remainingAmount: number,
    status: number,
    createdAt: Date,
    modifiedAt: Date
}