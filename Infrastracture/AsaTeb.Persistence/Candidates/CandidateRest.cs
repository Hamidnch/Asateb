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

        public Guid CandidateId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderType Gender { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Email { get; set; }
        public string? FavoriteMusicGenre { get; set; }
        public string? Dad { get; set; }
        public string? Mom { get; set; }
        public bool CanSwim { get; set; }
        public string? Barcode { get; set; }
        public IEnumerable<ExperienceRest> Experience { get; set; }
    }
}
