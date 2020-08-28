using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Builder
{
    public interface IItemVMBuilder
    {
        ItemViewModel GetItemViewModel(Item item, Category category, List<ItemAddition> itemAdditions);
    }
}
