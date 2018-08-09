using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
            linkedList.AddEnd(0);
            linkedList.AddEnd(1);
            linkedList.Write();
            Console.ReadKey();
        }
    }
}
