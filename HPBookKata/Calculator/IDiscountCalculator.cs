using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPBookKata.DiscountRules;

namespace HPBookKata.Calculator
{
   public interface IDiscountCalculator
   {
       decimal Calculate();
   }
}
