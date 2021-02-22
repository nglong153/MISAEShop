using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var errorMsg = validate(entity);
            var existShop = _baseRepository.GetEntityByCode(entity.ShopCode);
            if (existShop != null)
            {
                errorMsg.UserMsg.Add(MISA.Services.Properties.Resources.ErrorService_DuplicateShopCode);
            }

            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            serviceResult.Data = errorMsg.UserMsg;
            
            if(errorMsg.UserMsg != null && !errorMsg.UserMsg.Any()) {
                var effectedRows = _shopReposity.AddEntity(entity);
                if (effectedRows > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = effectedRows;
                }
                return serviceResult;
            }
            return serviceResult;            
        }

        public override ServiceResult UpdateEntity(Shop entity)
        {
            var errorMsg = validate(entity);
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            serviceResult.Data = errorMsg.UserMsg;
            
            if (errorMsg.UserMsg != null && !errorMsg.UserMsg.Any())
            {
                var effectedRows = _shopReposity.UpdateEntity(entity);
                if (effectedRows > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = effectedRows;
                    
                }
                return serviceResult;
            }
            return serviceResult;
        }

        public ErrorMsg validate(Shop entity)
        {
            var errorMsg = new ErrorMsg();
            if (String.IsNullOrEmpty(entity.ShopCode))
            {
                errorMsg.UserMsg.Add(MISA.Services.Properties.Resources.ErrorService_EmptyShopCode);
            }

            if (String.IsNullOrEmpty(entity.ShopName))
            {
                errorMsg.UserMsg.Add(MISA.Services.Properties.Resources.ErrorService_EmptyShopName);
            }

            if (String.IsNullOrEmpty(entity.ShopAddress))
            {
                errorMsg.UserMsg.Add(MISA.Services.Properties.Resources.ErrorService_EmptyShopAddress);
            }
            return errorMsg;
        }

        #endregion
    }
}
