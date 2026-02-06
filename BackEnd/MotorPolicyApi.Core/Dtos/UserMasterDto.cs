using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorPolicyApi.Core.Dtos
{
    public class UserMasterDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Password { get; set; }
        public string? Type { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
