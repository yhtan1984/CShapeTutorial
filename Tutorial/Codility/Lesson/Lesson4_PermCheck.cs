using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson4_PermCheck
{
    class Lesson4_PermCheck:SolutionClass
    {
        public override void execute()
        {
            CheckingFunction(new[] { 4,1,3 }, 0);
        }

        public void CheckingFunction(int[] parameter, int expected)
        {
            Solution s = new Solution();

            var result = s.solution(parameter);
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
            int max = A.Length;
            bool[] checker = new bool[max];
            int Counter = max;
            
            int number = 0;
            for (int i = 0; i < max; i++)
            { 
                number= A[i];
                if (number > max)
                {
                    return 0;
                }
                else { 
                    //check is repeated or not. if not, update.
                    if (checker[number - 1] == true)
                    { return 0; }
                    else
                    { 
                        checker[number - 1] = true;
                        Counter--;
                    }
                }
            }

            return (Counter == 0) ? 1:0;
        }
    }
}
