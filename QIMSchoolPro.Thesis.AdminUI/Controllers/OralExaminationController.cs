using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
	public class OralExaminationController : Controller
	{
		private IOralExaminationService _oralExaminationService;

        public OralExaminationController(IOralExaminationService oralExaminationService)
        {
            _oralExaminationService = oralExaminationService;
        }

        public async  Task<IActionResult> Index(int id)
		{
			ViewBag.Id = id;
			var data = await _oralExaminationService.GetAll();
			return View(data);
		}
		
		public async  Task<IActionResult> Schedule (ScheduleCommand command)
		{
			var data = await _oralExaminationService.Schedule(command);	
			return Ok(data);
		}

      
    }

	
}
