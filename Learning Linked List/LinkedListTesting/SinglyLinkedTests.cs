using System;
using Xunit;
using Learning_Linked_List;

namespace LinkedListTesting
{
    public class SinglyLinkedTests
    {
        [Fact]
        public void AddStart()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddStart(3);
            list.AddStart(2);
            list.AddStart(1);
            list.AddStart(0);

            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }

            Assert.True(list.Count == 4);
        }

        [Fact]
        public void AddEnd()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(0);
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddEnd(3);

            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }

            Assert.True(list.Count == 4);
        }

        [Fact]
        public void AddAfter()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(0);
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddEnd(3);
            list.AddAfter(new SinglyLinkedNode<int>(0, new SinglyLinkedNode<int>(1)), 4);
            int i = 0;
            /*foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }*/

            Assert.True(list[1] == 4);

            //Assert.True(list.Count == 5);
        }

        [Fact]
        public void AddAt()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(0);
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddAt(3, 3);
            int i = 0;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }
        }

        [Fact]
        public void Remove()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(0);
            list.AddEnd(1);
            list.AddEnd(2);
            list.AddEnd(3);
            list.Remove(0);

            int i = 1;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i++;
            }
        }

        [Fact]
        public void RemoveFirst()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(2);
            list.AddEnd(3);
            list.AddEnd(1);
            list.RemoveFirst();
            int i = 3;
            foreach (var num in list)
            {
                Assert.True(num == i);
                i -= 2;
            }
        }

        [Fact]
        public void Clear()
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();
            list.AddEnd(0);
            list.Clear();
            Assert.True(list.Count == 0);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2 }, 3)]
        [InlineData(new int[] { }, 3)]
        [InlineData(new int[] { 0 }, 3)]
        [InlineData(new int[] { 0, 1 }, 3)]
        public void DankMemes(int[] array, int toAdd)
        {
            var test = new SinglyLinkedList<int>();
            for (int i = 0; i < array.Length; i++)
            {
                test.AddEnd(array[i]);
            }

            int length = test.Count;
            test.AddStart(toAdd);
            Assert.True(length != test.Count);
        }

    }
}
