using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.WebFresher072023.Demo.Application;

namespace MISA.WebFresher072023.Demo.Controllers.Base
{

	public class BaseController<TDto, TCreateDto, TUpdateDto> : BaseReadOnlyController<TDto>
	{
		protected readonly IBaseService<TDto, TCreateDto, TUpdateDto> BaseService;
	
		public BaseController(IBaseService<TDto, TCreateDto, TUpdateDto> baseService) : base(baseService)
		{
			BaseService = baseService;


		}

	

		[HttpPost]
		public async Task<int> InsertAsync([FromBody] TCreateDto createDto)
		{
			var result = await BaseService.InsertAsync(createDto);
			return result;
		}

		[HttpPut("{id}")]
		public async Task<int> UpdateAsync(Guid id, [FromBody] TUpdateDto updateDto)
		{
			var result = await BaseService.UpdateAsync(id, updateDto);
			return result;
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<int> DeleteAsync(Guid id)
		{
			var result = await BaseService.DeleteAsync(id);
			return result;
		}

		[HttpDelete()]
		public async Task<int> DeleteMultipleAsync(List<Guid> ids)
		{
			var result = await BaseService.DeleteManyAsync(ids);
			return result;
		}

	}
}
