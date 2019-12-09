using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DepartmentManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string  StudentReg { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}