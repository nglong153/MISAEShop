using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface IDistrictService:IBaseService<District>
    {
        /// <summary>
        /// Service thực hiện lấy GUID của quận / huyện được chọn
        /// </summary>
        /// <param name="CityID">GUID của tỉnh/ thành phố quận thuộc về</param>
        /// <param name="DistrictName">Tên của quận / huyện được chọn</param>
        /// <returns>Kết quả service lấy GUID của quận/ huyện</returns>
        ServiceResult GetDistrictID(Guid CityID, string DistrictName);
        /// <summary>
        /// Service thực hiện lấy danh sách các quận/ huyện theo tỉnh / thành phố
        /// </summary>
        /// <param name="CityID">Guid của tính / thành phố được chọn</param>
        /// <returns>Kết quả service lấy danh sách các quận / huyện theo yêu cầu </returns>
        ServiceResult GetDistrictByCity(Guid CityID);
    }
}
