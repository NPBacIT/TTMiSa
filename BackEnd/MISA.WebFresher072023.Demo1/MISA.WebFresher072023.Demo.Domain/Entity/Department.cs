using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public class Department : BaseEntity, IEntity
	{
		public Guid DepartmentId { get; set; }
		public string DepartmentName { get; set; }
		public Guid GetId()
		{
			return DepartmentId;
		}

		public void SetId(Guid id)
		{
			DepartmentId = id;
		}
	}
}
