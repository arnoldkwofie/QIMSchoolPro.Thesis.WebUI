using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using QIMSchoolPro.Thesis.WebUI.Services.Implementations;
using System.Net;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class GradeController : Controller
    {
        private IGradeService _gradeService;

        public GradeController(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetGradeParams()
        {
            var data = await _gradeService.GetGradeParams();
            return View(data);
        }

        public async Task<IActionResult> SaveGrade(Payload payload)
        {
            var result = await _gradeService.SaveGrade(payload.Data);
            return Ok(result);
        }

        public async Task<IActionResult> UploadReport(VersionCommand model)
        {
            try
            {
                if (model.File != null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Report", model.File.FileName);
                    model.FilePath = FilePath;
                    using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }
                }

                UploadCommand data = new UploadCommand();
                data.ThesisAssignmentId = model.DocumentId;
                data.Path = model.File.FileName;

                var result = await _gradeService.UploadReport(data);
                return Json(result);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(Response);
            }

        }
    }

 

}
