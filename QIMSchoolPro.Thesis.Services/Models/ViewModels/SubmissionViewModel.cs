using QIMSchoolPro.Thesis.Services.Models.Enum;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.Enum;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class SubmissionViewModel
    {
        public int Id { get; set; }
        public string StudentNumber { get; set; }
        public StudentViewModel Student { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public TransitionState TransitionState { get; set; }
        public DateTime SubmissionDate { get; set; }
        public AcademicPeriod AcademicPeriod { get; set; }
        public List<DocumentViewModel> Documents { get; set; }
        public List<SubmissionHistoryViewModel> SubmissionHistories { get; set; }

        
    }
}
