using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{

    //Faster for insertion & deletion
    //slower for indexing
    public class SinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
    {
        SinglyLinkedNode<T> head;
        SinglyLinkedNode<T> tail;
        //Tail 
        public int Count { get; private set; }

        //Indexer: use [] (worse)
        //Enumerator: foreach (better)

        //THIS IS BAD, ONLY WRITTEN FOR EXAMPLE (use case is arrays)
        public T this[int index]
        {
            get
            {
                var curr = head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }
                return curr.Item;
            }
        }



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

        //AddAfter(Node, value)
        public bool AddAfter(SinglyLinkedNode<T> node, T value)
        {
            SinglyLinkedNode<T> temp = head;

            if (temp == null)
            {
                return false;
            }

            while (temp.Item.CompareTo(node.Item) != 0)
            {
                temp = temp.Next;
            }
            Count++;
            var tempNode = new SinglyLinkedNode<T>(value, temp.Next);
            temp.Next = tempNode;
            return true;
        }

        public bool AddAt(T value, uint index)
        {
            SinglyLinkedNode<T> temp = head;

            /*if (index == 0)
            {
                head = new SinglyLinkedNode<T>(value, temp.Next);
            }*/

            if (temp == null)
            {
                return false;
            }

            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            var node = new SinglyLinkedNode<T>(value, temp.Next);
            temp.Next = node;
            Count++;
            return true;
        }

        //Remove(T value)
        public bool Remove(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (head.Item.CompareTo(value) == 0)
            {
                head = head.Next;
                Count--;
                return true;
            }

            //stop on the node before we want to remove
            SinglyLinkedNode<T> temp = head;

            while (temp.Next.Item.CompareTo(value) != 0)
            {
                temp = temp.Next;
            }
            //link AROUND the node
            temp.Next = temp.Next.Next;
            Count--;
            return true;
        }

        //RemoveFirst()
        public bool RemoveFirst()
        {
            if (head == null)
            {
                return false;
            }
            head = head.Next;
            Count--;
            return true;
        }

        //Clear
        public void Clear()
        {
            Count = 0;
            head = null;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SinglyLinkedNode<T> current = head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //IEnumerator
    //public class Thingy<T>
    //{
    //    private SinglyLinkedNode<T> current;
    //    public T Current
    //    {
    //        get
    //        {
    //            return current.item;
    //        }
    //    }

    //    public Thingy(SinglyLinkedNode<T> head)
    //    {
    //        current = null;
    //    }

    //    public bool MoveNext()
    //    {
    //        if (current.Next == null)
    //        {
    //            return false;
    //        }

    //        current = current.Next;
    //        return true;
    //    }
    //}

}
