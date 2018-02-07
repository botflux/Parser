using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPackage.Parser;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter un nom:");
                string nom = Console.ReadLine();
                Console.WriteLine("Entrer une valeur:");
                string v = Console.ReadLine();
                Console.WriteLine("Résultat: {0}", FrameParser.Encode(nom, v));
            }
        }
    }
}
