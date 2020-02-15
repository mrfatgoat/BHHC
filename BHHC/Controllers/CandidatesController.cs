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

        [HttpGet("{id}")]
        public IActionResult GetCandidate(int id)
        {
            CandidateDto candidateDto = _candidateService.GetCandidate(id);

            if (candidateDto == null)
            {
                // No resource by that id, so 404
                return new StatusCodeResult(404);
            }
            else
            {
                return new JsonResult(candidateDto) { StatusCode = 200 };
            }
        }
    }
}
