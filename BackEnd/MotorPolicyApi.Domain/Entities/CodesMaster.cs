using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Entities
{
    public class CodesMaster
    {
        public string CmCode { get; set; } = null!;
        public string CmType { get; set; } = null!;
        public string? CmDesc { get; set; }
        public decimal? CmValue { get; set; }
        public string? CmCrBy { get; set; }
        public DateTime? CmCrDt { get; set; }
        public string? CmUpBy { get; set; }
        public DateTime? CmUpDt { get; set; }
        public string CmActiveYn { get; set; } = "Y";
    }
}
