using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class SubmissionController : Controller
    {
		private readonly IThesisAssignmentService _thesisAssignmentService;
        private readonly ISubmissionService _submissionService;
        private readonly IStaffService _staffService;

		public SubmissionController(IThesisAssignmentService thesisAssignmentService, ISubmissionService submissionService, IStaffService staffService)
		{
			_thesisAssignmentService = thesisAssignmentService;
            _submissionService = submissionService;
            _staffService = staffService;
		}

		public async Task<IActionResult> Index()
        {
			var data = await _thesisAssignmentService.GetAssignmentByStaffId("admin@localhost");
			return View();
        }


        public async Task<IActionResult> SubmissionDetail(int id)
        {
            var data = await _submissionService.GetAsync(id);

            var staffLookup = await _staffService.StaffLookup(id);
         

            ViewBag.StaffLookup = staffLookup.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            return View(data);
        }
    }
}
