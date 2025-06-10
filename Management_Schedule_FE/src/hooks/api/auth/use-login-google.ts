import { showErrorToast } from "@/components/common/toast/toast";
import { useAxios } from "@/hooks/api/use-axios"
import { Endpoints } from "@/lib/endpoints"
import { useState } from "react"
export const useLoginGoogle = () => {
    const axios = useAxios();
    const [loading, setLoading] = useState(false);

    const loginGoogle = async (tokenId: string) => {
        try {
            setLoading(true);
            debugger
            console.log(Endpoints.baseApiURL.URL, Endpoints.Auth.LOGIN_GOOGLE);
            const response = await axios.post(`${Endpoints.baseApiURL.URL}${Endpoints.Auth.LOGIN_GOOGLE}`, {
                idToken: tokenId
            });
            const result = response.data;
            return result;
        } catch (error: any) {
            const errorMessage =
                error?.response?.data?.message ||
                error?.message ||
                "Đăng nhập thất bại"
            showErrorToast(errorMessage)
            throw error
        } finally {
            console.log("🔵 Kết thúc login")
            setLoading(false)
        }
    }
    return { loginGoogle, loading }
}