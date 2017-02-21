using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.Mediator
{
    // Name :       Mediator
    // Intention :  Define an object that encapsulates how a set of objects interact. 
    //              Mediator promotes loose coupling by keeping objects from referring to each other explicitly, and it lets you vary their interaction independently. 
    //              Create an "intermediary" that decouples "senders" from "receivers"
    //              
    // URL :        http://www.dofactory.com/net/mediator-design-pattern
    // URL :        https://www.tutorialspoint.com/design_pattern/mediator_pattern.htm

    class Mediator:DemoClass
    {
        public override void execute()
        {
            abstractMediator M = new ConcreteMediator();

            ConcreteColleague Alice = new ConcreteColleague("Alice");
            ConcreteColleague Bob = new ConcreteColleague("Bob");

            Alice.Mediator = M;
            Bob.Mediator = M;

            Alice.send("I love you", "Bob");

        }
    }
    
    public abstract class abstractMediator
    {
        public List<AbstractColleague> Cs = new List<AbstractColleague>();

        public abstract void addColleague(AbstractColleague c);
        public abstract void sendMessage(string message, string senderName, string receiverName);
    }

    public class ConcreteMediator : abstractMediator
    {
        public override void addColleague(AbstractColleague c)
        { this.Cs.Add(c); }

        public override void sendMessage(string message, string senderName, string receiverName)
        {
            var receiverC = Cs.Where(c => c.name == receiverName).FirstOrDefault();
            if (receiverC != null)
            { receiverC.receive(message, senderName); }
        }
    }

    public abstract class AbstractColleague
    {
        private abstractMediator _Mediator;
        public abstractMediator Mediator
        {
            get {
                return _Mediator;
            }
            set {
                _Mediator = value;
                _Mediator.addColleague(this);
            }
        }
        public string name { get; set; }

        public abstract void send(string message, string receiverName);
        public abstract void receive(string message, string senderName);
    }

    public class ConcreteColleague : AbstractColleague
    {
        public ConcreteColleague(string name)
        {
            this.name = name;
        }

        public override void send(string message, string receiverName)
        {
            Mediator.sendMessage(message, this.name, receiverName); //**Instead of we find which colleague to sent the message, we let the mediator to handler it.
        }

        public override void receive(string message, string senderName)
        {
            Console.WriteLine("{0}:{1} received message from {2}: \"{3}\"", DateTime.UtcNow, this.name, senderName, message);
        }
    }
}
