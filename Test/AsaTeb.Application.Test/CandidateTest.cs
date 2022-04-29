using System;
using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Queries;
using AsaTeb.Application.Candidates.Repositories;
using AsaTeb.Application.Test.Mocks;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AsaTeb.Application.Test
{
    public class CandidateTest
    {
        private Mock<ICandidateRepository> _mockRepo;

        public CandidateTest()
        {
            _mockRepo = MockCandidateRepository.MockLoadAllCandidatesRepository();
        }

        [Fact]
        public async Task Load_All_Candidates_Test()
        {
            var handler = new GetAllCandidatesQuery.GetAllCandidatesQueryHandler(_mockRepo.Object);
            var result = 
                handler.Handle(new GetAllCandidatesQuery(), CancellationToken.None);
            
            await result.ShouldBeOfType<Task<IEnumerable<CandidateDto>>>();

            result.Result.Count().ShouldBe(2);
        }

        [Fact]
        public async Task Filter_Candidates_By_Test()
        {
            var candidateByDto = new CandidateByDto()
            {
                OperatorId = 0,
                TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA05"),
                YearsOfExperience = 3
            };
            _mockRepo = MockCandidateRepository.MockFilterCandidatesRepository(candidateByDto);

            var handler = new FilterCandidatesQuery.FilterCandidatesQueryHandler(_mockRepo.Object);
            var result = handler.Handle(new FilterCandidatesQuery(candidateByDto), CancellationToken.None);

            await result.ShouldBeOfType<Task<IEnumerable<CandidateDto>>>();
            result.Result.Count().ShouldBe(2);
        }
    }
}