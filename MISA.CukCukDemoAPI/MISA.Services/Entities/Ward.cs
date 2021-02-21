using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Entities
{
    public class Ward
    {
        public Guid CityID { get; set; }
        public Guid DistrictID { get; set; }
        public Guid WardID { get; set; }
        public string WardCode { get; set; }
        public string WardName { get; set; }
    }
}
