﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Entities
{
    public class District
    {
        public Guid CityID { get; set; }
        public Guid DistrictID { get; set; }
        public string DistrictCode { get; set; }
        public string DistrictName { get; set; }
    }
}
