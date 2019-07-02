﻿using System;
using System.ComponentModel.DataAnnotations;

namespace VideoProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string  Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //Navigation Property
        public MembershipType MembershipType { get; set; }
        //Foreign key
        public byte MembershipTypeId { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}