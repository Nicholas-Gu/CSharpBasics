using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasics
{
    class Employee
    {
        public string LastName;
        public string FirstName;
        public string CityOfBirth;

        public string this[int index]
        {
            set
            {
                switch (index)
                {
                    case 0: LastName = value; break;
                    case 1: FirstName = value; break;
                    case 2: CityOfBirth = value; break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            get
            {
                switch (index)
                {
                    case 0: return LastName;
                    case 1: return FirstName;
                    case 2: return CityOfBirth;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }
    }


    class SomeClass 
    { 
        public string Field1="A";
        public void Test1() 
        {
            Console.WriteLine("SomeClass: {0}", Field1);
        }
    }
    class OtherClass : SomeClass 
    { 
        public new string Field1="B";
        public void Test2()
        {
            Console.WriteLine("OtherClass: {0}", Field1);
        }

        public void Test2_2()
        {
            Console.WriteLine("OtherClass: {0}", base.Field1);
        }
    }

    class MyBaseClass { public void Print() { Console.WriteLine("This is the base class.");} }
    class MyDerivedClass : MyBaseClass { new public void Print() { Console.WriteLine("This is the derived class."); } }

    class BaseClass { virtual protected void Print() { } }
    class DerivedClass : BaseClass { override protected void Print() { } }
    class Program
    {
        static void Main(string[] args)
        {
            /*
            //int number;//= 10; //不需要赋值,赋了也没用
            //int result = Test(out number);
            //Console.WriteLine("number={0}  result={1}", number, result);
            
            //Test(out number);
            //Console.WriteLine("number={0}  ", number);
            //Test(out number);

            //string s = "123ss";
            //int re;
            //if (int.TryParse(s, out re))
            //{
            //    Console.WriteLine("转换成功,转换后的值是: {0}", re);
            //}else
            //{
            //    Console.WriteLine("转换失败");
            //}

            //const int a = 1; //const是(本地)常量n声明的一部分,而不是修饰符,且只能放在类型的前面
            //int const int = 2;
            //int number = 100;
            //TestRef(ref number);
            //Console.WriteLine(number);

            //Console.ReadKey();
            //Console.Write("AAA");

            ////对象初始化列表
            //Point pt1 = new Point();
            //Point pt2 = new Point() { X=5, Y=6};
            //Console.WriteLine("pt1: {0}, {1}", pt1.X, pt1.Y);
            //Console.WriteLine("pt2: {0}, {1}", pt2.X, pt2.Y);

            ////索引的使用
            //Employee emp1 = new Employee();
            //emp1[0] = "Doe";
            //emp1[1] = "Jane";
            //emp1[2] = "Dallas";
            //Console.WriteLine("{0}, {1}, {2}", emp1.LastName, emp1.FirstName, emp1.CityOfBirth);

            ////隐藏基类的成员
            //SomeClass cls1 = new SomeClass();
            //cls1.Test1();

            //OtherClass oth = new OtherClass();
            // oth.Test2();
            //oth.Test2_2();

            //MyDerivedClass derived = new MyDerivedClass();
            //MyBaseClass mybc = (MyBaseClass)derived;
            //derived.Print();
            //mybc.Print();
           */ 
           

            Console.ReadKey();
        }

        public class Point {
            public int X = 1;
            public int Y = 2;
        }
  
        static void Test(out int a)
        {
            //Console.WriteLine(a); //报错,因为a是作为传出的,必须先赋值再使用
            //方法中必须对a赋值(初始化),因为a是作为返值的.
            a = 20;
           // return a;
        }

        static void TestRef(ref int a)
        {
            int b = a;
            a = 100;

        }

        void TestRef(int a) {}

        static int Age
        {
            get;
            set;
        }

        static readonly int b=1;
        static Program()
        { b = 2; }

        int Name
        {
             get;
            set;
        }
    }

}
