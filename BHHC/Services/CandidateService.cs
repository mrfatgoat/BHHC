using BHHC.Database;
using BHHC.Database.Models;
using BHHC.Services.Interfaces;
using BHHC.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace BHHC.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly AppDbContext _db;

        public CandidateService(AppDbContext db)
        {
            _db = db;
        }

        public List<CandidateDto> GetCandidates()
        {
            // Select all candidates and project them as DTOs for exposure outside the service.
            List<CandidateDto> candidates = _db.Candidates
                .Select(this.CreateDto)
                .ToList();

            return candidates;
        }

        public CandidateDto CreateDto(Candidate c)
        {
            return new CandidateDto()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName
            };
        }
    }
}
