using AsaTeb.Domain.Shared.Common;

namespace AsaTeb.Domain.Candidates
{
    public class Candidate : BaseEntity
    {
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public GenderType GenderType { get; private set; }
        public string? ProfilePicture { get; private set; }
        public string? Email { get; private set; }
        public string? FavoriteMusicGenre { get; private set; }
        public string? Dad { get; private set; }
        public string? Mom { get; private set; }
        public bool CanSwim { get; private set; } = default;
        public string? Barcode { get; private set; }

        public ICollection<Experience> Experiences { get; private set; }

        public Candidate()
        {
            
        }
        public Candidate(string? firstName, string? lastName, GenderType genderType,
            string? profilePicture, string? email, string? favoriteMusicGenre,
            string? dad, string? mom, bool canSwim, string? barcode)
        {
            FirstName = firstName;
            LastName = lastName;
            GenderType = genderType;
            ProfilePicture = profilePicture;
            Email = email;
            FavoriteMusicGenre = favoriteMusicGenre;
            Dad = dad;
            Mom = mom;
            CanSwim = canSwim;
            Barcode = barcode;
            Experiences = new List<Experience>();
        }
    }
}
