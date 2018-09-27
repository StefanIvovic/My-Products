using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessEntities
{
    public class CategoryEntity
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
