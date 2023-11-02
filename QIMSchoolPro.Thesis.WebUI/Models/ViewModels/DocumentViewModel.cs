using QIMSchoolPro.Thesis.WebUI.Models.Enum;
using System.Xml.Linq;

namespace QIMSchoolPro.Thesis.WebUI.Models.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        //public SubmissionViewModel Submission { get; set; }
        public string Name { get; set; }
        public DocumentType DocumentType { get; set; }
        public List<VersionViewModel> Versions { get; set; }
    }
}
