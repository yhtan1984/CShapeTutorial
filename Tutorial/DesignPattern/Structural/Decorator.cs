using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Decorator
{
    //Name      : Decorator, light proxy
    //Intention : Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionality.
    //            Without modification on the original class.
    //            in simple, add additional method to the existing class without real "extend" and modification to the original.
    class Decorator
    {
        public Decorator()
        {
            //original switch
            Switch original_sw;
            original_sw = new RemoteControl();
            original_sw.turnOn();

            Console.WriteLine("-----------------------------------");

            //decorated type switch 1
            SwitchDecorator decorated_switch;
            decorated_switch = new SwitchFeatureByTime(original_sw);
            decorated_switch.turnOn();

            Console.WriteLine("-----------------------------------");

            //decorated type switch 2
            decorated_switch = new SwitchFeatureByTemperature(original_sw);
            decorated_switch.turnOn();
        }
    }


    //component
    abstract class Switch
    {
        public virtual void turnOn()
        {
            Console.WriteLine("\nOriginal turnOn method");
        }
    }

    //concrete component
    class RemoteControl : Switch { 
    
    }

    class WallControl : Switch { 
        
    }

    //decorator
    abstract class SwitchDecorator: Switch
    {
        protected Switch _originalSwitch;

        public SwitchDecorator(Switch originalSwitch)
        {
            _originalSwitch = originalSwitch;
        }

        //here we can override, use the default and/or extend the _originalSwitch.turnOn()
        public override void turnOn()
        {
            Console.WriteLine("SwitchDecorator turnOn method");
        }
    }

    //concrete decorator
    class SwitchFeatureByTime : SwitchDecorator
    {
        public SwitchFeatureByTime(Switch _originalSwitch)
            :base(_originalSwitch)
        {
        }

        public override void turnOn()
        {
            //base.turnOn();
            Console.WriteLine("SwitchFeatureByTime turnOn method");
        }

        public void autoTurnOff()
        {
            Console.WriteLine("Auto switch off after 5minutes");
        }

    }

    class SwitchFeatureByTemperature : SwitchDecorator
    {
        public SwitchFeatureByTemperature(Switch _originalSwitch)
            : base(_originalSwitch)
        {
        }

        public override void turnOn()
        {
            base.turnOn();
            Console.WriteLine("SwitchFeatureByTemperature turnOn method");
        }

        public void turnOnIfTooHot()
        {
            Console.WriteLine("Switch on if too hot");
        }
    }

}
