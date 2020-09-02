using System;
using System.Collections.Generic;

namespace FlyweightDemo
{
    public interface ILetter
    {
        void Display();
    }


    public class Letter : ILetter
    {
        private char _name;
        private string _font;
        private int _size;

        public Letter(char name)
        {
            _name = name;
            _font = "Arial";
            _size = 10;
            Console.WriteLine($"Letter {_name} with font {_font} and size {_size}px created");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying letter {_name}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

    public class Document
    {
        private Dictionary<char, ILetter> _letters;

        public Document()
        {
            _letters = new Dictionary<char, ILetter>();
        }


        public ILetter CreateLetter(char name)
        {
            name = char.ToUpper(name);
            ILetter letter;
            if (_letters.ContainsKey(name))
            {
                letter = _letters[name];
            }
            else
            {
                letter = new Letter(name);
                _letters.Add(name, letter);
            }
            return letter;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Document textDocument = new Document();
            string valueToDisplay = "Abracadabra";
            ILetter letter;
            for (int i = 0; i < valueToDisplay.Length; i++)
            {
                letter = textDocument.CreateLetter(valueToDisplay[i]);
                letter.Display();
            }
        }
    }
}
