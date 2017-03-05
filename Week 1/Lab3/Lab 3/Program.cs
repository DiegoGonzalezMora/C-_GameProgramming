using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            float originalFahrenheit=0;
            float calculatedCelsius=0;
            float calculatedFahrenheit=0;

            Console.Write("Enter temperature (Fahrenheit): ");
            originalFahrenheit = float.Parse(Console.ReadLine());

            calculatedCelsius = ((originalFahrenheit - 32) / 9)*5;
            calculatedFahrenheit = ((calculatedCelsius * 9) / 5) + 32;

            Console.WriteLine(originalFahrenheit + " degrees Fahrenheit is " + calculatedCelsius + " degress Celsius" +
                "\n" + calculatedCelsius + " degress Celsius is " + calculatedFahrenheit + " degress Fahrenheit.\n");
        }
    }
}
