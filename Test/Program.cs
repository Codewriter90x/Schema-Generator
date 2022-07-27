using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schema_Generator;


namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Article_SD class1 = new Article_SD(
                Headline: "Prova di articolo", 
                Images: new List<string> { "prova 1"},
                datePublished: DateTime.Now,
                dateModified: DateTime.Now,
                authors: new List<Author>() { new Author() { Name = "Luca Baron", Url = "ti piacerebbe sapera sicuramente" } },
                publisher: new Publisher() {}
                ) ;
            Console.Write(class1.ToString());
            Console.ReadKey();
        }
    }
}
