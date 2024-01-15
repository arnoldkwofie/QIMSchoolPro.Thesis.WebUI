﻿using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using System.Threading.Tasks;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IThesisAssignmentService 
    {
		Task<List<ThesisAssignmentViewModel>> GetAssignmentByStaffId(string id);
        Task<RequestResponse> AssignThesis(ThesisAssignmentCommand payload);


    }
}