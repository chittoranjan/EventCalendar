using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models.ViewModels
{
    public class RegistrationDetailViewModel
    {
        public int? Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        [MaxLength(250)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Mobile No")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}