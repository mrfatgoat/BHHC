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
        private readonly AppDbContext _db;

        public CandidatesController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("")]
        public JsonResult GetCandidates()
        {
            var candidates = _db.Candidates.Select(c => new
            {
                Id = c.Id,
                Name = $"{c.FirstName} {c.LastName}"
            });

            return new JsonResult(candidates) { StatusCode = 200 };
        }
    }
}
