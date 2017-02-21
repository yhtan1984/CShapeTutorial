using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Adapter
{
    //  Name      : Adapter
    //  Intention : Convert the interface of a class into another interface clients expect. 
    //              Adapter lets classes work together that couldn't otherwise because of incompatible interfaces. 
    
    class Adapter:DemoClass
    {
        public override void execute()
        {
            Car c = new Car();
            Airplane a = new Airplane();

            Airplane flyCar = new FlyingCar();

            c.run();

            a.fly();

            flyCar.fly();
        }
    }

    //target class
    class Airplane {
        public virtual void fly()
        {
            Console.WriteLine("{0} fly at 400km//j", typeof(Airplane).Name);
        }
    }

    //adaptee class
    class Car {
        public void run()    
        {
            Console.WriteLine("{0} run at 200km//j", typeof(Car).Name);
        }
    }

   //adaptor class, this is the core how you turn car to fly...
   class FlyingCar : Airplane
   {
       Car c=new Car();

       public override void fly()
       {
           Console.WriteLine("Now my car can fly too");
           c.run();
       }
   }

}
