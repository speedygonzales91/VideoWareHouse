using System;
using System.ComponentModel.DataAnnotations;

namespace VideoProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        public string  Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //Navigation Property
        public MembershipType MembershipType { get; set; }
        //Foreign key

        [Display(Name= "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? BirthDate { get; set; }
    }
}