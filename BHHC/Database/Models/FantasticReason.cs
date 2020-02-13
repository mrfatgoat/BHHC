using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Database.Models
{
    public class FantasticReason
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; } = 1;
        public string Reason { get; set; }
    }
}
