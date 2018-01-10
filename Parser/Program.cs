using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            string parsed = MessageParser.Parse("rouge", "100");

            Console.WriteLine(parsed);
            
            MessageParser.ParsedData data = MessageParser.Decode(parsed);
            Console.WriteLine(data.ToString());

            Console.ReadKey();
        }
    }
}
