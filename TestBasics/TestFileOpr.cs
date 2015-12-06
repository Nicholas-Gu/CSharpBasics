using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBasics
{
    class TestFileOpr
    {
        static void Main(string[] args)
        {
            //文件读写
            //string file = @"C:\\Datas\test.dat";
            
            //string[] data = new string[2];
            //data[0] = "第一条信息";
            //data[1] = "第二条信息";
            //try
            //{
            //    System.IO.File.WriteAllLines(file, data);
            //}
            //catch (Exception e)
            //{
                
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine(e.GetType());
            //}

            //if (System.IO.File.Exists(file))
            //{
            //    string[] data = new string[2];
            //    data = System.IO.File.ReadAllLines(file);
            //    Console.WriteLine(data[0]);
            //    Console.WriteLine(data[1]);
            //}

           // //数组
           // int[] a = new int[2];
           ////矩形数组
           // int[, ,] intArray = new int[4, 3, 2] { 
           //                                         {{8,6},{5,2},{12,9}},
           //                                         {{6,4},{13,9},{18,4}},
           //                                         {{7,2},{1,13},{9,3}},
           //                                         {{4,6},{3,2},{23,8}}
           //                                      };
           // Console.WriteLine(intArray.Rank);
           // Console.WriteLine(intArray.Length);
           // Console.WriteLine(intArray.GetLength(0));
           // int[] arr1 = { 10, 20, 30 };
           // var sArr2 = new[] { "life","a" };           

           // //交错数组:每个数组必须独立创建
           // int[][] Arr = new int[3][]; //声明语句中只可初始化最高级别数组
           // Arr[0] = new int[] { 10, 20, 30 };
           // Arr[1] = new int[] { 40, 50, 60, 70 };
           // Arr[2] = new int[] { 80, 90, 100, 110, 120 };

            //数组遍历
            //var arr = new int[,] { { 0, 1, 2 }, { 10, 11, 12 } };
            //for (int i = 0; i < 2; i++)
            //{ 
            //    for(int j=0; j<3; j++)
            //    {
            //        Console.WriteLine("Element [{0},{1}] is {2}", i, j, arr[i, j]);
            //    }
            //}

            //foreach (var item in arr1)
            //{
            //    //item++;  //迭代变量是只读的,不能对它赋值
            //}

            //数组Clone,只是浅复制
            int[] intArr1 = { 1, 2, 3 };
            int[] intArr2 = (int[])intArr1.Clone();
            foreach(var item in intArr2)
            {
                Console.WriteLine(item);
            }
            intArr2[0] = 100; intArr2[1] = 200; intArr2[2] = 300;
            foreach (var item in intArr2)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}
