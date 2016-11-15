using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Utilities;

namespace Problems.Stacks
{
    // EOPI 9.1
    [TestClass]
    public class ImplementStackWithMaxAPI
    {
        [TestMethod]
        public void ImplementStackWithMaxAPITest()
        {
            StackWithMaxAPI[] stacks = new StackWithMaxAPI[]
            {
                new StackWithMaxIterate(),
                new StackWithMaxCache(),
                new StackWithMaxStack()
            };

            int[] data = ArrayUtilities.CreateRandomArray(20, 10, 50);
            int[] results = new int[stacks.Length];

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < stacks.Length; j++)
                {
                    stacks[j].Push(data[i]);
                    results[j] = stacks[j].Max;
                    Assert.AreEqual(results[0], results[j]);
                }
            }

            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < stacks.Length; j++)
                {
                    stacks[j].Pop();
                    results[j] = stacks[j].Max;
                    Assert.AreEqual(results[0], results[j]);
                }
            }
        }

        private abstract class StackWithMaxAPI
        {
            public abstract void Push(int item);
            public abstract int Pop();
            public abstract int Count { get; }
            public abstract int Max { get; }
        }

        private class StackWithMaxIterate : StackWithMaxAPI
        {
            private Stack<int> stack = new Stack<int>();

            public override int Count
            {
                get
                {
                    return this.stack.Count;
                }
            }

            public override int Max
            {
                get
                {
                    return this.stack.Items().Max();
                }
            }

            public override void Push(int item)
            {
                this.stack.Push(item);
            }

            public override int Pop()
            {
                return this.stack.Pop();
            }

        }

        private class StackWithMaxCache : StackWithMaxAPI
        {
            private class CacheNode
            {
                public int Value { get; set; }
                public int Max { get; set; }
            }

            Stack<CacheNode> stack = new Stack<CacheNode>();

            public override int Count
            {
                get
                {
                    return this.stack.Count;
                }
            }

            public override int Max
            {
                get
                {
                    CacheNode node = this.stack.Peek();
                    return node.Max;
                }
            }

            public override void Push(int item)
            {
                CacheNode node = new CacheNode { Value = item };

                if (this.stack.Count == 0)
                    node.Max = item;
                else
                {
                    CacheNode tail = this.stack.Peek();
                    node.Max = Math.Max(item, tail.Max);
                }

                stack.Push(node);
            }

            public override int Pop()
            {
                CacheNode node = this.stack.Pop();
                return node.Value;
            }
        }

        private class StackWithMaxStack : StackWithMaxAPI
        {
            private class CacheNode
            {
                public int Value { get; set; }
                public int Count { get; set; }
            }

            private Stack<int> stack = new Stack<int>();
            private Stack<CacheNode> cache = new Stack<CacheNode>();

            public override int Count
            {
                get
                {
                    return this.stack.Count;
                }
            }

            public override int Max
            {
                get
                {
                    CacheNode node = this.cache.Peek();
                    return node.Value;
                }
            }

            public override void Push(int item)
            {
                this.stack.Push(item);

                if(this.cache.Count > 0)
                {
                    CacheNode node = cache.Peek();
                    if (node.Value == item)
                    {
                        node.Count++;
                        return;
                    }
                    else if (node.Value > item)
                        return;
                }

                CacheNode newNode = new CacheNode { Count = 1, Value = item };
                this.cache.Push(newNode);
            }

            public override int Pop()
            {
                int item = this.stack.Pop();
                CacheNode node = this.cache.Peek();

                if(node.Value == item)
                {
                    node.Count--;
                    if (node.Count == 0)
                        this.cache.Pop();
                }

                return item;
            }
        }
    }
}
