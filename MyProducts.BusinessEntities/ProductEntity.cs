using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessEntities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }

        public int ManufacturerId { get; set; }
        public ManufacturerEntity Manufacturer { get; set; }

        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; }
    }
}
