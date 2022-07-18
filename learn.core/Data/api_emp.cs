using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class api_emp
    {
        [Key]
        public int empId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string email { get; set; }
        public float salary { get; set; }
        public int depId { get; set; }
    }
}
