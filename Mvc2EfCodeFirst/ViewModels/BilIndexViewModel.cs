using System.Collections.Generic;
using System.Diagnostics;

namespace Mvc2EfCodeFirst.ViewModels
{
    public class BilIndexViewModel
    {
        public List<BilListItem> Items { get; set; }

    }


    public class BilListItem
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
    }


    public class BilCartViewModel
    {
        public List<BilListItem> Items { get; set; }
        
    }


}