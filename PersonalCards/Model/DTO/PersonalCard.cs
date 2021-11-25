using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalCards.Model.DTO
{
    [Table("personal_card")]
    public class PersonalCard
    {
        public int Id { get; set; }
        public float? Discount { get; set; }
        public UserProfile UserProfile { get; set; }

        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
