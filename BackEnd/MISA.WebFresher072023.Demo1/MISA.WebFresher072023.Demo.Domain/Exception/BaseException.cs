using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public class BaseException
	{

		public string? DevMsg { get; set; }

		public string? UserMsg { get; set; }

		public object? Data { get; set; }

		public int? ErrorCode { get; set; }

		public string? MoreInfo { get; set; }

		public string? TraceId { get; set; }


		/// <summary>
		/// 
		///Trả về 1 chuỗi json// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}
}
