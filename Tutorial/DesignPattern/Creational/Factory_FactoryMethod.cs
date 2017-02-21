using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.Creational.Factory_FactoryMethod
{
    //Name      : Factory Method
    //Intention : Define an interface for creating an object, but let subclasses decide which class to instantiate. 
    //            Factory Method lets a class defer instantiation to subclasses.
    //URL       : http://www.dofactory.com/net/factory-method-design-pattern

    class Factory_FactoryMethod : DemoClass
    {
        public override void execute()
        {
            Document[] docs = new Document[2];    // Here, we define 2 "generic document".
            docs[0] = new Resume();
            docs[1] = new Report();  // Here, we defer to the sub class for instantiate.

            foreach (var doc in docs)
            {
                foreach (Page page in doc.Pages)
                {
                    Console.WriteLine(doc.GetType().Name + ">" + page.GetType().Name);
                }
            }
        }
    }


  /// The 'Creator' abstract class
  abstract class Document
  {
    private List<Page> _pages = new List<Page>();

    // Constructor calls abstract Factory method
    public Document()
    {
        this.CreatePages();
    }

    public List<Page> Pages
    {
        get { return _pages; }
    }

    // Factory Method
    public abstract void CreatePages();
  }

  /// A 'ConcreteCreator' class
  class Resume : Document
  {
    // Factory Method implementation
    public override void CreatePages()
    {
      Pages.Add(new SkillsPage());
      Pages.Add(new EducationPage());
      Pages.Add(new ExperiencePage());
    }
  }

  class Report : Document
  {
    // Factory Method implementation
    public override void CreatePages()
    {
      Pages.Add(new IntroductionPage());
      Pages.Add(new ResultsPage());
      Pages.Add(new ConclusionPage());
      Pages.Add(new SummaryPage());
      Pages.Add(new BibliographyPage());
    }
  }

  //abstract product
  abstract class Page { }

  //concrete product
  class SkillsPage : Page { }
  class EducationPage : Page { }
  class ExperiencePage : Page { }
  class IntroductionPage : Page { }
  class ResultsPage : Page { }
  class ConclusionPage : Page { }
  class SummaryPage : Page { }
  class BibliographyPage : Page { }

    }
