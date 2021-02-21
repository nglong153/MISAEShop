using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Entities
{
    public class City
    {
        public Guid CityID{ get; set; }
        public string CityCode { get; set; }
        public string CityName { get; set; }
    }
}
