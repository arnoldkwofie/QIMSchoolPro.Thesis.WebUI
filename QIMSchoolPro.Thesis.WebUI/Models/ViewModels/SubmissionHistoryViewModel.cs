using QIMSchoolPro.Thesis.WebUI.Models.Enum;

namespace QIMSchoolPro.Thesis.WebUI.Models.ViewModels
{
    public class SubmissionHistoryViewModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public int PartyId { get; set; }
        public string Activity { get; set; }
        public DateTime ActivityDate { get; set; }


    }
}
