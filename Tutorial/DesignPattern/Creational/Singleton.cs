using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational.Singleton
{
    //  Name      : Singleton
    //  Intention : Ensure a class has only one instance and provide a global point of access to it. 
    //              good to store global variable at single point.

    //  A singleton allows access to a single created instance - that instance (or rather, a reference to that instance) 
    //  can be passed as a parameter to other methods, and treated as a normal object.
    //  A static class allows only static methods.

    class Singleton:DemoClass
    {
        public override void execute()
        {
            Log myLoggerA = Log.getInstance();

            Log myLoggerB = Log.getInstance();

            Console.WriteLine(myLoggerB.getCount());

            myLoggerA.setCount(5);

            Console.WriteLine(myLoggerB.getCount());

            if (myLoggerA.Equals(myLoggerB))
            { Console.WriteLine("it's the same."); }
        }
    }

    class Log
    { 
        private static Log _logInstance= new Log(); //1. a private static instance.

        private Log ()  //2. a private constructor.
	    {}

        public static Log getInstance()
        {
            return _logInstance; //3. return the private instance
        }

        private int _count = 1;
        public int getCount()
        {
            return _count;
        }

        public void setCount(int count)
        {
            _count = count;
        }

        public static int staticMethod()
        {
            //return count; //ERROR: static method cannot use non-static properties/method
            return 0;
        }
    }


}
