using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.Enum;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ISubmissionService _submissionService;

        public LibraryController(ISubmissionService submission)
        {
            _submissionService = submission;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _submissionService.GetLibrarySubmissions();
            return View(data);
        }
    }
}
