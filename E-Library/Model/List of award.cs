﻿using System.ComponentModel.DataAnnotations;

namespace E_Library.Model
{
    public class List_of_award
    {
        [Key]
        public int List_of_award_ID { get; set; }
        public string Award_date { get; set; } = string.Empty;
        public string Award_content { get; set; } = string.Empty;
        public IEnumerable<Student> Student { get; set; }
        public IEnumerable<Class> Class { get; set; }
    }
}