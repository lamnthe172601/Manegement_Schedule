using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using Management_Schedule_BE.Common;

namespace Management_Schedule_BE.Middlewares
{
    public class ResponseWrapperMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseWrapperMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var originalBodyStream = context.Response.Body;
            using var memoryStream = new MemoryStream();
            context.Response.Body = memoryStream;

            await _next(context);

            memoryStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
            memoryStream.Seek(0, SeekOrigin.Begin);

            context.Response.Body = originalBodyStream;

            // Nếu response đã đúng format chuẩn thì trả về luôn, không wrap lại nữa
            if (!string.IsNullOrEmpty(responseBody))
            {
                try
                {
                    var json = JsonDocument.Parse(responseBody);
                    if (json.RootElement.ValueKind == JsonValueKind.Object &&
                        json.RootElement.TryGetProperty("status", out _) &&
                        json.RootElement.TryGetProperty("message", out _))
                    {
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(responseBody);
                        return;
                    }
                }
                catch { }
            }

            object data = null;
            object errors = null;
            string status;
            string message = null;

            if (context.Response.StatusCode >= 400)
            {
                status = "error";
                errors = !string.IsNullOrEmpty(responseBody) ? TryDeserialize(responseBody) : null;

                // Ưu tiên lấy message động từ response body nếu có
                message = ExtractMessageFromBody(errors);

                if (string.IsNullOrEmpty(message))
                {
                    switch (context.Response.StatusCode)
                    {
                        case 400:
                            message = "Dữ liệu không hợp lệ";
                            break;
                        case 401:
                            message = "Bạn chưa đăng nhập hoặc token hết hạn";
                            break;
                        case 403:
                            message = "Bạn không có quyền truy cập";
                            break;
                        case 404:
                            message = "Không tìm thấy tài nguyên";
                            break;
                        case 500:
                            message = "Lỗi hệ thống";
                            break;
                        default:
                            message = "Có lỗi xảy ra";
                            break;
                    }
                }
            }
            else
            {
                status = "success";
                // Ưu tiên lấy message động từ response body nếu có
                data = !string.IsNullOrEmpty(responseBody) ? TryDeserialize(responseBody) : null;
                message = ExtractMessageFromBody(data) ?? "Thành công";
            }

            var wrapper = new CommonResponse<object>(status, message, status == "success" ? data : null, status == "error" ? errors : null);
            var jsonStr = JsonSerializer.Serialize(wrapper);

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(jsonStr);
        }

        private object TryDeserialize(string responseBody)
        {
            try
            {
                return JsonSerializer.Deserialize<object>(responseBody);
            }
            catch
            {
                return responseBody;
            }
        }

        private string ExtractMessageFromBody(object body)
        {
            if (body is JsonElement je && je.ValueKind == JsonValueKind.Object && je.TryGetProperty("message", out var msg))
                return msg.GetString();
            if (body is System.Text.Json.Nodes.JsonObject jo && jo.TryGetPropertyValue("message", out var node))
                return node?.ToString();
            return null;
        }
    }
} 