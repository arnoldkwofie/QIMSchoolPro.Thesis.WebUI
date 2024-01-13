using QIMSchoolPro.Thesis.Services.Models.Enum;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using System.Xml.Linq;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
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
