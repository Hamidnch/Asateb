using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AsaTeb.WebFramework.Models
{
    public class CriteriaModel
    {
        public CriteriaModel()
        {
            Technologies = new List<SelectListItem>();
            YearsOfExperiences = new List<SelectListItem>();
            Operators = new List<SelectListItem>();
        }

        public List<SelectListItem> Technologies { get; set; }
        public List<SelectListItem> YearsOfExperiences { get; set; }
        public List<SelectListItem> Operators { get; set; }

        public Guid TechnologyId { get; set; }
        public int Year { get; set; }
        public int Operator { get; set; }
    }
}
