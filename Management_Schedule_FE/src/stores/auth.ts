import { User } from "@/hooks/api/user/use-get-users"
import { atomWithStorage } from "jotai/utils"
import { atom } from "jotai/vanilla"

// export const userInfoAtom = atomWithStorage<User | null>("userInfo", null)
const fakeUser: User = {
  _id: "demo-id-001",
  full_name: "Demo Admin",
  email: "admin@example.com",
  identity_number: "123456789",
  phone: "0123456789",
  role: "member",
  createdAt: new Date("2025-01-01T00:00:00Z"),
  updatedAt: new Date("2025-05-22T00:00:00Z"),
  is_active: true,
}

export const userInfoAtom = atom<User>(fakeUser)
