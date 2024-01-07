using MISA.WebFresher072023.Demo.Domain;
using MISA.WebFresher072023.Demo.Infrastruture;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application.UnitTests
{
	[TestFixture]
	public class EmployeeServiceTest
	{
		public IEmployeeRepository EmployeeRepository { get; set; }

		public IEmployeeValidate EmployeeValidate { get; set; }

		public EmployeeService EmployeeService { get; set; }

		[SetUp]

		public void Setup()
		{
			 EmployeeRepository = Substitute.For<IEmployeeRepository>();
			 EmployeeValidate = Substitute.For<IEmployeeValidate>();
			 EmployeeService = Substitute.For<EmployeeService>(EmployeeRepository,EmployeeValidate);

		}

		/// <summary>
		/// Test GetAllAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task GetAllAsync_ValidInput_Success()
		{
			// Arrange
			var employees = new List<Employee>();
			EmployeeRepository.GetAllAsync().Returns(employees);

			// Act
			await EmployeeService.GetAll();

			// Assert
			await EmployeeRepository.Received(1).GetAllAsync();
		}

		/// <summary>
		/// Test GetAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task GetAsync_ValidInput_Success()
		{
			// Arrange
			var guid = Guid.NewGuid();
			var employee = new Employee()
			{
				EmployeeId = guid,
			};
			EmployeeRepository.GetAsync(guid).Returns(employee);

			// Act
			await EmployeeService.GetAsync(guid);

			// Assert
			await EmployeeRepository.Received(1).GetAsync(guid);
		}


		/// <summary>
		/// Test InsertAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test] 
		public async Task InsertAsync_EmptyEmployeeId_ReturnIdNotEmpty()
		{
			//Arrage
			var employeeCreateDto = new EmployeeCretateDto();
			var employee = new Employee()
			{
				EmployeeId = Guid.Empty
			};

			EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

			//Act

			var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

			//Asert

			Assert.That(employee.EmployeeId, Is.Not.EqualTo(Guid.Empty));

			//await EmployeeService.Received(1).ValidateCreateBusiness(employee);

			//await EmployeeRepository.Received(1).InsertAsync(employee);


		}

		/// <summary>
		/// Test InsertAsync với audit bằng null
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)



		[Test]
		public async Task InsertAsync_EmployeeAuditNull_ReturnEmployeeAuditNotNull()
		{
			//Arrage
			var employeeCreateDto = new EmployeeCretateDto();
			var employee = new Employee()
			{
				EmployeeId = Guid.Empty
			};

			EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

			//Act

			var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

			//Asert

			Assert.That(employee.CreateBy, Is.EqualTo("NPBac"));

			Assert.That(employee.ModifileBy, Is.EqualTo("NPBac"));

			//await EmployeeService.Received(1).ValidateCreateBusiness(employee);

			//await EmployeeRepository.Received(1).InsertAsync(employee);


		}



		[Test]
		public async Task InsertAsync_ValidInput_Success()
		{
			//Arrage
			var employeeCreateDto = new EmployeeCretateDto();
			var employee = new Employee()
			{
				EmployeeId = Guid.Empty
			};

			EmployeeService.MapCreateDtoToEntity(employeeCreateDto).Returns(employee);

			//Act

			var employeeDto = await EmployeeService.InsertAsync(employeeCreateDto);

			//Asert

			await EmployeeService.Received(1).ValidateCreateBusiness(employee);

			await EmployeeRepository.Received(1).InsertAsync(employee);



		}


		/// <summary>
		/// Test UpdateAsync với đầu vào employee có audit null
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task UpdateAsync_EmployeeAuditNull_EmployeeAuditNotNull()
		{
			// Arrange
			var employeeUpdateDto = new EmployeeUpdateDto();
			var guid = Guid.NewGuid();
			var employee = new Employee();
			EmployeeRepository.GetAsync(guid).Returns(employee);
			EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(employee);

			// Act
			var employeeDto = await EmployeeService.UpdateAsync(guid, employeeUpdateDto);

			// Arrange
			Assert.That(employee.ModifileBy, Is.EqualTo("NPBac"));
		}

		/// <summary>
		/// Test UpdateAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task UpdateAsync_ValidInput_Success()
		{
			// Arrange
			var employeeUpdateDto = new EmployeeUpdateDto();
			var guid = Guid.NewGuid();
			var employee = new Employee();
			EmployeeRepository.GetAsync(guid).Returns(employee);
			EmployeeService.MapUpdateDtoToEntity(employeeUpdateDto, employee).Returns(employee);

			// Act
			var employeeDto = await EmployeeService.UpdateAsync(guid, employeeUpdateDto);

			// Arrange
			await EmployeeService.Received(1).ValidateUpdateBusiness(employee);
			await EmployeeRepository.Received(1).UpdateAsync(employee);
			EmployeeService.Received(1).MapEntityToDto(employee);
		}


		/// <summary>
		/// Test DeleteAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task DeleteAsync_ValidInput_Success()
		{
			// Arrange
			var guid = Guid.NewGuid();
			var employee = new Employee();
			EmployeeRepository.GetAsync(guid).Returns(employee);
			// Act
			await EmployeeService.DeleteAsync(guid);

			// Assert
			await EmployeeRepository.Received(1).GetAsync(guid);
			await EmployeeRepository.Received(1).DeleteAsync(employee);
		}
		/// <summary>
		/// Test DeleteManyAsync với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task DeleteManyAsync_ValidInput_Success()
		{
			// Arrange
			List<Guid> ids = new List<Guid>();
			var employees = new List<Employee>();
			EmployeeRepository.GetByListIdAsync(ids).Returns(employees);

			// Act
			await EmployeeService.DeleteManyAsync(ids);

			// Assert
			await EmployeeRepository.Received(1).GetByListIdAsync(ids);
			await EmployeeRepository.Received(1).DeleteManyAsync(employees);
		}


		/// <summary>
		/// Test ValidateUpdateBusines với đầu vào hợp lệ
		/// </summary>
		/// <returns></returns>
		/// Created by: NPBac (24/09/2023)
		[Test]
		public async Task ValidateUpdateBusiness_ValidInput_Success()
		{
			// Arrange
			var employee = new Employee();
			var employeeService = new EmployeeService(EmployeeRepository, EmployeeValidate);
			// Act
			await employeeService.ValidateUpdateBusiness(employee);
			// Assert
			await EmployeeValidate.Received(1).CheckEmployeeExistAsync(employee);
		}


	}
}
