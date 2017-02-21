using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Structural.Flyweight
{
    // Name :       Flyweight   
    // Intention :  Flyweight pattern is primarily used to reduce the number of objects created and to decrease memory footprint and increase performance. 
    //              This type of design pattern comes under structural pattern as this pattern provides ways to decrease object count thus improving the object structure of application
    //URL:https://www.tutorialspoint.com/design_pattern/flyweight_pattern.htm
    //URL: http://www.dofactory.com/net/flyweight-design-pattern

    class Flyweight:DemoClass
    {
        Random r = new Random();
        
        public override void execute()
        {
            for (int i = 0; i < 20; i++)
            {
                Shape Sh = FlyWeightFactory.getCircle(getRandomColor(r.Next(1, 5)));
                Sh.setDetails(r.Next(1, 100), r.Next(1, 100), r.Next(1, 20));
                Sh.draw();
            }
        }

        private string getRandomColor(int randomNumber)
        {
            string randomColor = "";
            switch (randomNumber)
            {
                case 1:
                    randomColor = "black";
                    break;
                case 2:
                    randomColor = "white";
                    break;
                case 3:
                    randomColor = "green";
                    break;
                case 4:
                    randomColor = "blue";
                    break;
                case 5:
                    randomColor = "red";
                    break;
                default:
                    randomColor = "radom";
                    break;
            }
            return randomColor;
        }

    }

    interface Shape
    {
        void draw();
        void setDetails(int posX, int posY, int radius);
    }

    class Circle : Shape
    {

        private string _color;// the share/cache part
        private int _posX;
        private int _posY;
        private int _radius;

        public void draw()
        {
            Console.WriteLine("draw {0} color circle at X: {1} Y: {2} with radius: {3}", _color, _posX, _posY, _radius);
        }

        public Circle(string color)
        {
            //we assume the Creational of the Circle are expensive.
            Console.WriteLine("Create an heavy {0} color circle...", color);
            _color = color;
        }
        public void setDetails(int posX, int posY, int radius)
        {
            _posX = posX;
            _posY = posY;
            _radius = radius;
        }
    }

    class FlyWeightFactory
    {
        //we use this dictionanry as flyweight to hold/share the shape.
        private static Dictionary<string, Shape> FlyWeight_Shape = new Dictionary<string, Shape>();

        public static Shape getCircle(string color)
        {
            Shape _shape;

            if (FlyWeight_Shape.ContainsKey(color))
            {
                _shape = FlyWeight_Shape[color];
            }
            else
            {
                _shape = new Circle(color);
                FlyWeight_Shape.Add(color, _shape);
            }
            return _shape;
        }
    }

}

