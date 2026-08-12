using System;
using System.Diagnostics.Metrics;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp8_12
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //var cai = (int x) =>
            //{
            //    Random n = new Random();
            //    int y = n.Next(1, 100);
            //    int count = 1;
            //    while (true)
            //    {
            //        if (x == y)
            //        {
            //            break;
            //        }
            //        else if (x > y) Console.WriteLine("大了");
            //        else if (x < y) Console.WriteLine("小了");
            //        Console.WriteLine("请重新输入");
            //        x = int.Parse(Console.ReadLine());
            //        count++;
            //        if (count == 5) break;
            //    }
            //};
            //Console.WriteLine("请输入你的数字");
            //int m = int.Parse(Console.ReadLine());
            //cai(m);

            //装修房间：参数1，圆的半径，计算圆的面积，每平方米收费200元，返回装修总价。计算这个半径的圆装修一半需要多少钱？

            //var area = (int r) =>
            //{
            //    double x;
            //    x = Math.PI  * r*r;
            //    double y = x * 200 / 2;
            //    return y;
            //};
            //Console.WriteLine("请输入圆的半径：");
            //int r =int .Parse(Console.ReadLine());
            //Console.WriteLine($"这个半径的圆装修一半需要{area(r).ToString("f2")}元");

            //计算字符在字符串中出现的次数：参数1字符串，参数2某个字符，函数统计次数，并返回。
            //var ci = (string x, string y) =>
            //{
            //    int count = 0;
            //    List<string> list = new List<string>();

            //    for (int i = 0; i < x.Length; i++)
            //    {
            //        if (x[i] == y[0])
            //        {
            //            count++;
            //        }
            //    }
            //    return count;

            //};
            //Console.WriteLine("请输入你的字符串");
            //string x = Console.ReadLine();
            //Console.WriteLine("请输入你的字符");
            //string y = Console.ReadLine();
            //Console.WriteLine($"一共出现{ci(x,y)}次");

            //计算一个整型数组中，最小值第一次出现的下标。
            //int[] x = [5, 3,4, 5,2,3 ,1,3 ,9, 10, 8 ];

            //int min=0, i=0;

            //    for (int j =1;j <x.Length-1; j++)
            //    {
            //       if (x[i] > x[j])
            //        {
            //            min = j;
            //            i = j;
            //        }
            //    }
            //Console.WriteLine($"{min}");


            //判断一个字符串是否为回文，返回布尔值类型。
            string str = "abcdcba";
            string str1 = "";
            for (int i =  str.Length - 1; i >= 0; i--)
            {
                str1 += str[i];
            }
            int count = 0;
            int x = 0;
            for(int i = 0; i<str.Length-1;i++) 
            {
                if (str1[i] == str[i]) { } else { count++; break; }
            }
                if (count == 0)
                {
                    Console.WriteLine($"{true}");
                }
                else Console.WriteLine($"{false}");
            
        }
    }
}
