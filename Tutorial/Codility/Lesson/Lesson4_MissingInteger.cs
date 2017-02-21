using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Codility.Lesson.Lesson4_MissingInteger
{
    class Lesson4_MissingInteger:SolutionClass
    {
        
        public override void execute()
        {
            Solution s = new Solution();

            CheckingFunction(new[] { 1 }, 2);
            CheckingFunction(new[] { 1 }, 2);
            CheckingFunction(new[] { 2 }, 1);
            CheckingFunction(new[] { -1 }, 1);

            CheckingFunction(new[] { -1, 5 }, 1);
            CheckingFunction(new[] { -1, 1 }, 2);
            CheckingFunction(new[] { -1, 3, 1 }, 2);
            CheckingFunction(new[] { -1, 1, 1, 3, 5 }, 2);

            CheckingFunction(new[] { 4, 5, 6, 2 }, 1);
            CheckingFunction(new[] { 1, 3, 6, 4, 1, 2 }, 5);
            CheckingFunction(new[] { 1, 1, 1, 1, 1, 1, 1, 2, 9, 8, 7, 1, 1, 1, 1 }, 3);

            CheckingFunction(new[] { 2, 5, 4, 1, 4, 5, 1 }, 3);

        }

        public void CheckingFunction(int[] parameter, int expected)
        {
            Solution s = new Solution();

            var result= s.solution(parameter);
            if (result != expected)
            {
                Console.WriteLine("fail for [{0}]", String.Join(",", parameter));
                Console.WriteLine("expected: {0}, get : {1}", expected, result);
            }
        }
    }

    class Solution {

        public int solution(int[] A)
        {
            int maxLength = 100001;
            bool[] Numbers = new bool[maxLength];

            int number;
            for (int i = 0; i < A.Length; i++)
            {
                number = A[i];
                if (number > 0 && number < maxLength)//1...100000
                {
                    Numbers[number] = true;
                }
            }

            int result = 100001;//if all Numbers are true, the the next possive integal will be 100001
            for (int j = 1; j < maxLength; j++)//1...100000
                {
                    if (Numbers[j] == false)
                    {
                        result = j; break;
                    }
                }
            return result;
        }


        //public int solution(int[] A)
        //{
        //    int result = 1;//0/1

        //    var sorted = A.ToList()
        //            .Where(a => a > 0)
        //            .Distinct()
        //            .OrderBy(a => a);

        //    //if (sorted.Count() == 0)
        //    //{
        //    //    result = 1;
        //    //}
        //    if(sorted.Count() == 1)
        //    {
        //        if (sorted.First() == 1)
        //            result = 2;
        //        //else
        //        //    result = 1;
        //    }
        //    else
        //    {
        //        if (sorted.Count() > 1)
        //        {
        //            if(sorted.First() == 1)
        //            {
        //                foreach (var i in sorted)
        //                {
        //                    if (i - result > 1)
        //                    { result++; break; }
        //                    else
        //                    { result = i; }
        //                }
        //            }
        //        }
        //    }
        //    return result;
        //}

    }
}
