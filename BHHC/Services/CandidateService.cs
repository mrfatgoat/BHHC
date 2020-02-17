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

        /// <summary>
        /// Get all candidates
        /// </summary>
        /// <returns></returns>
        public List<CandidateDto> GetCandidates()
        {
            // Select all candidates and project them as DTOs for exposure outside the service.
            List<CandidateDto> candidates = _db.Candidates
                .Select(this.CreateDto)
                .ToList();

            return candidates;
        }

        /// <summary>
        /// Get a single candidate
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A <see cref="CandidateDto"/> if a candidate exists, else null</returns>
        public CandidateDto GetCandidate(int id)
        {
            CandidateDto candidateDto = _db.Candidates
                .Where(c => c.Id == id)
                .Select(this.CreateDto)
                .SingleOrDefault();

            return candidateDto;
        }

        /// <summary>
        /// Maps a database entity to a DTO
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public CandidateDto CreateDto(Candidate c)
        {
            if (c == null)
            {
                return null;
            }

            return new CandidateDto()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Blurb = c.Blurb
            };
        }
    }
}
