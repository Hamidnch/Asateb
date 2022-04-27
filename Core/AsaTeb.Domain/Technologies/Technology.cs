namespace AsaTeb.Domain.Technologies
{
    public class Technology : BaseEntity
    {
        public string? Name { get; set; }

        public Technology(string? name)
        {
            Name = name;
        }

        public Technology(Guid id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
