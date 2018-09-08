using System;
using Xunit;
using Learning_Linked_List;

namespace LinkedListTesting
{
    public class DoublyLinkedTests
    {
        [Fact]
        public void AddStart()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddFront(1);
            list.AddFront(0);
            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }
        }

        [Fact]
        public void AddEnd()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddEnd(0);
            list.AddEnd(1);
            list.AddEnd(2);
            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }
        }

        [Fact]
        public void AddAt()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.AddEnd(0);
            list.AddAt(1, 100);
            list.AddEnd(200);
            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i += 100;
            }
        }
    }
}
