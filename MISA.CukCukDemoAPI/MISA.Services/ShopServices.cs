using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services
{
    public class ShopServices : BaseService<Shop>,IShopService
    {
        #region Declare Field
        IBaseReposity<Shop> _baseRepository;
        IShopReposity _shopReposity;
        #endregion

        #region Constructor
        public ShopServices(IBaseReposity<Shop> baseReposity, IShopReposity shopReposity) : base(baseReposity)
        {
            _baseRepository = baseReposity;
            _shopReposity = shopReposity;
        }
        #endregion

        #region Override Parent Methods
        public override ServiceResult AddEntity(Shop entity)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var effectedRows = _shopReposity.AddEntity(entity);
            if (effectedRows > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = effectedRows;
            }
            return serviceResult;            
        }

        public override ServiceResult UpdateEntity(Shop entity)
        {
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var effectedRows = _shopReposity.UpdateEntity(entity);
            if (effectedRows > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = effectedRows;
            }
            return serviceResult;
        }
        #endregion
    }
}
