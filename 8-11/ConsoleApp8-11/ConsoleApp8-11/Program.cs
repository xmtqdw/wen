using System.Text.Json;

namespace ConsoleApp8_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "7-16-30-38-49-52-63-70";
            //string result = ""; // 最终获取到的情报

            // 先将salt 转为数组
            //string[] nums = salt.Split("-");

            //// 遍历nums获取每个数字(字符串), 作为text的索引 
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    //nums[i] // 转换为整数 才能作为下标使用
            //    int index = int.Parse(nums[i]);
            //    result += text[index];
            //}

            //Console.WriteLine(result); // 午夜渡口交换情报


            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "午夜渡口交换情报";
            //    List<int> nums = []; // 创建一个list 用于未来的密文索引存储

            //    // 遍历salt 字符串
            //    for (int i = 0; i < salt.Length; i++)
            //    {
            //        //  根据 salt[i] 去text中查找对应的下标
            //        int index = text.IndexOf(salt[i]);
            //        nums.Add(index);// 将获取的下标 添加到 nums list集合中
            //    }
            //    string result = string.Join("-", nums);
            //    // 最终的下标
            //    Console.WriteLine(result); // "7-16-30-38-49-52-63-70"

            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "午夜渡口交换情报";
            //List<int> nums = []; // 创建一个list 用于未来的密文索引存储
            //                     // 遍历salt 字符串
            //for (int i = 0; i < salt.Length; i++)
            //{
            //    //  根据 salt[i] 去text中查找对应的下标
            //    int index = text.IndexOf(salt[i]) - 1;
            //    nums.Add(index);// 将获取的下标 添加到 nums list集合中
            //}
            //string result = string.Join("-", nums);
            //// 最终的下标
            //Console.WriteLine(result); // "6-15-29-37-48-51-62-69"

            //string res = "";
            //string[] m =result.Split("-");
            //for (int i = 0; i < m.Length; i++)
            //{
            //    int y = int.Parse(m[i])+1;
            //    res += text[y];
            //}
            //Console.WriteLine(res);


            // 奇偶数处理 生成密文的时候，奇数就-1，偶数就+1：
            //string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
            //string salt = "午夜渡口交换情报";
            //List<int> nums = []; // 创建一个list 用于未来的密文索引存储
            //                     // 遍历salt 字符串
            //for (int i = 0; i < salt.Length; i++)
            //{
            //    //  根据 salt[i] 去text中查找对应的下标
            //    int index = text.IndexOf(salt[i]);
            //    // 处理index  奇数就-1，偶数就+1：
            //    index += index % 2 == 0 ? 1 : -1;
            //    nums.Add(index);// 将获取的下标 添加到 nums list集合中
            //}
            //string result = string.Join("-", nums);
            //// 最终的下标
            //Console.WriteLine(result); // "6-17-31-39-48-53-62-71"


            //int money = 11000;
            //string str = money.ToString();
            //// 0    1    2   3   4  。。。
            //// 零   壹   贰  叁  肆
            //// 对应关系：数字当作下标，从下面的集合中用下标获取汉字
            //// 创建汉字数组
            //string[] arr = ["零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"];
            //// 创建单位数组
            //string[] units = ["", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "亿"];
            //string result = "";


            //for (int i = str.Length - 1; i >= 0; i--)
            //{
            //    int x = int.Parse(str[i].ToString());
            //    int y = str.Length - 1 - i;
            //    string u = units[y];

            //    if (x != 0)
            //    {
            //        result = arr[x] + u + result;
            //    }
            //    else
            //    {
            //        if (str.Length - 5 == i)
            //        {
            //            result = arr[x] + units[4] + result;
            //        }
            //        else
            //        {
            //            result = arr[x] + result;
            //        }
            //    }
            //}
            //result = Regex.Replace(result, @"零+萬", "萬");
            //result = Regex.Replace(result, @"零+", "零");
            //if (result.EndsWith("零"))
            //{
            //    result = result.Substring(0, result.Length - 1);
            //}
            //Console.WriteLine(result);
            //double x = 1234.4357;
            ////Console.WriteLine(x.ToString("c3"));
            //Console.WriteLine(x.ToString("e3"));



            // 要序列化的List数据
            //List<Dictionary<string, dynamic>> singerList = new ()
            //{
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1001},
            //        {"singerName", "周杰伦"},
            //        {"genre", "流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1002},
            //        {"singerName", "林俊杰"},
            //        {"genre", "华语流行"}
            //    },
            //    new Dictionary<string, dynamic>
            //    {
            //        {"singerId", 1003},
            //        {"singerName", "邓紫棋"},
            //        {"genre", "流行、摇滚"}
            //    }
            //};

            // 配置序列化
            //var options = new JsonSerializerOptions
            //{
            //    WriteIndented = true,// JSON序列化时候美化
            //    AllowTrailingCommas = true, // JSON反序列化时候允许 最后出现逗号
            //};

            //string json = JsonSerializer.Serialize(singerList, options);
            //Console.WriteLine(json);

            // 将unicode编码汉字转成中文汉字
            //string source = "\\u6C11\\u8C23\\u6D41\\u884C";
            //// 将需要反序列化的数据前面加双引号和大括号
            //string json = $"\"{source}\"";
            //string result = JsonSerializer.Deserialize<string>(json);
            //Console.WriteLine(result); // 民谣流行

            int[,] arr = new int[5,5]
            {
                {1,2,3,4,5 }, 
                {1,2,3,4,6},
                {1,2,3,5,6},
                {1,2,4,6,7}, 
                {1,2,5,6, 7}, 
                
            };
            //Console.WriteLine(arr[2,0]);
            // 获取行列的数量
            int rowCount = arr.GetLength(0); // 3
            int colCount = arr.GetLength(1); // 2
            Console.WriteLine(rowCount);
            Console.WriteLine(colCount);



        }

    }
}
