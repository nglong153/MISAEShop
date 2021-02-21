using DemoApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCukDemoAPI.Controllers
{
    public class WardController : BaseController<Ward>
    {
        #region Declare Field
        IWardService _wardService;
        #endregion

        #region Constructor
        public WardController(IWardService wardService) : base(wardService)
        {
            _wardService = wardService;
        }
        #endregion

        #region Children Own Route
        [HttpGet()]
        [Route("/GetWardID")]
        public IActionResult GetWardID([FromQuery] Guid DistrictID,string WardName)
        {
            var serviceResult = _wardService.GetStreetID(DistrictID, WardName);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện lấy GUID của phường/ xã thành công",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Không thực hiện được lấy GUID của phường / xã"
                });
        }

        [HttpGet()]
        [Route("/GetWardByDistrict")]
        public IActionResult GetWardByDistrict([FromQuery] Guid DistrictID)
        {
            var serviceResult = _wardService.GetStreetByDistrict(DistrictID);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện lấy danh sách xã/ phường theo quận/ huyện thành công",
                    Data = serviceResult.Data
                });
            else
                return Ok(new
                {
                    Success = false,
                    Message = "Thực hiện lấy danh sách xã/ phường không thành công"
                });
        }
        #endregion

    }
}
