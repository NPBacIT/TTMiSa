using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
	public interface IBaseReadOnlyService<TDto>
	{
		/// <summary>
		/// Lấy thông tin nhân viên
		/// </summary>
		/// <param name="employeeId">Id của nhân viên</param>
		/// <returns>Thông tin nhân viên</returns>
		/// Created by: npbac (18/09/2023) 
		Task<TDto> GetAsync(Guid Id);
		/// <summary>
		/// Lấy tất cả ttin nhân viên
		/// </summary>
		/// <param name="employeeId">Id của nhân viên</param>
		/// <returns>Thông tin nhân viên</returns>
		/// Created by: npbac (18/09/2023) 
		Task<List<TDto>> GetAll();
	}
}
