using AsaTeb.Domain.Shared.Common;

namespace AsaTeb.Persistence.Candidates
{
    public class CandidateRest
    {
        public CandidateRest(Guid candidateId, string? firstName, string? lastName,
            GenderType gender, string? profilePicture, string? email, string? favoriteMusicGenre, 
            string? dad, string? mom, bool canSwim, string? barcode)
        {
            CandidateId = candidateId;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            ProfilePicture = profilePicture;
            Email = email;
            FavoriteMusicGenre = favoriteMusicGenre;
            Dad = dad;
            Mom = mom;
            CanSwim = canSwim;
            Barcode = barcode;
            Experience = new List<ExperienceRest>();
        }

        private Guid CandidateId { get; set; }
        private string? FirstName { get; set; }
        private string? LastName { get; set; }
        private GenderType Gender { get; set; }
        private string? ProfilePicture { get; set; }
        private string? Email { get; set; }
        private string? FavoriteMusicGenre { get; set; }
        private string? Dad { get; set; }
        private string? Mom { get; set; }
        private bool CanSwim { get; set; }
        private string? Barcode { get; set; }
        public IEnumerable<ExperienceRest> Experience { get; set; }
    }
}
