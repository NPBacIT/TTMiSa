using MISA.WebFresher072023.Demo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MISA.WebFresher072023.Demo.Application
{
	public abstract class BaseService<TEntity, TDto, TCreateDto, TUpdateDto> : BaseReadOnlyService<TEntity, TDto>,
		IBaseService<TDto, TCreateDto, TUpdateDto> where TEntity : IEntity

	{
		protected BaseService(IBaseRepository<TEntity> baseRepository) : base(baseRepository)
		{
		}

		public async Task<int> InsertAsync(TCreateDto cretateDto)
		{
			
			var entity = MapCreateDtoToEntity(cretateDto);

			if (entity.GetId() == Guid.Empty)
			{
				entity.SetId(Guid.NewGuid());
			}
			if (entity is BaseEntity baseEntity)
			{
				baseEntity.CreateBy ??= "NPBac";
				baseEntity.CreateDate ??= DateTime.Now;
				baseEntity.ModifiedDate ??= DateTime.Now;
			}

			await ValidateCreateBusiness(entity);

			var result = await BaseRepository.InsertAsync(entity);
			return result;
			


		}

		public async Task<int> UpdateAsync(Guid id, TUpdateDto updateDto)
		{
			var entity = await BaseRepository.GetAsync(id);
			var newEntity = MapUpdateDtoToEntity(updateDto, entity);

			if (entity is BaseEntity baseEntity)
			{
				baseEntity.ModifileBy ??= "NPBac";
				baseEntity.ModifiedDate ??= DateTime.Now;
			}

			await ValidateUpdateBusiness(newEntity);
			var result = await BaseRepository.UpdateAsync(newEntity);
			return result;
		}
		public async Task<int> DeleteAsync(Guid id)
		{
			var entity = await BaseRepository.GetAsync(id);
			var result = await BaseRepository.DeleteAsync(entity);
			return result;
		}

		public async Task<int> DeleteManyAsync(List<Guid> ids)
		{
			var entities = await BaseRepository.GetByListIdAsync(ids);

			var result = await BaseRepository.DeleteManyAsync(entities);
			return result;

		}

		public abstract TEntity MapCreateDtoToEntity(TCreateDto entity);
		public async virtual Task ValidateCreateBusiness(TEntity entity)
		{
			await Task.CompletedTask;
		}
		public abstract TEntity MapUpdateDtoToEntity(TUpdateDto updateDto ,TEntity entity);

		public async virtual Task ValidateUpdateBusiness(TEntity entity)
		{
			await Task.CompletedTask;
		}
	}
}
