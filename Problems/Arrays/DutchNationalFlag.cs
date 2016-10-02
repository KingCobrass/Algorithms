using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Arrays
{
    [TestClass]
    public class DutchNationalFlag
    {
        [TestMethod]
        public void DutchNationalFlagTest()
        {
            Action<int[], int>[] actions = new Action<int[], int>[]
            {
                DutchNationalFlag.Nested,
                DutchNationalFlag.DoublePass,
                DutchNationalFlag.SinglePass
            };

            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    for(int k = 0; k < actions.Length; k++)
                    {
                        int[] data = ArrayUtilities.CreateRandomArray(i, 0, 20);
                        int pivot = data[j];
                        actions[k](data, j);

                        DutchNationalFlag.Validate(data, pivot);
                    }
                }
            }
        }

        private static void Nested(int[] data, int pivotIndex)
        {
            int pivot = data[pivotIndex];

            for(int i = 0; i < data.Length; i++)
            {
                for(int j = i; j < data.Length; j++)
                {
                    if(data[j] < pivot)
                    {
                        ArrayUtilities.Swap(data, i, j);
                        break;
                    }
                }
            }

            for(int i = data.Length - 1; i >= 0; i--)
            {
                for(int j = i; j >= 0; j--)
                {
                    if(data[j] > pivot)
                    {
                        ArrayUtilities.Swap(data, i, j);
                        break;
                    }
                }
            }
        }

        private static void DoublePass(int[] data, int pivotIndex)
        {
            int pivot = data[pivotIndex];

            int smaller = 0;

            for(int i = 0; i < data.Length; i++)
            {
                if(data[i] < pivot)
                {
                    ArrayUtilities.Swap(data, i, smaller);
                    smaller++;
                }
            }

            int larger = data.Length - 1;

            for(int i = larger; i >= smaller; i--)
            {
                if(data[i] > pivot)
                {
                    ArrayUtilities.Swap(data, i, larger);
                    larger--;
                }
            }
        }

        private static void SinglePass(int[] data, int pivotIndex)
        {
            int pivot = data[pivotIndex];

            int lower = 0;
            int equal = 0;
            int higher = data.Length;

            while(equal < higher)
            {
                if (data[equal] < pivot)
                {
                    ArrayUtilities.Swap(data, equal, lower);
                    lower++;
                    equal++;
                }
                else if (data[equal] == pivot)
                    equal++;
                else
                {
                    higher--;
                    ArrayUtilities.Swap(data, equal, higher);
                }
            }
        }

        private static void Validate(int[] data, int pivot)
        {
            bool pivotFound = false;
            bool pivotPassed = false;

            for(int i = 0; i < data.Length; i++)
            {
                if (data[i] == pivot)
                    pivotFound = true;
                else if (data[i] > pivot)
                    pivotPassed = true;

                if (!pivotFound)
                    Assert.IsTrue(data[i] < pivot);
                else if (pivotPassed)
                    Assert.IsTrue(data[i] > pivot);
                else
                    Assert.AreEqual(data[i], pivot);
            }
        }
    }
}
