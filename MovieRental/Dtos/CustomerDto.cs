﻿using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetters { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte? MembershipTypeId { get; set; }
        //[Must18YearsOldIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}