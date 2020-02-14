using BHHC.Services.Models;
using System.Collections.Generic;

namespace BHHC.Services.Interfaces
{
    public interface IFantasticReasonService
    {
        List<FantasticReasonDto> GetReasonsByCandidate(CandidateDto candidateDto);
        List<FantasticReasonDto> GetReasonsByCandidateId(int candidateId);
    }
}
