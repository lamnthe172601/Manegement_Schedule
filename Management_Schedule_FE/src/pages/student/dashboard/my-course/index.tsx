import StudentLayout from "@/components/features/guest/StudentLayout"
import { Button } from "@/components/ui/button"
import Image from "next/image"
import { Plus } from "lucide-react"
function Page() {
  const listCourse = [
    {
      image: "/courses.png",
      name: "HTML CSS Pro",
    },
    {
      image: "/courses.png",
      name: "HTML CSS Pro",
    },
    {
      image: "/courses.png",
      name: "HTML CSS Pro",
    },
    {
      image: "/courses.png",
      name: "HTML CSS Pro",
    },
    {
      image: "/courses.png",
      name: "HTML CSS Pro",
    },
  ]
  return (
    <StudentLayout>
      <div className="mx-5 mt-3">
        <h1 className="font-extrabold text-3xl">Khóa học của tôi</h1>
        <h4 className="mt-2 text-gray-600">
          Bạn chưa hoàn thành khóa học nào.
        </h4>
        <div className="grid sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-x-1 gap-y-6 mt-[40px] ">
          {listCourse.map((c, index) => (
            <div className="relative group cursor-pointer" key={index}>
              <Image
                src={c.image}
                alt="khoa hoc"
                width={300}
                height={200}
                className="rounded-xl"
              />
              <h3 className="mt-2 mb-2 font-semibold">{c.name}</h3>
              <h4 className="text-gray-600 text-sm">
                Bạn chưa học khóa học này
              </h4>
              <div className="absolute inset-0 bg-[#00000033] bg-opacity-20 opacity-0 group-hover:opacity-100 transition duration-300 rounded-xl w-[300px] h-[170px]"></div>
              <Button
                className="absolute top-1/2 left-1/2 transform -translate-x-20 -translate-y-10
                     opacity-0 group-hover:opacity-100 hover:!bg-gray-400 transition duration-300
                     bg-white text-black px-4 py-2 rounded-full"
              >
                Bắt đầu học
              </Button>
            </div>
          ))}
          <div className="relative border-dotted border-5 rounded-xl flex flex-col items-center justify-center w-[300px] h-[200px]">
            <Button className="border-2 rounded-4xl bg-[#6A6A6A] mb-[50px]">
              <Plus size={20} />
            </Button>
            <Button className="text-[#91AD9C] border-2 rounded-xl border-[#91AD9C] bg-white">
              Thêm khóa học
            </Button>
          </div>
        </div>
      </div>
    </StudentLayout>
  )
}

export default Page
