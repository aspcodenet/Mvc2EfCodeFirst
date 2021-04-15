using System.Collections.Generic;

namespace Mvc2EfCodeFirst.ViewModels
{
    public class BilIndexViewModel
    {
        public List<Item> Items { get; set; }

        public class Item
        {
            public int Id { get; set; }
            public string Manufacturer { get; set; }
        }
    }
}