using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Car
{
    // 客户管理类
    internal class UserManager
    {
        private string Path { get; } = "./user.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        // 新增客户方法
        public void Add()
        {
            // 提示输入客户信息
            Console.WriteLine("请输入客户姓名：");
            string userName = Console.ReadLine();
            Console.WriteLine("请输入身份证号：");
            string userCardId = Console.ReadLine();
            Console.WriteLine("请输入性别：");
            string gender = Console.ReadLine();
            Console.WriteLine("请输入手机号：");
            string telNum = Console.ReadLine();
            Console.WriteLine("请输入座右铭：");
            string motto = Console.ReadLine();

            // 验证手机号
            if(!Regex.IsMatch(telNum,@"^1\d{10}$")) {
                Console.WriteLine("输入手机格式错误！！！");
                return;
            }

            // 定义一个空的用户列表  List<User>  list
            List<User> list = new();
            // 判断存储数据的文件是否存在
            // 文件存在===>读文件 ---> 反序列化 List<User> 赋值给list ===>判断客户是否存在
            // 根据身份证号码判断是否存在 ---->存在则提示
            if (File.Exists(this.Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                list = JsonSerializer.Deserialize<List<User>>(jsonStr);
                if (list.Exists(item => item.IdCard == userCardId))
                {
                    Console.WriteLine("客户已存在，请勿重复添加！");
                    return;
                }
            }
            // 创建新增的客户对象===>添加到list中后 序列化 写入文件
            int id = list.Count == 0 ? 1 : list[list.Count - 1].Id + 1;
            string regTime = DateTime.Now.ToString();
            // 实例化客户对象
            User userObj = new User(id, userName, userCardId, regTime, gender, telNum, motto);
            list.Add(userObj);
            string resStr = JsonSerializer.Serialize(list, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
            Console.WriteLine("---------");
            Console.WriteLine("新增客户成功！！！");
            Console.WriteLine("---------");

        }
        // 查看所有客户方法
        public void SearchAll()
        {
            //  判断存储数据的文件是否存在
            // 文件不存在---提示
            if(!File.Exists(this.Path))
            {
                Console.WriteLine("暂无客户信息，请先添加");
                return;
            }
            // 文件存在===>读文件 ---> 反序列化 List<User>
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            Console.WriteLine("======================所有客户信息======================");
            // 遍历输出
            list.ForEach(item => Console.WriteLine($"ID: {item.Id} -- 姓名: {item.Name} -- 身份证: {item.IdCard} -- 性别: {item.Gender} -- 手机号: {item.PhoneNo} -- 座右铭: {item.Motto} "));
            Console.WriteLine("======================所有客户信息======================");
        }
        // 查看某个客户方法
        public void SearchOne()
        {
            Console.WriteLine("请输入客户ID：");
            int userId = int.Parse(Console.ReadLine());
            // 判断存储数据的文件是否存在
            // 文件不存在---提示
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("暂无客户信息，请先添加");
                return;
            }
            // 文件存在===>读文件 ---> 反序列化 List<User>  list
            // 文件存在===>读文件 ---> 反序列化 List<User>
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            // 根据ID查找客户对象===》找不到 ----->提示
            User userObj = list.Find(item => item.Id == userId);
            if(userObj == null)
            {
                Console.WriteLine("暂无该客户信息，请先添加");
                return;
            }
            // 找到了展示
            Console.WriteLine("=================================所有客户信息=================================");
            // 遍历输出
            Console.WriteLine($"ID: {userObj.Id} -- 姓名: {userObj.Name} -- 身份证: {userObj.IdCard} -- 性别: {userObj.Gender} -- 手机号: {userObj.PhoneNo} -- 座右铭: {userObj.Motto} ");
            Console.WriteLine("=================================所有客户信息=================================");

        }

        // 根据id查找用户是否存在
        public bool SearchOneById(int id)
        {
            // 判断存储数据的文件是否存在
            // 文件不存在---提示
            if (!File.Exists(this.Path)) return false;

            // 文件存在===>读文件 ---> 反序列化 List<User>  list            
            string jsonStr = File.ReadAllText(this.Path);
            List<User> list = JsonSerializer.Deserialize<List<User>>(jsonStr);
            // 根据ID查找客户对象===》找不到 ----->提示
            User userObj = list.Find(item => item.Id == id);
            if (userObj == null) return false;           
            return true;
        }


    }
}
