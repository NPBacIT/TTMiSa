using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	/// <summary>
	/// Validate nghiệp vụ
	/// </summary>
	public class EmployeeValidate : IEmployeeValidate
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeeValidate(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}


		public async Task CheckEmployeeExistAsync(Employee employee)
		{
			var isExistEmployee = false;
			isExistEmployee= await _employeeRepository.IsExistEmployeeAsync(employee.EmployeeCode);
			if (isExistEmployee)
			{
				throw new ConflictException(Resources.MISAResourceVN.EmployeeCode_Duplicate);
			}
		}
	}
}
