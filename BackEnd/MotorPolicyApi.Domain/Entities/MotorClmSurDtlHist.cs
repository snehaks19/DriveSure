using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Domain.Entities
{
    public class MotorClmSurDtlHist
    {
        public long SurdhUid { get; set; }
        public int SurdhSrl { get; set; }
        public string? SurdhAction { get; set; }
        public string? SurdhItemCode { get; set; }
        public string? SurdhType { get; set; }
        public decimal? SurdhUnitPrice { get; set; }
        public decimal? SurdhQuantity { get; set; }
        public decimal? SurdhFcAmt { get; set; }
        public decimal? SurdhLcAmt { get; set; }
        public string? SurdhRemarks { get; set; }
        public string? SurdhCrBy { get; set; }
        public DateTime? SurdhCrDt { get; set; }
        public string? SurdhUpBy { get; set; }
        public DateTime? SurdhUpDt { get; set; }
    }
}
