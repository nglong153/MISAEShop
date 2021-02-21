using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Service.Entities;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class CityReposity : BaseReposity<City>, ICityReposity
    {
        #region Constructor
        public CityReposity(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion
        #region Implement Methods
        public City GetCityIDByName(string CityName)
        {
            var sql = $"Select * from City where City.CityName = '{CityName}'";
            var selectedCity = _dbConnection.Query<City>(sql, commandType: CommandType.Text).FirstOrDefault();
            return selectedCity;
        }
        #endregion
    }
}
