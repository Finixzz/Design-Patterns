using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Models
{
    public class ItemAddition
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }


        public Item Item { get; set; }

        public int ItemId { get; set; }


    }
}
