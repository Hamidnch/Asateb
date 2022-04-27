using System.ComponentModel.DataAnnotations;

namespace AsaTeb.WebFramework.Models
{
    public record TechnologyModel
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
