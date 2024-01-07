using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo;
using MySqlConnector;
using Dapper;
using MISA.WebFresher072023.Demo.Controllers.Base;
using MISA.WebFresher072023.Demo.Application;
using MISA.WebFresher072023.Demo.Domain;

namespace MISA.WebFresher072023.Demo.Controllers
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class DepartmentsController : BaseReadOnlyController<DepartmentDto>
	{
		private readonly IDepartmentService _departmentService;
		public DepartmentsController(IDepartmentService departmentService) : base(departmentService)
		{
			_departmentService = departmentService;
		}

	

		

	}
}
