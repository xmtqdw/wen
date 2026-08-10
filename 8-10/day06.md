# day06

## 上节回顾

 数组定义方式: 可以固定长度定义, 也可以初始值定义, 简写

```C#
// 数组特点,通过下标访问, 长度不可变(不可以删除新增元素), 元素可以修改
类型[] 变量 = new 类型[长度];
类型[] 变量 = new (){...};
类型[] 变量 = {...};
类型[] 变量 = [...];
// List 加强版数组(通过下标操作), 可以通过下标修改,新增, 可以通过方法删除,新增及其他的查询等操作 
List<类型> 变量 = [...]
```

List去重: 找到List中重复的元素删除,  通过字典的键是唯一, 将List中的元素添加到新List中(重复不添加)

字典方法:

- Add 新增
- Remove 删除
- Clear  清除
- Count 元素个数
- ContainsKey   判断键是否存在
- ContainsValue 判断值是否存在
- Keys  获取键的集合
- Values 获取值的集合
- TryAdd  添加(如果键名存在不会报错)

冒泡排序:  前后两两数据比较大小, 交换位置

```c#
for(var i = 0;i<list.Count-1;i++){
    for(var j =0;j<list.Count-1-i;j++){
        if(list[j] > list[j+1]){
            var tmp = list[j];
            list[j] = list[j+1];
            list[j+1] = tmp;            
        }        
    }    
}
```



## 一、字符串方法

字符串是只读数据，可以用下标获取字符，但不能修改。

```c#
 // 字符串: 一串字符的集合, 字符串的内容不可变,但是可以通过下标访问内容
 string str = "abcdefg";
 //Console.WriteLine(str[0]);
 //Console.WriteLine(str[1]);
 //str[0] = "s"; // 报错, 字符串内容不可修改

```

### null

null是一个关键字，表示变量空间不跟任何数据空间产生关联的关系。

正常（值不为null）的变量，一般都是在栈内存中开辟变量空间，跟数据空间产生关联来存储的。

当一个变量赋值为null的时候，就表示这个变量空间不跟任何数据空间产生关联。原本使用的数据就会被销毁掉了。

如果希望给一个变量赋值为null，可以在类型和变量名之间加`?`

```c#
// int底层语法不允许为null
int? a = null; // 表示整型变量a允许为null
// 字符串允许为null
string b = null; // 字符串的null 等同于 ""
b = b += "abc";
```

### 字符串方法属性

- Length获取字符串长度

  ```C#
  // 字符串可以通过Length属性 获取字符串的长度
  //Console.WriteLine(str.Length); // 7
  // 可以使用 下标 配合 长度 完成字符串的遍历
  for (int i = 0; i < str.Length; i++) Console.WriteLine(str[i]);
  ```

  - 利用遍历对字符串去重

    ```C#
    // 字符串去重
    string str = "abcedgjjjsssabcd";
    string resStr = ""; // 去重后的字符串
    //遍历str
    for (int i = 0; i < str.Length; i++)
    {
        // 循环判断 str[i] 在resStr中是否存在
        int j = 0;
        for (; j < resStr.Length; j++)
        {
            // 如果str[i] 在resStr中存在则终止for-j循环
            if (str[i] == resStr[j]) break;
        }
        /*
            for-j循环结束
            1. for循环条件为false, 循环结束, 那么循环结束后j == resStr.Length
            2. for循环中执行了break(str[i]在resStr中存在),循环结束, 循环条件还是true             
        */
        // 循环结束后 j == resStr.Length 成立, 说明for-j循环中没有执行break, 那么str[i] 在resStr中不存在
        if (j == resStr.Length) resStr += str[i];
    }
    Console.WriteLine(resStr);
    ```

- string.IsNullOrEmpty：判断字符串是否为空或null

- string.IsNullOrWhiteSpace：判断字符串是否为null或空格

  ```C#
  // 字符串 空值 判断
  //string.IsNullOrEmpty：判断字符串是否为空或null
  //string.IsNullOrWhiteSpace：判断字符串是否为null或空格
  
  //string str = null;
  ////bool res = string.IsNullOrEmpty(str);
  //bool res = string.IsNullOrWhiteSpace(str);
  //Console.WriteLine(res); // True
  
  //string str = "";
  ////bool res = string.IsNullOrEmpty(str);
  //bool res = string.IsNullOrWhiteSpace(str);
  //Console.WriteLine(res); // True
  
  //string str = "   ";
  ////bool res = string.IsNullOrEmpty(str); // False
  //bool res = string.IsNullOrWhiteSpace(str); // True
  //Console.WriteLine(res); 
  
  //string str = "abc";
  ////bool res = string.IsNullOrEmpty(str); // False
  //bool res = string.IsNullOrWhiteSpace(str); // False
  //Console.WriteLine(res);
  ```

- Substring：截取字符串

  ```C#
   // Substring：截取字符串
   // 字符串.Substring(开始下标)   // 从开始下标到最后截取字符串内容
   // 字符串.Substring(开始下标,个数) // 从开始下标根据个数,截取字符串内容
   string str = "abcdefg";
   //string res = str.Substring(2);
   string res = str.Substring(2, 3);
   Console.WriteLine(res);
  ```

- Contains：判断字符串中是否包含小字符串（子串）

  ```C#
  string str = "abcdefg";
  //bool res = str.Contains("bc");
  bool res = str.Contains("bcaa");
  Console.WriteLine(res);
  ```

  例：去重

  ```C#
  // 使用Contains 字符串去重
  string str = "abcedgjjjsssabcd";
  string resStr = ""; // 去重后的字符串
  //遍历str
  for (int i = 0; i < str.Length; i++)
  {
      if (!resStr.Contains(str[i])) resStr += str[i];
  }
  Console.WriteLine(resStr);
  ```

- StartsWith：判断字符串是否用某个子串开头

- EndsWith：判断字符串是否以某个子串结尾

  ```C#
  string str = "abcdddddefg";
  //bool res = str.StartsWith("a");
  //bool res = str.StartsWith("abc");
  //bool res = str.StartsWith("aaa");
  //bool res = str.EndsWith("g");
  //bool res = str.EndsWith("efg");
  bool res = str.EndsWith("aaa");
  Console.WriteLine(res);
  ```

- IndexOf：在字符串中找某个子串第一次出现的下标，找到得到下标，找不到得到-1

  ```C#
  // 字符串.IndexOf(子串)  查找子串第一次出现的下标
  // 字符串.IndexOf(子串,开始下标)  从开始下标查找子串第一次出现的下标            
  string str = "abcdebfg";
  //int index = str.IndexOf("b");
  int index = str.IndexOf("k");
  //int index = str.IndexOf("b",2);
  Console.WriteLine(index);
  ```

  

- LastIndexOf：在字符串中找某个子串最后一次出现的下标，找到得到下标，找不到得到-1

  ```C#
  // 语法参数和IndexOf 一样
  //string str = "abcdebfg";
  ////int index = str.LastIndexOf("b");
  ////int index = str.LastIndexOf("b", 2);
  //int index = str.LastIndexOf("b",0 );
  //Console.WriteLine(index);
  ```

  

- ToUpper：将字符串中的小写字母转成大写字母

  - 只有字母区分大小写，其他字符没有大小写区分

- ToLower：将字符串中的大写字母转成小写字母

  ```C#
  // ToUpper: 将字符串内容转为大写
  // ToLower: 将字符串内容转为小写
  // 注意: 只有英文字符串才有大小写区分
  string str = "abcDDDDefg";
  Console.WriteLine(str.ToUpper()); // ABCDDDDEFG
  Console.WriteLine(str.ToLower()); // abcddddefg
  ```

  

- Trim：去除字符串首尾两端的空格

  补充：类型中还有一种类型char类型，字符类型，单个字符(字符串)

  ```C#
  // string 字符串类型 使用双引号包裹 表示一串字符的集合 一般用表示一段内容 
  // char 字符类型 使用单引号包裹, 表示单个字符, 字符类型可以和整型转换
  //string str = "ABC";
  //char s = 'A';
  //Console.WriteLine((int)s);
  
  //string str = ",,!!,abc!!,,,";
  //Console.WriteLine("-" + str + "|"); // -  abc    |
  ////string res = str.Trim(','); // 根据传入的字符去除首尾两端内容
  //string res = str.Trim(',', '!'); // 根据传入的字符去除首尾两端内容
  //Console.WriteLine("-" + res + "|"); // -abc|
  ```

- TrimStart：去除开头的空格

- TrimEnd：去除结尾的空格

  ```C#
  // Trim：去除字符串首尾两端的空格
  //string str = "  abc    ";
  //Console.WriteLine("-" + str + "|"); // -  abc    |
  //string res = str.Trim();
  //Console.WriteLine("-" + res + "|"); // -abc|
  
  // TrimStart：去除开头的空格
  //string str = "  abc    ";
  //Console.WriteLine("-" + str + "|"); // -  abc    |
  //string res = str.TrimStart();
  //Console.WriteLine("-" + res + "|"); // -abc    |
  
  // TrimEnd：去除结尾的空格
  string str = "  abc    ";
  Console.WriteLine("-" + str + "|"); // -  abc    |
  string res = str.TrimEnd();
  Console.WriteLine("-" + res + "|"); // -  abc|
  ```

  

- Replace：将字符串中指定的子串都替换成的新的子串

  ```C#
  // Replace：将字符串中指定的子串都替换成的新的子串
  //string str = "abacdaeafeeg";
  ////Console.WriteLine(str.Replace("a","0"));
  //Console.WriteLine(str.Replace("ee","**"));
  
  // 敏感词替换为 * , 而且个数要保持一致
  string str = "生活总会有大麻烦, 黑夜总会过去";
  // 假设list存储敏感词
  List<string> mgc = ["大麻", "夜总会"];
  
  foreach (string str1 in mgc)
  {
      string newStr = "";
      for (int i = 0; i < str1.Length; i++) newStr += "*";    
      str = str.Replace(str1, newStr);
  }
  Console.WriteLine(str);
  // 生活总会有**烦, 黑***过去
  ```

  

- 分割字符串 Split

  ```C#
  // 字符串.Split(指定分隔符)
  //string str = "西瓜_葡萄_芒果_榴莲";
  //string[] resArr = str.Split("_");
  ////Console.WriteLine(resArr);
  //foreach(string item in resArr) Console.WriteLine(item);
  
  //string str = "西瓜 葡萄 芒果 榴莲";
  //string[] resArr = str.Split(); // 默认使用空格作为分隔符
  ////Console.WriteLine(resArr);
  //foreach (string item in resArr) Console.WriteLine(item);
  
  //string str = "西瓜-葡萄-芒果-榴莲";
  //string[] resArr = str.Split("-",2); // 参数2 数字将字符串分割为两份
  ////Console.WriteLine(resArr);
  //foreach (string item in resArr) Console.WriteLine(item);
  
  //string str = "西瓜--葡萄--芒果--榴莲"; // ""   "  "
  ////string[] resArr = str.Split("-"); 
  //string[] resArr = str.Split("-", StringSplitOptions.RemoveEmptyEntries);  //移除空字符串 
  ////Console.WriteLine(resArr);
  //foreach (string item in resArr) Console.WriteLine(item);
  
  string str = "西瓜-葡萄!芒果+榴莲";
  string[] resArr = str.Split(['-', '!', '+']);
  //Console.WriteLine(resArr);
  foreach (string item in resArr) Console.WriteLine(item);
  ```

  例：`"you love i"`转成`"I Love You"`

  ```C#
  string oldStr = "you love i";
  // 将oldStr 通过Split分隔得到 字符串数组 
  string[] strArr = oldStr.Split();
  // 将字符串数组转为 List集合,然后调用Reverse方法反转
  List<string> strList = new();
  foreach (string str in strArr) strList.Add(str);
  strList.Reverse();
  // 将反转后的每个元素字符串的首字母改为大写并拼接为最终的字符串
  string resStr = "";
  foreach (string item in strList) {
      //Console.WriteLine(item);
      string fisrtLetter = item.Substring(0,1).ToUpper(); // 截取第一个字符转大写
      string otherLetters = item.Substring(1).ToLower();  // 其他字符转小写
      resStr += fisrtLetter + otherLetters + " ";
  }
  // 处理最后多余的 " "
  Console.WriteLine(resStr.Substring(0,resStr.Length-1));
  ```

  

- string.Concat：将多个字符串拼接成一个大字符串

  ```C#
  string str1 = "aa";
  string str2 = "bb";
  string str3 = "cc";
  //string[] strArr = ["qq", "ww", "EE"];
  string res = string.Concat(str1, str2, str3);
  //string res = string.Concat(strArr);
  Console.WriteLine(res); // aabbcc
  ```

  

- string.Join：将数组或List中的所有元素使用指定的连接符拼接成一个字符串

  ```C#
  //string[] strArr = ["qq", "ww", "EE"];
  //Console.WriteLine(string.Join("-", strArr)); // qq-ww-EE
  
  List<string> strList = ["I", "Love", "U"];
  Console.WriteLine(string.Join(" ",strList)); // I Love U 
  ```

  

- PadLeft：给字符串左边填充指定的符号填满指定的长度

- PadRight：给字符串右边填充指定的符号填满指定的长度

  ```C#
  //string str = "aa";
  // 字符串.PadLeft(数字,填充字符) // 数字表示填充后的长度
  //Console.WriteLine(str.PadLeft(2, '*')); // aa
  //Console.WriteLine(str.PadLeft(1, '*')); // aa
  //Console.WriteLine(str.PadLeft(4, '*')); // **aa
  
  //Console.WriteLine(str.PadRight(3,'*')); // aa*
  
  //// 敏感词替换为 * , 而且个数要保持一致
  //string str = "生活总会有大麻烦, 黑夜总会过去";
  //// 假设list存储敏感词
  //List<string> mgc = ["大麻", "夜总会"];
  
  //foreach (string str1 in mgc)
  //{
  //    string newStr = "".PadRight(str1.Length,'*');                
  //    str = str.Replace(str1, newStr);
  //}
  //Console.WriteLine(str);
  ```

- Remove：删除字符串中的一段

  ```C#
  string str = "abcdefhijk";
  // 字符串.Remove(开始下标)// 从开始下标往最后的全删除
  // 字符串.Remove(开始下标,个数)// 从开始下标根据个数删除
  // 返回的是删除后的字符串
  //Console.WriteLine(str.Remove(2)); // ab
  Console.WriteLine(str.Remove(2,3)); // abfhijk
  Console.WriteLine(str);
  ```

  


## 二、正则表达式

### 1、概念

用于处理字符串的规则。可以验证字符串是否符合某种规则，例如验证用户输入的用户名是否符合规范；可以提取字符串中符合规则的部分，例如将一段话中的关键信息（手机号）提取出来；可以将字符串中符合规则的部分替换成新的内容，例如将文章中的敏感词替换成星号。

这个规则是使用一些特殊符号组成的。主要分为字符和量词组成，另外有一些特殊意义的符号，例如位置锚点、分组、选择等符号。

定义语法：

```c#
@"字符"；
```

### 2、普通字符

用来匹配字符串中对应的字符。

例：

```c#
@"a";
```

### 3、处理字符串的方法

#### 3.1、提取

```c#
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string reg = @"a";
            string str = "bac";
            //  Regex.Match(字符串,正则规则);  // 按照规则从字符串中提取内容
            Match res = Regex.Match(str, reg);
            Console.WriteLine(res.Value); // a
        }
    }
}
```

#### 3.2、验证方法

```c#
// Regex.IsMatch(字符串,正则)  // 判断字符串是否符合规则内容
string reg = @"a";
bool res = Regex.IsMatch("bac", reg);
Console.WriteLine(res); // True
bool res1 = Regex.IsMatch("bcd", reg);
Console.WriteLine(res1); // False
```

#### 3.3、替换方法

```c#
// // Regex.Replace(字符串,正则,替换上的内容) // 按照正则规则 将字符串中的内容替换上指定字符串
// 返回替换完成的字符串
string reg = @"a";
string res = Regex.Replace("bac", reg, "e");
Console.WriteLine(res); // bec
```

### 4、特殊字符

代表规则中要匹配的字符。

| 符号      | 含义                             |
| --------- | -------------------------------- |
| `.`       | 任意一个字符                     |
| `\d`      | 任意一个数字                     |
| `\w`      | 任意一个字母、数字、下划线       |
| `\s`      | 一个空格                         |
| `\D`      | 任意一个非数字字符               |
| `\W`      | 任意一个非字母、数字、下划线字符 |
| `\S`      | 任意一个非空格字符               |
| `[字符]`  | 中括号中的任意一个字符           |
| `[^字符]` | 非中括号中的任意一个字符         |

```C#
// 特殊字符:  代表规则中要匹配的字符。
//var reg = @"."; // 表示任意一个字符
//Console.WriteLine(Regex.IsMatch("  ",reg));                
//Console.WriteLine(Regex.IsMatch(" 你好 ", reg));                

//var reg = @"\d"; // 表示任意一个数字
//Console.WriteLine(Regex.IsMatch("abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("abc1", reg));  // True
//Console.WriteLine(Regex.IsMatch("123", reg));  // True

//var reg = @"\D"; // 表示任意一个非数字
//Console.WriteLine(Regex.IsMatch("abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("abc1", reg));  // True
//Console.WriteLine(Regex.IsMatch("123", reg));  // False

//var reg = @"\w"; // 表示任意一个数字字母下划线
//Console.WriteLine(Regex.IsMatch("abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("abc1", reg));  // True
//Console.WriteLine(Regex.IsMatch("123", reg));  // True
//Console.WriteLine(Regex.IsMatch("你好_", reg));  // True
//Console.WriteLine(Regex.IsMatch("你好AAA", reg));  // True
//Console.WriteLine(Regex.IsMatch("*<>", reg));  // False
//Console.WriteLine(Regex.IsMatch("!@#$", reg));  // False

//var reg = @"\W"; // 表示任意一个非数字字母下划线
//Console.WriteLine(Regex.IsMatch("abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("abc1", reg));  // False
//Console.WriteLine(Regex.IsMatch("123", reg));  // False
//Console.WriteLine(Regex.IsMatch("你好_", reg));  // False
//Console.WriteLine(Regex.IsMatch("你好AAA", reg));  // False
//Console.WriteLine(Regex.IsMatch("*<>", reg));  // True
//Console.WriteLine(Regex.IsMatch("!@#$", reg));  // True

//var reg = @"\s"; // 表示任意一个空白符(空格)
//Console.WriteLine(Regex.IsMatch("abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("a bc", reg)); // True
//Console.WriteLine(Regex.IsMatch(" ", reg)); // True
//Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // False

//var reg = @"\S"; // 表示任意一个非空白符(空格)
//Console.WriteLine(Regex.IsMatch("abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("a bc", reg)); // True
//Console.WriteLine(Regex.IsMatch(" ", reg)); // False
//Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True

//var reg = @"[abc]"; // 表示abc中的任意一个字符
//Console.WriteLine(Regex.IsMatch("abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("a bc", reg)); // True
//Console.WriteLine(Regex.IsMatch("c", reg)); // True
//Console.WriteLine(Regex.IsMatch("C", reg)); // False
//Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True

//var reg = @"[a-z]"; // 表示任意一个小写字母
//Console.WriteLine(Regex.IsMatch("abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("a bc", reg)); // True
//Console.WriteLine(Regex.IsMatch("c", reg)); // True
//Console.WriteLine(Regex.IsMatch("C", reg)); // False
//Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // False

// @"[0-9]"  表示任意一个数字
// @"[A-Z]"  表示任意一个大写字母
// @"[A-Za-z]"  表示任意一个字母

var reg = @"[^abc]"; // 表示任意一个除了abc的字符
Console.WriteLine(Regex.IsMatch("abc", reg)); // False
Console.WriteLine(Regex.IsMatch("a bc", reg)); // True/
Console.WriteLine(Regex.IsMatch("c", reg)); // False
Console.WriteLine(Regex.IsMatch("C", reg)); // True
Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True
```



### 5、量词

修饰前面的字符要匹配到的数量。

| 符号    | 含义             |
| ------- | ---------------- |
| `*`     | 任意个           |
| `+`     | 至少1个          |
| `?`     | 至多1个          |
| `{m}`   | 必须是m个        |
| `{m,}`  | 至少m个          |
| `{m,n}` | 至少m个，至多n个 |

```C#
//量词: 修饰前面的字符要匹配到的数量。
//var reg = @"a*"; // 表示任意个字符a
////Console.WriteLine(Regex.IsMatch("abc", reg)); // True
////Console.WriteLine(Regex.IsMatch("a bc", reg)); // True
////Console.WriteLine(Regex.IsMatch("c", reg)); // True
////Console.WriteLine(Regex.IsMatch("C", reg)); // True
////Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True
//Console.WriteLine(Regex.Match("abc", reg)); // a
//Console.WriteLine(Regex.Match("123-ABC", reg)); // 

//var reg = @"\d+"; // 表示至少1个数字字符
//Console.WriteLine(Regex.IsMatch("abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("a2bc", reg)); // True
//Console.WriteLine(Regex.IsMatch("c", reg)); // False
//Console.WriteLine(Regex.IsMatch("123", reg)); // True
//Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True

//var reg = @"\d?"; // 表示0个或1个数字字符
////Console.WriteLine(Regex.IsMatch("abc", reg)); // True
////Console.WriteLine(Regex.IsMatch("a2bc", reg)); // True
////Console.WriteLine(Regex.IsMatch("c", reg)); // True
////Console.WriteLine(Regex.IsMatch("123", reg)); // True
////Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True
//Console.WriteLine(Regex.Match("abc", reg)); //
//Console.WriteLine(Regex.Match("123-ABC", reg)); // 1 

//var reg = @"\d{3}"; // 表示三个连续的数字字符
////Console.WriteLine(Regex.IsMatch("abc", reg)); // False
////Console.WriteLine(Regex.IsMatch("a2bc", reg)); // False
////Console.WriteLine(Regex.IsMatch("c", reg)); // False
////Console.WriteLine(Regex.IsMatch("123", reg)); // True
////Console.WriteLine(Regex.IsMatch("123-ABC", reg)); // True
////Console.WriteLine(Regex.IsMatch("1c23", reg)); // False
//Console.WriteLine(Regex.Match("1abc12", reg)); //
//Console.WriteLine(Regex.Match("123-ABC", reg)); // 123 

//var reg = @"\d{3,5}"; // 表示3到5个连续的数字字符
////Console.WriteLine(Regex.IsMatch("abc", reg)); // False
////Console.WriteLine(Regex.IsMatch("a2bc", reg)); // False
////Console.WriteLine(Regex.IsMatch("c", reg)); // False
////Console.WriteLine(Regex.IsMatch("a123", reg)); // True
////Console.WriteLine(Regex.IsMatch("a1123", reg)); // True
////Console.WriteLine(Regex.IsMatch("a11235", reg)); // True
////Console.WriteLine(Regex.IsMatch("12323-ABC", reg)); // True
////Console.WriteLine(Regex.IsMatch("1c2333333", reg)); // True
//Console.WriteLine(Regex.Match("1abc1222", reg)); // 1222
//Console.WriteLine(Regex.Match("123-ABC", reg)); // 123 

var reg = @"\d{3,}"; // 表示3到无数个连续的数字字符
//Console.WriteLine(Regex.IsMatch("abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("a2bc", reg)); // False
//Console.WriteLine(Regex.IsMatch("c", reg)); // False
//Console.WriteLine(Regex.IsMatch("a123", reg)); // True
//Console.WriteLine(Regex.IsMatch("a1123", reg)); // True
//Console.WriteLine(Regex.IsMatch("a11235", reg)); // True
//Console.WriteLine(Regex.IsMatch("12323-ABC", reg)); // True
//Console.WriteLine(Regex.IsMatch("1c2333333", reg)); // True
Console.WriteLine(Regex.Match("1abc1222111111", reg)); // 1222111111
Console.WriteLine(Regex.Match("123-ABC", reg)); // 123 
```



### 6、其他符号

| 符号              | 含义                                   |
| ----------------- | -------------------------------------- |
| `^`               | 放在正则开头，修饰必须以哪个字符开头   |
| `$`               | 放在正则结尾，修饰必须以哪个字符结尾   |
| `|`               | 或者                                   |
| `[\u4e00-\u9fa5]` | 1个汉字                                |
| `\`               | 转义符，将特殊含义的字符的特殊含义去掉 |

```C#
// 其他符号
//// ^ 表示以什么内容开头  必须书写在最开头
//var reg = @"^\d{3}"; // 表示必须以3到个连续的数字字符开头
//Console.WriteLine(Regex.IsMatch("12abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("123abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("111abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("123456abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("1a23111", reg)); // False
//Console.WriteLine(Regex.IsMatch("12z33333", reg)); // False

//// $ 表示以什么内容结尾  必须书写在最后
//var reg = @"\d{3}$"; // 表示必须以3到个连续的数字字符结尾
//Console.WriteLine(Regex.IsMatch("12abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("123abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("111abc11", reg)); // False
//Console.WriteLine(Regex.IsMatch("123456abc123", reg)); // True
//Console.WriteLine(Regex.IsMatch("1a23111", reg)); // True
//Console.WriteLine(Regex.IsMatch("12z33333", reg)); // True


//// 以匹配到的这三个数字开头, 并以匹配到的这三个数字结尾
//var reg = @"^\d{3}$"; // 表示必须  3个连续的数字字符
//Console.WriteLine(Regex.IsMatch("12abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("123abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("111", reg)); // True
//Console.WriteLine(Regex.IsMatch("123", reg)); // True
//Console.WriteLine(Regex.IsMatch("123a123", reg)); // False
//Console.WriteLine(Regex.IsMatch("123123", reg)); // False
//Console.WriteLine(Regex.IsMatch("1a23111", reg)); // False
//Console.WriteLine(Regex.IsMatch("12z33333", reg)); // False


//var reg = @"a|bc"; // 表示  包含一个a或者bc 
//Console.WriteLine(Regex.IsMatch("12abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("123abc", reg)); // True
//Console.WriteLine(Regex.IsMatch("111", reg)); // False
//Console.WriteLine(Regex.IsMatch("123", reg)); // False
//Console.WriteLine(Regex.IsMatch("123a123", reg)); // True
//Console.WriteLine(Regex.IsMatch("123123", reg)); // False
//Console.WriteLine(Regex.IsMatch("1a23111", reg)); // True
//Console.WriteLine(Regex.IsMatch("12z33333", reg)); // False


//var reg = @"[\u4e00-\u9fa5]"; // 表示  包含一个汉字
//Console.WriteLine(Regex.IsMatch("12abc", reg)); // False
//Console.WriteLine(Regex.IsMatch("hello", reg)); // False
//Console.WriteLine(Regex.IsMatch("hel你好lo", reg)); // True
//Console.WriteLine(Regex.IsMatch("hel你lo", reg)); // True


var reg = @"\."; // 表示  包含字符.
Console.WriteLine(Regex.IsMatch("12abc", reg)); // False
Console.WriteLine(Regex.IsMatch("he.llo", reg)); // True
Console.WriteLine(Regex.IsMatch("hel你好lo", reg)); // False
Console.WriteLine(Regex.IsMatch("hel.你lo", reg)); // True
```



### 7、多次提取

```c#
string reg = @"a|b";
MatchCollection res = Regex.Matches("abc", reg);
Console.WriteLine(res[0]);
Console.WriteLine(res[1]);
```

### 8、分组

用小括号表示一组

```c#
string reg = @"(\d{4})-(\d{2})-(\d{2})";
Match res = Regex.Match("2026-07-22", reg);
// 正则中的() 是一个个单独的整体,除了整个正则表达式会匹配之外, 每个小括号也会单独匹配
// 这些小括号单独匹配的内容 在整体匹配结果的分组中
Console.WriteLine(res.Value); // 2026-07-22
Console.WriteLine(res.Groups[0]); // 2026-07-22
Console.WriteLine(res.Groups[1]); // 2026  // 第一个小括号匹配的结果
Console.WriteLine(res.Groups[2]); // 07
Console.WriteLine(res.Groups[3]); // 22
Console.WriteLine(res.Groups.Count); // 4

// () 也可以表示一个小的单独整体
//var reg = @"^a|b$";
//Console.WriteLine(Regex.IsMatch("a",reg)); // True
//Console.WriteLine(Regex.IsMatch("b",reg)); // True
//Console.WriteLine(Regex.IsMatch("accc",reg)); // True
//Console.WriteLine(Regex.IsMatch("cccb", reg)); // True


//var reg = @"^(a|b)$";
//Console.WriteLine(Regex.IsMatch("a", reg)); // True
//Console.WriteLine(Regex.IsMatch("b", reg)); // True
//Console.WriteLine(Regex.IsMatch("accc", reg)); // False
//Console.WriteLine(Regex.IsMatch("cccb", reg)); // False
```

`?:`放在小括号中，表示不产生分组，只用于匹配使用。

例：

```c#
string reg = @"(?:\d{4})-(?:\d{2})-(?:\d{2})";
Match res = Regex.Match("2026-07-22", reg);
Console.WriteLine(res.Value); // 2026-07-22
Console.WriteLine(res.Groups[0]); // 2026-07-22
Console.WriteLine(res.Groups[1]); // 
Console.WriteLine(res.Groups.Count); // 1
```



案例：

- 手机号
- qq号
- 邮箱号
- 提取一句话中的所有工资

```C#
//-手机号 // 假设第二位不能是0
var reg1 = @"^1[1-9]\d{9}$";
//- qq号
var reg2 = @"[1-9]\d{4,8}";
//- QQ邮箱号
var reg3 = @"[1-9]\d{4,8}@qq\.com";
//- 提取一句话中的所有工资
var str = "你的工资是: 10000 我的工资是:3000,小明的工资是: 20000";
var reg4 = @"[1-9]\d{3,}";
var res = Regex.Matches(str, reg4);
foreach (var item in res) Console.WriteLine(item);
```



### 作业:
- 提取一句话中所有的中文姓名

  ```C#
  string str = "hello, I am 刘德华,your name is 黎明?"
  ```

- 替换所有多余空格

  ```C#
  string str = "abc  dd  ee  ff  gg  HH  h j k"
  ```

- 身份证号码

  ```C#
  string str = "我的身份证号是: 360731200111052112,你的身份证是: 42108320041119211X";
  // 书写正则, 找到字符串中的身份证号及 出生年,月,日
  ```

- 密码强度检测：强中弱（字母、数字、特殊符号）

  ```C#
  // 请输入密码（字母、数字、特殊符号）
  
  //密码中可以有数字,字母,特殊符号;长度要求8~15 
  //如果只有一种则 强度为弱
  //如果只有两种则 强度为中
  //如果两种都有则 强度为强
  
  //验证密码长度是否符合,并输出密码强度
  ```

  