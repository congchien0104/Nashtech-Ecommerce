using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Nashtech_Ecommerce.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        [ForeignKey("OrderId")]
        public string OrderId { get; set; }
        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
    }
}
