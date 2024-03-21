using QIMSchoolPro.Thesis.Services.Models.Enum;
using System.Reflection.Metadata;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class VersionViewModel
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        //public DocumentViewModel Document { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ChangePath => Path;
    }
}
