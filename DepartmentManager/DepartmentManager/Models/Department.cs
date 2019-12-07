using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DepartmentManager.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please enter department code")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Department code should be 7-2 character long")]
        [Column(TypeName = "varchar")]
        [Remote("IsCodeExist","Department",ErrorMessage = "Code already Exist")]
        [DisplayName("Department Code")]
        public string DepartmentCode { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50,ErrorMessage = "Department name should be 50 character long")]
        [DisplayName("Department Name")]

        public string DepartmentName { get; set; }
    }
}