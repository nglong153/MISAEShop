using MISA.Service.Entities;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Services.Interfaces
{
    public interface IWardReposity:IBaseReposity<Ward>
    {
        /// <summary>
        /// Hàm thực hiện lấy về danh sách xã/ phường trong quận / huyện
        /// </summary>
        /// <param name="DistrictID">Mã GUID của quận / huyện được chọn</param>
        /// <returns>List các xã / phường thỏa mãn yêu cầu</returns>
        IEnumerable<Ward> GetStreetByDistrict(Guid DistrictID);
        /// <summary>
        /// Hàm thực hiện lấy xã/ phường được chọn
        /// </summary>
        /// <param name="DistrictID">Mã GUID của quận/ huyện có mã phường / xã được chọn</param>
        /// <param name="WardName">Tên của xẫ / phường được chọn</param>
        /// <returns>Object Xã / phường thỏa mãn</returns>
        Ward GetStreetID(Guid DistrictID, string WardName);
    }
}
