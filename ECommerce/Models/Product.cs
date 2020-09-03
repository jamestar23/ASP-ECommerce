using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Column(TypeName="decimal(18,2)")]
        public decimal Fee { get; set; }
        public string ImageUrl { get; set; }
        public bool HasFastShipping { get; set; }

        public Category Category { get; set; }

        public bool HasDiscount { get; set; }
    }
}
