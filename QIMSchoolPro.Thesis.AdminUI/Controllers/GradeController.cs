﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

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
    }
}
