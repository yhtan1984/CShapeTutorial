using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson3_FrogJmp
{
    class Lesson3_FrogJmp:SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();

            int X = 20;
            int Y = 101;
            int D = 10;

            Console.WriteLine("X: {0}, Y:{1}, D:{2}", X, Y, D);

            Console.WriteLine("Result : {0}", s.solution(X, Y, D));
        }
    }

    class Solution { 

        public int solution(int X, int Y, int D)
        {
            return (int)Math.Ceiling((Y - X) / (double)D);
        }
    }
}
