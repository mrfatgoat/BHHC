using BHHC.Database;
using BHHC.Database.Models;
using BHHC.Services;
using BHHC.Services.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Services
{
    public class FantasticReasonServiceTest
    {
        public class GetReasonsByCandidateMethod : IDisposable
        {
            private readonly AppDbContext _db;

            public GetReasonsByCandidateMethod()
            {
                _db = TestHelper.CreateInMemoryDb();
            }

            public void Dispose()
            {
                _db.Dispose();
            }

            [Trait("Category", "Unit Test")]
            [Fact(DisplayName = "logs and throws when candidate is null")]
            public void ThrowsWhenCandidateIsNull()
            {
                // Arrange
                ILogger<FantasticReasonService> logger = Substitute.For<ILogger<FantasticReasonService>>();
                FantasticReasonService uut = CreateService(db: _db, logger: logger);

                // Act
                Action act = () => uut.GetReasonsByCandidate(null);

                // Assert
                act.Should().Throw<Exception>();
                logger.ReceivedCalls().Should().ContainSingle()
                    .Which.GetArguments().Should().Contain(LogLevel.Error);
            }
        }

        public class GetReasonsByCandidateIdMethod : IDisposable
        {
            private readonly AppDbContext _db;

            public GetReasonsByCandidateIdMethod()
            {
                _db = TestHelper.CreateInMemoryDb();
            }

            public void Dispose()
            {
                _db.Dispose();
            }

            [Fact(DisplayName = "gets correct reasons for candidateId")]
            public void GetsCorrectReasons()
            {
                // Arrange
                const int targetCandidateId = 10;

                // Seed our target candidate
                Candidate c1 = new Candidate()
                {
                    Id = targetCandidateId,
                    FirstName = "Test",
                    LastName = "Person1",
                    FantasticReasons = new List<FantasticReason>()
                    {
                        new FantasticReason()
                        {
                            Reason = "reason 1",
                            DisplayOrder = 1
                        },
                        new FantasticReason()
                        {
                            Reason = "reason 2",
                            DisplayOrder = 2
                        },
                        new FantasticReason()
                        {
                            Reason = "reason 3",
                            DisplayOrder = 3
                        }
                    }
                };

                // Seed some other candidate
                Candidate c2 = new Candidate()
                {
                    Id = targetCandidateId + 2,
                    FirstName = "Test",
                    LastName = "Person2",
                    FantasticReasons = new List<FantasticReason>()
                    {
                        new FantasticReason()
                        {
                            Reason = "reason 1",
                            DisplayOrder = 1
                        },
                        new FantasticReason()
                        {
                            Reason = "reason 2",
                            DisplayOrder = 2
                        },
                        new FantasticReason()
                        {
                            Reason = "reason 3",
                            DisplayOrder = 3
                        }
                    }
                };

                _db.AddRange(c1, c2);
                _db.SaveChanges();

                FantasticReasonService uut = CreateService(db: _db);

                // Act
                List<FantasticReasonDto> result = uut.GetReasonsByCandidateId(targetCandidateId);

                // Assert
                // Database should contain 6 total reasons
                _db.Candidates.SelectMany(c => c.FantasticReasons).Should().HaveCount(6);
                // Our result should only contain 3
                result.Should().HaveCount(3);
            }
        }


        private static FantasticReasonService CreateService(
            AppDbContext db,
            ILogger<FantasticReasonService> logger = null)
        {
            return new FantasticReasonService(
                logger: logger ?? Substitute.For<ILogger<FantasticReasonService>>(),
                db: db);
        }
    }
}
