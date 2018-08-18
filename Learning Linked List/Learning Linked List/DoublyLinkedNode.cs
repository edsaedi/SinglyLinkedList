using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{
    public class DoublyLinkedNode<T> where T : IComparable<T>
    {
        public T item { get; set; }
        public DoublyLinkedNode<T> Next { get; set; }
        public DoublyLinkedNode<T> Previous { get; set; }
        public DoublyLinkedList<T> List { get; }

        public DoublyLinkedNode(T itemToStore, DoublyLinkedNode<T> next = null, DoublyLinkedNode<T> previous = null)
        {
            item = itemToStore;
            Next = next;
            Previous = previous;
        }

        internal DoublyLinkedNode(T itemToStore, DoublyLinkedList<T> list, DoublyLinkedNode<T> next = null, DoublyLinkedNode<T> previous = null)
        {
            item = itemToStore;
            List = list;
            Next = next;
            Previous = previous;
        }
    }
}
