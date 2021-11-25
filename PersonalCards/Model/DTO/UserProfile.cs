using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalCards.Model.DTO
{
    [Table("user_profile")]
    public class UserProfile
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public PersonalCard PersonalCard { get; set; }
    }
}
