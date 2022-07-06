using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class api_course
    {
        [Key]
        public int CourseId { get; set; }
        public string Coursename { get; set; }
        public float? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImagePath { get; set; }

    }
}
