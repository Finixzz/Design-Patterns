using DesignPatternsConsoleAppDemo.Builder;
using DesignPatternsConsoleAppDemo.Implementations;
using DesignPatternsConsoleAppDemo.Interfaces;
using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FacadeDemo
{


    public class ItemFacade
    {
        private IItemRepository _itemRepository;
        private IItemAdditionRepository _itemAdditionRepository;
        private ICategoryRepository _categoryRepository;
        private ItemVMBuilder _itemVMBuilder;

        public ItemFacade()
        {
            _itemRepository = new ItemMockUpRepository();
            _itemAdditionRepository = new ItemAdditionMockUpRepository();
            _categoryRepository = new CategoryMockUpRepository();
            _itemVMBuilder = new ItemVMBuilder();

        }


        private ItemViewModel GetItemData(int itemId)
        {
            Item itemInDb = _itemRepository.GetItem(itemId);
            Category itemCategory = _categoryRepository.GetCategory(itemInDb.CategoryId);
            List<ItemAddition> itemAdditions = _itemAdditionRepository.GetItemAdditions(itemId).ToList();
            ItemViewModel itemViewModel = _itemVMBuilder.GetItemViewModel(itemInDb, itemCategory, itemAdditions);
            return itemViewModel;
        }

        public int ChoseItem()
        {
            var itemsInRepo = _itemRepository.GetItems().ToList();
            itemsInRepo.ForEach(i =>
            {
                Console.WriteLine($"Item ID: {i.Id}");
                Console.WriteLine($"Name: {i.Name}");
                Console.WriteLine("------------------");
            });
            Console.Write("Input item id to see all corelated informations: ");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void printItemInfo(int itemId)
        {
            ItemViewModel itemViewModel = GetItemData(itemId);
            Console.WriteLine($"Item ID: {itemViewModel.Id}");
            Console.WriteLine($"Name : {itemViewModel.Name}");
            Console.WriteLine($"Price: {itemViewModel.Price}");
            Console.WriteLine($"Category ID: {itemViewModel.Category.Id}");
            Console.WriteLine($"Category Name: {itemViewModel.Category.Name}");
            Console.WriteLine("Available item additions: ");
            itemViewModel.ItemAdditions.ForEach(ia =>
            {
                Console.WriteLine($"[Item addition ID: {ia.Id}, Name: {ia.Name}, Price: {ia.Cost}]");
            });



        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            ItemFacade itemFacade = new ItemFacade();
            int itemId = itemFacade.ChoseItem();
            itemFacade.printItemInfo(itemId);
        }
    }
}
