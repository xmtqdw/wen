---
typora-copy-images-to: img
---

# day07

## 上节回顾

字符串相关:

 - 空值: 当我们希望将变量的值销毁时候,可以赋值为null

    - int? 变量 = null
    - string str = null
 - 字符类型: 单个字符,使用单引号包裹,char 变量= 'A';
     - 字符型可以和整型转换  
- 字符串属性方法
    - Length  长度
    - string.IsNullOrEmpty()     空值判断
    - string.IsNullOrWhiteSpace()   空值空格判断
    - Substring  字符串截取
    - Trim  去除首尾空格
    - TrimStart   去除首空格
    - TrimEnd     去除尾空格
    - Contains  判断子串是否存在
    - StartsWith  判断开头
    - EndsWith  判断结尾
    - IndexOf   查找子串在字符串中的下标(第一次出现)
    - LastIndexOf   查找子串在字符串中的下标(最后一次出现)
    - Replace  字符串替换
    - ToUpper  转大写 
    - ToLower  转小写
    - Split     将字符串分隔为集合
    - string.Join    将集合的元素按照指定的符号拼接为字符串
    - string.Concat  将多个字符串进行拼接
    - PadLeft    左填充
    - PadRight 右填充

正则表达式: 也叫规则表达式, 用于验证, 提取,替换字符串 中符合规则的内容

- 正则方法
  - Regex.IsMatch()  验证
  - Regex.Match()  提取
  - Regex.Matches()  多次提取
  - Regex.Replace()  替换
- 正则相关的字符
  - `\d`  一位任意数字
  - `\D` 一位任意非数字
  - `\w` 一位任意字母数字_
  - `\W` 一位任意非字母数字_
  - `\s` 一位任意空格
  - `\S` 一位任意非空格
  - `.` 一位任意字符
  - [^abc]  除了中括号中的任意一位
  - [abc]  中括号中的任意一位
    - [0-9]  任意一位数字
  - `*`   0~无数次
  - `+`  1~无数次
  - `?`  0~1
  - `{n}`  n次
  - `{n,m}`  n~m次数
  - `{n,}`   n~无数次
  - `^ `    限定开头
  - `$`  限定结尾
  - `|`   或者 
  - `\`   转义 
  - `()  `    表示一个小整体, 可以单独匹配
  - `[\u4e00-\u9fa5]`

​        



## 一、类型转换 

语法：

```c#
(int)value // 转浮点数的时候等同于向下取整，不能转字符串
(double)value // 只能转整数
int.TryParse(str, out int result); // 字符串安全转int，得到成功与否的布尔值，结果为result
ToString() // 转字符串，可用于格式化数字和日期，不能转null，会报错 ==> Convert.ToString(value) 安全的转字符串
ToArray() // List/集合转数组
ToList() // 数组/序列转List
```

## 二、数据加密

传递的情报是一段看不懂的数字，明文是报纸或其他文章的一段，从文章中根据情报上的数字，找到对应的字，组合在一起形成真正的情报。

通过下标获取到情报内容：

```c#
string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
string salt = "7-16-30-38-49-52-63-70";
string result = ""; // 最终获取到的情报

// 先将salt 转为数组
string[] nums = salt.Split("-");

// 遍历nums获取每个数字(字符串), 作为text的索引 
for (int i = 0; i < nums.Length; i++)
{
    //nums[i] // 转换为整数 才能作为下标使用
    int index = int.Parse(nums[i]);
    result += text[index];
}

Console.WriteLine(result); // 午夜渡口交换情报
```

通过情报内容获取到下标：

```c#
string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
string salt = "午夜渡口交换情报";
List<int> nums = []; // 创建一个list 用于未来的密文索引存储

// 遍历salt 字符串
for (int i = 0; i < salt.Length; i++)
{
    //  根据 salt[i] 去text中查找对应的下标
    int index = text.IndexOf(salt[i]);
    nums.Add(index);// 将获取的下标 添加到 nums list集合中
}
string result = string.Join("-", nums);
// 最终的下标
Console.WriteLine(result); // "7-16-30-38-49-52-63-70"
```

为了更安全，生成密文的时候可以调整下标：（上一个字符）：

```C#
string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
string salt = "午夜渡口交换情报";
List<int> nums = []; // 创建一个list 用于未来的密文索引存储
// 遍历salt 字符串
for (int i = 0; i < salt.Length; i++)
{
    //  根据 salt[i] 去text中查找对应的下标
    int index = text.IndexOf(salt[i]) - 1;
    nums.Add(index);// 将获取的下标 添加到 nums list集合中
}
string result = string.Join("-", nums);
// 最终的下标
Console.WriteLine(result); // "6-15-29-37-48-51-62-69"
```

通过密文获获取情报的时候，需要在原本的下标基础上+1：

```C#
// 解密
string res = ""; // 最终获取到的情报
// 先将result密文 转为数组
string[] nums1 = result.Split("-");
// 遍历nums获取每个数字(字符串), 作为text的索引 
for (int i = 0; i < nums1.Length; i++)
{
    //nums[i] // 转换为整数 才能作为下标使用
    int index = int.Parse(nums1[i]) + 1;
    res += text[index];
}
Console.WriteLine(res); // 午夜渡口交换情报
```

还可以在生成密文的时候，奇数就-1，偶数就+1：

```C#
// 奇偶数处理 生成密文的时候，奇数就-1，偶数就+1：
string text = "清风漫过湖畔，午间薄雾缓缓消散，夜色悄然而至，河水静静流淌，渡船缓缓靠岸，渡口游人往来，相逢知己相交，互换见闻感受，留心世间风情，记录山河晚报。";
string salt = "午夜渡口交换情报";
List<int> nums = []; // 创建一个list 用于未来的密文索引存储
// 遍历salt 字符串
for (int i = 0; i < salt.Length; i++)
{
    //  根据 salt[i] 去text中查找对应的下标
    int index = text.IndexOf(salt[i]);
    // 处理index  奇数就-1，偶数就+1：
    index += index % 2 == 0 ? 1 : -1;
    nums.Add(index);// 将获取的下标 添加到 nums list集合中
}
string result = string.Join("-", nums);
// 最终的下标
Console.WriteLine(result); // "6-17-31-39-48-53-62-71"
```

此时找到情报的时候，也要判断下标是奇数还是偶数，奇数就-1，偶数就+1：

```C#
//找到情报的时候，也要判断下标是奇数还是偶数，奇数就 -1，偶数就 +1：
// 解密
string res = ""; // 最终获取到的情报
// 先将result密文 转为数组
string[] nums1 = result.Split("-");
// 遍历nums获取每个数字(字符串), 作为text的索引 
for (int i = 0; i < nums1.Length; i++)
{
    //nums[i] // 转换为整数 才能作为下标使用
    int index = int.Parse(nums1[i]);
    // 判断下标是奇数还是偶数，奇数就 -1，偶数就 +1：
    index += index % 2 == 0 ? 1 : -1;
    res += text[index];
}
Console.WriteLine(res); // 午夜渡口交换情报
```



## 三、数字转汉字 

```c#
int money = 123456;
string str = money.ToString();
// 0    1    2   3   4  。。。
// 零   壹   贰  叁  肆
// 对应关系：数字当作下标，从下面的集合中用下标获取汉字
// 创建汉字数组
string[] arr = ["零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖"];
// 创建单位数组
string[] units = ["", "拾", "佰", "仟", "萬", "拾", "佰", "仟", "亿"];
string result = "";
for(int i = str.Length - 1; i >= 0; i--)
{
    int idx = int.Parse(str[i].ToString());
    // 找单位的下标
    int index = str.Length - 1 - i;
    // 获取单位
    string unit = units[index];
    if (idx != 0)
    {
        result = arr[idx] + unit + result;
    } else
    {
        if (str.Length - 5 == i)
        {
            result = arr[idx] + units[4] + result;
        } else
        {
            result = arr[idx] + result;
        }
    }
}
// 零万 => 万   零零万=>万 零零零万=>万
result = Regex.Replace(result, @"零+萬", "萬");
// 多个零都换成一个零
result = Regex.Replace(result, @"零+", "零");
// 结尾是零的判断
if (result.EndsWith("零"))
{
    // 将零截取掉
    result = result.Substring(0, result.Length - 1);
}

Console.WriteLine(result);
```

## 四、数字格式化 

| 格式化字符 | 名称         | 描述                                               | 示例                          | 结果        |
| ---------- | ------------ | -------------------------------------------------- | ----------------------------- | ----------- |
| C/c        | 货币格式     | 带货币符号，千分位分割，控制小数点位数（四舍五入） | 1234.5678.ToString("C2")      | ￥1,234.57  |
| D/d        | 十进制格式   | 整数位补全，只能处理整数                           | 123456.ToString("D10")        | 0000123456  |
| E/e        | 科学记数法   | 科学记数法，符号后面的数字表示保留小数点后的位数   | 1234.5678.ToString("E2")      | 1.23E+003   |
| F/f        | 定点格式     | 保留小数点位数，会四舍五入                         | 1234.5678.ToString("f3")      | 1234.568    |
| N/n        | 数字格式     | 千分位分割，保留小数点位数                         | 1234.5678.ToString("N3")      | 1,234.568   |
| P/p        | 百分比格式   | 百分比表示，保留小数点位数                         | 1234.5678.ToString("P1")      | 123,456.8%  |
| X/x        | 十六进制格式 | 仅能转整数                                         | 15.ToString("X")              | F           |
| 0          | 零占位符     | 补全位数，转百分比                                 | 12.34.ToString("000000.000%") | 001234.000% |
| `,`        | 千分位       | 整数千分位分割                                     | 1234.5678.ToString("#,#")     | 1,235       |
| `%`        | 百分比占位符 | 将数字乘以100并显示%                               | 1234.5678.ToString("0.0%")    | 123456.8%   |

例：

```c#
//数字格式化
//货币格式
//double d1 = 1234.5678;
//Console.WriteLine(d1.ToString("C2")); // "￥1,234.57"
// 十进制格式 (只有整数才可以十进制格式化) 整数位补全
//int d2 = 1234;
//Console.WriteLine(d2.ToString("d6")); // "001234"
//科学记数法  小数部分(四舍五入)
//double d3 = 1234.5678;
//Console.WriteLine(d3.ToString("e3"));  // "1.235e+003"
// 定点格式, 保留小数位
//double d4 = 1234.5678;
////Console.WriteLine(d4.ToString("f3")); // "1234.568" 
//Console.WriteLine(d4.ToString("f6")); // "1234.567800" 
// 数字格式
//double d5 = 1234.5678;
////Console.WriteLine(d5.ToString("n3")); // "1,234.568" 
//Console.WriteLine(d5.ToString("n6"));  // "1,234.567800"
// 百分比格式
//double d6 = 1234.5678;
//Console.WriteLine(d6.ToString("p1")); // "123,456.8%" 
//Console.WriteLine(d6.ToString("p6"));  // "123,456.780000%"
// 十六进制格式            
//int d7 = 11;
//Console.WriteLine(d7.ToString("x")); // "b" 
// 零占位符
//double d8 = 1234.5678;
//Console.WriteLine(d8.ToString("0000.0000%")); // "123456.7800%" 
//Console.WriteLine(d8.ToString("00000000.0000%"));  // "00123456.7800%"
//Console.WriteLine(d8.ToString("00000000.000000"));  // "00001234.567800"
// 千分位  整数千分位分割
int d9 = 12345678;
Console.WriteLine(d9.ToString("#,#")); // "12,345,678" 
```



## 五、时间对象 

获取当前时间：

```c#
var date = DateTime.Now; // 获取当前时间
Console.WriteLine(date); // 
 var year = date.Year;
 var month = date.Month;
 var day = date.Day;
 var dayOfWeek = date.DayOfWeek;
 var hour = date.Hour;
 var minute = date.Minute;
 var second = date.Second;
 var milliSecond = date.Millisecond;
 Console.WriteLine($"年={year},月={month},日={day},周={dayOfWeek},时={hour},分={minute},秒={second},毫秒={milliSecond}"); 
```

获取指定日期时间：

```c#
DateTime d = new DateTime(2026, 08, 29, 15, 02, 45);
Console.WriteLine(d); // 
DateTime d1 = DateTime.Parse("2026-08-29 15:02:45");
Console.WriteLine(d1); // 
```

时间戳：从`1970-1-1 8:0:0`  到 某一个时间点的经过的毫秒数

```c#
// 当前时间戳: 
var s = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
Console.WriteLine(s); // 
// 指定时间的时间戳
DateTimeOffset d = DateTimeOffset.Parse("2026-08-29 15:02:45");
var s1 = d.ToUnixTimeMilliseconds();
Console.WriteLine(s1); // 
// 将时间戳转为日期时间字符串
DateTimeOffset d = DateTimeOffset.Parse("2026-08-29 15:02:45");
var s1 = d.ToUnixTimeMilliseconds();
DateTime d2 = DateTimeOffset.FromUnixTimeMilliseconds(s1).DateTime;
Console.WriteLine(d2); // 
// 转换后的时间是格林威治时间，跟当前本地时间相差8小时，若需要展示，就要补上8个小时
DateTime d3 = d2.AddHours(8); // 除了可以增加小时，也可以增加天数、分钟等
Console.WriteLine(d3); 
```

日期时间运算：

```c#
// 日期运算
DateTime d1 = DateTime.Now;
DateTime d2 = d1.AddDays(1); // 当前时间的一天后
// 时间差
TimeSpan d3 = d2 - d1;
Console.WriteLine(d3); // 1.00:00:00 
// 总天数
var diffDays = d3.TotalDays;
Console.WriteLine(diffDays); // 1
// 总小时数
var diffHours = d3.TotalHours;
Console.WriteLine(diffHours); // 24
```

## 六、日期格式化

| 字符 | 说明                        | 示例                    | 结果                          |
| ---- | --------------------------- | ----------------------- | ----------------------------- |
|      |                             | DateTime.Now.ToString() | 2026/7/26 16:56:38            |
| d    | 短日期                      | .ToString("d")          | 2026/7/26                     |
| D    | 长日期                      | .ToString("D")          | 2026年7月26日                 |
| t    | 短时间                      | .ToString("t")          | 16:58                         |
| T    | 长时间                      | .ToString("T")          | 16:58:31                      |
| f    | 完整日期时间（短时间）      | .ToString("f")          | 2026年7月26日 16:59           |
| F    | 完整日期时间（长时间）      | .ToString("F")          | 2026年7月26日 16:59:46        |
| g    | 常规日期时间（短时间）      | .ToString("g")          | 2026/7/26 17:00               |
| G    | 常规日期时间（长时间）      | .ToString("G")          | 2026/7/26 17:00:46            |
| M/m  | 月日格式                    | .ToString("M")          | 7月26日                       |
| Y/y  | 年月格式                    | .ToString("Y")          | 2026年7月                     |
| U    | 通过完整格式（UTC格林威治） | .ToString("U")          | 2026年7月26日 9:04:13         |
| R/r  | RFC1123模式                 | .ToString("R")          | Sun, 26 Jul 2026 17:05:00 GMT |

扩展：RFC 1123 是互联网标准定义的**时间字符串格式**，HTTP 协议头部（`Date`、`Expires`、`Last-Modified`）默认使用这个格式。 它基于 RFC822 修订，规定：

- 时区固定为 GMT（UTC+0）
- 英文星期缩写 + 日期 + 月份英文缩写 + 4 位年份 + 24 小时制时间 + `GMT`

标准格式：

```tex
ddd, dd MMM yyyy HH:mm:ss 'GMT'
```



代码：

```c#
 // 日期格式化
 var date = DateTime.Now;
 //Console.WriteLine(date.ToString()); //2026-08-11 15:58:27
 //// 短日期
 //Console.WriteLine(date.ToString("d")); //2026-08-11            
 //// 长日期
 //Console.WriteLine(date.ToString("D")); //2026年8月11日, 星期二
 //// 短时间
 //Console.WriteLine(date.ToString("t")); //16:00            
 //// 长时间
 //Console.WriteLine(date.ToString("T")); //16:00:04
 //// 完整日期时间（短时间）
 //Console.WriteLine(date.ToString("f")); //2026年8月11日, 星期二 16:01            
 //// 完整日期时间（长时间）
 //Console.WriteLine(date.ToString("F")); //2026年8月11日, 星期二 16:01:25
 //// 常规日期时间（短时间）
 //Console.WriteLine(date.ToString("g")); //2026-08-11 16:02            
 //// 常规日期时间（长时间）
 //Console.WriteLine(date.ToString("G")); //2026-08-11 16:02:09
 //// 月日格式
 //Console.WriteLine(date.ToString("M")); //8月11日            
 //// 年月格式
 //Console.WriteLine(date.ToString("Y")); //2026年8月
 // 通用完整格式（UTC格林威治）
 //Console.WriteLine(date.ToString("U")); //2026年8月11日, 星期二 8:04:35
 // RFC1123模式
 Console.WriteLine(date.ToString("R"));  //Tue, 11 Aug 2026 16:05:25 GMT
```



## 七、JSON序列化

序列化：

```c#
using System.Text.Json; // 使用的库

// 要序列化的List数据
List<Dictionary<string, dynamic>> singerList = new List<Dictionary<string, dynamic>>
{
    new Dictionary<string, dynamic>
    {
        {"singerId", 1001},
        {"singerName", "周杰伦"},
        {"genre", "流行"}
    },
    new Dictionary<string, dynamic>
    {
        {"singerId", 1002},
        {"singerName", "林俊杰"},
        {"genre", "华语流行"}
    },
    new Dictionary<string, dynamic>
    {
        {"singerId", 1003},
        {"singerName", "邓紫棋"},
        {"genre", "流行、摇滚"}
    }
};

// 配置序列化
var options = new JsonSerializerOptions
{    
    WriteIndented= true,// JSON序列化时候美化
    AllowTrailingCommas = true, // JSON反序列化时候允许 最后出现逗号
};

string json = JsonSerializer.Serialize(singerList, options);
Console.WriteLine(json);

```

反序列化：

```c#
// 反序列化
var result1 = JsonSerializer.Deserialize<List<Dictionary<string, dynamic>>>(result);
foreach(var item in result1)
{
    Console.WriteLine(item["singerName"]);
}
```

反序列化的应用：

```c#
// 将unicode编码汉字转成中文汉字
string source = "\\u6C11\\u8C23\\u6D41\\u884C";
// 将需要反序列化的数据前面加双引号和大括号
string json = $"\"{ source}\"";
string result = JsonSerializer.Deserialize<string>(json);
Console.WriteLine(result); // 民谣流行
```

## 八、多维数组

数组中嵌套数组，就组成了二维数组。如果在内部的数组中再次嵌套数组，就成了三维数组。这种数组统称为多维数组。在使用场景中，二维数组使用的多些。

如一个表格，有固定的行数和列数，每行的列数都相同。再比如我们要开发一个棋盘、或者扫雷的地图，就需要使用二维数组。

定义语法：

 二维数组：`类型[,]`
 三维数组：`类型[,,]`

访问语法：`数组[行,列]`

例：表格数据

```c#
// 二维数组
// 表格数据 ==> 3行2列
int[,] tables = new int[3, 2]
{
    {1,10 },
    {2,20 },
    {3,30 },
};

// 访问
//Console.WriteLine(tables[0,1]); // 10
// 获取行列的数量
int rowCount = tables.GetLength(0); // 3
int colCount = tables.GetLength(1); // 2
//Console.WriteLine(rowCount);
//Console.WriteLine(colCount);

// 遍历二维数组
for (int i = 0; i < rowCount; i++)
{
    for (int j = 0; j < colCount; j++)
    {
        Console.Write(tables[i, j] + "\t");
    }
    Console.WriteLine();
}

/*
    1       10
    2       20
    3       30
 */
```

例：五子棋棋盘

```c#
int[,] chessBoard = new int[15, 15];
// 0 空位 1 黑子 2 白子
chessBoard[7, 7] = 1;
```

多维数组使用注意事项：

1. 每行长度强制相等，结构整齐
2. 整体是单个数组对象，一块连续内存
3. 不能单独获取 “某一行” 当成独立一维数组直接使用
4. 长度一旦初始化固定，不能扩容（和普通一维数组一样）

还有一些需求，需要多维数组，但需要每一行的列数不尽相同，这种多维数组叫**交错数组**。

定义语法：`[][]`

访问语法：`arr[i][j]` 两个独立下标

类似于一个收纳盒，里面放若干独立纸条。每条纸条长度可以不一样！

再比如：一班 5 个人、二班 3 个人、三班 7 个人。分组长度不一样，无法塞进规整矩形。

例：

```c#
int[][] classes = new int[3][];

// 添加班级分数
classes[0] = [60, 70, 80, 90, 100];
classes[1] = [80, 90, 100];
classes[2] = [60, 70, 80, 90, 100, 50, 99];

// Console.WriteLine(classes[1][2]);// 100
// Console.WriteLine(classes.Length); // 3
for (int i = 0; i < classes.Length; i++)
{
    foreach (int score in classes[i])
    {
        Console.Write(score + " ");
    }
    Console.WriteLine();                
}
/*
    60 70 80 90 100
    80 90 100
    60 70 80 90 100 50 99             
 */
```

例：聊天软件用户消息记录。每个用户聊天消息条数不一样： 用户 A：20 条消息 用户 B：6 条消息 用户 C：42 条消息。

```c#
// 3表示 3个用户
int[][] userChatMsg = new int[3][];

// 用户的消息
userChatMsg[0] = new int[20];
userChatMsg[1] = new int[6];
userChatMsg[2] = new int[42];
```

交错数组使用注意事项：

1. 外层是一维数组，**每个元素是独立一维数组**
2. 各个子数组长度可以互不相同（参差不齐）
3. 可以单独替换某一行子数组
4. 内存不连续，是多个分开的数组

