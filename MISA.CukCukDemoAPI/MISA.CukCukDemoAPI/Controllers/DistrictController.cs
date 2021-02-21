using DemoApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Entities;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCukDemoAPI.Controllers
{
    public class DistrictController : BaseController<District>
    {
        #region Declare Fields
        IDistrictService _districtService;
        #endregion

        #region Constructor
        public DistrictController(IDistrictService districtService) : base(districtService)
        {
            _districtService = districtService;
        }
        #endregion

        #region Children Own Route
        [HttpGet()]
        [Route("/GetDistrictByCity")]
        public  IActionResult GetDistrictByCity([FromQuery] Guid CityID)
        {
            var serviceResult = _districtService.GetDistrictByCity(CityID);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện lấy danh sách quận / huyện theo tỉnh/ thành phố thành công",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Thực hiện lấy danh sách quận/ huyện theo tỉnh / thành phố không thành công",
                    Data = "null"
                });
        }
        [HttpGet()]
        [Route("/GetDistrictID")]
        public  IActionResult GetDistrictID([FromQuery] Guid CityID,string DistrictName)
        {
            var serviceResult = _districtService.GetDistrictID(CityID, DistrictName);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện lấy GUID của quận/ huyện thành công",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Thực hiện lấy GUID của quận/ huyện không thành công"
                });
        }
        #endregion
    }
}
