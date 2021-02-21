using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Service.Entities;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class ShopReposity : BaseReposity<Shop>, IShopReposity
    {
        #region Field
        ICityReposity _cityReposity;
        IDistrictReposity _districtReposity;
        IWardReposity _wardReposity;
        #endregion
        #region Constructor
        public ShopReposity(IConfiguration configuration, IWardReposity wardReposity, IDistrictReposity districtReposity, ICityReposity cityReposity) : base(configuration)
        {
            _cityReposity = cityReposity;
            _wardReposity = wardReposity;
            _districtReposity = districtReposity;
        }
        #endregion

        #region Children Own Methods
        public override int AddEntity(Shop entity)
        {

            var cityID = _cityReposity.GetCityIDByName(entity.CityName).CityID;
            var districtId = _districtReposity.GetDistrictID(cityID, entity.DistrictName).DistrictID;
            var wardID = _wardReposity.GetStreetID(districtId, entity.WardName).WardID;

            entity.CityID = cityID;
            entity.DistrictID = districtId;
            entity.WardID = wardID;
            entity.ShopID = Guid.NewGuid();

            return base.AddEntity(entity);
        }


        public override int UpdateEntity(Shop entity)
        {

            var cityID = _cityReposity.GetCityIDByName(entity.CityName).CityID;
            var districtId = _districtReposity.GetDistrictID(cityID, entity.DistrictName).DistrictID;
            var wardID = _wardReposity.GetStreetID(districtId, entity.WardName).WardID;

            entity.CityID = cityID;
            entity.DistrictID = districtId;
            entity.WardID = wardID;

            return base.UpdateEntity(entity);
        }

        public bool ValidateData()
        {
            return true;
        }
        public List<string> SqlBuilder(Shop shop)
        {
            var properties = typeof(Shop).GetProperties();
            var sqlPropertyBuilder = string.Empty;
            var sqlPropertyParamBuilder = string.Empty;

            var ret = new List<string>();


            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(shop);
                if (propertyName != "CityName" && propertyName != "DistrictName" && propertyName != "WardName")
                {
                    sqlPropertyBuilder += $",{propertyName}";
                    sqlPropertyParamBuilder += $",@{propertyName}";
                }
                //  else if (propertyName == "DepartmentName")
                // {
                //     var _departmentGUID = _dbConnection.Query<Department>($"Proc_GetDepartmentIDByName", new { DepartmentName = property.GetValue(entity) },
                //             commandType: CommandType.StoredProcedure).FirstOrDefault();
                //     parameters.Add($"@DepartmentID", _departmentGUID.DepartmentID);
                //     sqlPropertyBuilder += "DepartmentID = @DepartmentID,";
                // }
            }
            ret.Add(sqlPropertyBuilder);
            ret.Add(sqlPropertyParamBuilder);
            return ret;
        }
        #endregion
    }
}
