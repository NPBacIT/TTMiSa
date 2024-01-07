using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Domain
{
	public interface IBaseRepository<TEntity>
	{
		/// <summary>
		/// Hàm lấy toàn bộ danh sách
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<List<TEntity>> GetAllAsync();

		/// <summary>
		/// Tìm 1 bả ghi
		/// </summary>
		/// <param></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<TEntity?> FindAsync(Guid Id);
		/// <summary>
		/// Hàm lấy một nhân viên 
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<TEntity?> GetAsync(Guid Id);
		/// <summary>
		/// Thêm 1 bản ghi
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<int> InsertAsync(TEntity entity);

		/// <summary>
		/// Cập nhật 1 bản ghi
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<int> UpdateAsync(TEntity entity);
		/// <summary>
		/// Xóa 1 bản ghi
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task<int> DeleteAsync(TEntity entity);
		/// <summary>
		/// Xóa nhiều bản ghi
		/// </summary>
		/// <param ></param>
		/// <returns></returns>
		/// create by npbac(17/9/2023)
		Task <int>DeleteManyAsync(List<TEntity> entities);

		Task<List<TEntity>> GetByListIdAsync(List<Guid> ids);

	}
}
