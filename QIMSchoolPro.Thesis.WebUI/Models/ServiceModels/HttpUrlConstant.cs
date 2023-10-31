namespace QIMSchoolPro.Thesis.WebUI.Models.ServiceModels
{
    public class HttpUrlConstant
    {
        public static string Create(string route) => $"{route}/Create";
        public static string Gets(string route) => $"{route}/Gets";
        public static string Get(string route, int id) => $"{route}/Get?id="+ id;

    }
}
