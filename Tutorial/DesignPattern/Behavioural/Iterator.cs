using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DesignPattern.Behavioural.Iterator
{
    //Name      : Iterator
    //Intention : Provide a way to access the elements of an aggregate object sequentially without exposing its underlying representation.
    //            Polymorphic traversal
    //url       : https://www.tutorialspoint.com/design_pattern/iterator_pattern.htm

    class Iterator:DemoClass
    {
        public override void execute()
        {
            MyCollection mycol = new MyCollection();
            mycol[0] = new MyItem("item 1");
            mycol[1] = new MyItem("item 2");
            mycol[2] = new MyItem("item 3");
            mycol[3] = new MyItem("item 4");

            MyIterator itor = mycol.getIterator();

            for (MyItem item = itor.First(); !itor.IsDone(); item = itor.Next())
            {
                Console.WriteLine(item.Name);
            }
        }
    }


    class MyItem
    { 
        public  string Name { get; set; }

        public MyItem(string Name)
        {
            this.Name= Name ;
        }
    }

    class MyCollection
    { 
        private ArrayList _Items=new ArrayList();
        public int Count {
            get {
                return _Items.Count;
            }
        }

        public object this[int index]
        {
            get {   return _Items[index];   }
            set {   _Items.Add(value); }
        }

        public MyIterator getIterator()
        {
            return new ConcreteIterator(this);
        }
    }

    abstract class MyIterator
    {
        public abstract MyItem First();
        public abstract MyItem Next();
        public abstract bool IsDone();
        public abstract MyItem CurrentItem();
    }

    class ConcreteIterator : MyIterator
    {
        MyCollection _collection = new MyCollection();
        private int _current = 0;

        public ConcreteIterator(MyCollection myCollection)
        {
            _collection = myCollection;
        }

        public override MyItem First()
        {
            _current = 0;
            return CurrentItem();
        }

        public override MyItem Next()
        {
            _current++;
            if(!IsDone())
                return CurrentItem();
            else
                return null;
        }

        public override bool IsDone()
        {
            return _current >= _collection.Count;
        }

        public override MyItem CurrentItem()
        {
            return _collection[_current] as MyItem;
        }
    }
}
