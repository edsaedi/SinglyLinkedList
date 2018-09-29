using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{
    //make this circular
    public class DoublyLinkedList<T> : IEnumerable where T : IComparable<T>
    {
        private DoublyLinkedNode<T> head;
        public ref DoublyLinkedNode<T> Head => ref head;

        private DoublyLinkedNode<T> tail;

        public int Count { get; private set; }

        public DoublyLinkedList()
        {
            Count = 0;
            head = null;
            tail = null;
        }

        public DoublyLinkedNode<T> GetNodeAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                return null;
            }

            var curr = head;
            for (int i = 0; i < index; i++)
            {
                curr = curr.Next;
            }
            return curr;
        }

        public void AddEnd(T value)
        {
            if (head == null)
            {
                head = new DoublyLinkedNode<T>(value, this);
                tail = head;
            }
            else
            {
                tail.Next = new DoublyLinkedNode<T>(value, this, null, tail);
                tail = tail.Next;
            }
            Count++;
        }

        public void AddFront(T value)
        {
            if (head == null)
            {
                head = new DoublyLinkedNode<T>(value, this);
                tail = head;
            }
            else
            {
                head = new DoublyLinkedNode<T>(value, this, head);
                head.Next.Previous = head;
            }
            Count++;
        }

        public void AddAt(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (head == null || index == 0)
            {
                AddFront(value);
            }
            else if (index == Count)
            {
                AddEnd(value);
            }
            else
            {
                var curr = head;
                for (int i = 0; i < index; i++)
                {
                    curr = curr.Next;
                }

                var prev = curr.Previous;
                var newNode = new DoublyLinkedNode<T>(value, this, curr, curr.Previous);

                if (prev != null)
                {
                    prev.Next = newNode;
                }
                curr.Previous = newNode;
            }

            Count++;
        }

        public void AddAfter(DoublyLinkedNode<T> node, T value)
        {
            if (this != node.List)
            {
                throw new ArgumentException("node does not belong to this list", "node");
            }

            var newNode = new DoublyLinkedNode<T>(value, this, node.Next, node);
            if (node.Next != null)
            {
                node.Next.Previous = newNode;
            }
            node.Next = newNode;

            Count++;
        }

        public void AddBefore(DoublyLinkedNode<T> node, T value)
        {
            if (node == null || this != node.List)
            {
                throw new ArgumentException("node does not belong to this list", "node");
            }

            var newNode = new DoublyLinkedNode<T>(value, this, node, node.Previous);
            if (node.Previous != null)
            {
                node.Previous.Next = newNode;
            }
            node.Previous = newNode;

            Count++;
        }

        public bool Remove(T value)
        {
            return Remove(FindFirst(value));
        }

        public bool Remove(DoublyLinkedNode<T> node)
        {
            if (node == null)
            {
                return false;
            }
            else if (node == head)
            {
                node.Next.Previous = null;
                head = node.Next;
                Count--;
                return true;
            }
            else if (node == tail)
            {
                node.Previous.Next = null;
                tail = node.Previous;
                Count--;
                return true;
            }
            else if (this == node.List)
            {
                node.Previous.Next = node.Next;
                node.Next.Previous = node.Previous;
                node.Previous = null;
                node.Next = null;
                Count--;
                return true;
            }
            return false;
        }

        public bool RemoveFront()
        {
            if (head.item == null)
            {
                return false;
            }
            head = new DoublyLinkedNode<T>(head.Next.item, this, head.Next, null);
            Count--;
            return true;
        }

        public void Clear()
        {
            Count = 0;
            head = null;
        }

        public bool IsEmpty()
        {
            if (head == null)
            {
                return true;
            }

            return false;
        }

        public DoublyLinkedNode<T> FindFirst(T value) //first instance of a value
        {
            var temp = head;
            while (temp.item.CompareTo(value) != 0)
            {
                temp = temp.Next;
            }
            return temp;
        }

        public DoublyLinkedNode<T> FindLast(T value)
        {
            var temp = tail;
            while (temp.item.CompareTo(value) != 0)
            {
                temp = temp.Previous;
            }
            return temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedNode<T> current = head;
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
}
