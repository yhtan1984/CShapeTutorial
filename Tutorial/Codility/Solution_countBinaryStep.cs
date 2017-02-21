using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQTesting
{
    class Class2
    {
        public Class2 ()
	    {
            string bits = "001";
            // string bits = new string('1', 1000000);
            int totalSteps = 0;
            int stepOfMinusOne = 0;
            int shiftStep = 0;

            //how many times you need to minus 1.
            stepOfMinusOne = bits.Count(f => f == '1');

            //how many times you need to shift to right
            if (bits.IndexOf('1') > -1)
            {
                //left significant bit (of 1) by index count from right.
                int RightIndexLSBOfOne = bits.Length - bits.IndexOf("1");

                //number of shift step needed
                shiftStep = RightIndexLSBOfOne - 1;
            }

            totalSteps = stepOfMinusOne + shiftStep;
            Console.WriteLine(totalSteps);
	    }
        
    }
}
