using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasics
{
    class MyBaseClass
    { 
        virtual public void Print()
        {
            Console.WriteLine("This is the base class.");
        }
        public MyBaseClass()
        {
            Console.WriteLine("MyBaseClass default Constructor!");
        }
    }
    class MyDerivedClass:MyBaseClass
    {
        public override void Print()
        {
            Console.WriteLine("This is the derived class.");
        }
        public MyDerivedClass()
        {
            Console.WriteLine("MyDerivedClass default Constructor!");
        }
    }
    class SecondDerived:MyDerivedClass
    {
        public override void Print()
        { 
            Console.WriteLine("This is the second_derived class.");
        }
        public SecondDerived()
        {
            Console.WriteLine("SecondDerived default Constructor!");
        }
    }

    class Program2
    {
        int a;
        static void Main()
        {
            //SecondDerived secondDerived = new SecondDerived();
            //MyBaseClass myBase = (MyBaseClass)secondDerived;
            //secondDerived.Print();
            //myBase.Print();
            MyDerivedClass derive = new MyDerivedClass();
            derive.Print();
            Console.WriteLine("****************华丽的分割线*********************");

            SecondDerived second = new SecondDerived();
            second.Print();
            Console.WriteLine("****************华丽的分割线*********************");

            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            catch { 
            
            }

            Console.ReadKey();
        }

        class B  //嵌套类
        {
            void Test()
            {
                int b = new Program2().a;
            }
        }
    }
}
