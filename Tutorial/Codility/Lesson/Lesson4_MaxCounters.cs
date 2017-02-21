using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson4_MaxCounters
{
    class Lesson4_MaxCounters:SolutionClass
    {
        public override void execute()
        {
            CheckingFunction(4, new int[] { 5, 1, 5, 5, 2 }, "{zzz}");
        }

        public void CheckingFunction(int X, int[] A, string expected)
        {
            Solution s = new Solution();

            var result = s.solution(X, A);
            if (true)
            {
                Console.WriteLine("fail for [{0}]", String.Join(",", A));
                Console.WriteLine("X: {0}", X);
                Console.WriteLine("expected: {0}, get : {1}", expected, String.Join(",", result));
            }
        }
    }

    class Solution
    {
        public int[] solution(int N, int[] A)
        {
            int[] Aresult = new int[N];
            int number = 0, currentMax = 0, levelMax = 0;

            for (int i = 0; i < A.Length; i++)
            {
                number = A[i];
                //operation Max : N+1
                if (number == N + 1)
                {
                    levelMax = currentMax;
                }
                //operation increase(x) if 1 <= X <= N
                else
                {
                    if (Aresult[number - 1] < levelMax)
                    {
                        Aresult[number - 1] = levelMax;
                    }

                    Aresult[number - 1]++;

                    if (Aresult[number - 1] > currentMax)
                    { currentMax++; }
                }
            }

            for (int i = 0; i < N; i++)
            {
                if (Aresult[i] < levelMax)
                { Aresult[i] = levelMax; }
            }

            return Aresult;
        }
    }
}
