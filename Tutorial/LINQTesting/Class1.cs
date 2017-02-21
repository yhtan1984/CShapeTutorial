using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQTesting
{
    public class Class1
    {
        public Class1()
        {
            List<A> As = new List<A> { 
                new A{
                    ID = 1,
                    Bs = new List<B> { 
                        new B{ID=101, isEnable= false},
                        new B{ID=102, isEnable= false}
                    }
                },
                new A{
                    ID=2,
                    Bs=new List<B>{
                        new B{ID=103, isEnable= true},
                        new B{ID=104, isEnable= false} 
                    }
                },
                new A{
                    ID=3,
                    Bs=new List<B>{
                        new B{ID=105, isEnable=false},
                        new B{ID=106, isEnable=false}
                    }
                }
            };

            var result = As.Where(x=> x.Bs.Any(y => y.isEnable ==true) );
          
        }


        class A
        {
            public int ID { get; set; }
            public List<B> Bs { get; set; }
        }

        class B
        {
            public int ID { get; set; }
            public bool isEnable { get; set; }
        }
    }

    

}
