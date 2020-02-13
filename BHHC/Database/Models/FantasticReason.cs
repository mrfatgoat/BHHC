using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Database.Models
{
    public class FantasticReason
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Reason { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
