using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain.UnitTests
{
	public class EmployeeRepositoryFake : IEmployeeRepository
	{
		public int TotalCall { get; set; } = 0;
		public Task<int> DeleteAsync(Employee entity)
		{
			throw new NotImplementedException();
		}

		public Task<int> DeleteManyAsync(List<Employee> entities)
		{
			throw new NotImplementedException();
		}

		public Task<Employee?> FindAsync(Guid Id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Employee>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Employee?> GetAsync(Guid Id)
		{
			throw new NotImplementedException();
		}

		public Task<List<Employee>> GetByListIdAsync(List<Guid> ids)
		{
			throw new NotImplementedException();
		}

		public Task<int> InsertAsync(Employee entity)
		{
			throw new NotImplementedException();
		}

		public Task<bool> IsExistEmployeeAsync(string employeeCode)
		{
			TotalCall++;
			return Task.FromResult(false);
		}

		public Task<int> UpdateAsync(Employee entity)
		{
			throw new NotImplementedException();
		}
	}
}
