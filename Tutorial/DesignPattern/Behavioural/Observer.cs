using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.Observer
{
    // Name :       Observer
    // Intention :  Define a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically. 
    //              
    // URL :        http://www.dofactory.com/net/observer-design-pattern
    // URL :        https://www.tutorialspoint.com/design_pattern/observer_pattern.htm

    class Observer:DemoClass
    {
        public override void execute()
        {
            View Alice_GraphView = new customShareGraphView("Alice_GraphView");
            View Alice_DetailView = new customShareDetailView("Alice_DetailView");

            View Bob_GraphView = new customShareGraphView("Bob_GraphView");
            View Bob_DetailView = new customShareDetailView("Bob_DetailView");

            View vendor_GraphView = new customShareGraphView("vendor_GraphView");
            View vendor_DetailView = new customShareDetailView("vendor_DetailView");

            Share IBM = new IBM("NYSE: IBM"); //will have alice, bob and vendor
            Share Google = new Google("NASDAQ: GOOGL"); // will have alice graph and vendor graph

            IBM.attachObserver(Alice_GraphView);
            IBM.attachObserver(Alice_DetailView);
            IBM.attachObserver(Bob_GraphView);
            IBM.attachObserver(Bob_DetailView);
            IBM.attachObserver(vendor_GraphView);
            IBM.attachObserver(vendor_DetailView);

            Google.attachObserver(Alice_GraphView);
            Google.attachObserver(vendor_GraphView);

            IBM.Price = 8.01M;
            Google.Price = 30.20M;

            Console.WriteLine("remove alice from IBM and update IBM price again\n");
            IBM.detechObserver(Alice_GraphView);
            IBM.detechObserver(Alice_DetailView);

            IBM.Price = 35.02M;

        }
    }

    //abstract subject
    abstract class Share
    {
        public List<View> views;
        public string CodeName { get; set; }
        private decimal _price;
        public decimal Price
        {
            get { return _price; }
            set
            {
                _price = value;
                notify();
            }
        }

        public void attachObserver(View v)
        {
            views.Add(v);
        }

        public void detechObserver(View v)
        {
            views.Remove(v);
        }

        public void notify()
        {
            foreach (View o in views)
            {
                o.update(this);
            }
        }

        public Share(string name)
        {
            this.CodeName = name;
            views = new List<View>();
        }
    }

    //ConcreteSubject
    class IBM :Share
    {
        public IBM(string name)
            : base(name)
        {
        }
    }

    //ConcreteSubject
    class Google : Share
    {
        public Google(string name)
            : base(name)
        {
        }
    }

    //abstract Observer
    abstract class View
    {
       public string type;
       public abstract void update(Share subject);

       public View(string type)
       {
           this.type = type;//vendor, client, client 1...
       }
    }

    //concrete Observer
    class customShareGraphView : View
    {
        public customShareGraphView(string type):base(type)
        {

        }

        public override void update(Share subject)
        {
            Console.WriteLine("GraphView for {0}", this.type);
            Console.WriteLine("Stock: {0}, Price: {1}\n", subject.CodeName, subject.Price);
        }
    }
    //concrete Observer
    class customShareDetailView : View
    {
        public customShareDetailView(string type)
            : base(type)
        {

        }

        public override void update(Share subject)
        {
            Console.WriteLine("DetailView for {0}", this.type);
            Console.WriteLine("{0}: Stock: {1}, Price: {2}\n", DateTime.UtcNow, subject.CodeName, subject.Price);
        }
    }
    
}
