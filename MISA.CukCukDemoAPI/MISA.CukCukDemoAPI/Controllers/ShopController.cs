using Microsoft.AspNetCore.Mvc;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;

namespace DemoApi.Controllers
{
    public class ShopController : BaseController<Shop>
    {
        #region Field
        IShopService _shopService;
        #endregion
        public ShopController(IShopService shopService) : base(shopService)
        {
            _shopService = shopService;
        }

        public override IActionResult AddEntity([FromBody] Shop entity)
        {
            var serviceResult = _shopService.AddEntity(entity);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện thêm mới shop thành công!",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Thực hiện thêm mới shop không thành công"
                });
        }

        public override IActionResult UpdateEntity([FromBody] Shop entity)
        {
            var serviceResult = _shopService.UpdateEntity(entity);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện sửa shop thành công!",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Thực hiện sửa shop không thành công"
                });
        }
    }
}