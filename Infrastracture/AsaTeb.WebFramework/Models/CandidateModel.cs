using AsaTeb.Domain.Shared.Common;

namespace AsaTeb.WebFramework.Models
{
    public class CandidateModel
    {
        public CandidateModel(IEnumerable<ExperienceModel> experience)
        {
            Experience = experience;
        }

        public Guid CandidateId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";
        public GenderType Gender { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Email { get; set; }
        public string? FavoriteMusicGenre { get; set; }
        public string? Dad { get; set; }
        public string? Mom { get; set; }
        public bool CanSwim { get; set; }
        public string? Barcode { get; set; }
        public IEnumerable<ExperienceModel> Experience { get; set; }
    }
}
