using DemoApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using MISA.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCukDemoAPI.Controllers
{
    public class CityController : BaseController<City>
    {
        #region Field
        ICityServices _cityServices;
        #endregion

        #region Constructor
        public CityController(ICityServices cityService) : base(cityService)
        {
            _cityServices = cityService;
        }
        #endregion

        #region Children own route
        [HttpGet()]
        [Route("/GetCityIDByName")]
        public IActionResult GetCityIDByName([FromQuery] string CityName)
        {
            var serviceResult = _cityServices.GetCityIDByName(CityName);
            if (serviceResult.Success)
                return Ok(new
                {
                    Success = true,
                    Message = "Thực hiện lấy mã Thành phố /tỉnh thành công",
                    Data = serviceResult.Data
                });
            else return Ok(new
            {
                Success = false,
                Message = "Không thực hiện lấy mã Thành phố / tỉnh theo tên thành công",
                Data = "null"
            });
        }
        #endregion
    }
}
