import Link from "next/link"
import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { ChevronRight, Clock } from "lucide-react"
import useGetCourses from "@/hooks/api/course/use-get-course"
import { Button } from "@/components/ui/button"

export default function CoursesPage() {

  const { data, error, isLoading } = useGetCourses()
  const freeCourses = [
    {
      id: 5,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 25,
    },
    {
      id: 6,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 18,
    },
    {
      id: 7,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 22,
    },
    {
      id: 8,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 30,
    },
  ]

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="mb-10">
        <h2 className="text-lg font-semibold flex items-center mb-4">
          <Badge className="bg-blue-500 text-white mr-2">Pro</Badge>
          Khóa học Pro
        </h2>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
          {data?.map((course) => (
            <Card key={course.courseID} className="overflow-hidden border-0 shadow-md relative">
              <CardContent className="p-0">
                {course.isPro && <Badge
                  variant="outline"
                  className="absolute w-18 right-2 top-2 rounded-full px-3 py-1 text-xs font-semibold bg-gradient-to-r from-purple-500 to-indigo-500 text-white shadow-md z-10"
                >
                  Pro
                </Badge>}

                <div className="bg-pink-500 text-white p-6 text-center">
                  <h3 className="font-bold text-xl mb-1">{course.courseName}</h3>
                  <p className="text-sm opacity-90">{course.description}</p>
                </div>
                <div className="p-4 flex justify-between">


                  <div className="text-sm text-gray-500 flex items-center">
                    Time học: <Clock className="w-4 h-4 mr-2" />{course.duration}Giờ

                  </div>
                  <div className="text-sm text-gray-500 flex items-center">
                    <Clock className="w-4 h-4 mr-2" />
                    Giảm Giá {course.discountPercent} %
                  </div>

                </div>
                <div className="flex justify-center mt-4">
                  {!course.isComingSoon ? (
                    <Button>Mua khóa học</Button>
                  ) : (
                    <span className="text-yellow-600 font-semibold">Sắp ra mắt</span>
                  )}
                </div>

              </CardContent>
            </Card>
          ))}
        </div>
      </div>

      <div className="mb-10">
        <div className="flex justify-between items-center mb-4">
          <h2 className="text-lg font-semibold">Khóa học miễn phí</h2>
          <Link href="/khoa-hoc-mien-phi" className="text-sm text-gray-500 flex items-center hover:text-blue-500">
            Xem tất cả <ChevronRight size={16} />
          </Link>
        </div>

        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
          {freeCourses.map((course) => (
            <Card key={course.id} className="overflow-hidden border-0 shadow-md">
              <CardContent className="p-0">
                <div className="bg-pink-500 text-white p-6 text-center">
                  <h3 className="font-bold text-xl mb-1">{course.title}</h3>
                  <p className="text-sm opacity-90">{course.subtitle}</p>
                </div>
                <div className="p-4">
                  <div className="flex flex-wrap gap-2 mb-3">
                    {course.tags.map((tag, index) => (
                      <Badge key={index} variant="outline" className="bg-gray-100 text-gray-700 border-0">
                        {tag}
                      </Badge>
                    ))}
                  </div>
                  <div className="text-sm text-gray-500">
                    <span className="inline-block mr-2">👤</span>
                    {course.students} học viên
                  </div>
                </div>
              </CardContent>
            </Card>
          ))}
        </div>
      </div>

    </div>
  )
}
