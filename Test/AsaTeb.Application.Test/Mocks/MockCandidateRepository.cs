using AsaTeb.Application.Candidates.Dtos;
using AsaTeb.Application.Candidates.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using AsaTeb.Domain.Shared.Common;

namespace AsaTeb.Application.Test.Mocks
{
    public static class MockCandidateRepository
    {
        public static Mock<ICandidateRepository> MockLoadAllCandidatesRepository()
        {
            var candidates = new List<CandidateDto>()
            {
                new CandidateDto
                {
                    CandidateId = Guid.Parse("2e061e56-a16d-4623-b0b6-1eab550394ad"),
                    Gender = GenderType.Male,
                    FirstName = "Bruce",
                    LastName = "Parisian",
                    Experience = new List<ExperienceDto>(3)
                    {
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA12"),
                            TechnologyName = "Swift",
                            YearsOfExperience = 2
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA17"),
                            TechnologyName = "R",
                            YearsOfExperience = 10
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA05"),
                            TechnologyName = "TypeScript",
                            YearsOfExperience = 2
                        }
                    }
                },

                new CandidateDto
                {
                    CandidateId = Guid.Parse("0ed053c0-27d6-4252-89a9-760f8e0e5e8a"),
                    FirstName = "Dana",
                    LastName = "Tillman",
                    Gender = GenderType.Male,
                    Experience = new List<ExperienceDto>(3)
                    {
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA04"),
                            TechnologyName = "Rust",
                            YearsOfExperience = 9
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA09"),
                            TechnologyName = "Julia",
                            YearsOfExperience = 8
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA15"),
                            TechnologyName = "Scala",
                            YearsOfExperience = 2
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA05"),
                            TechnologyName = "TypeScript",
                            YearsOfExperience = 4
                        }
                    }
                },
            };

            var mockRepo = new Mock<ICandidateRepository>();
            mockRepo.Setup(r => r.LoadAllCandidatesAsync()).ReturnsAsync(candidates);

            return mockRepo;
        }

        public static Mock<ICandidateRepository> MockFilterCandidatesRepository(CandidateByDto candidateByDto)
        {
            var candidates = new List<CandidateDto>()
            {
                new CandidateDto
                {
                    CandidateId = Guid.Parse("2e061e56-a16d-4623-b0b6-1eab550394ad"),
                    Gender = GenderType.Male,
                    FirstName = "Bruce",
                    LastName = "Parisian",
                    Experience = new List<ExperienceDto>(3)
                    {
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA12"),
                            TechnologyName = "Swift",
                            YearsOfExperience = 2
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA17"),
                            TechnologyName = "R",
                            YearsOfExperience = 10
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA05"),
                            TechnologyName = "TypeScript",
                            YearsOfExperience = 2
                        }
                    }
                },

                new CandidateDto
                {
                    CandidateId = Guid.Parse("0ed053c0-27d6-4252-89a9-760f8e0e5e8a"),
                    FirstName = "Dana",
                    LastName = "Tillman",
                    Gender = GenderType.Male,
                    Experience = new List<ExperienceDto>(3)
                    {
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA04"),
                            TechnologyName = "Rust",
                            YearsOfExperience = 9
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA09"),
                            TechnologyName = "Julia",
                            YearsOfExperience = 8
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA15"),
                            TechnologyName = "Scala",
                            YearsOfExperience = 2
                        },
                        new ExperienceDto()
                        {
                            TechnologyId = Guid.Parse("3B85BE83-9B4E-4B15-9EB2-68363936CA05"),
                            TechnologyName = "TypeScript",
                            YearsOfExperience = 4
                        }
                    }
                },
            };

            var mockRepo = new Mock<ICandidateRepository>();
            mockRepo.Setup(r => r.FilterCandidatesAsync(candidateByDto)).ReturnsAsync(candidates);

            return mockRepo;
        }
    }
}
