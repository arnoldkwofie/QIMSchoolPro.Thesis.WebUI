using System;
using System.Collections.Generic;
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
			public int Decision { get; set; }
			public DateTime Deadline { get; set; }

		
	}
}
