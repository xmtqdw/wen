
using System.IO;
using System.Text.Json;
using System.Threading.Channels;

namespace ConsoleApp8_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 实例化图书对象
            BookManager.BookManager BM = new BookManager.BookManager("./book.json", new JsonSerializerOptions
            {
                WriteIndented = true, // 美化格式内容
                AllowTrailingCommas = true,
            });


            string num = "";
            while (num != "0")
            {
                // 提示信息
                Console.WriteLine("======欢迎来到图书管理系统======");
                Console.WriteLine("1: 新增图书");
                Console.WriteLine("2: 删除图书");
                Console.WriteLine("3: 编辑图书");
                Console.WriteLine("4: 查询所有图书");
                Console.WriteLine("5: 查询单个图书");
                Console.WriteLine("0: 退出");
                num = Console.ReadLine();

                switch (num)
                {
                    case "1":
                        Console.WriteLine("----新增图书----");
                        Console.WriteLine("请输入书名");
                        string bookName = Console.ReadLine();
                        Console.WriteLine("请输入作者");
                        string author = Console.ReadLine();
                        Console.WriteLine("请输入标签");
                        string mark = Console.ReadLine();
                        Console.WriteLine("请输入价格");
                        double price = double.Parse(Console.ReadLine());
                        // 组装 书籍 字典
                        Dictionary<string, dynamic> bookDic = new()
                        {
                            ["name"] = bookName,
                            ["author"] = author,
                            ["isBorrow"] = false,
                            ["id"] = new Random().NextDouble(),
                            ["mark"] = mark,
                            ["price"] = price
                        };
                        // 调用实例方法  实现 添加书籍
                        string res = BM.AddBook(bookDic);
                        Console.WriteLine(res);
                        break;
                    case "2":
                        Console.WriteLine("----删除图书----");
                        Console.WriteLine("请输入你要删除的图书名字");
                        string x1 = Console.ReadLine();
                        string res3 = BM.RemoveBook(x1);
                        Console.WriteLine(res3);
                        break;
                    case "3":
                        Console.WriteLine("----编辑图书----");
                        Console.WriteLine("请输入书名");
                        bookName = Console.ReadLine();
                        List<Dictionary<string, dynamic>> bookList = new();
                        if (File.Exists(BM.path))
                        {
                            // 读取文件===>反序列化
                            var json = File.ReadAllText(BM.path);
                            // 反序列化
                            bookList = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(json);
                        }
                        var editBook1 = bookList.Find(item => item["name"].ToString() == bookName);
                        if (editBook1 != null)
                        {
                            string res6 = BM.EditBook(editBook1);
                        }
                        else Console.WriteLine("该图书不存在");
                        break;
                    case "4":
                        Console.WriteLine("----查询所有图书----");
                        string res1 = BM.SearchBook();
                        Console.WriteLine(res1);
                        
                        break;
                    case "5":
                        Console.WriteLine("----查询单个图书----");
                        Console.WriteLine("请输入你要查询的图书");
                        string x = Console.ReadLine();
                        string res2 = BM.SearchBook(x);
                        
                        Console.WriteLine(res2);
                        break;
                    case "0":
                        Console.WriteLine("--**退出**--");
                        break;
                    default:
                        Console.WriteLine("****输入有误****");
                        break;
                }
            
            }
        }
    }
}
