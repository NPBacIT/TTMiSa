using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
    public interface IBaseService<TDto, TCretateDto, TUpdateDto> : IBaseReadOnlyService<TDto>
    {
       

        /// <summary>
        /// thêm nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Thông tin nhân viên</returns>
        /// Created by: npbac (18/09/2023) 
        Task<int> InsertAsync(TCretateDto cretateDto);

        /// <summary>
        /// cập nhật ttin nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Thông tin nhân viên</returns>
        /// Created by: npbac (18/09/2023) 
        Task<int> UpdateAsync(Guid Id, TUpdateDto updateDto);
        /// <summary>
        /// xóa ttin nhân viên
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns>Thông tin nhân viên</returns>
        /// Created by: npbac (18/09/2023) 
        Task<int> DeleteAsync(Guid Id);

        Task<int> DeleteManyAsync(List<Guid> Ids);
    }
}
