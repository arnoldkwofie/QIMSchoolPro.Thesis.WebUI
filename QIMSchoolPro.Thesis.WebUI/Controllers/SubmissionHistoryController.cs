using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using System.Net;
using System.Reflection;

namespace QIMSchoolPro.Thesis.WebUI.Controllers
{
    public class SubmissionHistoryController : Controller
    {
        public ISubmissionService _submissionService { get; }
        public SubmissionHistoryController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        public IActionResult Index()
        {
            return View();
        }


    

      
    }
}
