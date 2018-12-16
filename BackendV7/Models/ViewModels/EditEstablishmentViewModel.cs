using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendV7.Models.ViewModels
{
    public class EditEstablishmentViewModel
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PictureURL { get; set; }
        [Required]
        public List<OpeningHour> OpeningHours { get; set; }
    }
}