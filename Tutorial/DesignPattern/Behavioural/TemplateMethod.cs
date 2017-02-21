using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Behavioural.TemplateMethod
{
    // Name :       TemplateMethod
    // Intention :  Define the skeleton of an algorithm in an operation, deferring some steps to client subclasses. Template Method lets subclasses redefine certain steps of an algorithm without changing the algorithm's structure.
    //              Base class declares algorithm 'placeholders', and derived classes implement the placeholders.

    // URL :        https://www.tutorialspoint.com/design_pattern/template_pattern.htm

    //layman terms: abstract have a major operation that run (and wrap) the minor operation which the minor operation is setup at subclass.

    class TemplateMethod:DemoClass
    {
        public override void execute()
        {
            Game game = new Hockey();

            game.play();

            game = new Soccer();

            game.play();
        }
    }

    //abstract class
    abstract class Game
    {
        public abstract void setupGame();
        public abstract void playGame();
        public abstract void endGame();

        //*** the Templete method
        public void play()
        {
            setupGame();
            playGame();
            endGame();
            Console.WriteLine("\n");
        }
    }

    //concrete class1
    class Hockey:Game
    {
        public override void setupGame()
        {
            Console.WriteLine("setup Hockey");
        }

        public override void playGame()
        {
            Console.WriteLine("play Hockey");
        }

        public override void endGame()
        {
            Console.WriteLine("end Hockey");
        }
    }

    //concrete class2
    class Soccer : Game
    {
        public override void setupGame()
        {
            Console.WriteLine("setup Soccer");
        }

        public override void playGame()
        {
            Console.WriteLine("play Soccer");
        }

        public override void endGame()
        {
            Console.WriteLine("end Soccer");
        }
    }
   
}
