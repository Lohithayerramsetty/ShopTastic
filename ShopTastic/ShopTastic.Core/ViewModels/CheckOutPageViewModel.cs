using ShopTastic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTastic.Core.ViewModels
{
   public class CheckOutPageViewModel
    {
        public CheckOutPage checkOutPage { get; set; }
        public IEnumerable<BasketItemViewModel> basketItemViewModels { get; set; }
    }
}
