using QIMSchoolPro.Thesis.Services.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class StudentViewModel
    {
        public string StudentNumber { get; set; }
        public string IndexNumber { get; set; }
        public string StudentType { get; set; }
       // public YearGroup YearGroup { get; set; }
        public AcademicCycle AcademicCycle { get; set; }
        public ProgrammeViewModel Programme { get;  set; }
        public PartyViewModel Party { get; set; }
    }
}
