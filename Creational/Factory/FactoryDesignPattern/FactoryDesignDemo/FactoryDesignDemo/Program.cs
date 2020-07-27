using System;

namespace FactoryDesignDemo
{

  
    public abstract class CreditCard
    {
        public abstract string CardType { get; }

        public abstract int CreditLimit { get; set; }

        public abstract int  AnnualCharge { get; set; }
    }


    public class MoneyBackCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;

        public MoneyBackCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "Money back";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }

    }


    public class TitaniumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;


        public TitaniumCreditCard(int creditLimit, int annualCharge)
        {
            _cardType = "Titanium";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType
        {
            get { return _cardType; }
        }

        public override int CreditLimit
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
    }


    public class PlatinumCreditCard : CreditCard
    {
        private readonly string _cardType;
        private int _creditLimit;
        private int _annualCharge;


        public PlatinumCreditCard(int creditLimit,int annualCharge)
        {
            _cardType = "Platinum";
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override string CardType 
        {
            get { return _cardType; }
        }

        public override int CreditLimit 
        {
            get { return _creditLimit; }
            set { _creditLimit = value; }
        }
        public override int AnnualCharge
        {
            get { return _annualCharge; }
            set { _annualCharge = value; }
        }
    }


    public abstract class CardFactory
    {
        protected int _creditLimit;
        protected int _annualCharge;

        public abstract CreditCard GetCreditCard();
    }

    public class MoneyBackFactory : CardFactory
    {

        public MoneyBackFactory(int creditLimit,int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new  MoneyBackCreditCard(_creditLimit, _annualCharge);
        }
    }

    public class PlatinumFactory : CardFactory
    {
        public PlatinumFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new PlatinumCreditCard(_creditLimit, _annualCharge);
        }
    }

    public class TitaniumFactory : CardFactory
    {
        public TitaniumFactory(int creditLimit, int annualCharge)
        {
            _creditLimit = creditLimit;
            _annualCharge = annualCharge;
        }
        public override CreditCard GetCreditCard()
        {
            return new TitaniumCreditCard(_creditLimit, _annualCharge);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CardFactory factory = null;
            Console.WriteLine("-------CARD TYPES---------");
            Console.WriteLine("1) Moneyback");
            Console.WriteLine("2) Titanium");
            Console.WriteLine("3) Platinum");
            Console.Write("Enter the card type: ");
            string factoryType = Console.ReadLine();

            switch (factoryType.ToLower())
            {
                case "moneyback":
                    factory = new MoneyBackFactory(5000, 0);
                    break;
                case "titanium":
                    factory = new TitaniumFactory(10000, 500);
                    break;
                case "platinum":
                    factory = new PlatinumFactory(50000, 1000);
                    break;
                default:
                    break;
            }

            CreditCard creditCard = factory.GetCreditCard();
            Console.WriteLine("\nYour card details are below : \n");
            Console.WriteLine("Card Type: {0}\nCredit Limit: {1}\nAnnual Charge: {2}",
                creditCard.CardType, creditCard.CreditLimit, creditCard.AnnualCharge);
            Console.ReadKey();
        }
    }
}
