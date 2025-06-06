export class Endpoints {
  static readonly baseApiURL={
    URL: process.env.NEXT_PUBLIC_API_URL
  }
  static readonly Auth = {
    REGISTER: "Authentication/SignUp",
    LOGIN: "Authentication/SignIn",
    LOGOUT: "auth/logout",
    REFRESH: "auth/refresh",
    SENDOTP: "Authentication/send-otp",
    CHANGE_PASSWORD_FIRST_TIME: "auth/change-password-first-time",
    LOGIN_GOOGLE: "Authentication/login-google"

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
  static readonly Review = {
    CREATE: "reviews",
    GET_BY_USER_BY_BOOK_ID: (id: string) => `reviews/book/${id}/user`,
    GET_ALL: (id: string) => `reviews/book/${id}`,
    UPDATE: (id: string) => `reviews/${id}`,
    DELETE: (id: string) => `reviews/${id}`,
  }
  static readonly Users = {
    GET_ALL: "User",
    GET_ALLV2: "User/v2",
    GET_BY_ID: (id: string) => `User/${id}`,
    RESET_PASSWORD: `User/update-password`,
    CREATE: "User",
    UPDATE: (id: string) => `User/${id}`,
    DELETE: (id: string) => `User/${id}`,
    GETUSERBYEMAIL: (email:string) => `User/${email}`
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
    GET_BY_ID: (id: string) => `Courses/${id}`,
    CREATE: "Courses",
    UPDATE: (id: string) => `Courses/${id}`,
    DELETE: (id: string) => `Courses/${id}`,
  }
  static readonly Categories = {
    GET_ALL: "categories",
    GET_BY_ID: (id: string) => `categories/${id}`,
    CREATE: "categories",
    UPDATE: (id: string) => `categories/${id}`,
    DELETE: (id: string) => `categories/${id}`,
  }
}
