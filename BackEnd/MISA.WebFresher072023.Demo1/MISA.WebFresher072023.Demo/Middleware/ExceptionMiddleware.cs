using MISA.WebFresher072023.Demo.Domain;
namespace MISA.WebFresher072023.Demo
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public ExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}

		}
		private async Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			Console.WriteLine(exception);
			context.Response.ContentType = "application/json";

			if (exception is NotFoundException)
			{
				context.Response.StatusCode = StatusCodes.Status404NotFound;
				await context.Response.WriteAsync(new BaseException()
				{
					ErrorCode = ((NotFoundException)exception).ErrorCode,
					UserMsg = "Không tìm thấy tài nguyên",
					DevMsg = exception.Message,
					TraceId = context.TraceIdentifier,
					MoreInfo = exception.HelpLink

				}.ToString() ?? ""

			);

			}
			else if (exception is ConflictException conflictException) {
				context.Response.StatusCode = StatusCodes.Status409Conflict;
				await context.Response.WriteAsync(new BaseException()
				{
					ErrorCode = conflictException.ErrorCode,
					UserMsg = "Tài nguyên bị trùng",
					DevMsg = exception.Message,
					TraceId = context.TraceIdentifier,
					MoreInfo = exception.HelpLink

				}.ToString() ?? ""
				);
			}
            else
            {
				context.Response.StatusCode = StatusCodes.Status500InternalServerError;

				await context.Response.WriteAsync(new BaseException()
				{
					ErrorCode = context.Response.StatusCode,
					UserMsg = "Lỗi hệ thống",
					DevMsg = exception.Message,
					TraceId = context.TraceIdentifier,
					MoreInfo = exception.HelpLink

				}.ToString() ?? ""
			);
			}

        }

	}
}
