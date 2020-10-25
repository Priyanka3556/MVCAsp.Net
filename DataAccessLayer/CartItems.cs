using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class CartItems
    {
        [Key]
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
    }
}
