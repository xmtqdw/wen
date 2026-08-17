using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


    namespace BookManager
    {
        internal class BookManager
        {
            // 属性：
            // 数据文件路径
            public string path { get; }
            // JSON序列化配置项
            public JsonSerializerOptions JsonOpts { get; }

            // 新增数据：强制要求 ==> 将list写入文件中
            public string AddBook(Dictionary<string, dynamic> bookDic)
            {

            // 判断图书是否已存在===>根据图书名判断(一个书名只有一本)
            
            // 新增的逻辑处理
            // 判断path路径是存在===> 不存在, 组装书籍list,序列化后 写入文件
            // 如果存在 =====> 先读取文件内容
            // 反序列化为list ====> 添加bookDic到list中
            // 序列化list ====> 写入文件
            List<Dictionary<string, dynamic>> bookList = new();
                if (File.Exists(path))
                {
                    // 读取文件===>反序列化
                    var json = File.ReadAllText(path);
                    // 反序列化
                    bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                   
               
                }
            var existBook = bookList.Find(item => item["name"].ToString() == bookDic["name"]);
            if (existBook != null)
            {
                Console.WriteLine("书库中已经有了这个书");
                return "请重新输入";
            }
            
            bookList.Add(bookDic);
                //序列化
                string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
                // 写入文件
                File.WriteAllText(path, jsonStr);

                return "新增数据成功!!!";
            }
            // 编辑数据
            public string EditBook(Dictionary<string, dynamic> bookDic)
            {
                // 编辑的逻辑处理
                return "ok";
            }
            // 删除数据
            public string RemoveBook(string bookName)
            {
                // 删除的逻辑处理
                return "ok";
            }
            // 查询所有数据
            public string SearchBook() // 返回值根据情况修改
            {
            List<Dictionary<string, dynamic>> bookList = new();
            if (File.Exists(path))
            {
                // 读取文件===>反序列化
                var json = File.ReadAllText(path);
                // 反序列化
                bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                foreach (var item in bookList)
                {
                    Console.WriteLine($"书名：{item["name"]}作者：{item["author"]}标签：{item["mark"]}价格：{item["price"]}");
                }
            }else Console.WriteLine("现在书库里面没有图书");
            return "";
            }
            // 根据图书名称查询当前图书数据：强制要求
            public string SearchBook(string bookName) // 返回值根据情况修改
            {
            List<Dictionary<string, dynamic>> bookList = new();
            if (File.Exists(path))
            {
                // 读取文件===>反序列化
                var json = File.ReadAllText(path);
                // 反序列化
                bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                var existBook = bookList.FindIndex(item => item["name"].ToString() == bookName);
                if (existBook != -1)
                {
                    var targetBook = bookList[existBook];
                    string name = targetBook["name"].GetString();
                    string author = targetBook["author"].GetString();
                    string mark = targetBook["mark"].GetString();
                    double price = targetBook["price"].GetDouble();

                    Console.WriteLine("==================== 查询到图书 ====================");
                    Console.WriteLine($"书名：{name}");
                    Console.WriteLine($"作者：{author}");
                    Console.WriteLine($"标签：{mark}");
                    Console.WriteLine($"价格：{price} 元");
                    Console.WriteLine("====================================================");
                    //foreach (var kv in targetBook)
                    //{
                    //  Console.WriteLine($"{kv.Key}：{kv.Value}");

                    //}
                }
                else Console.WriteLine("现在书库里面没有该图书");
            }
            
            return "";
            }

            // 自定义实例构造函数
            public BookManager(string bookPath, JsonSerializerOptions Opts)
            {
                // 实例化初始化属性
                path = bookPath;
                JsonOpts = Opts;
            }
        }
    }


