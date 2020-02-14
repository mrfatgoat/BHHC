﻿using BHHC.Database;
using BHHC.Database.Models;
using BHHC.Services.Interfaces;
using BHHC.Services.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BHHC.Services
{
    public class FantasticReasonService : IFantasticReasonService
    {
        private readonly ILogger<FantasticReasonService> _logger;
        private readonly AppDbContext _db;

        public FantasticReasonService(ILogger<FantasticReasonService> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public List<FantasticReasonDto> GetReasonsByCandidate(CandidateDto candidateDto)
        {
            try
            {
                return this.GetReasonsByCandidateId(candidateDto.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving reasons by candidate");
                throw ex;
            }
        }

        public List<FantasticReasonDto> GetReasonsByCandidateId(int candidateId)
        {
            List<FantasticReasonDto> reasons = _db.Candidates
                .Where(c => c.Id == candidateId)
                .SelectMany(c => c.FantasticReasons)
                .Select(this.CreateDto)
                .ToList();

            return reasons;
        }

        public FantasticReasonDto CreateDto(FantasticReason fr)
        {
            return new FantasticReasonDto()
            {
                Id = fr.Id,
                CandidateId = fr.CandidateId,
                DisplayOrder = fr.DisplayOrder,
                Reason = fr.Reason
            };
        }
    }
}
