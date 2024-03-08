using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QIMSchoolPro.Thesis.Services.Models.CommandModels
{
    public class GradeCommand
    {
        public int AssignmentId { get; set; }
        public int GradeParamId { get; set; }
        public decimal Marks { get; set; }
        public string Comment { get; set; }
    }

    public class Payload
    {
        public int AssignmentId { get; set; }
        public List<GradeCommand> Data { get; set; }
    }
}
