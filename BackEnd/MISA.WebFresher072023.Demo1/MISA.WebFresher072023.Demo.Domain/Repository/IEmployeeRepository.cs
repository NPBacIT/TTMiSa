using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	/// <summary>
	/// interface tương tác với Repository
	/// </summary>
	public interface IEmployeeRepository : IBaseRepository<Employee>
	{
	
		Task<bool> IsExistEmployeeAsync(string employeeCode);
		
	}
}
