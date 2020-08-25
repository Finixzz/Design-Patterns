using System;

namespace DecoratorDemo
{
    public interface ICoffe
    {
        decimal GetCost();

        void PrintDetails();
    }

    public class Coffee : ICoffe
    {
        public decimal Cost { get; set; }


        public Coffee()
        {
            Cost = 1.55M;
        }
        public decimal GetCost()
        {
            return Cost;
        }

        public void PrintDetails()
        {
            Console.WriteLine("Base coffee made. Price: " + Cost);
        }
    }

    public abstract class CoffeeDecorator : ICoffe
    {
        protected ICoffe _baseCoffee;

        public CoffeeDecorator(ICoffe coffe)
        {
            _baseCoffee = coffe;
        }
        public abstract decimal GetCost();

        public abstract void PrintDetails();
    }

    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffe coffe) : base(coffe)
        {

        }

        public override decimal GetCost()
        {
            return _baseCoffee.GetCost() + 0.5M;
        }

        public override void PrintDetails()
        {
            _baseCoffee.PrintDetails();
            Console.WriteLine("Added milk, current price: " + GetCost());
        }
    }

    public class SoyDecorator : CoffeeDecorator
    {
        public SoyDecorator(ICoffe coffe) : base(coffe)
        {

        }

        public override decimal GetCost()
        {
            return _baseCoffee.GetCost() + 1.1M;
        }

        public override void PrintDetails()
        {
            _baseCoffee.PrintDetails();
            Console.WriteLine("Added soy, current price: " + GetCost());
        }
    }

    public class WhipCreamDecorator : CoffeeDecorator
    {
        public WhipCreamDecorator(ICoffe coffe) : base(coffe)
        {

        }

        public override decimal GetCost()
        {
            return _baseCoffee.GetCost() + 0.7M;
        }

        public override void PrintDetails()
        {
            _baseCoffee.PrintDetails();
            Console.WriteLine("Added whip, current price: " + GetCost());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ICoffe coffee = new Coffee();
            coffee.PrintDetails();
            Console.WriteLine("--------------------------");
            MilkDecorator coffeeWithMilk = new MilkDecorator(coffee);
            coffeeWithMilk.PrintDetails();
            Console.WriteLine("--------------------------");
            SoyDecorator coffeeWithSoy = new SoyDecorator(coffee);
            coffeeWithSoy.PrintDetails();
            Console.WriteLine("--------------------------");
            WhipCreamDecorator coffeeWithWhippedCream = new WhipCreamDecorator(coffee);
            coffeeWithWhippedCream.PrintDetails();
            Console.WriteLine("--------------------------");
            MilkDecorator milk = new MilkDecorator(coffee);
            SoyDecorator soyWithMilk = new SoyDecorator(milk);
            WhipCreamDecorator whippedCreamWithSoyAndMilk = new WhipCreamDecorator(soyWithMilk);
            whippedCreamWithSoyAndMilk.PrintDetails();
        }
    }
}
