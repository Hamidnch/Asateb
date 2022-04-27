using AsaTeb.Domain.Shared.Common;

namespace AsaTeb.Application.Candidates
{
    public class CandidateDto
    {
        public Guid Id { get; set; }
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
    }
}
