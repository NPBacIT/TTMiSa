using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public interface IEntity
	{
		public Guid GetId();
		public void SetId(Guid id);
	}
}
