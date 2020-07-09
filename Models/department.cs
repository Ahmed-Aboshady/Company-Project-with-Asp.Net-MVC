using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int deptid { get; set; }

        [StringLength(50)]
        public string deptname { get; set; }

        [StringLength(50)]
        public string location { get; set; }

        [StringLength(50)]
        public string imgpath { get; set; }

        public virtual ICollection<employee> employees { get; set; }

    }
}