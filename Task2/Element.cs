using System;

namespace PeriodicTable
{
    public class Element
    {
        private int _atomicNumber;
        private string _name;
        private string _class;
        private string _description;

        public Element(int atomicNumber, string name, string elementClass, string description)
        {
            _atomicNumber = atomicNumber;
            _name = name;
            _class = elementClass;
            _description = description;
        }

        public int GetAtomicNumber()
        {
            return _atomicNumber;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetClass()
        {
            return _class;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}