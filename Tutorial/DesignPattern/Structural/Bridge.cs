using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Bridge
{
    //  Name      : Bridge
    //  Intention : Decouple an abstraction from its implementation so that the two can vary independently. 

    class Bridge: DemoClass
    {
        public override void execute()
        {
            Switch mySuperSwitch;

            mySuperSwitch = new remoteControl();

            mySuperSwitch.application = new TV();
            mySuperSwitch.turnOn();

            //change the application to radio.
            mySuperSwitch.application = new Radio();
            mySuperSwitch.turnOn();

            //change the control?
            mySuperSwitch = new wallControl();
            mySuperSwitch.application = new TV();
            mySuperSwitch.turnOn();

            //from this example
            //1. The "mySuperSwitch|abstraction" can be easily change to other "control|abstraction".
            //2. At the same time, the "application|implementor" can be change easily also.
            //3. Here, we can see how easy to seperate 2 difference sets of logic rather that traditional way, 
            //   eg: remoteControl have TV_ON(), Radio_ON(),Computer_ON(), WallControl have TV_ON(), Radio_ON(),Computer_ON()...
            //4. NOTE: Need to have machanized to specify/instantiation those 2 difference sets of logic.
        }
    }

    //abstraction
    abstract class Switch
    {
        public IApplication application;

        public virtual void turnOn()
        {
            Console.WriteLine("\nI use {0} to turn on the application", this.GetType().Name);
            application.ON();
        }
    }

    //concrete abstraction
    class remoteControl : Switch
    {
    }

    class wallControl : Switch
    {
    }

    class mobileControl: Switch
    {
    }

    //implementor
    interface IApplication
    {
        void ON();
    }

    //concrete implementor
    class TV : IApplication
    {
        public void ON()
        {
            Console.WriteLine("{0} is ON.", this.GetType().Name);
        }
    }

    class Radio : IApplication
    {
        public void ON()
        {
            Console.WriteLine("{0} is ON.", this.GetType().Name);
        }
    }

    class Computer : IApplication
    {
        public void ON()
        {
            Console.WriteLine("{0} is ON.", this.GetType().Name);
        }
    }
}
