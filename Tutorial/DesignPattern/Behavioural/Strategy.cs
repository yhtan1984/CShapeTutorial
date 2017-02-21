using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.Strategy
{
    // Name :       Strategy
    // Intention :  In Strategy pattern, a class behavior or its algorithm can be changed at run time.
    //              
    // URL :        https://www.tutorialspoint.com/design_pattern/strategy_pattern.htm
    // URL :        http://www.dofactory.com/net/strategy-design-pattern


    class Strategy:DemoClass
    {
        public override void execute()
        {

            Calculator calculator = new Calculator();

            calculator.strategy = new AddStrategy();//Add

            calculator.execute(3, 6);

            //9

            calculator.strategy = new MinusStrategy();//Minus

            calculator.execute(3, 6);

            //-3
        }
    }

    //abstract strategy
    public interface IStrategy{
        int doCalculation(int NumA, int NumB);
    }

    //concrete strategy
    class AddStrategy : IStrategy
    {
        public int doCalculation(int NumA, int NumB)
        {
            return NumA + NumB;
        }
    }

    class MinusStrategy : IStrategy
    {
        public int doCalculation(int NumA, int NumB)
        {
            return NumA - NumB;
        }
    }

    //context
    class Calculator
    {
        public IStrategy strategy { get; set; }//get and set the strategy

        public void execute(int NumberA, int NumberB)
        {
            int result = strategy.doCalculation(NumberA, NumberB);

            Console.WriteLine("Calculate {0} and {1} by this Strategy class: {2} , result is :{3}", NumberA, NumberB, strategy.GetType().Name, result);
        }
    }
}
