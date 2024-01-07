using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public interface IEmployeeValidate
	{
		/// <summary>
		/// Kiểm tra có tồn tại employeeCode chưaa
		/// </summary>
		/// <param name="employeeCode"></param>
		/// <returns>
		/// 
		/// </returns>
		/// create : npbac(17/9/2023)
		Task CheckEmployeeExistAsync(Employee employee);
	}
}
