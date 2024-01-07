using Dapper;
using MISA.WebFresher072023.Demo.Domain;
using MISA.WebFresher072023.Demo;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MISA.WebFresher072023.Demo.Infrastruture
{
	public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
	{
		private readonly IConfiguration _config;

		public EmployeeRepository(IConfiguration config) : base(config)
		{
			_config = config;
		}

		private MySqlConnection CreateConnection()
		{
			var connectionString = _config.GetConnectionString("DefaultConnection");
			return new MySqlConnection(connectionString);

		}








		/// <summary>
		/// Kiểm tra xem mã đã tồn tại chưa 
		/// </summary>
		/// <param name="employeeCode">mã nhân viên</param>
		/// <returns>Kết quả kiểm tra</returns>
		/// Created by: Npbac (1/09/2023)
		public async Task<bool> IsExistEmployeeAsync(string employeeCode)
		{
			var connetion = CreateConnection();

			// Câu truy vấn 
			string query = "Select * From Employee where EmployeeCode = @EmployeeCode";

			// Thêm các tham số 
			var parameters = new DynamicParameters();
			parameters.Add("@EmployeeCode", employeeCode);

			// Thực hiện truy vấn 
			var result = await connetion.QuerySingleOrDefaultAsync<Employee>(query, parameters);

			// Nếu không tìm thấy nhân viên
			if (result == null)
			{
				return false;
			}

			return true;
		}

		
	}
}
