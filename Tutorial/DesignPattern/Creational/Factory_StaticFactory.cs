using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational.Factory_StaticFactory
{
    //Name      : Simple factory, static factory
    //Intention : Instead of creating a new object by calling the class constructor, you call another function (the “factory”) that constructs the object. 

    public class Factory_StaticFactory : DemoClass
    {
        public override void execute()
        {
            //before 
            Car myCar = new Car();

            //after
            Car mySecondCar = CarFactory.createNewCar();
        }
    }

    public class Car {
        public Car()
        { Console.WriteLine("new Car created"); }
    }

    public class CarFactory{
        public static Car createNewCar()
        {
            // 1. reduce the code to add "new" everywhere.

            // 2. what if the we want to load some spec. from an file the Car? Then, we can implement here also.
            //    e.g.
            //    if (fileIsFound)
            //    { return new Car(loadSpecFromFile()); }
            //    else
            //    { return new Car(); }

            // 3. Should we move this logic to inside the Car class? and Why?
            //    No. Because the car class might use by other that don't need this.

            return new Car();
        }
    }
}
