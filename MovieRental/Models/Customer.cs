using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRental.Models
{
    public class Customer
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter the Name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetters { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte? MembershipTypeId { get; set; }
        [Must18YearsOldIfAMember]
        public DateTime? BirthDate { get; set; }

        

    }
}