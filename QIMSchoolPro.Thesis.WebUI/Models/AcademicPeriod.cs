namespace QIMSchoolPro.Thesis.WebUI.Models
{
    public class AcademicPeriod
    {
        public string AcademicYear { get; set; }
        public Semester Semester { get; set; }
    }
    public enum Semester
    {
        FirstSemester = 1,
        SecondSemester,
    }
}
