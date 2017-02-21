using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational.Factory_AbstractFactory
{
    //Name      : Abstract Factory
    //Intention : Provide an interface for creating families of related or dependent objects without specifying their concrete classes. 

    class Factory_AbstractFactory : DemoClass
    {
        public override void execute()
        {
            client c = new client();
            
            ICountry babarianCountry = new Malaysia();

            c.showCountryInfo(babarianCountry); //Here, we use the abstract "ICountry" without specifying their concrete classes, and on the client level, it use the abstract product.

            babarianCountry = new Singapore();

            c.showCountryInfo(babarianCountry); //hence, we can reuse the client whithout much change.
        }
    }


    //abstract factory (can use interface or abstract product)
    public interface ICountry
    {
        ICountryName getCountry();   //** abstract factory return the abstract product 
        OfficialLanguage getLanguage();
    }

    //concrete factory
    class Malaysia : ICountry
    {
        public ICountryName getCountry()
        {
            return new CountryName_Malaysia();  //** concrete factory return concrete product , but signature is abstract product
        }

        public OfficialLanguage getLanguage()
        {
            return new Melayu();
        }
    }

    //concrete factory
    class Singapore : ICountry
    {
        public ICountryName getCountry()
        {
            return new CountryName_Singapore();
        }

        public OfficialLanguage getLanguage()
        {
            return new English();
        }
    }

    //abstract product A (can use interface or abstract product)
    public interface ICountryName
    {
    }

    //abstract product B
    public abstract class OfficialLanguage
    {
    }

    //concerte product A
    class CountryName_Malaysia : ICountryName
    {
    }

    class CountryName_Singapore : ICountryName
    {
    }

    //concerte product B
    class English : OfficialLanguage
    {
    }

    class Melayu : OfficialLanguage
    {
    }

    public class client
    {
        public void showCountryInfo(ICountry c)
        {
            ICountryName CName = c.getCountry();
            OfficialLanguage Clanguage = c.getLanguage();
            Console.WriteLine(CName.GetType().Name + ":" + Clanguage.GetType().Name);
        }
    }
}