using System.Security.Cryptography;
using System.Text;

namespace Management_Schedule_BE.Helpers
{
    public class PasswordHassing
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Tạo đối tượng SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi chuỗi đầu vào thành byte[]
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Chuyển đổi byte[] thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // định dạng hex 2 chữ số
                }
                return builder.ToString();
            }
        }
    }
}
