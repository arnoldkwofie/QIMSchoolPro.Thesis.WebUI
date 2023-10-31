using QIMSchoolPro.Thesis.WebUI.Models.Enum;

namespace QIMSchoolPro.Thesis.WebUI.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public TransitionState TransitionState { get; set; }
        public DateTime SubmissionDate { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
    }
}
