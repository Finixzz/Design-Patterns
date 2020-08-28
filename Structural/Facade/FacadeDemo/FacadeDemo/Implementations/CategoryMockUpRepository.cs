using DesignPatternsConsoleAppDemo.Interfaces;
using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Implementations
{
    public class CategoryMockUpRepository : ICategoryRepository
    {
        private List<Category> _categories;

        public CategoryMockUpRepository()
        {
            _categories = new List<Category>()
            {
                new Category(){Id=1000,Name="Non alcohol beverages"},
                new Category(){Id=1001,Name="Alcohol beverages"}
            };
        }
        public Category GetCategory(int id)
        {
            return _categories.SingleOrDefault(c => c.Id == id);
        }
    }
}
