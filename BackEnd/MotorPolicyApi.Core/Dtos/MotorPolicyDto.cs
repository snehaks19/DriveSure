using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Dtos
{
    public class MotorPolicyDto
    {
        public int polUid { get; set; }

        public string polNo { get; set; }

        public DateTime? issueDate { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }

        public string name { get; set; }
        public string mobile { get; set; }

        public string currency { get; set; }

        public decimal fcPremium { get; set; }
        public decimal lcPremium { get; set; }

        public string vehMake { get; set; }
        public string vehModel { get; set; }

        public string chassisNo { get; set; }
        public string engineNo { get; set; }
        public string regNo { get; set; }

        public decimal vehValue { get; set; }

        //public string polApprStatus { get; set; }
        //public DateTime? PolApprDt { get; set; }
        //public string PolApprBy { get; set; }
        //public string PolCrBy { get; set; }
        //public DateTime? PolCrDt { get; set; }
        //public string PolUpBy { get; set; }
        //public DateTime? PolUpDt { get; set; }
    }
}
