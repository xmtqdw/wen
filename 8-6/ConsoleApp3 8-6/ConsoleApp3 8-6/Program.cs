using System.Threading.Channels;

namespace ConsoleApp3_8_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Math.Abs(100);
            //  var n=Math.PI;
            //  Math.Sin(n);
            //  Math.Cos(n);
            //  Math.Floor(n);
            //  Math.Max(1, 3);
            //  Math.Min(1, 3);
            //var m =  Math.Round(n);

            //  Console.WriteLine(m);
            //int i=1; int num = 0;
            //while (i <= 10)
            //{
            //    num =num + i;
            //   Console.WriteLine($"i为{i},num为{num}");     
            //    i++;

            //}
            // Console.WriteLine($"i为{i},num为{num}");


            //int i = 0;
            //do {
            //    Console.WriteLine(i);
            //    i++;
            //}while (i<=5);

            //for (int i = 0; i <= 5; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //int x= int.Parse(Console.ReadLine());
            //for (int i = 0;i < 10; i +=x)
            //{

            //    if(i%2==0)Console.WriteLine(i);
            //}
            //  Console.WriteLine("输入x的值");
            // int x = int.Parse( Console.ReadLine());
            //for (int i = 1; i <= x; i++)
            //  {
            //      for (int j = 1; j <= i; j++)
            //      {
            //          //if (j == 3) continue;

            //          Console.Write("*");

            //      }
            //      Console.WriteLine();
            //  }

            //作业1
            //Console.WriteLine("请输入0到多少的范围");
            //int x = int.Parse(Console.ReadLine());
            //int sum = 0;
            //for (int i=0;i <= x; i++)
            //{
            //    if(i %2==0)sum += i;
            //}
            //Console.WriteLine($"0到{x}的偶数和是{sum}");

            //作业2

            //int i = 0;
            //     for (int p = 1000; p < 2000; p++)
            //     {
            //         if (p % 4 == 0 && p % 100 != 0)
            //         {
            //             Console.Write($"{p}\t");
            //             i++;    
            //         }
            //         if (i%4==0)
            //         {
            //            Console.WriteLine();
            //         }
            //     }

            //作业3
            //Console.WriteLine("请输入倒三角形的高度");
            //int x= int.Parse(Console.ReadLine());
            //for (int i = 0; i < x; i++)
            //{
            //    for (int j = x; j> i; j--)
            //    {
            //        Console.Write("*");
            //    }
            //    Console.WriteLine();
            //}

            //作业4
            //double sum = 0;
            //for (double i = 1; i <= 100; i++)
            //{
            //    if (i % 2 == 0)
            //    {
            //        sum = sum - (1 / i);//i是double类型才行，int会显示1
            //        {
            //            sum = sum + (1 / i);
            //        }
            //    }
            //    Console.WriteLine(sum);
            //}


            //作业5
            //int sum = 1;
            //int x = 0;
            //    for  (int j =1; j <= 10; j++)
            //    {
            //        sum = sum * j;
            //        x=sum + x;
            //    }           
            //Console.WriteLine(x);

            //作业6
            /*篮球从5米高的地方掉下来，每次弹起的高度是原来的30 %，经过几次弹起，篮球的高度小于0.1米。*/
            //double x = 5;int i = 0;
            //do
            //{
            //    x = x * 0.3;
            //    i += 1;
            //}while (x>0.1);
            //Console.WriteLine(i);

            //作业7
            /*有一个棋盘，有64个方格，在第一个方格里面放1粒芝麻重量是0.00001kg，第二个里面放2粒，第三个里面放4，棋盘上放的所有芝麻的重量*/

            //double t = 0; 
            //for (int i = 1; i <=64; i++)
            //{          
            //        t = t + 0.0001*Math.Pow(2, i - 1);           
            //}

            //Console.WriteLine($"{t}");

            //作业8
            /*某人在银行有50000元存款。银行每月都要收取服务费，存款大于5000元时每个月收取总额的5%，总额不大于5000元的时候不收服务费；假设这个人存了以后从来都不用，用循环计算银行要扣这个人的手续费能扣多少次？每次扣取后剩余多少钱？*/

            //int x= 0; double y= 50000;
            //     for(double i = 50000; i > 5000; i = i - i * 0.05)
            //     {
            //     Console.WriteLine(i * 0.05);
            //     x++;
            //     }

            //     Console.WriteLine(x);


            //作业9
            /*猴子摘桃，猴子摘了x个桃，每天吃一半，再多吃一个，第7天吃的时候剩下一个了，猴子摘了多少桃子？*/
            // int x = 1;
            //for (int i = 0;i<6;i++)
            // {
            //     x = (x+1)*2;
            // }
            // Console.WriteLine(x);


            //作业10
            /*有个皮球，每次落地弹起都是高度的一半，如果从10米高的地方丢下，第十次弹起时，皮球总过经历了多少距离。*/
            //double x = 10, s = 0;
            //for (int i = 0; i < 9; i++)
            //{
            //    x = x / 2;
            //    s += x *2;
            //}
            //s = s +10 +x/2;
            //Console.WriteLine($"{s}");
        }
    }
}
