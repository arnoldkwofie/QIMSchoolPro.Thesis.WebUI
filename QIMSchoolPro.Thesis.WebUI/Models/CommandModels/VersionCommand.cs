namespace QIMSchoolPro.Thesis.WebUI.Models.CommandModels
{
    public class VersionCommand
    {
        public int DocumentId { get; set; }
        public IFormFile File { get; set; }
        public string FilePath { get; set; }
       
    }
}
