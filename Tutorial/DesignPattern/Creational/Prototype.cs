using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational.Prototype
{
    //  Name      : Prototype
    //  Intention : Ensure a class has only one instance and provide a global point of access to it. 
    //              good to store global variable at single point.

    //shallow copy: copy value type only, object reference type are shared. 
    //deep copy: copy value type only, object reference type are clone and use seperately. 

    class Prototype: DemoClass
    {
        public override void execute()
        {
            Dog d1 = new Dog("harimau");
            Dog d2 = d1.getClone() as Dog;

            Console.WriteLine("Before d2 rename:");
            Console.WriteLine("d1 name: {0}", d1.name);
            Console.WriteLine("d2 name: {0}", d2.name);

            d2.name = "Tiger";

            Console.WriteLine("\nAfter d2 rename:");
            Console.WriteLine("d1 name: {0}", d1.name);
            Console.WriteLine("d2 name: {0}", d2.name);

            if (d1.Equals(d2))
            { Console.WriteLine("it's the same."); }
            else
            { Console.WriteLine("it's not the same."); }
        }
    }

    public abstract class clonableClass
    {
        public abstract clonableClass getClone();
    }

    public class Dog : clonableClass
    {
        //you can have a lot of properties to be copy...

        public string name { get; set; }
        
        public Dog(string Name)
        {
            this.name = Name;  
        }

        //prototype method, shallow copy by existing .net method MemberwiseClone()
        public override clonableClass getClone()
        {
            return this.MemberwiseClone() as clonableClass;
        }
    }

}
