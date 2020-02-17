namespace BHHC.Services.Models
{
    public class FantasticReasonDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int DisplayOrder { get; set; }
        public string Reason { get; set; }
        public string Description { get; set; }
    }
}
