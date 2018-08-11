using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Linked_List
{
    public class SinglyLinkedNode<T>
    {
        public T item { get; set; }
        public SinglyLinkedNode<T> Next { get; set; }

        public SinglyLinkedNode(T itemToStore, SinglyLinkedNode<T> next = null)
        {
            item = itemToStore;
            Next = next;
        }
    }
}
