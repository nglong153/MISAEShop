using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface ICityServices:IBaseService<City>
    {
        /// <summary>
        /// Lấy Guid của tính/ thành phố dựa theo tên
        /// </summary>
        /// <param name="CityName">tên thành phố/ tỉnh</param>
        /// <returns>Guid của tỉnh/ thành phố<returns>
        ServiceResult GetCityIDByName(string CityName);
    }
}
