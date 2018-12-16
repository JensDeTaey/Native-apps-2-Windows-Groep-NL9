using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendV7.Models.ViewModels
{
    public class EditBusinessViewModel
    {


        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string PictureURL { get; set; }
        [Required]
        public string LinkWebsite { get; set; }
    }
}