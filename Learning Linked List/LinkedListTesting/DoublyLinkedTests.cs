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

        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 4, 0 })]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 4, 1 })]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 4, 2 })]
        public void AddAt(int[] data, int insert, int pos)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            for (int i = data.Length - 1; i >= 0; i--)
            {
                list.AddAt(0, data[i]);
            }

            var before = list.GetNodeAt(pos - 1);
            var after = list.GetNodeAt(pos);
            int count = list.Count;

            list.AddAt(pos, insert);

            if (before != null)
            {
                Assert.True(before.Next.item == insert);
            }
            if (after != null)
            {
                Assert.True(after.Previous.item == insert);
            }

            Assert.True(count != list.Count);
        }

        /*[Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, new DoublyLinkedNode<int>(3), 4 })]
        public void AddAfter(int[] data, DoublyLinkedNode<int>, int value)
        {

        }*/

        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 3 })]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 2 })]
        [InlineData(new object[] { new int[] { 1, 2, 3 }, 1 })]
        public void Remove(int[] data, int remove)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            for (int i = data.Length - 1; i >= 0; i--)
            {
                list.AddFront(data[i]);
            }

            var temp = list;

            list.Remove(remove);

            var listNum = list.Head;
            foreach (int num in temp)
            {
                if (remove != num)
                {
                    Assert.True(num == listNum.item);
                    listNum = listNum.Next;
                }
            }
            //Check to see if list is equivalent to data except for portion with deletion.
        }

        [Theory]
        [InlineData(new object[] { new int[] { 1, 2, 3 } })]
        //[InlineData(new object[] { new int[] { 2, 1, 3 } })]
        //[InlineData(new object[] { new int[] { 3, 2, 1 } })]
        public void RemoveFront(int[] data)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            for (int i = 0; i < data.Length; i++)
            {
                list.AddEnd(data[i]);
            }

            var temp = list;
            list.Remove(new DoublyLinkedNode<int>(4, null, null));
            list.RemoveFront();

            var listNum = list.Head;
            foreach (int num in temp)
            {
                if (num == temp.Head.item)
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.True(num == listNum.item);
                    listNum = listNum.Next;
                }
            }
        }
    }
}
