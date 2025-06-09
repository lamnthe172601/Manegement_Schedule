export class Endpoints {
  static readonly baseApiURL = {
    URL: process.env.NEXT_PUBLIC_API_URL,
  }
  static readonly Auth = {
    REGISTER: "Authentication/SignUp",
    LOGIN: "Authentication/SignIn",
    LOGOUT: "auth/logout",
    REFRESH: "auth/refresh",
    SENDOTP: "Authentication/send-otp",
    CHANGE_PASSWORD_FIRST_TIME: "auth/change-password-first-time",
    LOGIN_GOOGLE: "Authentication/login-google",
  }
  static readonly Fine = {
    GET_ALL: "fines",
    GET_BY_ID: (id: string) => `fines/${id}`,
    CREATE: "fines",
    UPDATE: (id: string) => `fines/${id}`,
    DELETE: (id: string) => `fines/${id}`,
    PATCH: (id: string) => `fines/${id}/pay`,
    GET_BY_USER: "fines/me",
  }

  static readonly Users = {
    GET_ALL: "User",
    GET_ALLV2: "User/v2",
    GET_BY_ID: (id: string) => `User/${id}`,
    RESET_PASSWORD: `User/update-password`,
    CREATE: "User",
    UPDATE: (id: string) => `User/${id}`,
    DELETE: (id: string) => `User/${id}`,
    GETUSERBYEMAIL: (email: string) => `User/${email}`,
    UPDATEBYEMAIL: (email: string) => `User/${email}`,
  }
  static readonly Classes = {
    GET_ALL: "Class",
    GET_COURSE_BY_STUDENT_ID: (studentId: string) =>
      `Class/student/${studentId}/enrolled`,
    GET_STUDENT_BY_CLASS_ID: (classId: number) => `Class/${classId}/students`,
    GET_ALL_BASIC: "Class/basic",
  }
  static readonly Schedule = {
    GET_ALL: "Schedule",
    GET_SCHEDULE_BY_STUDENT_ID: (studentid: string) =>
      `Schedule/student/${studentid}`,
    GET_SCHEDULE_BY_TEACHER_ID: (teacherid: string) =>
      `Schedule/teacher/${teacherid}`,
  }
  static readonly Books = {
    GET_ALL: "books",
    GET_ALL_V2: "books/v2",
    GET_BY_ID: (id: string) => `books/${id}`,
    CREATE: "books",
    UPDATE: (id: string) => `books/${id}`,
    DELETE: (id: string) => `books/${id}`,
  }
  static readonly Courses = {
    GET_ALL: "Course",
    GET_ALL_V2: "Courses/v2",
    GET_BY_ID: (id: number) => `Course/${id}`,
    CREATE: "Courses",
    UPDATE: (id: string) => `Courses/${id}`,
    DELETE: (id: string) => `Courses/${id}`,
  }

  static readonly Teacher = {
    GET_CLASS_BY_TEACHER_ID: (teacherId: string) =>
      `Teacher/${teacherId}/classes`,
  }
  static readonly Enrollment = {
    UPDATE_STATUS_ENROLL: (enrollId: number) => `Enrollment/${enrollId}/status`,
  }
  static readonly Report = {
    Dashboard: "Report/dashboard", // GET /api/Report/dashboard
    ScheduleStatusStatistics: "Report/schedule-status-statistics", // GET /api/Report/schedule-status-statistics
    TopTeachers: "Report/top-teachers", // GET /api/Report/top-teachers?top=5
    StudentDistributionByClass: "Report/student-distribution-by-class", // GET /api/Report/student-distribution-by-class
    Teacher: "Report/teacher", // GET /api/Report/teacher/{teacherId}
    Class: "Report/class", // GET /api/Report/class/{classId}
    Room: "Report/room", // GET /api/Report/room/{room}
    Daily: "Report/daily", // GET /api/Report/daily
    TeacherStatistics: "Report/teacher", // GET /api/Report/teacher/{teacherId}/statistics
    RoomStatistics: "Report/room", // GET /api/Report/room/{room}/statistics
  }
}
