using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAV.Models
{
    public class DailyVerse
    {
        public int Id { get; set; }
        [Required]
        public DateTime VerseDate { get; set; }
        [Required]
        [MaxLength(250)]
        public string VerseTitle { get; set; }
        [Required]
        [MaxLength(2500)]
        public string Verse { get; set; }

    }
}