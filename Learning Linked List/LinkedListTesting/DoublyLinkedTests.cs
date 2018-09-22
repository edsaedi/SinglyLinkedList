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
            var dontusevarwoman = list.FindFirst(remove);
            //Assert

            /*foreach (int num in list)
            {
                tNum = num;
                if (num != remove)
                {
                    Assert.True(num == tNum);
                }
            }*/

            foreach (int num in list, int tNum in dontusevarwoman)
            {
                tNum = num;
                if (num != )
                //Check to see if the value of temp is not equivalent to the value of list
                //If not, see if it is remove.
            }
            //Check to see if list is equivalent to data except for portion with deletion.
        }
    }
}
