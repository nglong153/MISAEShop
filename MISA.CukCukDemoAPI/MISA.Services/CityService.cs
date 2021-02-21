using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services
{
    public class CityService : BaseService<City>, ICityServices
    {
        #region Field
        IBaseReposity<City> _baseReposity;
        ICityReposity _cityReposity;
        #endregion


        #region Constructor
        public CityService(IBaseReposity<City> baseReposity, ICityReposity  cityReposity) : base(baseReposity)
        {
            _baseReposity = baseReposity;
            _cityReposity = cityReposity;
        }
        #endregion
        public ServiceResult GetCityIDByName(string CityName)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var CityID = _cityReposity.GetCityIDByName(CityName).CityID;
            if (CityID != null)
            {
                serviceResult.Success = true;
                serviceResult.Data = CityID;
            }
            return serviceResult;
        }
    }
}
