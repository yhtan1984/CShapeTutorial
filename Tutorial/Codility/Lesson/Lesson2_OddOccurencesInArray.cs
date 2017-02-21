using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson2_OddOccurencesInArray
{
    class Lesson2_OddOccurencesInArray:SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();

            int[] A = { 9, 5, 9, 3, 9 ,6 ,5, 6,9,3,9};

            Console.WriteLine("Original Array: [{0}]", String.Join(", ", A));

            Console.WriteLine("Result: {0}", s.solution(A));
        }
    }

    class Solution {
        
        public int solution(int[] A)
        {
            return A.GroupBy(a => a)
                     .Select(Group => new { Group.Key, Count = Group.Count() })
                        .Where(b => b.Count % 2 != 0)
                        .Select(c => c.Key).First();

        }
    }
}
