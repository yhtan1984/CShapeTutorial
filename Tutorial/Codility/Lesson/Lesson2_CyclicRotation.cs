using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility.Lesson.Lesson2_CyclicRotation
{
    class Lesson2_CyclicRotation:SolutionClass
    {
        public override void execute()
        {
            Solution s = new Solution();

            int[] A = new int[RandomFactory.getInt_SinglePositive(1,10)];

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = RandomFactory.getInt_SinglePositive();
            }

            int K = RandomFactory.getInt_SinglePositive();

            int[] result = s.solution(A, K);

            Console.WriteLine("Original Array: [{0}]", string.Join(", ", A));

            Console.WriteLine("Rotation: {0}", K);

            Console.WriteLine("Result: [{0}]", string.Join(", ", result));
        }
    }

    class Solution {
        
        public int[] solution(int[] A, int K)
        {
            if (A == null || A.Length == 0)
                return A;

            int[] B = new int[A.Length];

            int shift = K % A.Length;

            for (int i = 0; i < A.Length; i++)
            {
                if ((i + shift) < A.Length)
                    B[i + shift] = A[i];
                else
                    B[(i + shift) - A.Length] = A[i];
            }
            return B;
        }
    
    }


}
