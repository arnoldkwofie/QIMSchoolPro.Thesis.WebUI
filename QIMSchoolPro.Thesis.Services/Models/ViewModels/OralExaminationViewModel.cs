using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class OralExaminationViewModel
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public SubmissionViewModel Submission { get; set; }
        public DateTime ExaminationDate { get; set; }
    }
}
