using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PersonalCards.Model.DTO
{
    [Table("purchase")]
    public class Purchase
    {
        public int Id { get; set; }
        public int? CardId { get; set; }
        public uint? PurchaseSum { get; set; }
        public PersonalCard PersonalCard { get; set; }
    }
}
