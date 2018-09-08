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
            //TODO: Finish ADD AFTER in Doubly Linked List
            #endregion
            SinglyLinkedList<int> linkedList = new SinglyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                linkedList.AddEnd(i);
            }

            DoublyLinkedList<int> doublyLinkedList = new DoublyLinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                doublyLinkedList.AddEnd(i);
            }

            //linkedList.AddEnd(25);
            doublyLinkedList.AddFront(2);


            //doublyLinkedList.AddAfter(doublyLinkedList.FindLast(2), 200);
            doublyLinkedList.RemoveFront();
            foreach (int number in doublyLinkedList)
            {
                Console.WriteLine(number);
            }

            Console.ReadKey();
        }
    }
}
