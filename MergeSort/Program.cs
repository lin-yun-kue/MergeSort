using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //var q = new Queue<int>();
            //var test = q.Peek();
            int[] data = new int[] { 41, 33, 17, 80, 61, 5, 55, 99, 11 };
            MergeSort(data);
            foreach(var item in data)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }

        static void MergeSort(int[] arr)
        {
            if(arr.Length > 1)
            {
                var mid = arr.Length / 2;
                var leftArr = arr.Take(mid).ToArray();
                var rightArr = arr.Skip(mid).ToArray();

                MergeSort(leftArr);
                MergeSort(rightArr);

                var leftQue = new Queue<int>(leftArr);
                var rightQue = new Queue<int>(rightArr);

                var mergeIndex = 0;

                while (leftQue.Count != 0 || rightQue.Count != 0)
                {
                    int? left = new Nullable<int>();
                    int? right = new Nullable<int>();

                    if(leftQue.Count != 0)
                    {
                        left = leftQue.Peek();
                    }

                    if(rightQue.Count != 0)
                    {
                        right = rightQue.Peek();
                    }

                    if(left.HasValue && right.HasValue)
                    {
                        if(left < right)
                        {
                            arr[mergeIndex] = leftQue.Dequeue();
                        }
                        else
                        {
                            arr[mergeIndex] = rightQue.Dequeue();
                        }
                    }
                    else
                    {
                        if (left.HasValue)
                        {
                            arr[mergeIndex] = leftQue.Dequeue();
                        }
                        if (right.HasValue)
                        {
                            arr[mergeIndex] = rightQue.Dequeue();
                        }
                    }
                    mergeIndex++;
                }
            }
            

        }
    }
}
