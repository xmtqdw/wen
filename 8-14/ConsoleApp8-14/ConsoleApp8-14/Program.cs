using System.Threading.Channels;

namespace ConsoleApp8_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 书写函数 实现写入日志操作, 日志内容: 输入内容+日期
            // 日志文件路径:  ./content.log
            //File.AppendAllText(@"./content.text",'w'+DateTime.Now.ToString()+"\n");
            //File.AppendAllText(@"./content.log","第一次"+DateTime.Now.ToString()+"\n");
            //File.Copy(@"./content.log", @"./dome1.text"); 
            //var r1 = @"D:\domeC#\ConsoleApp8-14\ConsoleApp8-14\bin\Debug\net8.0\dome\content1.text";
            //File.Move(@"D:\domeC#\ConsoleApp8-14\ConsoleApp8-14\bin\Debug\net8.0\content.text", r1);

            // 定义一个函数, 一个参数(接收路径), 返回值0 表示啥也不是,1是文件,2是文件夹
            //Func<string, int> res = path =>
            //{
            //    if (File.Exists(path)) return 1;
            //    if (Directory.Exists(path)) return 2;
            //    return 0;
            //};
            //string[] r = { "撒也不是", "是文件", "是文件夹" };   
            //string x =Console.ReadLine();
            //res(x);
            //Console.WriteLine(r[res(x)]);


            // 封装一个函数 一个参数(接收路径), 返回值 List<string>
            //Func<string, List<string>> res1 = path =>
            //{
            //    List<string> newlist = [];
            //    if (res(path) != 2)
            //    {

            //    }
            //};

            //作业:  使用读写文件配合命令行窗口  模拟实现注册功能
            //要求输入用户名和密码,完成注册; (注册的用户信息记录在user.txt文件中, 一行一个用户信息 数据之间通过 === 分隔)作业


            var res = (string x, string y) =>
            {
                File.AppendAllText("./user.txt", $"用户名:{x}  密码:{y}   {DateTime.Now}\n");
                File.AppendAllText("./user.txt", "===============================================\n");
            };
            Console.WriteLine("请输入你用户名和密码");
            string x =Console.ReadLine();
            string y = Console.ReadLine();
            res(x,y);



        }
    }
}
