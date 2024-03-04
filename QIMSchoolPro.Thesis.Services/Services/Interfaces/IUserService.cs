using QIMSchoolPro.Thesis.Services.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetLoginUser();
        //Task InitAsync(string id);

    }
}
