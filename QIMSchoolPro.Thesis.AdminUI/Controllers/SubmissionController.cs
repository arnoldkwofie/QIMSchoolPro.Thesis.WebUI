using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;
using System.Net;

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


        public async Task<IActionResult> Create(SubmissionCommand model)
        {
            try
            {
                if (model.PrimaryFile != null)
                {
                    string primaryFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileUpload", model.PrimaryFile.FileName);
                    model.PrimaryFilePath = primaryFilePath;
                    using (FileStream stream = new FileStream(primaryFilePath, FileMode.Create))
                    {
                        await model.PrimaryFile.CopyToAsync(stream);
                    }
                }

                if (model.ThesisForm != null)
                {
                    string thesisFormPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileUpload", model.ThesisForm.FileName);
                    model.ThesisFormPath = thesisFormPath;
                    using (FileStream stream = new FileStream(thesisFormPath, FileMode.Create))
                    {
                        await model.PrimaryFile.CopyToAsync(stream);
                    }
                }


                if (model.SecondaryFile != null)
                {
                    string secondaryFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileUpload", model.SecondaryFile.FileName);
                    model.SecondaryFilePath = secondaryFilePath;
                    using (FileStream stream = new FileStream(secondaryFilePath, FileMode.Create))
                    {
                        await model.SecondaryFile.CopyToAsync(stream);
                    }
                }

                var data = await _submissionService.Create(model);
                return Json(data);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(Response);
            }

        }



        public async Task<IActionResult> MySubmissions()
        {
            var data = await _submissionService.GetUserSubmissions();
            return View(data);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var data = await _submissionService.Delete(id);
            return Ok(data);
        }
        public async Task<IActionResult> AssignedSubmissions()
        {
            //var data = await _submissionService.GetUserSubmissions();
            //return View(data);
            return View();
        }

        public async Task<IActionResult> StudentSubmissionDetail(int id)
        {
            var data = await _submissionService.GetAsync(id);

            return View(data);
        }

        public async Task<IActionResult> PostSubmission(PostSubmission command)
        {
            var data = await _submissionService.PostSubmission(command);
            return Json(data);
        }

        public async Task<IActionResult> Reports()
        {
            return View();
        }
    }
}
