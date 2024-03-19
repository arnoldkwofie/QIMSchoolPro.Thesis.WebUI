using QIMSchoolPro.Thesis.Services.Models.Enum;
using System.Reflection.Metadata;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class StaffViewModel
    {
        public string StaffNumber { get;  set; }
        public string ProfileUrl { get;  set; }
        public int DepartmentId { get;  set; }
        public PartyViewModel Party { get; set; }
        public int PartyId { get; set; }
    }
}
