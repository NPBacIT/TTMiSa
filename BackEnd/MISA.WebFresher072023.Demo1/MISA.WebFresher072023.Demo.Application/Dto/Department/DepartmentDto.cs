using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
	public class DepartmentDto : BaseDto
	{
		/// <summary>
		/// Mã phòng ban
		/// </summary>
		public Guid DepartmentId { get; set; }

		/// <summary>
		/// Tên phòng ban
		/// </summary>
		public string DepartmentName { get; set; }
	}
}
