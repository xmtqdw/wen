using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;

namespace dome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, dynamic> dic = new()
            //{
            //    ["name"] = "张三",
            //    ["age"] = 12
            //};
            //var dicKyes = dic.Keys;
            ////Console.WriteLine(dicKyes);
            ////string[] keyArr = dicKyes.ToArray(); // 将键集合转为数组
            ////foreach (string key in keyArr) Console.WriteLine(key);
            //List<string> keylist = dicKyes.ToList(); // 将键集合转为list集合
            //foreach (string key in keylist) Console.WriteLine(key);


            //编程题 1（类型转换 + 控制台输入输出）
            // 编写程序：
            //控制台提示 “请输入一个整数”，接收用户输入；
            //将输入的字符串使用int.Parse()转换成 int；
            //计算该数字的 5 倍；
            //使用占位输出打印结果；
            //再使用字符串插值打印同一个结果。

            //Console.WriteLine("请输入一个整数");
            //int x = int.Parse(Console.ReadLine());
            //int y = x * 5;
            //Console.WriteLine(y);
            //Console.WriteLine("{0}",y);
            //Console.WriteLine($"{y}");

            //编程题 2（字典基础操作）
            // 创建字典 Dictionary<string, dynamic> phone，存储手机信息：
            //初始化数据：品牌："小米"，价格：2499，颜色："黑色"；
            //修改价格为 2199；
            //新增键memory，值为 "12+256G"；
            //foreach 遍历字典，输出每一组键和值；
            //删除颜色这个键；
            //最后输出字典里面键值对总数量(Count)
            //Dictionary<string,dynamic> phone = new()
            //{
            //    ["name"]="小米",
            //    ["price"] =2499,
            //    ["color"]="黑色", 
            //};
            //phone["price"] = 2199;
            //phone["memory"]="12+256G";
            //phone.Remove("color");
            //foreach (var i in phone) { Console.WriteLine(i); }
            //Console.WriteLine(phone.Count);

            //编程题 3（List 基础）
            //创建List<string> 列表，初始化加入 3 个水果："芒果"、"葡萄"、"菠萝"；
            //使用 Add 新增 "草莓"；
            //在下标 1 的位置插入 "榴莲"（Insert）；
            //删除数据 "菠萝"（Remove）；
            //foreach 循环输出列表全部元素；
            //输出列表当前元素总个数。

            //List<string> res = new()
            //{
            //    "芒果","葡萄","菠萝"
            //};
            //res.Add("草莓");
            //res.Insert(1, "榴莲");
            //res.Remove("菠萝");
            //foreach (string item in res) { Console.WriteLine(item); }
            //Console.WriteLine(res.Count);


            //创建 List<Dictionary<string, dynamic>> foodList；
            //初始化 2 条食物字典：
            //第一条：name = "热干面"，price = 12
            //第二条：name = "豆皮"，price = 8
            //使用.Add()，再新增第 3 条字典：name = "面窝"，price = 3
            //foreach 遍历整个 foodList，每一条输出：食物：xxx，价格：xx元
            //打印列表总数量.Count。

            //List<Dictionary<string, dynamic>> foodList = new()
            //{
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["name"] = "热干面",
            //        ["price"] = 12
            //    },
            //    new Dictionary<string, dynamic>()
            //    {
            //        ["name"] = "豆皮",
            //        ["price"] = 8
            //    }
            //};
            //foodList.Add(new Dictionary<string, dynamic>() { ["name"] = "面窝", ["price"] = 3 });
            //foreach (var item in foodList)
            //{
            //    Console.WriteLine($"{item["name"]}--{item["price"]}");
            //}
            //Console.WriteLine(foodList.Count);

            //编程题 B（练习 Find 查询）
            //基于上面 foodList：
            //使用Find()查找第一个价格大于 10 的食物；
            //判断：如果不为 null，输出食物名字；如果找不到，输出 “没有找到贵的食物”。

            //var i = foodList.Find(item => item["price"] > 10);
            //if (i != null) Console.WriteLine($"{i["name"]}"); else Console.WriteLine("没有找到贵的食物");

            //编程题 C（练习 FindAll）
            //继续使用上面的foodList：
            //使用FindAll()查询所有价格小于 10的食物，得到新列表；
            //foreach 遍历这个新列表，打印每一个食物 name。

            //var x = foodList.FindAll(item => item["price"] < 10);
            //foreach (var item in x)
            //{
            //    Console.WriteLine(item["name"]);
            //}

            //编程题 D（综合，修改字典里面的值）
            //创建 List<Dictionary< string,dynamic >> userList，两个用户
            //用户 1：username = "张三"，age = 16
            //用户 2：username = "李四"，age = 23
            //通过Find找到李四这条字典；
            //把李四的 age 修改成 24；
            //foreach 全部输出，看年龄是否修改成功。
            //List<Dictionary<string, dynamic>> userlist = new()
            //{
            //     new Dictionary<string,dynamic>()
            //    {
            //        ["username"] = "张三",
            //        ["age"] = 16
            //    },
            //      new Dictionary<string,dynamic>()
            //    {
            //        ["username"] = "李四",
            //        ["age"] = 23
            //    },
            //       new Dictionary<string,dynamic>()
            //    {
            //        ["username"] = "王五",
            //        ["age"] = 30
            //    }
            //};
            //var x = userlist.Find(item => item["username"] == "李四");
            //if ( x != null)
            //{
            //    x["age"] = 24;
            //}
            //foreach (var item in userlist)
            //{
            //    Console.WriteLine($"{item["username"]}--{item["age"]}");
            //}



            //编程题 E（结合输入转换）
            //创建空集合 List<Dictionary< string,dynamic >> stuList = new();
            //控制台让用户输入学生姓名；
            //控制台让用户输入学生年龄（字符串转 int）；
            //把姓名、年龄封装成字典，Add 加入 stuList；
            //循环遍历 stuList 输出全部学生信息。

            //List<Dictionary<string, dynamic>> stuList = new();
            //Console.WriteLine("请输入学生姓名和年龄");
            //string x=Console.ReadLine();
            //int y = int .Parse(Console.ReadLine());
            //Dictionary<string, dynamic> dict = new()
            //{
            //    ["x"] = "null",
            //    ["y"] = 1,
            //};
            //dict["x"]=x; dict["y"]=y;
            //stuList.Add(dict);
            //foreach (var item in stuList)
            //{
            //    Console.WriteLine($"{item["x"]}--{item["y"]}");
            //}


            //编程题 4（List 里面存放字典，Find 查询）
            //定义 List<Dictionary< string, dynamic >> workerList，存储工人信息：
            //初始化 2 个工人：
            //第一个：name = "老张"，age = 32，salary = 6000
            //第二个：name = "小李"，age = 24，salary = 4500
            //使用 Add 方法，新增第三个工人 name = "小王"，age = 28，salary = 7200；
            //使用Find()方法，查找第一个工资大于 7000 的工人；
            //判断：如果找到，输出工人姓名；找不到输出没有符合条件的工人。

            //List<Dictionary<string, dynamic>> workerList = new()
            //{
            //    new Dictionary<string, dynamic> {
            //    ["name"] = "老张",
            //    ["age"] = 32,
            //    ["salary"] = 6000
            //    },
            //    new Dictionary<string, dynamic> {
            //    ["name"] = "小李",
            //    ["age"] = 24,
            //    ["salary"] = 4500
            //    }
            //};
            //workerList.Add(new Dictionary<string, dynamic>
            //{
            //    ["name"] = "小王",
            //    ["age"] = 28,
            //    ["salary"] = 7200
            //});
            //var i =workerList.Find(item => item["salary"] > 7000);
            //if (i != null) Console.WriteLine(i["name"]); else Console.WriteLine("没有符合条件的工人");

            //var x = workerList.Where(item =>item["salary"] > 7000);
            //foreach (var item in x)
            //{
            //    Console.WriteLine(item["name"]);
            //}


            //编程题 5（字符串 + 字典统计字符）
            //控制台提示用户输入任意一段文字；
            //读取输入字符串；
            //使用Dictionary<string, int> 统计每个字符出现多少次；
            //遍历字典输出每个字符以及对应的出现次数。
            //提示：循环字符串，char 转 string 作为 key；ContainsKey 判断键是否存在，存在次数 + 1，不存在赋值为 1。

            string x = Console.ReadLine();
            Dictionary<string,int> map = new Dictionary<string,int>();
            int n = 1;
            foreach (var item in x)
            {
                
                if (map.TryGetValue(item.ToString(),out int v))
                {
                    map[item.ToString()]++;
                }
                else 
                {
                    map.Add(item.ToString(), 1);
                }
            }
            foreach (var item in map)
            {
                Console.WriteLine(item.Key+item.Value);
            }


            }
    }
}
