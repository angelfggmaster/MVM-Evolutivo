using System;
using System.Collections.Generic;

namespace PruebaMVM
{
    class Program
    {
        static void Main(string[] args)
        {
            CharactersManager cm = new CharactersManager();
            string initialString = cm.CreateInitialString();

            int top = cm.RateString(initialString);
            int posGeneration = 1;

            while (top < initialString.Length)
            {
                List<string> currentGeneration = cm.CreateGeneration(initialString);
                MaxStringValue maxStringValue = cm.GetMaxStringValue(currentGeneration);
                Console.WriteLine(string.Format("Generacion: {0} - Mutación: {1} - Puntaje: {2}", 
                    posGeneration, maxStringValue.Text, maxStringValue.Value));

                top = maxStringValue.Value;
                posGeneration++;
                initialString = maxStringValue.Text;
            }

            Console.ReadLine();
        }
    }
}
