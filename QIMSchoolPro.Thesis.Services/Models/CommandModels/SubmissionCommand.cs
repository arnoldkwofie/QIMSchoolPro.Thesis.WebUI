using Microsoft.AspNetCore.Http;

namespace QIMSchoolPro.Thesis.Services.Models.CommandModels
{
    public class SubmissionCommand
    {
        public string StudentNumber { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public IFormFile PrimaryFile { get; set; }
        public IFormFile ThesisForm { get; set; }
        public IFormFile SecondaryFile { get; set; }

        public string PrimaryFilePath { get; set; }
        public string ThesisFormPath { get; set; }
        public string SecondaryFilePath { get; set; }
    }

    public class PostSubmission
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Abstract { get; set; }

	}

    public class PublishCommand
    {
        public int Id { get; set; }
        

    }

    public class ScheduleCommand
    {
        public int SubmissionNo { get; set; }
        public DateTime ExaminationDate { get; set; }

    }
}
