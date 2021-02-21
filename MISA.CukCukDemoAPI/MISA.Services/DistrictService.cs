using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services
{
    public class DistrictService : BaseService<District>, IDistrictService
    {
        #region Declare Field
        IBaseReposity<District> _baseRepostiy;
        IDistrictReposity _districtReposity;
        #endregion

        #region Constructor
        public DistrictService(IBaseReposity<District> baseReposity, IDistrictReposity districtReposity) : base(baseReposity)
        {
            _baseRepostiy = baseReposity;
            _districtReposity = districtReposity;
        }
        #endregion

        #region Implement Interface Methods
        public ServiceResult GetDistrictByCity(Guid CityID)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var districtList = _districtReposity.GetDistrictByCityID(CityID);
            if (districtList != null)
            {
                serviceResult.Success = true;
                serviceResult.Data = districtList;
            }
            return serviceResult;
        }

        public ServiceResult GetDistrictID(Guid CityID, string DistrictName)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var selectedDistrict = _districtReposity.GetDistrictID(CityID,DistrictName);
            if (selectedDistrict != null)
            {
                serviceResult.Success = true;
                serviceResult.Data = selectedDistrict.DistrictID;
            }
            return serviceResult;
        }
        #endregion
    }
}
