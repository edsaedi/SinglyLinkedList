using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{
    class SinglyLinkedList<T>
    {
        SinglyLinkedNode<T> head;
        SinglyLinkedNode<T> tail;
        //Tail 
        public int Count { get; private set; }

        //Indexer: use [] (worse)
        //Enumerator: foreach (better)


        public SinglyLinkedList()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        public void AddStart(T value)
        {
            Count++;
            if (head == null)
            {
                head = new SinglyLinkedNode<T>(value);
                tail = head;
            }
            else
            {
                SinglyLinkedNode<T> temp = head;
                head = new SinglyLinkedNode<T>(value);
                head.Next = temp;
            }
        }

        public void AddEnd(T value)
        {
            Count++;
            if (head == null)
            {
                head = new SinglyLinkedNode<T>(value);
                tail = head;
            }
            else
            {
                tail.Next = new SinglyLinkedNode<T>(value);
                tail = tail.Next;
                /*SinglyLinkedNode<T> temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = new SinglyLinkedNode<T>(value);*/
            }
        }

        public void AddAt(T value, int index)
        {
            Count++;
            SinglyLinkedNode<T> temp = head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            //temp.Next = new SinglyLinkedNode<T>(value);

        }
    }
}
