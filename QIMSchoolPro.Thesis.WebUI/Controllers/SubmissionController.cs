using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;

using QIMSchoolPro.Thesis.Services.Services.Interfaces;
using System.Net;
using System.Reflection;

namespace QIMSchoolPro.Thesis.WebUI.Controllers
{
    public class SubmissionController : Controller
    {
        public ISubmissionService _submissionService { get; }
        
        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
            

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(SubmissionCommand model)
        {
            try
            {
                if(model.PrimaryFile !=null)
                {
                    string primaryFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileUpload", model.PrimaryFile.FileName);
                    model.PrimaryFilePath = primaryFilePath;
                    using (FileStream stream = new FileStream(primaryFilePath, FileMode.Create))
                    {
                        await model.PrimaryFile.CopyToAsync(stream);
                    }
                }
              

                if(model.SecondaryFile != null)
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

    

        public async Task<IActionResult> MySubmissions( ) 
        {
            var data = await _submissionService.GetUserSubmissions();
            return View(data);
        }

        public async Task<IActionResult> SubmissionDetail(int id)
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
