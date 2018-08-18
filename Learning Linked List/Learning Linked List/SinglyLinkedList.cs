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
    class SinglyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
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
                return curr.item;
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
        public void AddAfter(SinglyLinkedNode<T> node, T value)
        {
            SinglyLinkedNode<T> temp = head;
            while (temp.item.CompareTo(node.item) != 0)
            {
                temp = temp.Next;
            }
            Count++;
            var tempNode = new SinglyLinkedNode<T>(value, temp.Next);
            temp.Next = tempNode;
        }

        public void AddAt(T value, int index)
        {
            Count++;
            SinglyLinkedNode<T> temp = head;
            for (int i = 0; i < index - 1; i++)
            {
                temp = temp.Next;
            }
            var node = new SinglyLinkedNode<T>(value, temp.Next);
            temp.Next = node;
        }

        //Remove(T value)
        public void Remove(T value)
        {
            if (head.item.CompareTo(value) == 0)
            {
                head = head.Next;
                Count--;
                return;
            }

            //stop on the node before we want to remove
            SinglyLinkedNode<T> temp = head;

            while (temp.Next.item.CompareTo(value) != 0)
            {
                temp = temp.Next;
            }
            //link AROUND the node
            temp.Next = temp.Next.Next;
            Count--;
        }

        //RemoveFirst()
        public void RemoveFirst()
        {
            head = head.Next;
            Count--;
            return;
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
                yield return current.item;
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
