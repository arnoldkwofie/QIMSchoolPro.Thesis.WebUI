namespace QIMSchoolPro.Thesis.Services.Models.ServiceModels
{
    public class HttpUrlConstant
    {
        public static string Create(string route) => $"{route}/Create";
        public static string Decide(string route) => $"{route}/Decide";
        public static string PostSubmission(string route) => $"{route}/PostSubmission";
        public static string GetUserSubmissions(string route) => $"{route}/GetUserSubmissions";
        public static string GetDepartmentSubmissions(string route) => $"{route}/GetDepartmentSubmissions";
        public static string GetSPSSubmissions(string route) => $"{route}/GetSPSSubmissions";
        public static string GetSubmissionHistoryBySubmissionId(string route, int id) => $"{route}/GetSubmissionHistoryBySubmissionId?id=" + id;
        public static string Get(string route, int id) => $"{route}/Get?id="+ id;
        public static string DepartmentApproval(string route, int submissionId, int approvalId)
        => $"{route}/DepartmentApproval?submissionId={submissionId}&approvalId={approvalId}";
        public static string GetByStaffId(string route) => $"{route}/GetByStaffId";
        public static string GetApprovedByStaffId(string route) => $"{route}/GetApprovedByStaffId";
        public static string StaffLookup(string route, int id) => $"{route}/StaffLookup?id=" + id;
        public static string GetGradeParams(string route) => $"{route}/GetGradeParams";

        public static string Delete(string route, int id) => $"{route}/Delete/"+ id;

    }
}
