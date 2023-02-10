using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BarcodeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            String URLString = "https://api-eu.hosted.exlibrisgroup.com/almaws/v1/items?item_barcode=025462201&apikey=l8xx60f2549444854849b9706a876352a5a9";
            XmlTextReader reader = new XmlTextReader(URLString);

           // XmlDocument doc1 = new XmlDocument();
           //// doc1.Load("https://api-eu.hosted.exlibrisgroup.com/almaws/v1/items?item_barcode=025462201&apikey=l8xx60f2549444854849b9706a876352a5a9");
           // Console.WriteLine(doc1);
          var a =  Console.ReadLine();
            Console.WriteLine(a);
        }
    }
}
// https://api-eu.hosted.exlibrisgroup.com/almaws/v1/bibs/991001623379706455/holdings/2236184320006455/items/2336184030006455?apikey=l8xx60f2549444854849b9706a876352a5a9