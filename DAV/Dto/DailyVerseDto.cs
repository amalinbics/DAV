using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAV.Dto
{
    public class DailyVerseDto
    {
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime VerseDate { get; set; }

        [Required]
        [MaxLength(250)]
        public string VerseTitle { get; set; }

        [Required]
        [MaxLength(2500)]
        public string Verse { get; set; }
    }
}