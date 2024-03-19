using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class SPSReviewController : Controller
    {
        private ISubmissionService _submissionService;
        private IStaffService _staffService;
        public SPSReviewController(ISubmissionService submissionService, IStaffService staffService)
        {
            _submissionService = submissionService;
            _staffService = staffService;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _submissionService.GetSPSSubmissions();
            
            return View(data);
        }

        public async Task<IActionResult> ProcessedReviews()
        {
            var data = await _submissionService.SPSProcessedReviews();
            return View(data);
        }

        //public async Task<IActionResult> Approval(int submissionId, int approvalId)
        //{
        //    var data = await _submissionService.Departmentapproval(submissionId, approvalId);
        //    return Ok(data);
        //}
    }
}
