using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearList
{
    class Program
    {
        static void Main(string[] args)
        {
            ILinearList<int> list = new SingleLinkList<int>();
            ReverseTest(list);
            Console.ReadKey();
        }

        private static void ReverseTest(ILinearList<int> list)
        {
            list.Print();
            list.Reverse();
            list.Print();
            list.Append(1);
            list.Print();
            list.Reverse();
            list.Print();
            list.Append(2);
            list.Print();
            list.Reverse();
            list.Print();
            list.Append(3);
            list.Print();
            list.Reverse();
            list.Print();
        }
    }
}
