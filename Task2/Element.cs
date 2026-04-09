using System;

namespace PeriodicTable
{
    public class Element
    {
        public int AtomicNumber { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }

        public Element(int atomicNumber, string name, string classification, string description)
        {
            AtomicNumber = atomicNumber;
            Name = name;
            Classification = classification;
            Description = description;
        }
    }
}