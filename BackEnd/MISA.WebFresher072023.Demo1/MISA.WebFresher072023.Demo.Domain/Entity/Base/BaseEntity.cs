using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public class BaseEntity
	{
		public string? CreateBy { get; set; }

		public DateTime? CreateDate { get; set; }

		public string? ModifileBy
		{
			get; set;

		}
		public DateTime? ModifiedDate { get; set; }
	}
}
