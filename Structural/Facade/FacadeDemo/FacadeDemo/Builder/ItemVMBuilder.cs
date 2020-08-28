using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Builder
{
    class ItemVMBuilder : IItemVMBuilder
    {
        public ItemViewModel GetItemViewModel(Item item, Category category, List<ItemAddition> itemAdditions)
        {
            ItemViewModel viewModel = new ItemViewModel();
            viewModel.Id = item.Id;
            viewModel.Name = item.Name;
            viewModel.Price = item.Price;
            viewModel.Category = category;
            viewModel.ItemAdditions = itemAdditions;
            return viewModel;
        }
    }
}
