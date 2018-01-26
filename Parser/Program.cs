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
            
            List<DataWrapper> array = new List<DataWrapper>();
            array.Add(new DataWrapper("red", 100));
            array.Add(new DataWrapper("bLue", "000"));
            array.Add(new DataWrapper("GrEeN", "210"));
            array.Add(new DataWrapper("tiME", "120"));
            array.Add(new DataWrapper("message", "Hello world"));

            string parsedArray = FrameParser.Encode(array);

            Console.WriteLine(parsedArray);

            List<DataWrapper> decoded = FrameParser.DecodeArray(parsedArray);

            foreach (var d in decoded)
            {
                Console.WriteLine(d.ToString());
            }
            
            Console.ReadKey();
        }
    }
}
