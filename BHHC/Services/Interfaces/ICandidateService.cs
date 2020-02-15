using BHHC.Services.Models;
using System.Collections.Generic;

namespace BHHC.Services.Interfaces
{
    public interface ICandidateService
    {
        List<CandidateDto> GetCandidates();
        CandidateDto GetCandidate(int id);
    }
}
