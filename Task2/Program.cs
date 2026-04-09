using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Element> elements;
            bool continueLoop;
            string input;
            int atomicNumber;

            elements = InitializeElements();
            continueLoop = true;

            Console.WriteLine("Hi there! Happy to help!");

            while (continueLoop)
            {
                Console.Write("Provide atomic number of the element: ");
                input = Console.ReadLine();

                if (int.TryParse(input, out atomicNumber))
                {
                    if (atomicNumber >= 1 && atomicNumber <= 30)
                    {
                        Element element;
                        element = elements[atomicNumber - 1];

                        Console.WriteLine("Atomic Number: " + element.GetAtomicNumber());
                        Console.WriteLine("Name: " + element.GetName());
                        Console.WriteLine("Class: " + element.GetClass() + " (" + element.GetDescription() + ")");
                    }
                    else
                    {
                        Console.WriteLine("Invalid atomic number. Please enter a number between 1 and 30.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.Write("Do you want to know more elements [y/n]? ");
                input = Console.ReadLine();

                if (input == "n" || input == "N")
                {
                    Console.WriteLine("Thanks !");
                    continueLoop = false;
                }
                else if (input == "y" || input == "Y")
                {
                    continueLoop = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Program will continue.");
                    continueLoop = true;
                }
            }
        }

        static List<Element> InitializeElements()
        {
            List<Element> elements;

            elements = new List<Element>();

            elements.Add(new Element(1, "Hydrogen", "Nonmetal", "Lightest element"));
            elements.Add(new Element(2, "Helium", "Noble Gas", "Used in balloons"));
            elements.Add(new Element(3, "Lithium", "Alkali Metal", "Used in batteries"));
            elements.Add(new Element(4, "Beryllium", "Alkaline Earth Metal", "Used in aerospace"));
            elements.Add(new Element(5, "Boron", "Metalloid", "Used in glass"));
            elements.Add(new Element(6, "Carbon", "Nonmetal", "Base of life"));
            elements.Add(new Element(7, "Nitrogen", "Nonmetal", "Found in air"));
            elements.Add(new Element(8, "Oxygen", "Nonmetal", "Needed for breathing"));
            elements.Add(new Element(9, "Fluorine", "Halogen", "Used in toothpaste"));
            elements.Add(new Element(10, "Neon", "Noble Gas", "Used in signs"));
            elements.Add(new Element(11, "Sodium", "Alkali Metal", "Part of salt"));
            elements.Add(new Element(12, "Magnesium", "Alkaline Earth Metal", "Burns brightly"));
            elements.Add(new Element(13, "Aluminium", "Metal", "Used in cans"));
            elements.Add(new Element(14, "Silicon", "Metalloid", "Used in chips"));
            elements.Add(new Element(15, "Phosphorus", "Nonmetal", "Used in fertilizers"));
            elements.Add(new Element(16, "Sulfur", "Nonmetal", "Yellow solid"));
            elements.Add(new Element(17, "Chlorine", "Halogen", "Used in cleaning"));
            elements.Add(new Element(18, "Argon", "Noble Gas", "Used in bulbs"));
            elements.Add(new Element(19, "Potassium", "Alkali Metal", "Important for body"));
            elements.Add(new Element(20, "Calcium", "Alkaline Earth Metal", "Needed for bones"));
            elements.Add(new Element(21, "Scandium", "Transition Metal", "Used in alloys"));
            elements.Add(new Element(22, "Titanium", "Transition Metal", "Strong and light"));
            elements.Add(new Element(23, "Vanadium", "Transition Metal", "Strengthens steel"));
            elements.Add(new Element(24, "Chromium", "Transition Metal", "Shiny metal"));
            elements.Add(new Element(25, "Manganese", "Transition Metal", "Used in steel"));
            elements.Add(new Element(26, "Iron", "Transition Metal", "Used in construction"));
            elements.Add(new Element(27, "Cobalt", "Transition Metal", "Used in batteries"));
            elements.Add(new Element(28, "Nickel", "Transition Metal", "Used in coins"));
            elements.Add(new Element(29, "Copper", "Transition Metal", "Used in wires"));
            elements.Add(new Element(30, "Zinc", "Transition Metal", "Prevents rust"));

            return elements;
        }
    }
}