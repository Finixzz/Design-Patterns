using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Interfaces
{
    public interface IItemAdditionRepository
    {
        IEnumerable<ItemAddition> GetAll();
        IEnumerable<ItemAddition> GetItemAdditions(int itemId);


    }
}
