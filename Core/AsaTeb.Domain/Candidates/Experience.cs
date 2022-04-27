using AsaTeb.Domain.Technologies;

namespace AsaTeb.Domain.Candidates
{
    public class Experience
    {
        public Guid TechnologyId { get; set; }
        public int YearsOfExperience { get; set; }
        //public virtual Technology Technology { get; set; }
    }
}
