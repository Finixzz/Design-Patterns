using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public List<ItemAddition> ItemAdditions { get; set; }
    }
}
