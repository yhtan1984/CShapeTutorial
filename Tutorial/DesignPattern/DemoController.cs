using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPattern.Creational.Factory_StaticFactory;
using DesignPattern.Creational.Factory_FactoryMethod;
using DesignPattern.Creational.Factory_AbstractFactory;
using DesignPattern.Creational.Builder;
using DesignPattern.Creational.Singleton;
using DesignPattern.Creational.Prototype;
using DesignPattern.Structural.Adapter;
using DesignPattern.Structural.Bridge;
using DesignPattern.Structural.Composite;
using DesignPattern.Structural.Decorator;
using DesignPattern.Structural.Facade;
using DesignPattern.Structural.Flyweight;
using DesignPattern.Structural.Proxy;
using DesignPattern.Behavioural.ChainOfResponsibility;
using DesignPattern.Behavioural.Command;
using DesignPattern.Behavioural.Interpreter;
using DesignPattern.Behavioural.Iterator;
using DesignPattern.Behavioural.Mediator;
using DesignPattern.Behavioural.Memento;
using DesignPattern.Behavioural.Observer;
using DesignPattern.Behavioural.State;
using DesignPattern.Behavioural.Strategy;
using DesignPattern.Behavioural.TemplateMethod;

namespace DesignPattern
{
    public abstract class DemoClass
    {
        public DemoClass()
        {
            execute();
        }

        public abstract void execute();
    }

    public enum Pattern{
        Factory_StaticFactory,
        Factory_FactoryMethod,
        Factory_AbstractFactory,
        Builder,
        Singleton,
        Prototype,

        Adapter,
        Bridge,
        Composite, 
        Decorator,
        Facade,
        Flyweight,
        Proxy,

        ChainOfResponsibility,
        Command,
        Interpreter,
        Iterator,
        Mediator,
        Memento,
        Observer,
        State,
        Strategy,
        TemplateMethod
    }
    
     public class DemoController
    {
         public DemoController() { }

         public Object execute(Pattern patternToBeDemo){

                          switch(patternToBeDemo)
             {
                 case Pattern.Factory_StaticFactory: return new Factory_StaticFactory();
                 case Pattern.Factory_FactoryMethod: return new Factory_FactoryMethod();
                 case Pattern.Factory_AbstractFactory: return new Factory_AbstractFactory();
                 case Pattern.Builder: return new Builder();
                 case Pattern.Singleton: return new Singleton();
                 case Pattern.Prototype: return new Prototype();

                 case Pattern.Adapter: return new Adapter();
                 case Pattern.Bridge: return new Bridge();
                 case Pattern.Composite: return new Composite();
                 case Pattern.Decorator: return new Decorator();
                 case Pattern.Facade: return new Facade();
                 case Pattern.Flyweight: return new Flyweight();
                 case Pattern.Proxy: return new Proxy();

                 case Pattern.ChainOfResponsibility: return new ChainOfResponsibility();
                 case Pattern.Command: return new Command();
                 case Pattern.Interpreter: return new Interpreter();
                 case Pattern.Iterator: return new Iterator();
                 case Pattern.Mediator: return new Mediator();
                 case Pattern.Memento: return new Memento();
                 case Pattern.Observer: return new Observer();
                 case Pattern.State: return new State();
                 case Pattern.Strategy: return new Strategy();
                 case Pattern.TemplateMethod: return new TemplateMethod();

                 default: return "";
             }
         }

    }
}
