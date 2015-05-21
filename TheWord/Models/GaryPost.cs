using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheWord.Models
{
    public class GaryPost
    {
        public int ID { get; set; }
        [Display(Name ="Title")]
        public string Title { get; set; }
        public DateTime PostedDate { get; set; }
        public string ByUser { get; set; }
        [Display(Name = "Tell your story Gary.")]
        public string PostDetail { get; set; }

    }
}