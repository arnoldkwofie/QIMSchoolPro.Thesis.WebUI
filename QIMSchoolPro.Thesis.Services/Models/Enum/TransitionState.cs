namespace QIMSchoolPro.Thesis.Services.Models.Enum
{
    public enum TransitionState
    {
        Created = 1,
        Department_Review,
        SPS_Review,
        Examiner_Review
    }

    public enum ReviewerType
    {
        First_Internal_Examiner = 1,
        Second_Internal_Examiner,
        Externa_Examiner
    }
}
