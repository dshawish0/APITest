using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class api_student
    {
        [Key]
        public int StudentId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public DateTime? BirthDate { get; set; }
        public float? StudentMark { get; set; }
    }
}
