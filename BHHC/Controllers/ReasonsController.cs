using BHHC.Services.Interfaces;
using BHHC.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BHHC.Controllers
{
    [ApiController]
    [Route("api")]
    public class ReasonsController
    {
        private readonly IFantasticReasonService _reasonService;

        public ReasonsController(IFantasticReasonService reasonService)
        {
            _reasonService = reasonService;
        }

        [HttpGet("candidates/{candidateId}/reasons")]
        public JsonResult GetCandidateReasons(int candidateId)
        {
            List<FantasticReasonDto> candidateReasonDtos = _reasonService.GetReasonsByCandidateId(candidateId);
            return new JsonResult(candidateReasonDtos) { StatusCode = 200 };
        }
    }
}
