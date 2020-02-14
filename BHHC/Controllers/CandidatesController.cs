using BHHC.Services.Interfaces;
using BHHC.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BHHC.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("")]
        public JsonResult GetCandidates()
        {
            List<CandidateDto> candidateDtos = _candidateService.GetCandidates();
            return new JsonResult(candidateDtos) { StatusCode = 200 };
        }
    }
}
