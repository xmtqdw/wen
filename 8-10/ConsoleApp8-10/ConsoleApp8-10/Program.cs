using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace ConsoleApp8_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string n = "这个东西真是大麻烦了，等会我第五代低档次";
            //List<string> str = ["大麻","第五代"];
            //foreach (string s in str)
            //{
            //    string w = "";
            //    for (int i = 0; i < s.Length; i++) w += "*";
            //  n = n.Replace(s, w);
            //}
            //Console.WriteLine(n);

            //string n = "you love i ";
            //string[] n1= n.Split();
            //List<string> list = new ();
            //foreach (string s in n1) list.Add(s);

            //作业1：提取一句话中所有的中文姓名
            //string str = "hello, I am 刘德华,your name is 黎明?";
            //var reg = @"[\u4e00-\u9fa5]{2,3}";
            //var res = Regex.Matches(str, reg);
            //foreach ( var item in res ) Console.WriteLine(item);

            //作业2：替换所有多余空格
            //string str = "abc  dd  ee  ff  gg  HH  h j k";
            //string x = @" ";
            //string y = Regex.Replace("abc  dd  ee  ff  gg  HH  h j k", x,"");
            //Console.WriteLine(y);

            //作业3：身份证号码
            //string str = "我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X";
            //// 书写正则, 找到字符串中的身份证号及 出生年,月,日
            //var n = @"(\d{6})(\d{4})(\d{2})(\d{2})(\d{4})|(\d{6})(\d{4})(\d{2})(\d{2})(\d{3})X";
            ////var res = Regex.Matches(str, n);
            ////foreach (var r in res) Console.WriteLine(r);
            //MatchCollection res = Regex.Matches(str, n);
            //Console.WriteLine("身份证号分别为：");
            //Console.WriteLine(res[0]);
            //Match x1 = res[0];
            //Console.Write("出生年：");
            //Console.WriteLine(x1.Groups[2]);
            //Console.Write("出生月：");
            //Console.WriteLine(x1.Groups[3]);
            //Console.Write("出生日：");
            //Console.WriteLine(x1.Groups[4]);

            //Console.WriteLine(res[1]);
            //Match x2 = res[1];
            //Console.Write("出生年：");
            //Console.WriteLine(x2.Groups[7]);
            //Console.Write("出生月：");
            //Console.WriteLine(x2.Groups[8]);
            //Console.Write("出生日：");
            //Console.WriteLine(x2.Groups[9]);

            //作业4：密码强度检测：强中弱（字母、数字、特殊符号）
            // 请输入密码（字母、数字、特殊符号）

            //密码中可以有数字,字母,特殊符号;长度要求8~15 
            //如果只有一种则 强度为弱
            //如果只有两种则 强度为中
            //如果两种都有则 强度为强

            //验证密码长度是否符合,并输出密码强度

            Console.WriteLine("请输入你的密码：");
            string pawssd = Console.ReadLine();//字符串
            double y = pawssd.Length;
            var reg = @"[\u4e00-\u9fa5]";
            bool t = Regex.IsMatch(pawssd, reg);
            t = !t;
            if (y >= 8 && y <= 15 && t)
            {
                var n = @"\d";//数字
                bool x1 = Regex.IsMatch(pawssd, n);
                var n2 = @"[A-Za-z]";//字母
                bool x2 = Regex.IsMatch(pawssd, n2);
                var n3 = @"\W";//符号
                bool x3 = Regex.IsMatch(pawssd, n3);
                int rex = 0;
                if (x1) rex += 1;
                if (x2) rex += 1;
                if (x3) rex += 1;
                if (rex == 1) Console.WriteLine("你的密码强度为弱");
                if (rex == 2) Console.WriteLine("你的密码强度为中");
                if (rex == 3) Console.WriteLine("你的密码强度为强");
            }
            else Console.WriteLine("密码没有中文，你输入的密码有问题");
        }
    }
}
