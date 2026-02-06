using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Entities
{
    public class MotorClmSurDtl
    {
        public long SurdUid { get; set; }
        public long? SurdSurUid { get; set; }
        public string? SurdItemCode { get; set; }
        public string? SurdType { get; set; }
        public decimal? SurdUnitPrice { get; set; }
        public decimal? SurdQuantity { get; set; }
        public decimal? SurdFcAmt { get; set; }
        public decimal? SurdLcAmt { get; set; }
        public string? SurdRemarks { get; set; }
        public string? SurdCrBy { get; set; }
        public DateTime? SurdCrDt { get; set; }
        public string? SurdUpBy { get; set; }
        public DateTime? SurdUpDt { get; set; }
    }
}
