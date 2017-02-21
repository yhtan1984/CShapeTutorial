using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.State
{
    // Name :       State
    // Intention :  In State pattern a class behavior changes based on its state.
    //              
    // URL :        http://www.dofactory.com/net/observer-design-pattern
    // URL :        https://www.tutorialspoint.com/design_pattern/observer_pattern.htm
    // URL :        http://gameprogrammingpatterns.com/state.html (nice explaination why the State need to handle the action.)

    class State:DemoClass
    {
        public override void execute()
        {
            // Open a new account
            Account account = new Account("Jim Johnson");
            // Apply financial transactions
            account.Deposit(500.0);
            account.Deposit(300.0);// change to silverState
            account.Deposit(550.0);// change to goldState
            account.PayInterest();
            account.Withdraw(2000.00);//change to redState
            account.Withdraw(1100.00);
        }
    }


    /// <summary>
    /// The 'State' abstract class
    /// </summary>
    abstract class AbsState
    {
        protected Account account;
        protected double balance;
        protected double interest;
        protected double lowerLimit;
        protected double upperLimit;
        // Properties
        public Account Account
        {
            get { return account; }
            set { account = value; }
        }
        public double Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
        public abstract void PayInterest();
    }
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Red indicates that account is overdrawn 
    /// </remarks>
    /// </summary>
    class RedState : AbsState
    {
        private double _serviceFee;
        // Constructor
        public RedState(AbsState state)
        {
            this.balance = state.Balance;
            this.account = state.Account;
            Initialize();
        }
        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = -100.0;
            upperLimit = 0.0;
            _serviceFee = 15.00;
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            amount = amount - _serviceFee;
            Console.WriteLine("No funds available for withdrawal!");
        }
        public override void PayInterest()
        {
            // No interest is paid
        }
        private void StateChangeCheck()
        {
            if (balance > upperLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Silver indicates a non-interest bearing state
    /// </remarks>
    /// </summary>
    class SilverState : AbsState
    {
        // Overloaded constructors
        public SilverState(AbsState state) :
            this(state.Balance, state.Account)
        {
        }
        public SilverState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }
        private void Initialize()
        {
            // Should come from a datasource
            interest = 0.0;
            lowerLimit = 0.0;
            upperLimit = 1000.0;
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }
        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            if (balance < lowerLimit)
            {
                account.State = new RedState(this);
            }
            else if (balance > upperLimit)
            {
                account.State = new GoldState(this);
            }
        }
    }
    /// <summary>
    /// A 'ConcreteState' class
    /// <remarks>
    /// Gold indicates an interest bearing state
    /// </remarks>
    /// </summary>
    class GoldState : AbsState
    {
        // Overloaded constructors
        public GoldState(AbsState state)
            : this(state.Balance, state.Account)
        {
        }
        public GoldState(double balance, Account account)
        {
            this.balance = balance;
            this.account = account;
            Initialize();
        }
        private void Initialize()
        {
            // Should come from a database
            interest = 0.05;
            lowerLimit = 1000.0;
            upperLimit = 10000000.0;
        }
        public override void Deposit(double amount)
        {
            balance += amount;
            StateChangeCheck();
        }
        public override void Withdraw(double amount)
        {
            balance -= amount;
            StateChangeCheck();
        }
        public override void PayInterest()
        {
            balance += interest * balance;
            StateChangeCheck();
        }
        private void StateChangeCheck()
        {
            if (balance < 0.0)
            {
                account.State = new RedState(this);
            }
            else if (balance < lowerLimit)
            {
                account.State = new SilverState(this);
            }
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    class Account
    {
        private AbsState _state;
        private string _owner;
        // Constructor
        public Account(string owner)
        {
            // New accounts are 'Silver' by default
            this._owner = owner;
            this._state = new SilverState(0.0, this);
        }
        // Properties
        public double Balance
        {
            get { return _state.Balance; }
        }
        public AbsState State
        {
            get { return _state; }
            set { _state = value; }
        }
        public void Deposit(double amount)
        {
            _state.Deposit(amount);
            Console.WriteLine("Deposited {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}",
              this.State.GetType().Name);
            Console.WriteLine("");
        }
        public void Withdraw(double amount)
        {
            _state.Withdraw(amount);
            Console.WriteLine("Withdrew {0:C} --- ", amount);
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }
        public void PayInterest()
        {
            _state.PayInterest();
            Console.WriteLine("Interest Paid --- ");
            Console.WriteLine(" Balance = {0:C}", this.Balance);
            Console.WriteLine(" Status = {0}\n",
              this.State.GetType().Name);
        }
    }
}
