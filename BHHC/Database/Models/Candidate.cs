using System.Collections.Generic;

namespace BHHC.Database.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Blurb { get; set; }

        public List<FantasticReason> FantasticReasons { get; set; }
    }
}
