using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.WebFresher072023.Demo.Domain;
using MISA.WebFresher072023.Demo.Domain.Resources;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.WebFresher072023.Demo.Infrastruture
{

	public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : IEntity
	{
		private readonly IConfiguration _config;

		public BaseRepository(IConfiguration config)
		{
			_config = config;
		}

		// Phương thức tạo kết nối đến cơ sở dữ liệu
		private MySqlConnection CreateConnection()
		{
			var connectionString = _config.GetConnectionString("DefaultConnection");
			return new MySqlConnection(connectionString);

		}
		public virtual string TableName { get; set; } = typeof(TEntity).Name;


		public async Task<int> DeleteAsync(TEntity entity)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			var sqlCommand = $"DELETE FROM {TableName} WHERE {TableName}Id = @id";
			DynamicParameters param = new DynamicParameters();
			param.Add("@id", entity.GetId());
			// Thực thi câu truy vấn
			var result = await sqlConnection.ExecuteAsync(sql: sqlCommand, param: param);
			return result;
		}

		public async Task<int> DeleteManyAsync(List<TEntity> entities)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			var sqlCommand = $"DELETE FROM {TableName} WHERE {TableName}Id IN @ids";
			var param = new DynamicParameters();
			param.Add("@ids", entities.Select(entity => entity.GetId()));
			var result = await sqlConnection.ExecuteAsync(sqlCommand, param);
			return result;
		}

		/// <summary>
		/// Tìm bản ghi
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)
		public async Task<TEntity?> FindAsync(Guid id)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			// Tạo câu truy vấn
			var sqlCommand = $"SELECT * FROM {TableName} WHERE {TableName}Id = @id";
			// Khởi tạo đối tượng DynamicParameters
			var param = new DynamicParameters();
			// Add giá trị đầu vào tương ứng
			param.Add("@id", id);
			// Thực hiện câu truy vấn
			var result = await sqlConnection.QueryFirstOrDefaultAsync<TEntity>(sql: sqlCommand, param: param);
			// Nếu không có dữ liệu thì trả về lỗi
			return result;
		}

		/// <summary>
		/// Lấy tất cả bản ghi
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)

		public async Task<List<TEntity>> GetAllAsync()
		{
			var sqlConnection = CreateConnection();


			// Tạo câu truy vấn 
			var sqlCommand = $"SELECT * FROM {TableName}";

			var result = await sqlConnection.QueryAsync<TEntity>(sql: sqlCommand);

			return result.ToList();
		}
		/// <summary>
		/// Lấy 1 bản ghi
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)
		public async Task<TEntity?> GetAsync(Guid id)
		{
			var entity = await FindAsync(id);
			if (entity == null)
			{
				throw new NotFoundException(MISAResourceVN.Employee_Not_Found);
			}
			return entity;
		}

		/// <summary>
		/// tìm nhiều ban rghi
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)
		public async Task<List<TEntity>> GetByListIdAsync(List<Guid> ids)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			// Tạo câu truy vấn
			var sqlCommand = $"SELECT * FROM {TableName} WHERE {TableName}Id IN @ids";
			// Khởi tạo đối tượng DynamicParameters
			var param = new DynamicParameters();
			// Add giá trị đầu vào tương ứng
			param.Add("@ids", ids);
			// Thực hiện câu truy vấn
			var result = await sqlConnection.QueryAsync<TEntity>(sql: sqlCommand, param: param);
			// Nếu không có dữ liệu thì trả về lỗi
			return result.ToList();
		}
		/// <summary>
		/// Thêm mới nhân viên
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)
		public async Task<int> InsertAsync(TEntity entity)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			// Mở kết nối với database
			sqlConnection.Open();
			// Khai báo biến lưu tên Procedure
			
			
			// Khởi tạo sql Command
			var parameters = new DynamicParameters();
			var procedureInsert = $"Proc_{TableName}_Insert";

			// Đọc các tham số đầu vào của store 
			var sqlCommand = sqlConnection.CreateCommand();

			sqlCommand.CommandText = procedureInsert;
			sqlCommand.CommandType = CommandType.StoredProcedure;
			MySqlCommandBuilder.DeriveParameters(sqlCommand);

			foreach (MySqlParameter parameter in sqlCommand.Parameters)
			{
				// Tên của tham số 
				var paramName = parameter.ParameterName;
				var propName = paramName.Replace("@p_", "");
				var enityProperty = entity.GetType().GetProperty(propName);
				if (enityProperty != null)
				{
					var propValue = enityProperty.GetValue(entity);

					parameters.Add($"{paramName}", propValue);
				}
				else
				{
					parameters.Add($"{paramName}", null);
				}
			}

			// Thực hiện truy vấn
			var result = await sqlConnection.ExecuteAsync(procedureInsert, parameters, commandType: CommandType.StoredProcedure);

			return result;
		}
		/// <summary>
		/// Cập nhật bản ghi
		/// </summary>
		/// <param name="employee">Thông tin nhân viên cần thêm</param>
		/// <returns>Số bản ghi được thêm</returns>
		/// Created by: npBac (18/09/2023)
		public async Task<int> UpdateAsync(TEntity entity)
		{
			// Tạo kết nối với MariaDB
			var sqlConnection = CreateConnection();
			// Mở kết nối với database
			sqlConnection.Open();
			// Khai báo biến lưu tên Procedure

			var parameters = new DynamicParameters();
			var procedureUpdate = $"Proc_{TableName}_Update"; ;

			// Đọc các tham số đầu vào của store 
			var sqlCommand = sqlConnection.CreateCommand();

			sqlCommand.CommandText = procedureUpdate;
			sqlCommand.CommandType = CommandType.StoredProcedure;
			MySqlCommandBuilder.DeriveParameters(sqlCommand);

			foreach (MySqlParameter parameter in sqlCommand.Parameters)
			{
				// Tên của tham số 
				var paramName = parameter.ParameterName;
				var propName = paramName.Replace("@p_", "");
				var enityProperty = entity.GetType().GetProperty(propName);
				if (enityProperty != null)
				{
					var propValue = enityProperty.GetValue(entity);

					parameters.Add($"{paramName}", propValue);
				}
				else
				{
					parameters.Add($"{paramName}", null);
				}
			}

			// Thực hiện truy vấn
			var result = await sqlConnection.ExecuteAsync(procedureUpdate, parameters, commandType: CommandType.StoredProcedure);

			return result;
		}
	}
}
