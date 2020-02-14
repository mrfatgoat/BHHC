using BHHC.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Controllers
{
    [ApiController]
    [Route("api/candidates")]
    public class CandidatesController
    {
        public CandidatesController()
        {

        }

        [HttpGet("")]
        public JsonResult GetCandidates()
        {
            throw new NotImplementedException();
        }
    }
}
