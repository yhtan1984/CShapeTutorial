using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson3_TapeEquilibrium
{
    class Lesson3_TapeEquilibrium : SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();

            Console.WriteLine("{0}",s.solution(new[] { -22,22,10000 }));
        }
    }

    class Solution {

        public int solution(int[] A)
        {
            var min = Int32.MaxValue;

            int left = 0;
            int right = A.Sum();

            for(int i=0; i<A.Length -1; i++)
            {
                left = left + A[i];
                right = right - A[i];

                int diff = Math.Abs(left - right);

                if (diff < min)
                { min = diff; }
            }

            return min;
        }
    
    }
}
