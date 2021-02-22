using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Entities
{
    public class Shop
    {
        public Guid ShopID { get; set; }
        public Guid CityID { get; set; }
        public Guid DistrictID { get; set; }
        public Guid WardID { get; set; }
        public string ShopName { get; set; }
        public string ShopAddress { get; set; }
        public string ShopPhoneNumber { get; set; }
        public string ShopCode { get; set; }
        public int ShopStatus { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string WardName { get; set; }
        public string ShopTaxCode { get; set; }
        public string ShopNation { get; set; }
        public string ShopStreet { get; set; }

    }

}
