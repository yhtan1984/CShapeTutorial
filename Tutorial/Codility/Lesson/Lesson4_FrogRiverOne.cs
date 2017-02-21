using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson4_FrogRiverOne
{
    class Lesson4_FrogRiverOne:SolutionClass
    {
        public override void execute()
        {
            CheckingFunction(3, new int[] { 13,3,3,3,1 }, -1);
        }

        public void CheckingFunction(int X, int[] A, int expected)
        {
            Solution s = new Solution();

            var result = s.solution(X,A);
            if (result != expected)
            {
                Console.WriteLine("fail for [{0}]", String.Join(",", A));
                Console.WriteLine("X: {0}", X);
                Console.WriteLine("expected: {0}, get : {1}", expected, result);
            }
        }
    }
}

class Solution
{
    public int solution(int X, int[] A)
    {
        bool[] AX = new bool[X];
        int target = X;

        int currentSecondLeavePosition = 0;
        for (int i = 0; i < A.Length; i++)
        {
            currentSecondLeavePosition = A[i];
            if (currentSecondLeavePosition <= X)
            { 
                //compare and check will bool[]
                if (AX[currentSecondLeavePosition -1] == false)
                {   AX[currentSecondLeavePosition -1] = true;
                    target--;
                    if (target == 0)
                    { return i; }
                }
            }
        }
        return -1;
    }
}

