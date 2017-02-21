using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.Memento
{
    // Name :       Memento
    // Intention :  Memento pattern is used to restore full/parties state(properties value) of an object to a previous state.
    //              
    // URL :        https://www.tutorialspoint.com/design_pattern/memento_pattern.htm
    // URL :        http://www.dofactory.com/net/memento-design-pattern

    class Memento:DemoClass
    {
        public override void execute()
        {
            Student student = new Student("Alice", 1, "Run");
            StudentMomento SM = student.createMomento();
            CareTaker.studentMomento = SM;//save to memory...

            Console.WriteLine("Before set Id to null :");
            student.showProps();
            Console.WriteLine("------------------------");

            student.Id = null;
            //blah blah blah...
            Console.WriteLine("After set Id to null :");
            student.showProps();
            Console.WriteLine("------------------------");


            //restore back the student
            student.setMomento(CareTaker.studentMomento);

            Console.WriteLine("After restore :");
            student.showProps();
        }
    }

    //the Originator
    class Student
    {
        //the states to be save
        public string Name { get; set; } 
        public int? Id { get; set; }
        public string Action { get; set; }

        public Student(string Name, int Id, string Action)
        {
            this.setStudent(Name, Id, Action);
        }

        public StudentMomento createMomento() 
        {
            return new StudentMomento(Name, Id, Action);
        }

        public void setMomento(StudentMomento studentMomento)
        {
            this.setStudent(studentMomento.Name, studentMomento.Id, studentMomento.Action);
        }

        public void setStudent(string Name, int? Id, string Action)
        {
            this.Name = Name;
            this.Id = Id;
            this.Action = Action;
        }

        public void showProps()
        {
            foreach (var prop in this.GetType().GetProperties())
            {
                Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(this,null));
            }
        }
    }

    //Momento, the object use to hold the Student state 
    class StudentMomento
    {
        //the states to be save
        public string Name { get; set; }
        public int? Id { get; set; }
        public string Action { get; set; }

        public StudentMomento(string Name, int? Id, string Action)
        {
            this.Name = Name;
            this.Id = Id;
            this.Action= Action;
        }
    }

    //CareTaker, use to keep one/all the Momento 
    static class CareTaker
    {
        public static StudentMomento studentMomento { get; set; }
    }


}
