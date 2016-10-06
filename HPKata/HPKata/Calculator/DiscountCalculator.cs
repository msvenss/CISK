using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HPKata.DiscountRules;

namespace HPKata.Calculator
{
    public class DiscountCalculator : ICalculator
    {
        public decimal CalculatedAmount
        {
            get { return Calculate(_purchase, _rules); }
        }

        private Purchase _purchase;
        private IEnumerable<IDiscountRule> _rules;

        public DiscountCalculator(Purchase purchase, IEnumerable<IDiscountRule> rules)
        {
            _purchase = purchase;
            _rules = rules;
        }

        public decimal Calculate(Purchase purchase, IEnumerable<IDiscountRule> rules)
        {
            decimal amount = 0;

            List<PurchaseItem> checkDiscountList = purchase.ItemRows.OrderByDescending(ir => ir.NrOfItems).ToList();
            bool listHasItems = checkDiscountList.Count > 1;
            while (listHasItems)
            {
                IDiscountRule currentDiscountRule;
                try
                {
                    currentDiscountRule =
                        rules.First(r => r.CanBeUsed(new Purchase(checkDiscountList)));
                }
                catch (Exception)
                {
                    currentDiscountRule = new DiscountRuleNoDiscount();
                }

                foreach (var itemRow in checkDiscountList)
                {
                    amount += itemRow.ItemToBuy.PriceEUR*(1 - currentDiscountRule.DiscountPercent);
                    itemRow.NrOfItems -= 1;
                }
                if (checkDiscountList.Any(x => x.NrOfItems == 0))
                {
                    checkDiscountList.RemoveAll(x => x.NrOfItems == 0);
                }

                if (checkDiscountList.Count <= 0)
                {
                    listHasItems = false;
                }
            }
            return amount;
        }
    }
}