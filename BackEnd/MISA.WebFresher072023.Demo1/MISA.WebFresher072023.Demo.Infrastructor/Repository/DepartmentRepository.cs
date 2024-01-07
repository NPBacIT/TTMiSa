using Microsoft.Extensions.Configuration;
using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Infrastruture
{
	public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
	{
		public DepartmentRepository(IConfiguration config) : base(config)
		{
		}
	}
}
