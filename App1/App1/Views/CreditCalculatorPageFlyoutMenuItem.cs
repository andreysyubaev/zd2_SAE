using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Views
{
    public class CreditCalculatorPageFlyoutMenuItem
    {
        public CreditCalculatorPageFlyoutMenuItem()
        {
            TargetType = typeof(CreditCalculatorPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}