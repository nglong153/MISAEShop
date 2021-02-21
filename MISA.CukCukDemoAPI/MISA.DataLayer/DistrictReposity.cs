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
    public class DistrictReposity : BaseReposity<District>, IDistrictReposity
    {
        public DistrictReposity(IConfiguration configuration) : base(configuration)
        {
        }
        public IEnumerable<District> GetDistrictByCityID(Guid CityID)
        {
            var sql = $"Select * from District where District.CityID = '{CityID.ToString()}'";
            var districtList = _dbConnection.Query<District>(sql, commandType: CommandType.Text);
            return districtList;
        }

        public District GetDistrictID(Guid CityID, string DistrictName)
        {
            var sql = $"Select * from District where District.CityID = '{CityID.ToString()}' and District.DistrictName = '{DistrictName}'";
            var selectedDistrict = _dbConnection.Query<District>(sql, commandType: CommandType.Text).FirstOrDefault();
            return selectedDistrict;        
        }
    }
}
