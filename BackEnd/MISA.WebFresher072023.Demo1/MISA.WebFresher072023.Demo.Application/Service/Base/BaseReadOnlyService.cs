using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
	public abstract class BaseReadOnlyService<TEntity,TDto> : IBaseReadOnlyService<TDto>
	{
		protected readonly IBaseRepository<TEntity> BaseRepository;

		protected BaseReadOnlyService(IBaseRepository<TEntity> baseRepository)
		{
			BaseRepository = baseRepository;
		}
		public async Task<List<TDto>> GetAll()
		{
			var entities = await BaseRepository.GetAllAsync();

			var result = entities.Select(entity => MapEntityToDto(entity)).ToList();

			return result;
		}

		public async Task<TDto> GetAsync(Guid Id)
		{
			var entity = await BaseRepository.GetAsync(Id);

			var result = MapEntityToDto(entity);

			return result;
		}

		public abstract TDto MapEntityToDto(TEntity entity);
	}
}
