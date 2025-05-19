import Link from "next/link"
import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { ChevronRight } from "lucide-react"

export default function CoursesPage() {
  const proCourses = [
    {
      id: 1,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 10,
    },
    {
      id: 2,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 15,
    },
    {
      id: 3,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 12,
    },
    {
      id: 4,
      title: "Ngôn ngữ Sass",
      subtitle: "CSS Preprocessor",
      tags: ["HTML", "CSS Pro"],
      students: 8,
    },
  ]

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
          {proCourses.map((course) => (
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
                    {course.students} học viên đã học
                  </div>
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
