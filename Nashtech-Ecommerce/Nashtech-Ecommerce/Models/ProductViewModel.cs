using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nashtech_Ecommerce.Models
{
    public class ProductViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float PromationPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string CategoryID { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
