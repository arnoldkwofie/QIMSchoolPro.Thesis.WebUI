namespace QIMSchoolPro.Thesis.WebUI.Models.ServiceModels
{
    public class HttpUrlConstant
    {
        public static string Create(string route) => $"{route}/Create";
        public static string PostSubmission(string route) => $"{route}/PostSubmission";
        public static string GetUserSubmissions(string route) => $"{route}/GetUserSubmissions";
        public static string GetSubmissionHistoryBySubmissionId(string route, int id) => $"{route}/GetSubmissionHistoryBySubmissionId?id=" + id;
        public static string Get(string route, int id) => $"{route}/Get?id="+ id;

    }
}
