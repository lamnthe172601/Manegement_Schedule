import Link from "next/link"
import { Phone, Mail } from "lucide-react"

export default function Footer() {
  return (
    <footer className="bg-blue-500 text-white py-3">
      <div className="container mx-auto px-4">
        <div className="flex flex-col md:flex-row items-center justify-center space-y-2 md:space-y-0 md:space-x-8">
          <div className="flex items-center">
            <Mail className="mr-2" size={18} />
            <Link href="mailto:info@landmaster.com" className="text-sm">
              info@landmaster.com
            </Link>
          </div>
          <div className="flex items-center">
            <Phone className="mr-2" size={18} />
            <Link href="tel:+84123456789" className="text-sm">
              Hotline: 0123 456 789
            </Link>
          </div>
        </div>
      </div>
    </footer>
  )
}
