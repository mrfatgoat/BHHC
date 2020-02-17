namespace BHHC.Database.Models
{
    public class FantasticReason
    {
        public int Id { get; set; }
        public int DisplayOrder { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
