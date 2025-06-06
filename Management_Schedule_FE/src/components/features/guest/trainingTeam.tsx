import Image from "next/image"
import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import useGetUsers from "@/hooks/api/user/use-get-users"
export default function TrainingTeamPage() {
  const { data, error, isLoading } = useGetUsers()

  console.log(data)

  const teamMembers = data?.filter((user: any) => user.role === 2) || []
  console.log("teamMembers", teamMembers)

  return (
    <div className="container mx-auto px-4 py-8">
      <div className="text-center mb-12">
        <h1 className="text-3xl font-bold text-blue-500 mb-2"> LEARNING SYSTEM</h1>
        <p className="text-lg text-gray-600 max-w-3xl mx-auto">
          Hệ thống học tiếng Anh giao tiếp toàn diện cho người bắt đầu
        </p>
      </div>

      <div className="mb-16">
        <h2 className="text-xl font-semibold text-blue-500 text-center mb-8 relative">
          <span className="relative inline-block">
            ĐỘI NGŨ ĐÀO TẠO
            <div className="absolute bottom-[-10px] left-1/2 transform -translate-x-1/2 w-16 h-[2px] bg-blue-500"></div>
          </span>
        </h2>

        <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
          {teamMembers.map((member) => (
            <Card key={member.userID} className="border-0 shadow-md overflow-hidden">
              <CardContent className="p-0 text-center">
                <div className="relative w-40 h-40 mx-auto mt-6 mb-4">
                  <Image
                    src={member.avatarUrl || "/teacher.jpg"}
                    alt={member.fullName}
                    fill
                    className="rounded-full object-cover"
                  />
                </div>
                <h3 className="font-bold text-lg mb-1">Teacher:{member.fullName}</h3>
                <p className="text-gray-500 text-sm mb-3">{member.gender == "M" ? "Nam" : "Nữ"}</p>
                <div className="flex justify-center gap-2 mb-4">
                  <Badge className="bg-blue-500 hover:bg-blue-600 rounded-full w-6 h-6 p-0 flex items-center justify-center">
                    f
                  </Badge>
                  <Badge className="bg-sky-400 hover:bg-sky-500 rounded-full w-6 h-6 p-0 flex items-center justify-center">
                    t
                  </Badge>
                  <Badge className="bg-red-500 hover:bg-red-600 rounded-full w-6 h-6 p-0 flex items-center justify-center">
                    y
                  </Badge>
                  <Badge className="bg-pink-500 hover:bg-pink-600 rounded-full w-6 h-6 p-0 flex items-center justify-center">
                    i
                  </Badge>
                </div>
                <p className="text-sm text-gray-600 mb-6">{member.introduction}</p>
              </CardContent>
            </Card>
          ))}
        </div>
      </div>

    </div>
  )
}
