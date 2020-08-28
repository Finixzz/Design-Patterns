using DesignPatternsConsoleAppDemo.Interfaces;
using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DesignPatternsConsoleAppDemo.Implementations
{
    public  class ItemMockUpRepository : IItemRepository
    {

        private List<Item> _itemList;

        public ItemMockUpRepository()
        {
            _itemList = new List<Item>()
            {
                new Item(){Id=1,Name="Coffee",Price=1.5M,CategoryId=1000},
                new Item(){Id=2,Name="Tea",Price=1.5M,CategoryId=1000},
                new Item(){Id=3,Name="Lemonade",Price=2.1M,CategoryId=1000},
            };
        }
        public Item GetItem(int id)
        {
            return _itemList.SingleOrDefault(c => c.Id == id);
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemList;
        }
    }
}
