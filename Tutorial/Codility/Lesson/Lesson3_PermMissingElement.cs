using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson3_PermMissingElement
{
    class Lesson3_PermMissingElement:SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();
            
            int[] A = { 1, 4, 2 , 7, 6, 3};

            Console.WriteLine("Original Array: [{0}]", string.Join(",", A));

            Console.WriteLine("Result : {0}", s.solution(A));
        }
    }

    class Solution
    {
        public int solution(int[] A)
        {
            Int64 ALength = A.Length;

            Int64 sumFrom1toN1 = (ALength + 1) * (ALength + 2) / 2;

            Int64 sumTotalInArray = A.Sum(a => (Int64)a);

            return (int)(sumFrom1toN1 - sumTotalInArray);
        }
    }

}
