using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "ivalid name")]
        [Display(Name = "fullname")]
        [Required(ErrorMessage = "*")]
        public string name { get; set; }

        [StringLength(50)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$")]
        public string emali { get; set; }
        [Required(ErrorMessage = "*")]
        public string password { get; set; }
        [NotMapped]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "not match")]
        [Display(Name = "confirm")]
        public string confirmpassword { get; set; }

        [Range(1000, 5000, ErrorMessage = "Salary must between 1000 and 5000")]
        public int? salary { get; set; }
       
        [Range(20, 60, ErrorMessage = "age must between 20 and 60")]
        public int? age { get; set; }

        [StringLength(50)]
        public string imgpath { get; set; }

        [StringLength(50)]
        public string cvpath { get; set; }

        public int? deptid { get; set; }

        public virtual department department { get; set; }


    }
}