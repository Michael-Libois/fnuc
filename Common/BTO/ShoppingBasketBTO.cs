﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.BTO
{
    public class ShoppingBasketBTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public UserBTO User { get; set; }
        public List<ShoppingProductBTO> shoppingProductBTOs { get; set; }
    }
}
