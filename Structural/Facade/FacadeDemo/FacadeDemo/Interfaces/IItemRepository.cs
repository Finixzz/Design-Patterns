using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Interfaces
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();

        Item GetItem(int id);
    }
}
