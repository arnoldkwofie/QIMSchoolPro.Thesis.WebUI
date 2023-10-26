namespace QIMSchoolPro.Thesis.WebUI.Models.CommandModels
{
    public class SubmissionCommand
    {
        public string StudentNumber { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IFormFile PrimaryFile { get; set; }
        public IFormFile SecondaryFile { get; set; }

        public string PrimaryFilePath { get; set; }
        public string SecondaryFilePath { get; set; }
    }
}
