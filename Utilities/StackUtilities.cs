using System.Linq;
using Algorithms.DataStructures;

namespace Utilities
{
    public static class StackUtilities
    {
        public static Stack<T> Initialize<T>(T[] data)
        {
            Stack<T> stack = new Stack<T>();

            foreach (T item in data)
                stack.Push(item);

            return stack;
        }

        public static bool AreEqual<T>(Stack<T> a, Stack<T> b)
        {
            return ArrayUtilities.AreEqual(a.Items.ToArray(), b.Items.ToArray());
        }

        public static void Sort<T>(Stack<T> stack)
        {
            T[] sorted = stack.Items.OrderByDescending(o => o).ToArray();
            while (!stack.IsEmpty)
                stack.Pop();

            foreach (T item in sorted)
                stack.Push(item);
        }
    }
}
