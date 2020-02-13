using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Database.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<FantasticReason> FantasticReasons { get; set; }
    }
}
