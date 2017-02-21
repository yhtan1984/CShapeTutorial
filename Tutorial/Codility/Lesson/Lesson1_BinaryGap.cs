using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson1_BinaryGap
{
    class Lesson1_BinaryGap:SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();

            int number = 15;//RandomFactory.getInt_SinglePositive();

            Console.WriteLine("bits for number {0} is {1}", number, Convert.ToString(number, 2));
            Console.WriteLine("Binary Gap for number {0} is {1}", number, s.solution(number));
        }
    }

    class Solution {
        
        public int solution(int N) {
            if (N == 0)
            { return 0; }

            string bits = Convert.ToString(N, 2);

            var splitBits = bits.Split('1').ToList();

            //remove right hand side result, since it will never be correct.
            splitBits.RemoveAt(splitBits.Count - 1);

            var BitGapList = splitBits.Where(a => !string.IsNullOrWhiteSpace(a));

            //get the max only.
            return (BitGapList.Count() > 0) ? BitGapList.Max().Length : 0;
        }
    }
}
