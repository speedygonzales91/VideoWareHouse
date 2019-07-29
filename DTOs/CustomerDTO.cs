using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoProject.ValidationAttributes;

namespace VideoProject.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }


        public MembershipDTO Membership { get; set; }


        public byte MembershipTypeId { get; set; }

       // [Min18YearsIsAMember]
        public DateTime? BirthDate { get; set; }
    }
}