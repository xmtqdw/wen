using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ConsoleApp8_20.Project;

namespace ConsoleApp8_20
{
    internal class Uersclass
    {
        public string path { get; } = "./uer.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        public void Uersadd() 
        {
            Console.WriteLine("请输入姓名");
            string UerName = Console.ReadLine();
            if (!Regex.IsMatch(UerName, @"^[\u4e00-\u9fa5]{2,4}$"))
            {
                Console.WriteLine("输入名字格式错误");
                return;
            }
            Console.WriteLine("请输入身份证号");
            string UerCard = Console.ReadLine();
            if (!Regex.IsMatch(UerCard, @"^45\d{16}X|[0-9]$"))
            {
                Console.WriteLine("输入身份证格式错误");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("请输入性别");
            string Gender = Console.ReadLine();
            if (!Regex.IsMatch(Gender, @"^男|女$"))
            {
                Console.WriteLine("输入性别格式错误");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("请输入手机号");
            string UerPhone = Console.ReadLine();
            if (!Regex.IsMatch(UerPhone, @"^1\d{10}$"))
            {
                Console.WriteLine("输入手机格式错误");
                Console.WriteLine();
                return;
            }
            Console.WriteLine("请输入座右铭");
            string Motto = Console.ReadLine();
            if (!Regex.IsMatch(Motto, @"^*{100}$"))
            {
                Console.WriteLine("输入座右铭长度超出");
                Console.WriteLine();
                return;
            }



            List<Uers> list = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(this.path);
                list = JsonSerializer.Deserialize<List<Uers>>(s1);
                if (list.Exists(item => item.UerName == UerName))
                {
                    Console.WriteLine("用户已经存在，请勿重复添加");
                    return;
                }
            }
            Uers Uersadd = new Uers(list.Count + 1, UerName, UerCard, DateTime.Now.ToString(), UerPhone, Gender, Motto);
            list.Add(Uersadd);
            string s2 = JsonSerializer.Serialize(list, this.JsonOpt);
            File.WriteAllText(this.path, s2);
            Console.WriteLine("---------");
            Console.WriteLine("新增客户成功！！！");
            Console.WriteLine("---------");
            return;
        }
        public void UersSearch()
        {
            List<Uers> list2 = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(this.path);
                list2 = JsonSerializer.Deserialize<List<Uers>>(s1);

            }
            else
            {
                Console.WriteLine("没有该用户，请先添加");//没有文件
                return;
            }
            if (list2.Count == 0)
            {
                Console.WriteLine("没有该用户，请先添加");//有文件但是文件内容为空
                return;
            }
            Console.WriteLine("======================所有客户信息======================");
             // 遍历输出
            list2.ForEach(item => Console.WriteLine($"ID: {item.UerId} -- 姓名: {item.UerName} -- 身份证: {item.UerCard} -- 性别: {item.Gender} -- 手机号: {item.UerPhone} -- 座右铭: {item.Motto} "));
            Console.WriteLine("======================所有客户信息======================");
            
        }
        public void UersSearchone(int x)
        {
            List<Uers> list3 = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(path);
                list3 = JsonSerializer.Deserialize<List<Uers>>(s1);
            }
            else
            {
                Console.WriteLine("没有该用户，请先添加");//没有文件
                return;
            }
            if (list3.Count == 0)
            {
                Console.WriteLine("没有该用户，请先添加");//有文件但是文件内容为空
                return;
            }

            Uers list4 = list3.Find(item => item.UerId == x);
            if (list4 != null)
            {
             Console.WriteLine("=================================所有客户信息=================================");
             // 遍历输出
             Console.WriteLine($"ID: {list4.UerId} -- 姓名: {list4.UerName} -- 身份证: {list4.UerCard} -- 性别: {list4.Gender} -- 手机号: {list4.UerPhone} -- 座右铭: {list4.Motto} ");
                Console.WriteLine("=================================所有客户信息=================================");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("没有该用户信息");
                Console.WriteLine();
                return;
            }
        }

    }
}
