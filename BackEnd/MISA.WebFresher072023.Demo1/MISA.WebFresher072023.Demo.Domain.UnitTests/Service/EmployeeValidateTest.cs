using MISA.WebFresher072023.Demo.Infrastruture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MISA.WebFresher072023.Demo.Domain.UnitTests
{
	[TestFixture]
	public class EmployeeValidateTest
	{
		[Test]    
		public async Task CheckEmployeeExitsAsync_NotExistEmployee_Success()
		{
			//Arrange
			var employee = new Employee();

			var employeeRepository = new EmployeeRepositoryFake();

			var employeeValidate = new EmployeeValidate(employeeRepository);

			//Act
			await employeeValidate.CheckEmployeeExistAsync(employee);

			//Assert
			Assert.That(employeeRepository.TotalCall, Is.EqualTo(1));

		}

		[Test]
		public async Task CheckEmployeeExitsAsync_ExistEmployee_Success()
		{
			//Arrange
			var employee = new Employee();

			var employeeRepository = new EmployeeRepositoryFake1();

			var employeeValidate = new EmployeeValidate(employeeRepository);

			//Act
			var exception = Assert.ThrowsAsync<ConflictException>(async()=>await employeeValidate.CheckEmployeeExistAsync(employee));
			Assert.That(exception.ErrorCode, Is.EqualTo(5464));

			Assert.That(employeeRepository.TotalCall, Is.EqualTo(1));

		}
	}
}
