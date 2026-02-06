using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Entities
{
    public class ErrorCodeMaster
    {
         public string ErrCode { get; set; } = null!;
        public string ErrType { get; set; } = null!;
        public string? ErrDesc { get; set; }
        public string? ErrCrBy { get; set; }
        public DateTime? ErrCrDt { get; set; }
        public string? ErrUpBy { get; set; }
        public DateTime? ErrUpDt { get; set; }
    }
}
