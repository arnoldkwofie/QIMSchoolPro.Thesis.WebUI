﻿using QIMSchoolPro.Thesis.Services.Models.CommandModels;
using QIMSchoolPro.Thesis.Services.Models.ServiceModels;
using QIMSchoolPro.Thesis.Services.Models.ViewModels;


namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IOralExaminationService 
    {
        Task<RequestResponse> Schedule(ScheduleCommand payload);
        Task<List<OralExaminationViewModel>> GetAll();
    }
}
