using DesignPatternsConsoleAppDemo.Interfaces;
using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Implementations
{
    public class ItemAdditionMockUpRepository : IItemAdditionRepository
    {
        private List<ItemAddition> _itemAdditions;

        public ItemAdditionMockUpRepository()
        {
            _itemAdditions = new List<ItemAddition>()
            {
                new ItemAddition(){Id=100,Name="Milk",Cost=0.5M,ItemId=1},
                new ItemAddition(){Id=101,Name="Soy",Cost=0.8M,ItemId=1},
                new ItemAddition(){Id=102,Name="Whipped Cream",Cost=0.6M,ItemId=1},
                new ItemAddition(){Id=101,Name="Milk",Cost=0.5M,ItemId=2},
                new ItemAddition(){Id=103,Name="Ginger",Cost=0.5M,ItemId=2},
                new ItemAddition(){Id=103,Name="Ginger",Cost=0.5M,ItemId=3},
            };
        }
        public IEnumerable<ItemAddition> GetAll()
        {
            return _itemAdditions;
        }

        public IEnumerable<ItemAddition> GetItemAdditions(int itemId)
        {
            return _itemAdditions.Where(c => c.ItemId == itemId);
        }
    }

}
