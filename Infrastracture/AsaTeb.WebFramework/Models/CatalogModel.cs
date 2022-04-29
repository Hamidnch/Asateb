namespace AsaTeb.WebFramework.Models
{
    public class CatalogModel
    {
        public CatalogModel()
        {
            CandidatesModel = new List<CandidateModel>();
            CriteriaModel = new CriteriaModel();
        }
        public IEnumerable<CandidateModel> CandidatesModel { get; set; }
        public CriteriaModel CriteriaModel { get; set; }
    }
}
