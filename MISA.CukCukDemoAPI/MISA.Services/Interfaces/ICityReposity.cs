
using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface ICityReposity : IBaseReposity<City>
    {   
        /// <summary>
        /// Hàm trả về GUID của tỉnh/ thành phố theo tên
        /// </summary>
        /// <param name="CityName">Tên tỉnh/ thành phố</param>
        /// <returns>Mã GUID cảu tình/ thành phố nếu tồn tại</returns>
        City GetCityIDByName(string CityName);
    }
}
