using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string No { get; set; }
        public string PhotoUrl { get; set; }
        public string Department { get; set; }
        public string Campus { get; set; }
        public int YearGroup { get; set; }
        public static UserViewModel Default()
        {
            return new UserViewModel
            {
                Name = "Session Expired",
                FirstName = "Init",
                LastName = "Mensah"
            };
        }
    }
}
