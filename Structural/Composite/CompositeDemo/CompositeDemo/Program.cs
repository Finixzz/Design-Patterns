using CompositeDemo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDemo
{
    public interface IIceCream
    {
        public decimal Price { get; set; }

        public List<string> Ingredients { get; set; }

        public void PrintDetails();
    }

    public class BaseIceCream : IIceCream
    {
        public decimal Price { get; set; }
        public List<string> Ingredients { get ; set; }

        public BaseIceCream()
        {
            Price = 1.5M;
            Ingredients = new List<string>()
            {
                "Milk","Sugar","Eggs"
            };
        }

        public void PrintDetails()
        {
            Console.WriteLine("Base ice cream made");
            Console.Write("Ingredients: ");
            Ingredients.ForEach(i =>
            {
                if(Ingredients[Ingredients.Count()-1]==i)
                    Console.Write(i);
                else
                    Console.Write(i + " ,");

            });
            Console.WriteLine();
            Console.WriteLine("Initial price: "+Price);
        }
    }

    public class IceCreamDecorator : IIceCream
    {
        private readonly IIceCream _decoratedIceCream;
        public decimal Price { get; set; }
        public List<string> Ingredients { get; set ; }

        public IceCreamDecorator(IIceCream iceCream)
        {
            _decoratedIceCream = iceCream;
            Price = _decoratedIceCream.Price;
            Ingredients = new List<string>();
            _decoratedIceCream.Ingredients.ForEach(i =>
            {
                Ingredients.Add(i);
            });
        }

        public virtual void PrintDetails()
        {
            _decoratedIceCream.PrintDetails();
        }
    }

    
    public class ChocolateDecorator : IceCreamDecorator
    {
        public ChocolateDecorator(IIceCream iceCream) : base(iceCream)
        {
            Price += .55M;
            Ingredients.Add("Chocolate");
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("Added chocolate ingredient");
            Console.WriteLine("Current price: "+Price);
        }
    }

    public class VanillaDecorator : IceCreamDecorator
    {
        public VanillaDecorator(IIceCream iceCream) : base(iceCream)
        {
            Price += .55M;
            Ingredients.Add("Vanilla");
        }

        public override void PrintDetails()
        {
            base.PrintDetails();
            Console.WriteLine("Added vanilla ingredient");
            Console.WriteLine("Current price: " + Price);
        }
    }

    public class ChocolateVanillaDecorator : IceCreamDecorator
    {
        public ChocolateVanillaDecorator(IIceCream iceCream) : base (iceCream)
        {
            Price += 1.1M;
            Ingredients.Add("Vanilla");
            Ingredients.Add()
        }
    }


}
class Program
{
    static void Main(string[] args)
    {
        IIceCream iceCream = new BaseIceCream();
        IIceCream chocolateIceCream = new ChocolateDecorator(iceCream);
        chocolateIceCream.PrintDetails();
        Console.WriteLine("------------------------");
        IIceCream vanillaIceCream = new VanillaDecorator(iceCream);
        vanillaIceCream.PrintDetails();
    }
}
