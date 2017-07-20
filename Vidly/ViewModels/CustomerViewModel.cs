using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;


namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthdate { get; set; }

        public bool IsSubsriberdToNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}