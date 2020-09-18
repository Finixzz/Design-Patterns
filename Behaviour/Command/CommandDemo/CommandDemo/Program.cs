using System;

namespace CommandDemo
{

   

    public class Light
    {
        private bool _isTurnedOn;

        public Light()
        {
            _isTurnedOn = false;
        }

        public void SwitchOFF()
        {
            _isTurnedOn = false;
        }

        public void SwitchON()
        {
            _isTurnedOn = true;
        }

        public bool IsTurnedOn()
        {
            return _isTurnedOn;
        }
    }

    public interface ICommand
    {
        public void Execute();
    }

    public class SwitchONCommand : ICommand
    {
        private Light _light;
        public SwitchONCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            if (!_light.IsTurnedOn())
            {
                _light.SwitchON();
                Console.WriteLine("Light turned ON");
            }
            else
            {
                Console.WriteLine("Light is already turned ON");
            }
                
        }
    }

    public class SwitchOFFCommand : ICommand
    {
        private Light _light;
        public SwitchOFFCommand(Light light)
        {
            _light = light;
        }
        public void Execute()
        {
            if (_light.IsTurnedOn())
            {
                _light.SwitchOFF();
                Console.WriteLine("Light turned OFF");
            }
            else
            {
                Console.WriteLine("Light is already turned OFF");
            }
            

        }
    }

    public class Invoker
    {
        private ICommand _switchONCommand;
        private ICommand _switchOFFComand;

        public Invoker(ICommand _switchONCommand,
                       ICommand _switchOFFComand)
        {
            this._switchOFFComand = _switchOFFComand;
            this._switchONCommand = _switchONCommand;
        }

        public void TurnLightON()
        {
            _switchONCommand.Execute();
        }

        public void TurnLigtOFF() 
        {
            _switchOFFComand.Execute();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Light roomLight = new Light();
            Invoker lightInvoker = new Invoker(new SwitchONCommand(roomLight), new SwitchOFFCommand(roomLight));

            lightInvoker.TurnLightON();

            lightInvoker.TurnLightON();

            lightInvoker.TurnLigtOFF();

            lightInvoker.TurnLigtOFF();
        }
    }
}
