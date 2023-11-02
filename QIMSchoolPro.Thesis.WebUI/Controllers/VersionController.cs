﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.WebUI.Models.CommandModels;
using QIMSchoolPro.Thesis.WebUI.Services.Interfaces;
using System.Net;
using System.Reflection;

namespace QIMSchoolPro.Thesis.WebUI.Controllers
{
    public class VersionController : Controller
    {
        public IVersionService _versionService { get; }
        public VersionController(IVersionService versionService)
        {
            _versionService = versionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(VersionCommand model)
        {
            try
            {
                if(model.File !=null)
                {
                    string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/FileUpload", model.File.FileName);
                    model.FilePath = FilePath;
                    using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(stream);
                    }
                }
              
                var data = await _versionService.Create(model);
                return Json(data);
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(Response);
            }
            
        }

    
    }
}