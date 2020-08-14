using System;

namespace AdapterDemo
{

    public class UKSocket
    {
        public void plugInSocket()
        {
            Console.WriteLine("Plugged in UK Socket");
        }
    }

    public interface IAdapter
    {
        void plugInAdapter();
    }

    public class UKAdapter : IAdapter
    {
        private UKSocket _socket;

        public UKAdapter(UKSocket socket)
        {
            _socket = socket;
        }
        public void plugInAdapter()
        {
            Console.WriteLine("Plugged in UK Adapter");
            _socket.plugInSocket();
        }
    }

    class EUCharger
    {
        private bool isPluggedInAdapter;

        public EUCharger()
        {
            isPluggedInAdapter = false;
        }
        public void plugIn(IAdapter adapter)
        {
            adapter.plugInAdapter();
            isPluggedInAdapter = true;
        }

        public void charge()
        {
            if (isPluggedInAdapter)
                Console.WriteLine("EU charger is plugged in UK Socket via UK Adapter. EU charger is charging.");
            else
                Console.WriteLine("In order to charge your device you have to use UK Adapter");

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAdapter UKAdapter = new UKAdapter(new UKSocket());
            EUCharger EUCharger = new EUCharger();

            EUCharger.charge();
            EUCharger.plugIn(UKAdapter);
            EUCharger.charge();
        }
    }
}
