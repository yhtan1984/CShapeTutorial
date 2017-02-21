using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Codility;
using DesignPattern;

namespace Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            //design pattern

            DemoController demoController = new DemoController();
            demoController.execute(Pattern.Factory_AbstractFactory);

            //codility
            //SolutionController SolController = new SolutionController();
            //SolController.execute(EnumSolution.Lesson1_BinaryGap);

            Console.ReadLine();
        }
    }
}
