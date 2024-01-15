using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class ThesisAssignmentController : Controller
    {
        private readonly IThesisAssignmentService _thesisAssignmentService;

        public ThesisAssignmentController(IThesisAssignmentService thesisAssignmentService)
        {
            _thesisAssignmentService = thesisAssignmentService;
        }
        public async Task<IActionResult> AssignThesis(ThesisAssignmentCommand comand)
        {
			var response = await _thesisAssignmentService.AssignThesis(comand);
			return View();
        }


		
	}
}
