using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using MISA.Service.Interfaces;
using MISA.Service.Entities;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace MISA.DataLayer
{
    public class BaseReposity<TEntity> : IBaseReposity<TEntity>
    {
        #region Declare Field.Protected để chỉ 2 thằng cha/con dùng được
        /// <summary>
        /// _Configuration field để đọc được connection String từ trong appseting.json
        /// </summary>
        /// Created By : NHLong (07/02/2021)
        IConfiguration _configuration;


        /// <summary>
        /// _connectionString là thông tin để kết nối tới Database 
        /// </summary>
        /// Created By : NHLong (07/02/2021)
        protected string _connectionString;

        /// <summary>
        /// _dBConnection để khởi tạo kết nối tới db, thông qua thông tin trong _connectionString
        /// </summary>
        protected IDbConnection _dbConnection ;

        /// <summary>
        /// _className là tên của kiểu TEntity
        /// </summary>
        /// Created By : NHLong (07/02/2021)
        protected string _className;
        #endregion

        #region Constructor
        /// <summary>
        /// Hàm Khởi tạo Reposity
        /// </summary>
        /// <param name="configuration">Config trong appsetting.json</param>
        /// Created By : NHLong (07/02/2021)
        public BaseReposity(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MISACukCukConnectionString");
            _dbConnection = new MySqlConnection(_connectionString);
            _className = typeof(TEntity).Name;
        }
        #endregion

        #region Methos
        public virtual IEnumerable<TEntity> GetEntities()
        {
            var res = _dbConnection.Query<TEntity>($"Proc_Get{_className}",commandType: CommandType.StoredProcedure);
            return res;
        }

        public TEntity GetEntityByID(Guid entityId){
            var sqlSelectEmployeeCode = $"SELECT * FROM {_className} AS E Where E.{_className}ID = '{entityId}'";
            var entityInDb = _dbConnection.Query<TEntity>(sqlSelectEmployeeCode).FirstOrDefault();
            return entityInDb;
        }

        public virtual TEntity GetEntityByCode(string entityCode)
        {
            var sqlSelectEntityCode = $"SELECT * FROM {_className} As E Where E.{_className}Code = '{entityCode}'";
            var entityInDb = _dbConnection.Query<TEntity>(sqlSelectEntityCode, commandType : CommandType.Text).FirstOrDefault();
            return entityInDb;
        }
        // Đặt virtual để lớp con có thể override - ghi đè
        public virtual int AddEntity(TEntity entity)
        {
            var effectRows = _dbConnection.Execute($"Proc_Insert{_className}", param: entity, commandType: CommandType.StoredProcedure);
            return effectRows;
        }

        public virtual int UpdateEntity(TEntity entity)
        {
            var effectRows = _dbConnection.Execute($"Proc_Update{_className}", param: entity, commandType: CommandType.StoredProcedure);
            return effectRows; ;
        }

        public int DeleteEntity(List<Guid> entityIdList){
            var sql = $"Delete from {_className} Where {_className}.{_className}ID = @Guid";
            var effectRows = 0;
            foreach (var id in entityIdList)
            {
                effectRows += _dbConnection.Execute(sql, new { Guid = id.ToString() });
            }
            return effectRows;
        }
        /// <summary>
        /// Hàm dùng chung Gắn dữ liệu với các các trường trong Model ( Entities)
        /// </summary>
        /// <param name="entity">Đối tượng</param>
        /// <returns>Dynamic parameter các trường đã được gắn dữ liệu</returns>
        /// Created By : NHLong (07/02/2021)
        private DynamicParameters MappingDbType(TEntity entity){
            var properties = typeof(TEntity).GetProperties();
            var parameters = new DynamicParameters();
            var sqlPropertyBuilder = string.Empty;
            var sqlPropertyParamBuilder = string.Empty;

        
            foreach ( var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                if (propertyName != "DepartmentName")
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                    sqlPropertyBuilder += $",{propertyName}";
                    sqlPropertyParamBuilder += $",@{propertyName}";
                }
            }
            return parameters;
        }
        #endregion
    }
}
