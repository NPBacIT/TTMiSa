using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo;
using MySqlConnector;
using Dapper;
using System.Linq.Expressions;
using System.Data;
using MISA.WebFresher072023.Demo.Enum;
using MISA.WebFresher072023.Demo.Application;
using MISA.WebFresher072023.Demo.Domain;

using MISA.WebFresher072023.Demo.Controllers.Base;


namespace MISA.WebFresher072023.Demo.Controllers
{
    [Route("api/v1/[controller]")]
	[ApiController]
	public class EmployeesController : BaseController<EmployeeDto, EmployeeCretateDto, EmployeeUpdateDto>
	{


		protected readonly IEmployeeService EmployeeService;
		public EmployeesController(IEmployeeService employeeService) : base(employeeService)
		{

			EmployeeService = employeeService;
		}
		/// <summary>
		/// Lấy danh sách nhân viên
		/// </summary>
		/// <returns>
		/// 200 - Thông tin nhân viên tương ứng
		/// 400 - Bad request 
		/// 404 - Không tìm thấy nhân viên
		/// 500 - Lỗi ở phía máy chủ 
		/// </returns>
		/// Created by npbac - 11/09/2023
		



		/// <summary>
		/// Lấy thông tin nhân viên theo Id
		/// </summary>
		/// <param name="employeeId">Id của nhân viên</param>
		/// <returns>
		/// 200 - Thông tin nhân viên tương ứng
		/// 400 - Bad request 
		/// 404 - Không tìm thấy nhân viên
		/// 500 - Lỗi ở phía máy chủ 
		/// </returns>
		/// Created by npbac - 11/09/2023



		/// <summary>
		/// Thêm mới một nhân viên
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>
		/// 201 - Thông tin của nhân viên sau khi thêm thành công
		/// 400 - Input không hợp lệ 
		/// 401 - Chưa được cấp quyền 
		/// 500 - Lỗi ở phía máy chủ 
		/// </returns>
		/// Created by npbac - 11/09/2023


		/// <summary>
		/// check mã nhân viên
		/// </summary>
		/// <param name="ex"></param>
		/// <returns></returns>
		//

		//private bool CheckEmployeeCode(string emlpoyeeCode)
		//{
		//	var connectionString = "Host=18.179.16.166; Port=3306; Database = MISA.WEB202307.MF1756_NPBAC ;User Id=nvmanh; Password = 12345678";
		//	// Tạo kết nối đến cơ sở dữ liệu 
		//	var sqlConnection = new MySqlConnection(connectionString);

		//	var sqlCommand = $"SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";

		//	var dynamicParam = new DynamicParameters();

		//	dynamicParam.Add("@EmployeeCode", emlpoyeeCode);

		//	var res = sqlConnection.QueryFirstOrDefault<string>(sqlCommand, dynamicParam);

		//	if(res != null)
		//	{
		//		return true;
		//	}
		//	return false;


		//}


		//vaild Email
		//bool IsvAlidEmail(string email)
		//{
		//	var trimmedEmail = email.Trim();

		//	if(trimmedEmail.EndsWith("." )) {

		//		return false;
		//	}

		//	try
		//	{

		//		var addr = new System.Net.Mail.MailAddress(email);
		//		return addr.Address == trimmedEmail;
		//	}
		//	catch 
		//	{
		//		return false;
		//	}
		//}



		/// <summary>
		/// Cập nhập thông tin nhân viên 
		/// </summary>
		/// <param name="employeeId">Id của nhân viên</param>
		/// <param name="employee">Thông tin nhân viên cần cập nhật</param>
		/// <returns>
		/// 200 - Cập nhật thành công 
		/// 400 - Input không hợp lệ 
		/// 401 - Chưa được cấp quyền 
		/// 500 - Lỗi ở phía máy chủ 
		/// /// Created by npbac - 11/09/2023
		/// </returns>



		/// <summary>
		/// Xóa nhân viên theo id 
		/// </summary>
		/// <param name="employeeId">Id của nhân viên</param>
		/// 200 - Xóa thành công 
		/// 400 - Input không hợp lệ 
		/// 401 - Chưa được cấp quyền 
		/// 500 - Lỗi ở phía máy chủ 
		/// create by : npbac (11/9/2023)

	} 
}




