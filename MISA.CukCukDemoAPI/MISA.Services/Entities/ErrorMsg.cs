using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Service.Entities
{
    public class ErrorMsg
    {
        /// <summary>
        /// Thong tin Them ve Loi
        /// </summary>
        /// <value></value>
        public string DevMsg { get; set; }
        public List<string> UserMsg { get; set; } = new List<string>();
        public string ErrorCode { get; set; }
        public string MoreInfo { get; set; }
        public string TraceID { get; set; }
    }
}