using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class DepartmentReviewController : Controller
    {
        private ISubmissionService _submissionService;

        public DepartmentReviewController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _submissionService.GetDepartmentSubmissions();
            return View(data);
        }
        public async Task<IActionResult> ProcessedReviews()
        {
            var data = await _submissionService.DepartmentProcessedReviews();
            return View(data);
        }
        public async Task<IActionResult> Approval(int submissionId, int approvalId)
        {
            var data = await _submissionService.Departmentapproval(submissionId, approvalId);
            return Ok(data);
        }
    }
}
