﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBookKata.DiscountRules
{
   public class DiscountRuleThreeDifferentBooks: IDiscountRule
   {
       public decimal DiscountPercent => 0.1m;
       public bool CanBeUsed(Purchase purchase)
       {
            return purchase.ItemRows.Count() >= 3;
        }
    }
}