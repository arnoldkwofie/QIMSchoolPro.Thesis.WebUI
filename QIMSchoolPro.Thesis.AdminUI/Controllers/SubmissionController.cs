using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class SubmissionController : Controller
    {
		private readonly IThesisAssignmentService _thesisAssignmentService;

		public SubmissionController(IThesisAssignmentService thesisAssignmentService)
		{
			_thesisAssignmentService = thesisAssignmentService;
		}

		public async Task<IActionResult> Index()
        {
			var data = await _thesisAssignmentService.GetAssignmentByStaffId("admin@localhost");
			return View();
        }
    }
}
