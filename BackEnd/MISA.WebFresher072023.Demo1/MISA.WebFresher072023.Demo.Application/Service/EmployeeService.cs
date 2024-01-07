using MISA.WebFresher072023.Demo.Application;
using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public class EmployeeService :BaseService<Employee, EmployeeDto, EmployeeCretateDto,EmployeeUpdateDto>, IEmployeeService

{
		private readonly IEmployeeRepository _employeeRepository ;

		private readonly IEmployeeValidate _employeeValidate ;

		public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeValidate employeeValidate) :base(employeeRepository)
		{

			_employeeRepository = employeeRepository;
			_employeeValidate = employeeValidate;

		}
	





		/// <summary>
		/// Chuyển từ employee create sang employee DTO
		/// </summary>
		/// <param name="employeeDTO">Dữ liệu của employee dto</param>
		/// <returns>employee</returns>
		/// Author: ptrung26 (16/09/2023)

		public override Employee MapCreateDtoToEntity(EmployeeCretateDto cretateDto)
		{
			var employee = new Employee()
			{
				EmployeeId = Guid.NewGuid(),
				EmployeeCode = cretateDto.EmployeeCode,
				FullName = cretateDto.FullName,
				Gender = cretateDto.Gender,
				DateOfBirth = cretateDto.DateOfBirth,
				DepartmentId = cretateDto.DepartmentId,
				Address = cretateDto.Address,
				Email = cretateDto.Email,
				TelephoneNumber = cretateDto.TelephoneNumber,
				BankAccount = cretateDto.BankAccount,
				BankBranchName = cretateDto.BankBranchName,
				BankName = cretateDto.BankName,
				PhoneNumber = cretateDto.PhoneNumber,
				PositionName = cretateDto.PositionName,
				IdentityDate = cretateDto.IdentityDate,
				IdentityNumber = cretateDto.IdentityNumber,
				IdentityPlace = cretateDto.IdentityPlace,
			};

			return employee;
		}
		/// <summary>
		/// cập nhật employee sang employee DTO
		/// </summary>
		/// <param name="employee">Dữ liệu của employee</param>
		/// <returns>employee DTO</returns>
		/// Author: npbac (18/09/2023)/// <summary>
		public override Employee MapUpdateDtoToEntity(EmployeeUpdateDto updateDto, Employee employee)
		{
			var newEmployee = new Employee()
			{

				
				EmployeeCode = updateDto.EmployeeCode,
				FullName = updateDto.FullName,
				Gender = updateDto.Gender,
				DateOfBirth = updateDto.DateOfBirth,
				DepartmentId = updateDto.DepartmentId,
				Address = updateDto.Address,
				Email = updateDto.Email,
				TelephoneNumber = updateDto.TelephoneNumber,
				BankAccount = updateDto.BankAccount,
				BankBranchName = updateDto.BankBranchName,
				BankName = updateDto.BankName,
				PhoneNumber = updateDto.PhoneNumber,
				PositionName = updateDto.PositionName,
				IdentityDate = updateDto.IdentityDate,
				IdentityNumber = updateDto.IdentityNumber,
				IdentityPlace = updateDto.IdentityPlace,
			};

			return newEmployee;
		}
		/// <summary>
		/// Chuyển từ employee sang employee DTO
		/// </summary>
		/// <param name="employee">Dữ liệu của employee</param>
		/// <returns>employee DTO</returns>
		/// Author: npbac (18/09/2023)
		public override EmployeeDto MapEntityToDto(Employee employee)
		{
			var employeeDto = new EmployeeDto()
			{
				EmployeeId = employee.EmployeeId,
				DepartmentId = employee.DepartmentId,
				EmployeeCode = employee.EmployeeCode,
				FullName = employee.FullName,
				PhoneNumber = employee.PhoneNumber,
				TelephoneNumber = employee.TelephoneNumber,
				Address = employee.Address,
				IdentityNumber = employee.IdentityNumber,
				IdentityDate = employee.IdentityDate,
				IdentityPlace = employee.IdentityPlace,
				Gender = employee.Gender,

			};
			return employeeDto;
		}

		public override async Task ValidateUpdateBusiness(Employee entity)
		{
			
			await _employeeValidate.CheckEmployeeExistAsync(entity);
		}
	}
}
