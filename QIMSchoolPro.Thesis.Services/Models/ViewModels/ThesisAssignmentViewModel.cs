using QIMSchoolPro.Thesis.Services.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
	public class ThesisAssignmentViewModel
	{
		
			public int Id { get; set; }
			public int SubmissionId { get; set; }
			
			public SubmissionViewModel Submission { get; set; }
			public int StaffId { get; set; }
			public StaffViewModel Staff { get; set; }
			public int Decision { get; set; }
        public ReviewerType ReviewerType { get; set; }
        public DateTime Deadline { get; set; }
			public bool Assessment { get; set; }
        public List<GradeViewModel> Grades { get; set; }
        public List<ExaminerReportViewModel> ExaminerReports { get; set; }

    }

    public class ThesisAssignmentViewModelAnnex
    {

        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public StaffViewModel Staff { get; set; }
        public int StaffId { get; set; }
        public int Decision { get; set; }
        public DateTime Deadline { get; set; }
        public bool Assessment { get; set; }
        //public List<GradeViewModel> Grades { get; set; }
        //public List<ExaminerReportViewModel> ExaminerReports { get; set; }
    }

    public class GradeViewModel
    {
        public int Id { get; set; }
        public int ThesisAssignmentId { get; set; }
        public int GradeParamId { get; set; }
        public GradeParamViewModel GradeParam { get; set; }
        public decimal Marks { get; set; }

    }

    public class ExaminerReportViewModel
    {
        public int Id { get;  set; }
        public int ThesisAssignmentId { get;  set; }
        //public ThesisAssignmentDto ThesisAssignment { get; private set; }
        public string Path { get;  set; }
    }
}
