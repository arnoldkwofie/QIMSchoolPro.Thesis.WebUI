using Microsoft.AspNetCore.Mvc;
using QIMSchoolPro.Thesis.Services.Services.Interfaces;

namespace QIMSchoolPro.Thesis.AdminUI.Controllers
{
    public class StaffController : Controller
    {
        private IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        //public async Task<IActionResult> StaffLopkup(int Id)
        //{
        //    var data = await _staffService.StaffLookup(Id);
        //    return View(data);
        //}

        //public async Task<IActionResult> Approval(int submissionId, int approvalId)
        //{
        //    var data = await _submissionService.Departmentapproval(submissionId, approvalId);
        //    return Ok(data);
        //}
    }
}
