using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(new Reverse_Polish_Notation.RPN().Calculate("(2+2)*2+(8-5)"));
            Console.ReadLine();
        }
    }
}
