using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace ConsoleApp3_8_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int r = int.Parse(Console.ReadLine());
            //int n = int.Parse(Console.ReadLine());
            //bool x = r > 300 || n >9.5 ;
            //bool x = r > 16 && r < 22;
            //Console.WriteLine(x);


            //Console.WriteLine("请输入你的成绩:");
            //int s =int.Parse(Console.ReadLine());
            //if (s < 60)
            //{
            //    Console.WriteLine($"{s}不及格");
            //}else if(s < 80)
            //{
            //    Console.WriteLine($"{s}及格");
            //}else if (s <90)
            //{
            //    Console.WriteLine($"{s}良好");
            //}else if (s <= 100)
            //{
            //    Console.WriteLine($"{s}优秀");
            //}else
            //{
            //    Console.WriteLine("你输入的成绩不对");
            //}


            //Console.WriteLine("请输入年份");
            //int n = int.Parse(Console.ReadLine());
            //if (n % 4 == 0 && n % 100 > 0 && n % 400 > 0)
            //{
            //    Console.WriteLine("普通闰年");
            //}
            //else if (n % 4 == 0 && n % 100 > 0 && n % 400 == 0)
            //{
            //    Console.WriteLine("世纪闰年");
            //}
            //else
            //{
            //    Console.WriteLine("不是闰年");
            //}

            //Console.WriteLine("请输入1~7的数字");
            //int day = int.Parse(Console.ReadLine());
            //switch (day)
            //{
            //    case 1:
            //        Console.WriteLine("星期一");
            //        break;
            //    case 2:
            //        Console.WriteLine("星期二");
            //        break;
            //    case 3:
            //        Console.WriteLine("星期三");
            //        break;
            //    case 4:
            //        Console.WriteLine("星期四");
            //        break;
            //    case 5:
            //        Console.WriteLine("星期五");
            //        break;
            //    case 6:
            //        Console.WriteLine("星期六");
            //        break;
            //    case 7:
            //        Console.WriteLine("星期天");
            //        break;
            //    default:
            //        Console.WriteLine("输入的数字有问题");
            //        break;
            //}

            //Console.WriteLine("请输入0~100分数");
            //int score = int.Parse(Console.ReadLine());
            //if (score > 0 && score <= 100)
            //{
            //    int s = score / 10;
            //    switch (s) {
            //        case 0: Console.WriteLine($"{score}成绩为F");break;
            //        case 1: Console.WriteLine($"{score}成绩为F");break;
            //        case 2: Console.WriteLine($"{score}成绩为F");break;
            //        case 3: Console.WriteLine($"{score}成绩为F");break;
            //        case 4: Console.WriteLine($"{score}成绩为F");break;
            //        case 5: Console.WriteLine($"{score}成绩为F");break;
            //        case 6: Console.WriteLine($"{score}成绩为D");break;
            //        case 7: Console.WriteLine($"{score}成绩为C");break;
            //        case 8: Console.WriteLine($"{score}成绩为B");break;
            //        case 9: Console.WriteLine($"{score}成绩为A");break;
            //        case 10: Console.WriteLine($"{score}成绩为A");break;
            //    }

            //} else {
            //    Console.WriteLine("你输入的成绩有问题，请重新输入");
            //}


            // 输出星期几  6-7输出周末  穿透写法
            //Console.WriteLine("请输入1~7的数字");
            //int day = int.Parse(Console.ReadLine());
            //switch (day)
            //{
            //    case 1: Console.WriteLine("星期一"); break;
            //    case 2: Console.WriteLine("星期二"); break;
            //    case 3: Console.WriteLine("星期三"); break;
            //    case 4: Console.WriteLine("星期四"); break;
            //    case 5: Console.WriteLine("星期五"); break;
            //    case 6:
            //    case 7: Console.WriteLine("周末"); break;
            //    default: Console.WriteLine("输入的数字有问题"); break;
            //}

            //成绩等级输出 switch 简写
            //Console.WriteLine("请输入0~100分数");
            //int score = int.Parse(Console.ReadLine());
            //if (score > 0 && score <= 100)
            //{
            //    string res = score switch
            //    {
            //        >= 90 => "A",
            //        >=80 => "B",
            //        >=70 => "C",
            //        >=60 => "D",
            //        <=59 => "E",
            //    };
            //    Console.WriteLine($"你的成绩为{res}");
            //}
            //else
            //{
            //    Console.WriteLine("你输入的成绩有问题，请重新输入");
            //}

            //三元表达式: 判断 成年了/ 未成年
            //Console.WriteLine("请输入年龄");
            //int age = int.Parse( Console.ReadLine());
            //string res =age > 18 ? "成年了" : "未成年";
            //Console.WriteLine(res);

            //三元表达式: 判断 闰年(能被4整除但不能被100整除,能被400整除) 平年
            //Console.WriteLine("请输入年份");
            //int year = int.Parse(Console.ReadLine());
            //if (year % 4 == 0 && year % 100 > 0)
            //{
            //    string res = year % 400 == 0 ? "世纪闰年" : "普通闰年";
            //    Console.WriteLine(res);
            //}
            //else
            //{
            //    Console.WriteLine("平年");
            //}

            /*账号密码验证（练习分支嵌套）：账号规定是"admin"，密码规定是"123456"。让用户输入账号和密码，判断账号和密码是否正确，账号和密码都正确就输出登入成功；账号不对，就输出账号不存在；密码不对，就输出密码错误。*/
            //Console.WriteLine("请分别输入账号密码");
            //string admin =  Console.ReadLine();
            //int password = int.Parse(Console.ReadLine());
            //if (admin == "admin")
            //{
            //    if (password == 123456)
            //    {
            //        Console.WriteLine("登陆成功");
            //    }
            //    else
            //    {
            //        Console.WriteLine("密码错误");

            //    }
            //}
            //else if (password != 123456)
            //{
            //    Console.WriteLine("密码错误");
            //    Console.WriteLine("账号错误");
            //}
            //else
            //{
            //    Console.WriteLine("密码错误");
            //}

            /*选择菜单（add/edit/del）执行操作（练习多分支和switch）：提示用户选择菜单（add/edit/del），判断输入的是add，就输出新增成功；输入的是edit，就输出编辑成功；输入的是del，就输出删除成功。*/
            //Console.WriteLine("请输入你选择的菜单（add/edit/del）");
            //string cont =Console.ReadLine();
            //if (cont == "add")
            //{
            //    Console.WriteLine("添加成功");
            //}else if (cont =="edit")
            //{
            //    Console.WriteLine("编辑成功");
            //}else if(cont == "del")
            //{
            //    Console.WriteLine("删除成功");
            //}

            //switch (cont)
            //{
            //    case "add": Console.WriteLine("添加成功"); break;
            //    case "edit": Console.WriteLine("编辑成功"); break;
            //    case "del": Console.WriteLine("删除成功"); break;
            //    default: Console.WriteLine("输入的操作有误");break;
            //}


            /*会员打折满1000打9折，普通用户满2000打9.5折（练习多分支和分支嵌套）：让用户输入自己的类型（VIP/USER）和消费金额，如果是VIP，判断消费金额是否达到1000，如果达到了，就输出他应该支付的金额，如果没有达到，也输出他应该支付的金额；如果是USER，判断消费金额是否达到2000，如果达到了和没有达到，都输出他应该支付的金额。*/
            //Console.WriteLine("请分别输入消费的金额与用户类型(vip  user)");
            //int money = int.Parse(Console.ReadLine());
            //string user = Console.ReadLine();
            //if (user == "vip")
            //{
            //    if (money >= 1000)
            //    {
            //        Console.WriteLine($"应该支付{money * 0.9}");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"应该支付{money}");
            //    }
            //}
            //else if (user =="user")
            //{
            //    if (money >= 2000)
            //    {
            //        Console.WriteLine($"应该支付{money*0.95}");
            //    }else {
            //        Console.WriteLine($"应该支付{money}");
            //    }
            //}

            /*通过月份判断季节（练习switch的穿透写法）：用户输入月份，判断月份如果是3、4、5月份，就输出这是春季；如果是6、7、8月份，就输出这是夏季；如果是9、10、11月份，就输出这是秋季，如果是12、1、2月份，就输出这是冬季。*/
            //Console.WriteLine("请输入月份:");
            //int month = int.Parse(Console.ReadLine());
            //switch (month)
            //{
            //    case 3: case 4: case 5: Console.WriteLine("春季"); break;
            //    case 6:  case 7:  case 8: Console.WriteLine("夏季"); break;
            //    case 9:   case 10:  case 11: Console.WriteLine("秋季"); break;
            //    case 12:  case 1:case 2: Console.WriteLine("冬季"); break;
            //default: Console.WriteLine("你输入的月份格式不对");break;
            //}

            /*快递运费（练习多分支）：输入快递重量，单位是Kg，如果重量小于1Kg，输出快递费10元；如果重量在1Kg~5Kg之间，就输出快递费20元；如果重量超过5Kg，就输出快递费50元。*/
            //Console.WriteLine("请输入快递的重量");
            //double weight = double.Parse( Console.ReadLine());
            //if (weight <= 1 && weight > 0)
            //{
            //    Console.WriteLine("快递费为10元");
            //}
            //else if (weight > 1 && weight <= 5)
            //{
            //    Console.WriteLine("快递费用为20元");
            //}else if (weight > 5) 
            //{
            //    Console.WriteLine("快递费用为50元");
            //}

            /*会员等级优惠（练习多分支和switch）：输入会员等级，等级是3~5的整数，判断等级如果是5，输出终身免运费；等级是4，输出每月可领优惠券；等级是3，输出购物打9折，否则没有福利。*/
            //Console.WriteLine("请输入你的会员等级");
            //int level  = int .Parse(Console.ReadLine());
            //if (level < 3)
            //{
            //    Console.WriteLine("等级太低了，没有福利");
            //}
            //else if (level == 3)
            //{
            //    Console.WriteLine("购物打9折");
            //}
            //else if (level == 4)
            //{
            //    Console.WriteLine("每月可领优惠券");
            //}
            //else if (level == 5)
            //{
            //    Console.WriteLine("终身免运费");
            //}
            //else
            //{
            //    Console.WriteLine("你输入的等级超过等级上限了");
            //}

            //string n = level switch
            //{
            //    <= 2 => "等级太低了，没有福利",
            //    <= 3 => "购物打9折",
            //    <= 4 => "每月可领优惠券",
            //    <= 5 => "终身免运费",
            //    _ => "你输入的等级超过等级上限了"
            //};
            //Console.WriteLine(n);

            /*自动售货机选商品（练习多分支和switch）：输入商品编号整数，1就输出已购买可乐；2输出已购买雪碧；3输出已购买矿泉水；否则输出无此商品。*/
            //Console.WriteLine("请输入你选择的商品编号(1~3)");
            //int number= int .Parse(Console.ReadLine());
            //if (number == 1)
            //{
            //    Console.WriteLine("已购买可乐");
            //}
            //else if (number == 2)
            //{
            //    Console.WriteLine("已经购买雪碧");
            //}
            //else if (number == 3)
            //{
            //    Console.WriteLine("已经购买矿泉水");
            //}else
            //{
            //    Console.WriteLine("你输入的编号没有售卖商品");
            //}
            //switch (number)
            //{
            //    case 1: Console.WriteLine("已购买可乐"); break;
            //    case 2: Console.WriteLine("已经购买雪碧"); break;
            //    case 3: Console.WriteLine("已经购买矿泉水"); break;
            //    default: Console.WriteLine("你输入的编号没有售卖商品"); break;
            //}

            /*速度分级（练习多分支）：输入当前速度，如果在0~30，输出低速通过；30~60输出中速通过；60~100输出高速通过；100~120输出超速通过。*/
            //Console.WriteLine("请输入当前的速度");
            //int speed = int.Parse(Console.ReadLine());
            //if (speed <= 30 && speed > 0)
            //{
            //    Console.WriteLine("低速通过");
            //}
            //else if (speed <= 60 && speed > 30)
            //{
            //    Console.WriteLine("中速通过");
            //}
            //else if (speed <= 100 && speed > 60)
            //{
            //    Console.WriteLine("高速通过");
            //}else if (speed <=120 && speed > 100)
            //{
            //    Console.WriteLine("超速通过");
            //} else if (speed >120)
            //{
            //    Console.WriteLine("速度异常尽快刹车");
            //}
        }

    }
}
