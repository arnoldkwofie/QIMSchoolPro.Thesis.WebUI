using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.CommandModels
{
    public class ThesisAssignmentCommand
    {
        public int SubmissionId { get; set; }
        public int StaffId { get; set; }
        public int ReviewerType { get; set; }
        public DateTime Deadline { get; set; }



    }
}
