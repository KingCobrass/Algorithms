using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.DynamicProgrammimg
{
    // CTCI 17.8
    [TestClass]
    public class CircusTower
    {
        [TestMethod]
        public void CircusTowerTest()
        {
            Func<Person[], int>[] functions = new Func<Person[], int>[]
            {
                CircusTower.BottomUp,
                CircusTower.TopDown
            };
            
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                Person[] people = new Person[15];
                for(int j = 0; j < 15; j++)
                    people[j] = new Person { Height = random.Next(3, 8), Weight = random.Next(80, 300) };

                Tests.TestFunctions(people, functions);
            }
        }

        private static int BottomUp(Person[] people)
        {
            int[] counts = new int[people.Length];

            for(int i = 0; i < counts.Length; i++)
            {
                for(int j = 0; j < counts.Length; j++)
                {
                    for(int k = 0; k < counts.Length; k++)
                    {
                        if (people[j].CanStandOn(people[k]))
                            counts[j] = Math.Max(counts[j], counts[k] + 1);
                    }
                }
            }

            return counts.Max() + 1;
        }

        private static int TopDown(Person[] people)
        {
            int[] counts = new int[people.Length];
            int max = int.MinValue;

            for(int i = 0; i < counts.Length; i++)
                max = Math.Max(max, CircusTower.GetCount(people, i, counts));

            return max;
        }

        private static int GetCount(Person[] people, int i, int[] counts)
        {
            if (counts[i] > 0)
                return counts[i];

            counts[i] = 1;

            for (int j = 0; j < people.Length; j++)
            {
                if (people[i].CanStandOn(people[j]))
                    counts[i] = Math.Max(counts[i], CircusTower.GetCount(people, j, counts) + 1);
            }

            return counts[i];
        }

        private class Person
        {
            public int Height { get; set; }
            public int Weight { get; set; }

            public bool CanStandOn(Person p)
            {
                return p.Height > this.Height && p.Weight > this.Weight;
            }
        }
    }
}
