using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface IWardService:IBaseService<Ward>
    {
        /// <summary>
        /// Service thực hiện lấy GUID của đường được chọn
        /// </summary>
        /// <param name="DistrictID">GUID của quận/ huyện có phường / xã</param>
        /// <param name="WardName">Tên phường / xã</param>
        /// <returns></returns>
        ServiceResult GetStreetID(Guid DistrictID,string WardName);
        /// <summary>
        /// Service thực hiện lấy danh sách phường / xã 
        /// </summary>
        /// <param name="DistrictID">GUID của quận/ huyện được chọn</param>
        /// <returns>Kết quả Service thực hiện lấy danh sách phường / xã theo quận / huyện</returns>
        ServiceResult GetStreetByDistrict(Guid DistrictID);
    }
}
