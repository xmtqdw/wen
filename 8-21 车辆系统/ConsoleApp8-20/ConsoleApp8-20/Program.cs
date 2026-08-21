using System.Reflection;
using System.Text.RegularExpressions;

namespace ConsoleApp8_20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string num = "";
            Carclass BM = new Carclass();
            Uersclass CM = new Uersclass();
            Rentcar RM = new Rentcar();
            while (num !="0") 
            {
                // 提示界面
                Console.WriteLine("==欢迎来到神车系统==");
                Console.WriteLine("请选择操作编号：");
                Console.WriteLine("0：退出系统");
                Console.WriteLine("1：新增车辆");
                Console.WriteLine("2：查看所有车辆信息");
                Console.WriteLine("3：查看某辆车");
                Console.WriteLine("4：查看所有空闲车辆");
                Console.WriteLine("5：新增客户");
                Console.WriteLine("6：查看所有客户");
                Console.WriteLine("7：查看某个客户");
                Console.WriteLine("8：租车");
                Console.WriteLine("9：还车");
                Console.WriteLine("10：还车记录");

                num = Console.ReadLine();
                



                switch (num)
                {

                    case "0":
                        Console.WriteLine("退出");
                        break;
                    case "1":
                        Console.WriteLine("请输入车牌号：");
                        string Card = Console.ReadLine();
                        Console.WriteLine("请输入车类型：  （轿车、卡车、摩托车）");
                        string Type = Console.ReadLine();
                        if (!Regex.IsMatch(Type, @"^\D{1,4}$"))
                        {
                            Console.WriteLine("输入时车类型格式错误");
                            Console.WriteLine();
                            return;
                        }
                        Console.WriteLine("请输入时租费：");
                        string Price = Console.ReadLine();
                        if (!Regex.IsMatch(Price, @"^[1-9]\d{1,4}$"))
                        {
                            Console.WriteLine("输入时租费格式错误");
                            Console.WriteLine();
                            return;
                        }
                        string x1 = BM.Caradd(Card, Type, Price);
                        Console.WriteLine(x1);
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine("================车库================");
                        BM.CarSearch();
                        Console.WriteLine("================车库================");
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine("请输入你要查询的车辆id");
                        int Id=int.Parse(Console.ReadLine());
                        Console.WriteLine("================车库================");
                        BM.CarSearchone(Id);
                        Console.WriteLine("================车库================");

                        break;
                    case "4":
                        Console.WriteLine("================空闲的车库================");
                        BM.Carkong();
                        Console.WriteLine("================车库================");
                        Console.WriteLine();
                        break;
                    case "5":
                        CM.Uersadd();
                        break;
                    case "6":
                        CM.UersSearch();
                        break;
                    case "7":
                        Console.WriteLine("请输入你要查询的用户id");
                        int UersId = int.Parse(Console.ReadLine());
                        CM.UersSearchone(UersId);
                        break;
                    case "8":
                        Console.WriteLine("请输入你要租车的车辆id");
                        int x = int .Parse(Console.ReadLine());
                        Console.WriteLine("请输入你要租车的用户id");
                        int y = int.Parse(Console.ReadLine());
                        RM.rentcar(x,y);
                        Console.WriteLine();

                        break;
                    case "9":
                        Console.WriteLine();
                        RM.Returncar();
                        Console.WriteLine( );
                        break;
                    case "10":
                        Console.WriteLine();
                        Console.WriteLine("=======================还车记录=======================");
                        RM.SearchAll();
                        Console.WriteLine();
                        break;
                }
            
            
            
            
            }








        }
    }
}
