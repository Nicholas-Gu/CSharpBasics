using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace TestBasics
{
    public static class MyExtensions
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }   

    class TestXML
    {
        static void Main()
        {
            /*//Linq
            int[] scores = new int[] { 97, 92, 81, 60 };
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;
            foreach (int i in scoreQuery)
            {
                Console.Write(i + " ");
            }
            */

            //TestXML t = new TestXML();
            //t.CreatePO("po.xml");

            //XmlDocument doc = new XmlDocument();   
            //XmlElement Root = doc.CreateElement("Root");//主内容
            //doc.AppendChild(Root);

            //XmlElement Child1 = doc.CreateElement("attr1");
            //XmlAttribute attr1 = doc.CreateAttribute("attr1");
            //attr1.Value = "arrt1Content";

            //Child1.Attributes.Append(attr1);
            //Root.AppendChild(Child1);

            ////这一行和上面顺序不能反//arr1就你的字段，如字段中有引号就要用\' ,最好不要用xml 的text段存内容
            ////如果你有170 你的循环要对 应该有两个循环 一个在attr1 这 用于添加150个字段 一个在child1 用于添加几行

            //// doc.InnerXml  这个属性就是你的xml 内容
            //string fileName = @"c:/Datas/1.xml";
            //List<string> a = new List<string> { "1","2","3"};
            //using (FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            //{
            //    //得到被序列化的类型
            //    Type type = doc.GetType();
            //    XmlSerializer sz = new XmlSerializer(type);
            //    //开始序列化
            //    sz.Serialize(stream, a);
            //}

           /* //可空数据类型
            int? num = null; //相当于Nullable<Int32> num
            if (num.HasValue)
            { 
                Console.WriteLine("num=" + num.Value);
            }else
            {
                System.Console.WriteLine("num = Null");
            }

            int y = num.GetValueOrDefault();
            try
            {
                y = num.Value;
            }catch(InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            */

            /*//这就是向String类中添加了一个静态函数叫WordCount
            string s = "Hello Extension Methods";
            Console.WriteLine(s.WordCount());
             */

            //迭代器调用
            foreach (int number in SomeNumbers())
            {
                Console.Write(number.ToString() + " ");
            }

            Console.WriteLine("\n带泛型的迭代器:");
            foreach(int number in EventSequeue(5,18))
            {
                Console.Write(number.ToString() + " ");
            }

            Console.WriteLine("\n调用自定义迭代器:");
            DaysOfTheWeek days = new DaysOfTheWeek();
            foreach(string day in days)
            {
                Console.Write(day + " ");
            }

            //go to 迭代器 －－ Create a  Zoo class that contains a collection of animals.
        https://msdn.microsoft.com/zh-cn/library/dscyy5s0(v=vs.120).aspx
            Console.ReadKey();
        }

        public static System.Collections.IEnumerable SomeNumbers()
        {
            yield return 3;
            yield return 5;
            yield return 8;
        }

        public static System.Collections.Generic.IEnumerable<int> EventSequeue
            (int firstNumber, int lastNumber)
        {
            for (int number = firstNumber; number <= lastNumber; number++)
            { 
                if(number %2 == 0)
                {
                    yield return number;
                }
            }
        }

        private void CreatePO(string filename)
        {
            // Create an instance of the XmlSerializer class;
            // specify the type of object to serialize.
            XmlSerializer serializer =
            new XmlSerializer(typeof(PurchaseOrder));
            TextWriter writer = new StreamWriter(filename);
            PurchaseOrder po = new PurchaseOrder();

            // Create an address to ship and bill to.
            Address billAddress = new Address();
            billAddress.Name = "Teresa Atkinson";
            billAddress.Line1 = "1 Main St.";
            billAddress.City = "AnyTown";
            billAddress.State = "WA";
            billAddress.Zip = "00000";
            // Set ShipTo and BillTo to the same addressee.
            po.ShipTo = billAddress;
            po.OrderDate = System.DateTime.Now.ToLongDateString();

            // Create an OrderedItem object.
            OrderedItem i1 = new OrderedItem();
            i1.ItemName = "Widget S";
            i1.Description = "Small widget";
            i1.UnitPrice = (decimal)5.23;
            i1.Quantity = 3;
            i1.Calculate();

            // Insert the item into the array.
            OrderedItem[] items = { i1 };
            po.OrderedItems = items;
            // Calculate the total cost.
            decimal subTotal = new decimal();
            foreach (OrderedItem oi in items)
            {
                subTotal += oi.LineTotal;
            }
            po.SubTotal = subTotal;
            po.ShipCost = (decimal)12.51;
            po.TotalCost = po.SubTotal + po.ShipCost;
            // Serialize the purchase order, and close the TextWriter.
            serializer.Serialize(writer, po);
            writer.Close();
        }
    }

    [XmlRootAttribute("PurchaseOrder", Namespace = "http://www.cpandl.com",IsNullable = false)]
    public class PurchaseOrder
    {
        public Address ShipTo;
        public string OrderDate;
        /* The XmlArrayAttribute changes the XML element name
         from the default of "OrderedItems" to "Items". */
        [XmlArrayAttribute("Items")]
        public OrderedItem[] OrderedItems;
        public decimal SubTotal;
        public decimal ShipCost;
        public decimal TotalCost;
    }

    public class Address
    {
        /* The XmlAttribute instructs the XmlSerializer to serialize the Name
           field as an XML attribute instead of an XML element (the default
           behavior). */
        [XmlAttribute]
        public string Name;
        public string Line1;

        /* Setting the IsNullable property to false instructs the 
           XmlSerializer that the XML attribute will not appear if 
           the City field is set to a null reference. */
        [XmlElementAttribute(IsNullable = false)]
        public string City;
        public string State;
        public string Zip;
    }

    public class OrderedItem
    {
        public string ItemName;
        public string Description;
        public decimal UnitPrice;
        public int Quantity;
        public decimal LineTotal;

        /* Calculate is a custom method that calculates the price per item,
           and stores the value in a field. */
        public void Calculate()
        {
            LineTotal = UnitPrice * Quantity;
        }
    }

    //the DaysOfTheWeek class implements the IEnumerable interface, which requires a GetEnumerator method. The compiler implicitly calls the GetEnumerator method, which returns an IEnumerator.
    public class DaysOfTheWeek :IEnumerable
    {
        private string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"};
        public IEnumerator GetEnumerator()
        { 
            for(int index =0; index<days.Length; index++)
            {
                yield return days[index]; //yield each day od the week
            }
        }
    }
}
