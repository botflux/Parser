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

            List<ParseData> array = new List<ParseData>();
            array.Add(new ParseData("red", "100"));
            array.Add(new ParseData("bLue", "000"));
            array.Add(new ParseData("GrEeN", "210"));
            array.Add(new ParseData("tiME", "120"));
            array.Add(new ParseData("message", "Hello world"));

            string parsedArray = DataParser.Parse(array);

            Console.WriteLine(parsedArray);

            List<ParseData> decoded = DataParser.DecodeArray(parsedArray);

            foreach (var d in decoded)
            {
                Console.WriteLine(d.ToString());
            }

            Console.ReadKey();
        }
    }
}
