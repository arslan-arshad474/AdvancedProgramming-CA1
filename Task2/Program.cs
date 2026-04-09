using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Element> elements = InitializeElements();

            Console.WriteLine("Hi there! Happy to help!");

            bool continueLoop = true;

            while (continueLoop)
            {
                Console.Write("Provide atomic number of the element: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int atomicNumber) && atomicNumber >= 1 && atomicNumber <= 30)
                {
                    Element element = elements[atomicNumber - 1];

                    Console.WriteLine($"Atomic Number: {element.AtomicNumber}");
                    Console.WriteLine($"Name: {element.Name}");
                    Console.WriteLine($"Class: {element.Classification} ({element.Description})");
                }
                else
                {
                    Console.WriteLine("Invalid atomic number. Please enter a number between 1 and 30.");
                }

                Console.Write("Do you want to know more elements [y/n]? ");
                string again = Console.ReadLine();

                if (again != null && again.Equals("n", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Thanks !");
                    continueLoop = false;
                }
            }
        }

        static List<Element> InitializeElements()
        {
            return new List<Element>
            {
                new Element(1, "Hydrogen", "Nonmetal", "Lightest element"),
                new Element(2, "Helium", "Noble Gas", "Used in balloons"),
                new Element(3, "Lithium", "Alkali Metal", "Used in batteries"),
                new Element(4, "Beryllium", "Alkaline Earth Metal", "Used in aerospace"),
                new Element(5, "Boron", "Metalloid", "Used in glass"),
                new Element(6, "Carbon", "Nonmetal", "Base of life"),
                new Element(7, "Nitrogen", "Nonmetal", "78% of air"),
                new Element(8, "Oxygen", "Nonmetal", "Needed for breathing"),
                new Element(9, "Fluorine", "Halogen", "Used in toothpaste"),
                new Element(10, "Neon", "Noble Gas", "Used in signs"),
                new Element(11, "Sodium", "Alkali Metal", "Part of salt"),
                new Element(12, "Magnesium", "Alkaline Earth Metal", "Burns bright"),
                new Element(13, "Aluminium", "Metal", "Used in cans"),
                new Element(14, "Silicon", "Metalloid", "Used in chips"),
                new Element(15, "Phosphorus", "Nonmetal", "Used in fertilizers"),
                new Element(16, "Sulfur", "Nonmetal", "Yellow solid"),
                new Element(17, "Chlorine", "Halogen", "Used in cleaning"),
                new Element(18, "Argon", "Noble Gas", "Used in bulbs"),
                new Element(19, "Potassium", "Alkali Metal", "Important for body"),
                new Element(20, "Calcium", "Alkaline Earth Metal", "Strong bones"),
                new Element(21, "Scandium", "Transition Metal", "Used in alloys"),
                new Element(22, "Titanium", "Transition Metal", "Strong and light"),
                new Element(23, "Vanadium", "Transition Metal", "Strengthens steel"),
                new Element(24, "Chromium", "Transition Metal", "Shiny metal"),
                new Element(25, "Manganese", "Transition Metal", "Used in steel"),
                new Element(26, "Iron", "Transition Metal", "Used in construction"),
                new Element(27, "Cobalt", "Transition Metal", "Used in batteries"),
                new Element(28, "Nickel", "Transition Metal", "Used in coins"),
                new Element(29, "Copper", "Transition Metal", "Used in wires"),
                new Element(30, "Zinc", "Transition Metal", "Prevents rust")
            };
        }
    }
}