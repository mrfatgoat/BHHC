using BHHC.Database;
using BHHC.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Services.Interfaces
{
    public interface ICandidateService
    {
        List<CandidateDto> GetCandidates();
    }
}
