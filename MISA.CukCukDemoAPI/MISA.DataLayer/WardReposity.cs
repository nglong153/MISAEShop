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
    public class WardReposity:BaseReposity<Ward>, IWardReposity
    {
        #region Constructor
        public WardReposity(IConfiguration configuration) : base(configuration)
        {
        }

        public IEnumerable<Ward> GetStreetByDistrict(Guid DistrictID)
        {
            var sql = $"Select * From Ward Where Ward.DistrictID = '{DistrictID.ToString()}'";
            var WardList = _dbConnection.Query<Ward>(sql, commandType: CommandType.Text);
            return WardList;
        }

        public Ward GetStreetID(Guid DistrictID, string WardName)
        {
            var sql = $"Select * From Ward Where Ward.DistrictID = '{DistrictID.ToString()}' and Ward.WardName = '{WardName}'";
            var selectedWard = _dbConnection.Query<Ward>(sql, commandType: CommandType.Text).FirstOrDefault();
            return selectedWard;
        }
        #endregion
    }
}
