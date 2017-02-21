using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.Command
{
    //Name      : Command
    //Intention : Encapsulate a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations. 
    
    class Command: DemoClass
    {
        public override void execute()
        {
            Order orderCommand = new BuyStock(new Stock("Google"));
            orderCommand.execute();

            orderCommand = new SellStock(new Stock("Microsoft"));
            orderCommand.execute();
        }
    }
    
    public class Stock
    {
        private string _name { get; set; }

        public Stock(string name)
        {
            _name = name;
        }

        public void buy()
        {
            Console.WriteLine("Buy {0}.", _name);
        }

        public void sell()
        {
            Console.WriteLine("Sell {0}.", _name);
        }
    }


    //command
    interface Order
    {
        void execute();
    }

    class BuyStock : Order
    {
        private Stock _stock;
        public BuyStock(Stock stock)
        {
            _stock = stock;
        }
        public void execute()
        {
            _stock.buy();
        }
    }
    class SellStock : Order
    { 
        private Stock _stock;
        public SellStock(Stock stock)
        {
            _stock = stock;
        }
        public void execute()
        {
            _stock.sell();
        }
    }





}
