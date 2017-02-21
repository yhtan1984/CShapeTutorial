﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Composite
{
    // Name     : Composite
    // Intention: Compose objects into tree structures to represent whole-part hierarchies. 
    //            Composite lets clients treat individual objects and compositions of objects uniformly.
    //            use Recursive composition
    // URL      : http://www.dofactory.com/net/composite-design-pattern

    class Composite : DemoClass
    {
        public override void execute()
        {
            // Create a tree structure

            MyComposite root = new MyComposite("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            MyComposite comp = new MyComposite("Composite X");
            comp.Add(new Leaf("Leaf XA"));
            comp.Add(new Leaf("Leaf XB"));
            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            // Add and remove a leaf
            Leaf leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);
        }
    }


    /// <summary>
    /// The 'Component' abstract class
    /// </summary>
    abstract class Component
    {
        protected string name;
        // Constructor
        public Component(string name)
        {
            this.name = name;
        }
        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }
    /// <summary>
    /// The 'Composite' class
    /// </summary>
    class MyComposite : Component
    {
        private List<Component> _children = new List<Component>();
        // Constructor
        public MyComposite(string name)
            : base(name)
        {
        }
        public override void Add(Component component)
        {
            _children.Add(component);
        }
        public override void Remove(Component component)
        {
            _children.Remove(component);
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
            // Recursively display child nodes
            foreach (Component component in _children)
            {
                component.Display(depth + 2);
            }
        }
    }
    /// <summary>
    /// The 'Leaf' class
    /// </summary>
    class Leaf : Component
    {
        // Constructor
        public Leaf(string name)
            : base(name)
        {
        }
        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to a leaf");
        }
        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from a leaf");
        }
        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}
