import { JwtUser, User } from "@/hooks/api/user/use-get-users"
import { atomWithStorage } from "jotai/utils"

// export const userInfoAtom = atomWithStorage<User | null>("userInfo", null)
export const userInfoAtom = atomWithStorage<JwtUser | null>("userInfo", null)
