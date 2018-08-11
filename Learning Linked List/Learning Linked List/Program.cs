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
            #region
            //TODO: Fix the breaking error in Add After.
            #endregion
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddEnd(i);
            }

            linkedList.Remove(9);
            //linkedList.AddEnd(25);
            linkedList.RemoveFirst();
            linkedList.AddAfter(new SinglyLinkedNode<int>(2), 200);
            foreach (int number in linkedList)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
