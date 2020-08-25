using CompositeDemo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeDemo
{
    public interface IGraphicElement
    {
        public void Draw();
    }
    public class PrimitiveElement : IGraphicElement
    {
        private string _name;


        public PrimitiveElement(string name)
        {
            _name = name;
        }

        public void Draw()
        {
            Console.WriteLine(_name + " leaf element drawn");
        }
    }


    public class ComplexElement : IGraphicElement
    {
        private string _name;
        private List<IGraphicElement> _elements;

        public ComplexElement(string name)
        {
            _name = name;
            _elements = new List<IGraphicElement>();
        }

        public void AddElement(IGraphicElement el)
        {
            _elements.Add(el);
        }

        public void RemoveElement(IGraphicElement el)
        {
            _elements.Remove(el);
        }

        public void Draw()
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Drawing " + _name);
            Console.WriteLine("-------------------------");
            foreach (var el in _elements)
                el.Draw();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IGraphicElement line1 = new PrimitiveElement("left line");
            IGraphicElement line2 = new PrimitiveElement("top line");
            IGraphicElement line3 = new PrimitiveElement("right line");
            IGraphicElement line4 = new PrimitiveElement("bottom line");
            ComplexElement square = new ComplexElement("square");
            square.AddElement(line1);
            square.AddElement(line2);
            square.AddElement(line3);
            square.AddElement(line4);

            ComplexElement box = new ComplexElement("box");
            for (int i = 0; i < 6; i++)
                box.AddElement(square);

            box.Draw();
        }
    }
}
