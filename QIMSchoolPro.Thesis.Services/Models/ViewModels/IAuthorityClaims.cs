using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
 
        public class IAuthorityClaims
        {
            public string Sub { get; set; }
            public string Website { get; set; }
            public string FamilyName { get; set; }
            public string GivenName { get; set; }
            public string Name { get; set; }
            public string PreferredUsername { get; set; }
            public string Token { get; set; }
        
    }
}
