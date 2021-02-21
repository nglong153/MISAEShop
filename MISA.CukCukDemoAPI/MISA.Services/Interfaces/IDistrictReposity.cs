using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface IDistrictReposity:IBaseReposity<District>
    {
        /// <summary>
        /// Hàm thực hiện lấy mã GUID của quận / huyện được chọn
        /// </summary>
        /// <param name="CityID">Mã GUID của thánh phố có quận / huyện</param>
        /// <param name="DistrictName">Tên của quận / huyện được chọn</param>
        /// <returns>object District nếu tồn tại </returns>
        District GetDistrictID(Guid CityID, string DistrictName);
        /// <summary>
        /// Hàm thực hiện lấy danh sách quận / huyện theo tỉnh/ thành phố
        /// </summary>
        /// <param name="CityID">Mã GUID của thánh phố / tỉnh</param>
        /// <returns>List object quận / huyện thỏa mãn</returns>
        IEnumerable<District> GetDistrictByCityID(Guid CityID);
    }
}
