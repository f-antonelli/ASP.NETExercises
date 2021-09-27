using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
		public class Customer
		{
			public int Id { get; set; }

			[Required]
			[StringLength(255)]
			public string Name { get; set; }
			public bool IsSubcribedToNewsletter { get; set; }

			[Display(Name = "Membership Type")]
			public MembershipType MembershipType { get; set; }
			public byte MembershipTypeId { get; set; } //Como es byte, el campo es requerido

			[Display(Name = "Date of Birth")]
			[Min18YearsIfAMember]
			public Nullable<DateTime> Birthdate { get; set; }

	}	
}