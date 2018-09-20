﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProducts.BusinessEntities
{
    public class ManufacturerEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public virtual List<ProductEntity> Products { get; set; }
    }
}