using DesignPatternsConsoleAppDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsConsoleAppDemo.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
    }
}
