using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace ConsoleApp8_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 作业1
            List<Dictionary<string, dynamic>> list = new() {
            new Dictionary<string, dynamic>(){
                ["name"] = "zs",
                ["age"] = 29,
                ["isMan"] = true,
                ["isSingle"] = true,
                ["salary"] = 4200
            },
            new Dictionary<string, dynamic>(){
                ["name"] = "ls",
                ["age"] = 20,
                ["isMan"] = false,
                ["isSingle"] = true,
                ["salary"] = 3400
            },
            new Dictionary<string, dynamic>(){
                ["name"] = "ww",
                ["age"] = 19,
                ["isMan"] = true,
                ["isSingle"] = false,
                ["salary"] = 6000
            },
            new Dictionary<string, dynamic>(){
                ["name"] = "zl",
                ["age"] = 14,
                ["isMan"] = false,
                ["isSingle"] = true,
                ["salary"] = 2000
            },
            new Dictionary<string, dynamic>(){
                ["name"] = "sq",
                ["age"] = 35,
                ["isMan"] = true,
                ["isSingle"] = false,
                ["salary"] = 7000
            },
            new Dictionary<string, dynamic>(){
                ["name"] = "zb",
                ["age"] = 27,
                ["isMan"] = false,
                ["isSingle"] = true,
                ["salary"] = 2900
            },
            };

            // 作业1
            // Find: 要求查找年龄小于20的

            //var res1 = list.Find( item =>
            //{
            //    return item["age"] < 20;//输出的是Dictionary<string, dynamic>字典
            //});
            //Console.WriteLine(res1["name"]);


            // FindLast: 要求查找年龄大于25的

            //var res2 = list.FindLast(item => 
            //{
            //    return item["age"] > 25;
            //});
            //Console.WriteLine(res2["name"]);

            // FindAll: 找出性别男的

            //var res3 = list.FindAll(item =>
            //{
            //    return item["isMan"] == true;//这个输出的是list列表
            //});
            //foreach (var dic in res3)
            //{
            //    Console.WriteLine($"姓名：{dic["name"]}，年龄：{dic["age"]}，工资：{dic["salary"]}");
            //}

            // FindIndex: 找出薪水大于5000

            //var res4 = list.FindIndex(item =>
            //{
            //    return item["salary"] > 5000;//输出下标int
            //});
            //Console.WriteLine(res4);

            // FindLastIndex: 找出薪水小于3000

            //var res5 = list.FindLastIndex(item =>
            //{
            //    return item["salary"] < 3000;
            //});
            //Console.WriteLine(res5);


            // Exists: 判断是否有薪水大于5000

            //var res6 = list.Exists(item =>
            //{
            //    return item["salary"] > 5000;
            //});
            //Console.WriteLine(res6);



            // ForEach: 输出每个的 名字-年龄-薪水

            //Action<Dictionary<string, dynamic>> fn = n => Console.WriteLine($"名字：{n["name"]}  年龄：{n["age"]}  工资：{n["salary"]}");//类型是字典，因为输入的是字典
            //list.ForEach(fn);
            //list.ForEach(n => Console.WriteLine(list["name"]));
            //list.ForEach(n => Console.WriteLine($"名字：{n["name"]}  年龄：{n["age"]}  工资：{n["salary"]}"));//输出的结果是一个人的字典

            // ConvertAll: 映射得到一个所以薪水的list

            //List<dynamic> newlist = list.ConvertAll(item => 
            //{
            //  return item["salary"];

            //});
            //newlist.ForEach(sal => Console.WriteLine(sal));



            //TrueForAll: 判断是否都成年

            //var res7 = list.TrueForAll(item =>
            //{
            //    return item["age"] > 18;
            //}); 
            //Console.WriteLine(res7);

            // IndexOf

            // LastIndexOf


            //作业2:  封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数

           

            var res8 = (string n) =>
            {
                var dic = new Dictionary<string, int>();
                foreach (var c in n)
                {
                    var key = c.ToString();
                    if (dic.ContainsKey(key)) dic[key]++;
                    else dic[key] = 1;
                }
                return dic;
            };
            Console.WriteLine("请输入你的字符串");
            string x = Console.ReadLine();
            var res = res8(x);
            foreach (var item in res)
            {
                Console.WriteLine($"字符：{item.Key}，出现次数：{item.Value}");
            }
            


        }
    }
}
