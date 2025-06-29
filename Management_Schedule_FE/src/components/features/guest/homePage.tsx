import Image from "next/image"
import Link from "next/link"
import { Button } from "@/components/ui/button"
import { Card, CardContent } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { ArrowRight, Star, Users, BookOpen, Award } from "lucide-react"
import useGetCourses from "@/hooks/api/course/use-get-course"

export default function HomePage() {
    const { data = [], isLoading, error } = useGetCourses();
    console.log("data", data)
    return (
        <div className="flex flex-col min-h-screen">
            {/* Hero Section */}
            {/* Features Section */}
            <section className="py-16 bg-white">
                <div className="container mx-auto px-4">
                    <div className="text-center mb-12">
                        <h2 className="text-2xl md:text-3xl font-bold text-gray-800 mb-4">Tại sao chọn chúng tôi?</h2>
                        <p className="text-gray-600 max-w-2xl mx-auto">
                            Chúng tôi cung cấp phương pháp học tiếng Anh hiệu quả với đội ngũ giảng viên chuyên nghiệp và nội dung
                            được thiết kế riêng cho người Việt.
                        </p>
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                        <Card className="border-0 shadow-md hover:shadow-lg transition-shadow">
                            <CardContent className="p-6 text-center">
                                <div className="w-16 h-16 bg-blue-100 rounded-full flex items-center justify-center mx-auto mb-4">
                                    <BookOpen className="w-8 h-8 text-blue-500" />
                                </div>
                                <h3 className="text-xl font-semibold mb-3 text-gray-800">Phương pháp học hiệu quả</h3>
                                <p className="text-gray-600">
                                    Phương pháp học tập trung vào giao tiếp thực tế, giúp học viên tự tin sử dụng tiếng Anh trong mọi tình
                                    huống.
                                </p>
                            </CardContent>
                        </Card>

                        <Card className="border-0 shadow-md hover:shadow-lg transition-shadow">
                            <CardContent className="p-6 text-center">
                                <div className="w-16 h-16 bg-pink-100 rounded-full flex items-center justify-center mx-auto mb-4">
                                    <Users className="w-8 h-8 text-pink-500" />
                                </div>
                                <h3 className="text-xl font-semibold mb-3 text-gray-800">Đội ngũ giảng viên chuyên nghiệp</h3>
                                <p className="text-gray-600">
                                    Giảng viên có nhiều năm kinh nghiệm giảng dạy, tận tâm hỗ trợ học viên trong suốt quá trình học.
                                </p>
                            </CardContent>
                        </Card>

                        <Card className="border-0 shadow-md hover:shadow-lg transition-shadow">
                            <CardContent className="p-6 text-center">
                                <div className="w-16 h-16 bg-green-100 rounded-full flex items-center justify-center mx-auto mb-4">
                                    <Award className="w-8 h-8 text-green-500" />
                                </div>
                                <h3 className="text-xl font-semibold mb-3 text-gray-800">Chứng chỉ được công nhận</h3>
                                <p className="text-gray-600">
                                    Hoàn thành khóa học, học viên nhận được chứng chỉ có giá trị cao, được nhiều doanh nghiệp công nhận.
                                </p>
                            </CardContent>
                        </Card>
                    </div>
                </div>
            </section>

            <section className="py-16 bg-gray-50">
                <div className="container mx-auto px-4">
                    <div className="flex justify-between items-center mb-10">
                        <h2 className="text-2xl md:text-3xl font-bold text-gray-800">Khóa học nổi bật</h2>
                        <Link href="/khoa-hoc" className="text-blue-500 hover:text-blue-600 flex items-center">
                            Xem tất cả <ArrowRight className="ml-2 w-4 h-4" />
                        </Link>
                    </div>

                    {isLoading ? (
                        <p>Đang tải khóa học...</p>
                    ) : error ? (
                        <p>Không thể tải khóa học</p>
                    ) : (
                        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-4 gap-6">
                            {data.map((course) => (
                                <Card key={course.courseID} className="overflow-hidden border-0 shadow-md hover:shadow-lg transition-shadow">
                                    <CardContent className="p-0">
                                        <div className="relative h-72 bg-gray-200">
                                            {course.thumbnailUrl ? (
                                                <img
                                                    src={course.thumbnailUrl}
                                                    alt={course.courseName}
                                                    className="w-full h-full object-cover"
                                                />
                                            ) : (
                                                <div className="w-full h-full flex items-center justify-center text-gray-500 text-sm">
                                                    Không có ảnh
                                                </div>
                                            )}
                                            <div className="absolute top-2 right-2">
                                                <Badge className="bg-blue-500">Nổi bật</Badge>
                                            </div>
                                        </div>
                                        <div className="p-5">
                                            <div className="flex justify-between items-center mb-2">
                                                <Badge variant="outline" className="bg-gray-100 text-gray-700 border-0">
                                                    {course.level === 1 ? "Cơ bản" : course.level === 2 ? "Trung cấp" : "Nâng cao"}
                                                </Badge>
                                                <div className="flex items-center text-yellow-500">
                                                    <Star className="fill-current w-4 h-4" />
                                                    <span className="text-sm ml-1">4.9</span>
                                                </div>
                                            </div>
                                            <h3 className="font-bold text-lg mb-2">{course.courseName}</h3>
                                            <p className="text-gray-600 text-sm mb-4">{course.description}</p>
                                            <div className="flex justify-between items-center">
                                                <span className="text-blue-500 font-bold">
                                                    {course.price === 0 ? "Miễn phí" : course.price.toLocaleString("vi-VN") + "₫"}
                                                </span>
                                                <span className="text-sm text-gray-500">120 học viên</span>
                                            </div>
                                        </div>
                                    </CardContent>
                                </Card>
                            ))}
                        </div>
                    )}
                </div>
            </section>

            {/* Statistics */}
            <section className="py-16 bg-blue-500 text-white">
                <div className="container mx-auto px-4">
                    <div className="grid grid-cols-2 md:grid-cols-4 gap-8 text-center">
                        <div>
                            <div className="text-4xl md:text-5xl font-bold mb-2">10K+</div>
                            <p className="text-blue-100">Học viên</p>
                        </div>
                        <div>
                            <div className="text-4xl md:text-5xl font-bold mb-2">50+</div>
                            <p className="text-blue-100">Khóa học</p>
                        </div>
                        <div>
                            <div className="text-4xl md:text-5xl font-bold mb-2">30+</div>
                            <p className="text-blue-100">Giảng viên</p>
                        </div>
                        <div>
                            <div className="text-4xl md:text-5xl font-bold mb-2">95%</div>
                            <p className="text-blue-100">Đánh giá tích cực</p>
                        </div>
                    </div>
                </div>
            </section>

            {/* Testimonials */}
            <section className="py-16 bg-white">
                <div className="container mx-auto px-4">
                    <div className="text-center mb-12">
                        <h2 className="text-2xl md:text-3xl font-bold text-gray-800 mb-4">Học viên nói gì về chúng tôi</h2>
                        <p className="text-gray-600 max-w-2xl mx-auto">
                            Hàng ngàn học viên đã thành công trong việc học tiếng Anh với Learning System
                        </p>
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                        {[1, 2, 3].map((id) => (
                            <Card key={id} className="border-0 shadow-md">
                                <CardContent className="p-6">
                                    <div className="flex items-center text-yellow-500 mb-4">
                                        {[...Array(5)].map((_, i) => (
                                            <Star key={i} className="w-4 h-4 fill-current" />
                                        ))}
                                    </div>
                                    <p className="text-gray-600 mb-6 italic">
                                        {id === 1 &&
                                            "Tôi đã học tiếng Anh nhiều năm nhưng chưa bao giờ tự tin giao tiếp. Sau 3 tháng học tại đây, tôi đã có thể nói chuyện với đồng nghiệp nước ngoài một cách tự tin."}
                                        {id === 2 &&
                                            "Phương pháp giảng dạy rất hiệu quả và dễ hiểu. Giảng viên nhiệt tình và luôn sẵn sàng giải đáp thắc mắc. Tôi đã cải thiện kỹ năng tiếng Anh rất nhiều."}
                                        {id === 3 &&
                                            "Nội dung khóa học được thiết kế rất khoa học và phù hợp với người Việt. Tôi đặc biệt thích cách họ dạy phát âm và ngữ điệu, giúp tôi nói tiếng Anh tự nhiên hơn."}
                                    </p>
                                    <div className="flex items-center">
                                        <div className="w-12 h-12 rounded-full overflow-hidden mr-4">
                                            <Image
                                                src={`/avatar-${id}.jpg`}
                                                alt={`Học viên ${id}`}
                                                width={48}
                                                height={48}
                                                className="object-cover"
                                            />
                                        </div>
                                        <div>
                                            <h4 className="font-semibold text-gray-800">
                                                {id === 1 && "Nguyễn Văn A"}
                                                {id === 2 && "Trần Thị B"}
                                                {id === 3 && "Lê Văn C"}
                                            </h4>
                                            <p className="text-sm text-gray-500">
                                                {id === 1 && "Nhân viên văn phòng"}
                                                {id === 2 && "Sinh viên"}
                                                {id === 3 && "Doanh nhân"}
                                            </p>
                                        </div>
                                    </div>
                                </CardContent>
                            </Card>
                        ))}
                    </div>
                </div>
            </section>

            {/* CTA Section */}
            <section className="py-16 bg-gray-50">
                <div className="container mx-auto px-4">
                    <div className="max-w-3xl mx-auto text-center">
                        <h2 className="text-2xl md:text-3xl font-bold text-gray-800 mb-4">
                            Sẵn sàng bắt đầu hành trình học tiếng Anh?
                        </h2>
                        <p className="text-gray-600 mb-8">
                            Đăng ký ngay hôm nay để nhận ưu đãi đặc biệt và bắt đầu hành trình chinh phục tiếng Anh cùng chúng tôi
                            Learning System.
                        </p>
                        <div className="flex flex-col sm:flex-row justify-center gap-4">
                            <Button size="lg" className="bg-blue-500 hover:bg-blue-600">
                                Đăng ký ngay
                            </Button>
                            <Button size="lg" variant="outline" className="border-blue-500 text-blue-500 hover:bg-blue-50">
                                Tư vấn miễn phí
                            </Button>
                        </div>
                    </div>
                </div>
            </section>

            {/* Blog/News Section */}
            <section className="py-16 bg-white">
                <div className="container mx-auto px-4">
                    <div className="flex justify-between items-center mb-10">
                        <h2 className="text-2xl md:text-3xl font-bold text-gray-800">Tin tức & Bài viết</h2>
                        <Link href="/tin-tuc" className="text-blue-500 hover:text-blue-600 flex items-center">
                            Xem tất cả <ArrowRight className="ml-2 w-4 h-4" />
                        </Link>
                    </div>

                    <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
                        {[1, 2, 3].map((id) => (
                            <Card key={id} className="border-0 shadow-md hover:shadow-lg transition-shadow">
                                <CardContent className="p-0">
                                    <div className="relative h-48">
                                        <Image src={`/blog-${id}.jpg`} alt={`Bài viết ${id}`} fill className="object-cover" />
                                    </div>
                                    <div className="p-5">
                                        <div className="flex items-center mb-3">
                                            <Badge variant="outline" className="bg-gray-100 text-gray-700 border-0">
                                                {id === 1 && "Phương pháp học"}
                                                {id === 2 && "Kinh nghiệm"}
                                                {id === 3 && "Tin tức"}
                                            </Badge>
                                            <span className="text-sm text-gray-500 ml-3">12/05/2023</span>
                                        </div>
                                        <h3 className="font-bold text-lg mb-2">
                                            {id === 1 && "5 phương pháp học tiếng Anh hiệu quả"}
                                            {id === 2 && "Kinh nghiệm luyện nói tiếng Anh lưu loát"}
                                            {id === 3 && "Xu hướng học tiếng Anh online năm 2023"}
                                        </h3>
                                        <p className="text-gray-600 text-sm mb-4">
                                            {id === 1 && "Khám phá 5 phương pháp học tiếng Anh hiệu quả giúp bạn tiến bộ nhanh chóng..."}
                                            {id === 2 && "Những bí quyết giúp bạn luyện nói tiếng Anh lưu loát như người bản xứ..."}
                                            {id === 3 && "Tìm hiểu xu hướng học tiếng Anh online đang được ưa chuộng nhất hiện nay..."}
                                        </p>
                                        <Link
                                            href={`/tin-tuc/${id}`}
                                            className="text-blue-500 hover:text-blue-600 font-medium flex items-center"
                                        >
                                            Đọc tiếp <ArrowRight className="ml-2 w-4 h-4" />
                                        </Link>
                                    </div>
                                </CardContent>
                            </Card>
                        ))}
                    </div>
                </div>
            </section>


        </div>
    )
}
