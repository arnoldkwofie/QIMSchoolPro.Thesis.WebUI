using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
   
    public class ExaminerReviewController : Controller
    {
        private IThesisAssignmentService _thesisAssignmentService;
        public ExaminerReviewController(IThesisAssignmentService thesisAssignmentService)
        {
            _thesisAssignmentService = thesisAssignmentService;
        }
        public async Task<IActionResult> Decide(DecisionCommand command)
        {
            var data = await _thesisAssignmentService.Decide(command);
            return Ok(data);
        }
    }
}
