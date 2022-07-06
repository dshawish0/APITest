using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace learn.core.Data
{
    public class api_book
    {
        [Key]
        public int BOOKID { get; set; }
        public string BOOKNAME { get; set; }
        public float? PRICE { get; set; }
        public DateTime? PUBLISHEDDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        public int COURSEID { get; set; }
    }
}
