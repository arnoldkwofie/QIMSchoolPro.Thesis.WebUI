﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.ViewModels
{
    public class GradeParamViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Section { get; set; }
        public Decimal MaxMarks { get; set; }
    }
}
