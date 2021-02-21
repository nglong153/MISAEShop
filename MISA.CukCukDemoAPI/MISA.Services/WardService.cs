using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services
{
    public class WardService : BaseService<Ward>, IWardService
    {
        #region Field
        IBaseReposity<Ward> _baseReposity;
        IWardReposity _wardReposity;
        #endregion

        #region Constructor
        public WardService(IBaseReposity<Ward> baseReposity,IWardReposity wardReposity) : base(baseReposity)
        {
            _baseReposity = baseReposity;
            _wardReposity = wardReposity;
        }
        #endregion

        #region Implement Methods
        public ServiceResult GetStreetByDistrict(Guid DistrictID)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var wardList = _wardReposity.GetStreetByDistrict(DistrictID);
            if (wardList != null)
            {
                serviceResult.Success = true;
                serviceResult.Data = wardList;
            }
            return serviceResult;
        }

        public ServiceResult GetStreetID(Guid DistrictID, string WardName)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var selectedWard = _wardReposity.GetStreetID(DistrictID, WardName);
            if (selectedWard != null)
            {
                serviceResult.Success = true;
                serviceResult.Data = selectedWard.WardID;
            }
            return serviceResult;
        }
        #endregion
    }
}
