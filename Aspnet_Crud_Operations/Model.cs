using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aspnet_Crud_Operations
{
    public class Model
    {
        public int studentID { get; set; }
        public string studentName { get; set; }
        public int firstYearMarks { get; set; }
        public int secondYearMarks { get; set; }
        public int totalMarks { get; set; }
        public String Grade { get; set; }
    }
}