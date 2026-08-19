using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            List<Dictionary<string, dynamic>> bookList = new();
            // 读取文件===>反序列化
            var json = File.ReadAllText(path);
            // 反序列化
            bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
            var existBook1 = bookList.FindIndex(item => item["name"].ToString() == bookDic["name"].ToString());
            int y = 0;
            while (y==0) {
                Console.WriteLine("输入你想修改的内容编号");
                Console.WriteLine("1：图书名称      2：图书作者");
                Console.WriteLine("3：图书标签      4：图书价格");
                Console.WriteLine("0: 退出修改");
                int x =int .Parse(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        Console.WriteLine("================");
                        Console.WriteLine("请修改后的图书名字");
                        string x1 = Console.ReadLine();
                        bookList[existBook1]["name"] = x1;
                        break;
                    case 2:
                        Console.WriteLine("================");
                        Console.WriteLine("请修改后的图书作者");
                        string x2 = Console.ReadLine();
                        bookList[existBook1]["author"] = x2;
                        break;
                    case 3:
                        Console.WriteLine("================");
                        Console.WriteLine("请修改后的图书标签");
                        string x3 = Console.ReadLine();
                        bookList[existBook1]["mark"] = x3;
                        break;
                    case 4:
                        Console.WriteLine("================");
                        Console.WriteLine("请修改后的图书价格");
                        string x4 = Console.ReadLine();
                        bookList[existBook1]["price"] = x4;
                        break;
                    case 0:
                        y = 1;
                        break;
                        default: Console.WriteLine("你输入的格式不对");
                        break;
                } 
            }
            //序列化
            string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
            // 写入文件
            File.WriteAllText(path, jsonStr);
            // 编辑的逻辑处理
            return "修改成功";
            }
            // 删除数据
            public string RemoveBook(string bookName)
            {
            List<Dictionary<string, dynamic>> bookList = new();
            if (File.Exists(path))
            {
                // 读取文件===>反序列化
                var json = File.ReadAllText(path);
                // 反序列化
                bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                if (bookList.Count != 0)
                {
                    var removeBook = bookList.Find(item => item["name"].ToString() == bookName);
                    bookList.Remove(removeBook);
                    //序列化
                    string jsonStr = JsonSerializer.Serialize(bookList, JsonOpts);
                    // 写入文件
                    File.WriteAllText(path, jsonStr);
                    return "删除成功";
                }
                else return "该图书不存在或者已经被删除过了";     
            }
            else return "图书库里面一本书都没有，请你添加图书";


            // 删除的逻辑处理

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

        public string BorrowBook(string bookName, List<Dictionary<string, dynamic>> borrowList1
            ) // 返回值根据情况修改
        {
            var borrowBook2 = borrowList1.Find(item => item["isBorrow"].ToString() == false.ToString() && item["name"].ToString() == bookName);
            if (borrowBook2 != null)
            {
                borrowBook2["isBorrow"]=true;
            }else return "该图书已经被借走了";
            //序列化
            string jsonStr = JsonSerializer.Serialize(borrowList1, JsonOpts);
            // 写入文件
            File.WriteAllText(path, jsonStr);
            return "借阅成功";
        }

        public string huanBook(string bookName, List<Dictionary<string, dynamic>> borrowList1
            ) // 返回值根据情况修改
        {
            var borrowBook2 = borrowList1.Find(item => item["isBorrow"].ToString() == true.ToString() && item["name"].ToString() == bookName);
            if (borrowBook2 != null)
            {
                borrowBook2["isBorrow"] = false;
            }
            else return "该图书未被借走";
            //序列化
            string jsonStr = JsonSerializer.Serialize(borrowList1, JsonOpts);
            // 写入文件
            File.WriteAllText(path, jsonStr);
            return "还书成功";
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


