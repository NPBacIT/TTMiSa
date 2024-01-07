using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
	public class DepartmentService : BaseReadOnlyService<Department, DepartmentDto>, IDepartmentService
	{
		public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
		{

		}

		public override DepartmentDto MapEntityToDto(Department entity)
		{
			var departmentDto = new DepartmentDto()
			{
				DepartmentId = entity.DepartmentId,
				DepartmentName = entity.DepartmentName,
				CreateBy = entity.CreateBy,
				CreateDate = entity.CreateDate,
				ModifileBy = entity.ModifileBy,
				ModifiedDate = entity.ModifiedDate,
			};
			return departmentDto;
		}
	}
}
