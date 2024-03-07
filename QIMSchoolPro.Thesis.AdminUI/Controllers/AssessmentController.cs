using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    
    public class AssessmentController : Controller
    {
        private readonly IThesisAssignmentService _thesisAssignmentService;
        private  readonly IGradeService _gradeService;
        public AssessmentController(IThesisAssignmentService thesisAssignmentService, IGradeService gradeService)
        {
            _thesisAssignmentService = thesisAssignmentService;
            _gradeService = gradeService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _thesisAssignmentService.GetApprovedAssignmentByStaffId();
            var paramData = await _gradeService.GetGradeParams();
            var result = new BigData
            {
                ThesisAssignment = data,
                GradeParam = paramData
            };
            
            return View(result);
        }

     
    }

    public class BigData
    {
        public List<ThesisAssignmentViewModel> ThesisAssignment { get; set; }
        public List<GradeParamViewModel> GradeParam  { get; set; }

    }
}
