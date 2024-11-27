﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.BasketDto
{
    public class CreateBasketDto
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public int ProductID { get; set; }
        public int MenuTableID { get; set; }
    }
}
