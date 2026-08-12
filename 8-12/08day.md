---
typora-copy-images-to: asset
---

# day08

## 上节回顾

- 数字转汉字案例, 数据加密案例

- 数据类型转换

  ```C#
  (int)value  转整数
  (double)value 转浮点数
  // 字符可以和数字转换 (字符的编码进行转换)
  int.TryParse()  和int.Parse() 都是将字符串转为整型数字, TryParse 不会报错
  value.ToString()   转字符串
  ToArray()  转数组
  ToList()   转List
  ```

- 数字格式化: 数字.ToString(参数)

  ```C#
  C数字   货币格式化   	
  D数字   十进制格式化   
  E数字   科学计数法     
  F数字   保留小数位
  N数字   千分位逗号分隔
  P数字   百分比格式化
  000.000% 百分比格式化
  X	   十六进制格式化
  00000.0000  补零格式化
  #,#    千分位逗号分隔
  // 涉及到的数字大部分都是 根据数字长度补零, 长度多了的时候四舍五入
  ```

- 时间日期

  ```C#
  DateTime 变量 = DateTime.Now; // 获取当前时间对象
  // 获取时间的时间对象
  new DateTime(年,月,日,时,分,秒) 
  DateTime.Parse("时间日期字符串")
  
  // 时间对象的属性
  时间对象.Year/Month/Day/DayOfWeek/Hour/Minute/Second/MilliSecond
  
  // 时间戳
  DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // 获取当前的时间戳
  var date = DateTimeOffset.Parse("2026-10-1 10:10:10");
  date.ToUnixTimeMilliseconds();  // 获取指定时间的时间戳
  ```

  - 时间差计算

    ```C#
    var d1 = DateTime.Now;
    var d2 = DateTime.Parse("国庆日期")
    var diff = d2 - d1;
    diff.TotalDays   // 转天数
    diff.TotalHours  // 转小时数
    ```

  - 时间日期格式化: 长时间/短时间/.....

- JSON序列化和反序列化

  ```C#
  Dictionary<string, dynamic> dic = new()
  {
      ["name"] = "张三",
      ["age"] = 18
  };
  // 配置序列化
  var options = new JsonSerializerOptions()
  {
      WriteIndented = true,// 美化
      AllowTrailingCommas=true,// 反序列化允许逗号结尾
  };
  // Json序列化
  var json = JsonSerializer.Serialize(dic, options);
  Console.WriteLine(json);
  // 反序列化
  var d = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(json);
  ```

  - 中文编码反序列化

    ```C#
    var str = "\\u4e00";
    var r = $"\"{str}\"";
    Console.WriteLine(JsonSerializer.Deserialize<string>(r));
    ```

- 多维数组

  ```C#
  int[,] 变量= new int[数字,数字]
  {
   {数字,数字,数字...},
   {数字,数字,数字...},
   {数字,数字,数字...}
  }
  // 访问
  变量[下标,下标]
  
  int[,] arr = new int[3, 2]{
      { 1,10},
      { 2,20},
      { 3,30}
  };
  
  // 获取的是每一个值
  foreach (var item in arr)
  {
      Console.WriteLine(item);
  }
  
  // 二维数组 就是一个整体; 不可以通过单独提取某一个小数组
  
  // 交错数组
  int[][] 变量= new int[长度][];
  
  foreach(var item in 变量){
      // item 是每一个小数组
      foreach(var val in item){
          // val 才是数组中的每个数据        
      }
  }
  ```

## 一、函数

### 1、概念

在我们开发的程序中，有时候，一段代码会多次被使用，如果这段代码能包装一个容器中，使用时就会方便很多。包装一段代码的程序就是**函数**。

例如：

​	手动洗衣服怎么洗？拿个盆，接水，放衣服，倒洗衣粉，洗，涮，拧干

​	挺费劲的，有没有简便的方法？

​	使用洗衣机，衣服放进去，倒上洗衣粉，按开关，一切就都搞定了。

再比如：

​	手工制作奶茶，要煮茶、加奶、放小料、调糖，步骤一大堆。
​	挺麻烦的，有没有简便的方法？
​	使用全自动奶茶机，选定小料、甜度，按下开关，一切就都搞定了。

大家思考一下：奶茶机内部，已经提前装好一整套制作奶茶的流程。 我们不需要知道机器里面怎么搅拌、怎么控温，只用给出要求，启动机器就行。

对应代码： 把一堆重复的步骤打包封装起来，**就是定义函数**； 启动奶茶机，**就是调用函数**； 我们选择珍珠、少糖这些设置，就是给函数传递**参数**； 最后机器送出一杯成品奶茶，就是函数的**返回值**。

例：`9*9乘法表`/`3*3乘法表`/`12*12乘法表`/任意乘法表

```c#
//for (int i = 1; i <= 9; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {

//        Console.Write($"{j}*{i}={i * j}" + "\t");
//    }
//    Console.WriteLine();
//}

//for (int i = 1; i <= 3; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {

//        Console.Write($"{j}*{i}={i * j}" + "\t");
//    }
//    Console.WriteLine();
//}

//for (int i = 1; i <= 12; i++)
//{
//    for (int j = 1; j <= i; j++)
//    {

//        Console.Write($"{j}*{i}={i * j}" + "\t");
//    }
//    Console.WriteLine();
//}

// 代码立即执行了
// 通过函数实现了 任意乘法表
var fn = (int n) =>
{
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= i; j++)
        {

            Console.Write($"{j}*{i}={i * j}" + "\t");
        }
        Console.WriteLine();
    }
};

fn(9);
Console.WriteLine("======================================");
fn(3);
/*
  函数特点: 封装,复用, 即用
    封装:  将要执行的代码包装起来
    复用:  封起来的代码可以重复使用
    即用:  封装的代码不会立即执行,调用才会执行
 */
```



### 2、语法

#### 2.1、定义函数

```c#
// 不涉及函数类型
var 函数名称 = () => {
    需要重复执行的代码段
}
函数抛出的结果类型 函数名称() // 没有结果就使用void表示
{
    需要重复执行的代码段
}
// 添加函数类型
Action 函数名称 = () => {
    需要重复执行的代码段
}
```

注意：函数定义好后，函数中的代码不会自动执行。

#### 2.2、调用函数

> 任何类型函数调用都一样 

```c#
函数名称();
```

第一种语法:

```c#
// 打印分割线
var printLine = () =>
{
    Console.WriteLine("=============================");
};
Console.WriteLine("张三");
Console.WriteLine(18);
printLine();
Console.WriteLine("李四");
Console.WriteLine(19);
```

第二种语法：

```c#
// 菜单打印函数(图书管理系统)
void PrintMenu()
{
    Console.WriteLine("===图书管理系统===");
    Console.WriteLine("1.新增");
    Console.WriteLine("2.修改");
    Console.WriteLine("3.查询");
    Console.WriteLine("4.删除");      
}
PrintMenu();
PrintMenu();
```

第三种语法：

```c#
// 打印星星
Action printStar = () =>
{
    Console.WriteLine("  *  ");
    Console.WriteLine(" *** ");
    Console.WriteLine("*****");
};
printStar();
printStar();
```

### 3、带参数的函数

打印菜单的函数无论我们调用多少次，永远只能显示【图书管理系统】菜单，因为这个菜单写死了。

如果我现在想要一个【学生管理系统】菜单、【商品管理系统】菜单，怎么办？

​	方案 1：复制粘贴，新建 `ShowStudentMenu()`、`ShowShopMenu()`；

​	缺点：大量重复代码，改一处就要改好多地方，非常麻烦！

我们能不能**只写一个函数**，但是允许我们告诉函数：你这次展示图书系统菜单，下次展示学生系统菜单？

想要实现这件事，我们就需要给函数增加**【参数】**

参数就相当于函数预留的**输入窗口**，调用函数的时候，把数据从外面传递进函数内部。

函数代码中会发生改变的值用变量来代替，入口是声明函数时的小括号。

```c#
// 定义函数时小括号定义变量，这个变量可以在函数中使用
void ShowMenu(string systemName)
{
    Console.WriteLine($"===={systemName}====");
    Console.WriteLine("1. 查询数据");
    Console.WriteLine("2. 新增数据");
    Console.WriteLine("0. 退出");
}
// 调用函数的时候，需要给参数赋值
ShowMenu("图书管理系统");
ShowMenu("学生管理系统");
ShowMenu("商品管理系统");
```

声明函数时候带进去的那个参数叫**形参**；调用函数的时候给形参进行赋值的实际值是**实参**。

也可以使用第三种定义方式：`Action<参数类型> 函数名 = (参数) =>{}`

```c#
// Action<参数类型,....> 函数名=(参数....)=>{}
// 前面声明了参数类型,则才()中则可以不写参数类型
Action<string> printMenu = (systemType) =>
{
    Console.WriteLine($"==={systemType}===");
    Console.WriteLine("1.新增");
    Console.WriteLine("2.修改");
    Console.WriteLine("3.查询");
    Console.WriteLine("4.删除");
    Console.WriteLine("==========底部==========");
};

printMenu("图书管理系统");
printMenu("学生管理系统");
printMenu("商品管理系统");
```

例：输出错误提示信息

```c#
// 输出错误提示信息
void printErrorMsg(string msg)
{
    Console.WriteLine($"错误提示{msg}");
}

printErrorMsg("被除数不能为0");
Console.WriteLine("=====================");
printErrorMsg("下标超出范围");
```

可选参数:

```C#
// 函数的参数可以有多个的
//// 加法函数
//var add = (int n1, int n2) =>
//{
//    Console.WriteLine($"总和: {n1 + n2}");
//};
////add(10, 20);
////add(30,40);

// 参数默认值, 也叫参数缺省值
// (参数=值)=>{}   // 此处的值就是参数的默认值
// 如果函数调用的时候没有给该参数传递实参,那么在函数内就使用默认值
// 如果调用使用传递了实参,则函数内就使用传递的实参值
// 有默认值的参数 也叫 可选参数(调用时候可以不传递,使用默认值)
// 没有默认值的参数 就是必需参数(调用时候必须传递实参)
// 必需要参数 只能在可选参数之前

// 运算函数
void cal(int n1, int n2 = 10, string opt="+")
{
    var res = opt switch
    {
            "+" => (n1 + n2).ToString(),
            "-" => (n1 - n2).ToString(),
            "*" => (n1 * n2).ToString(),
            "/" => (n1 / n2).ToString(),
            _ => "输入有误",
    };
    Console.WriteLine($"计算结果{res}");
};
//cal(10, 20, "+");
//cal(10, 20, "*");
//cal(100, 20, "/");
//cal(100, 20);
//cal(10);
```

函数实参位置:

```C#
void cal(int n1, int n2, string opt)
{
    var res = opt switch
    {
        "+" => (n1 + n2).ToString(),
        "-" => (n1 - n2).ToString(),
        "*" => (n1 * n2).ToString(),
        "/" => (n1 / n2).ToString(),
        _ => "输入有误",
    };
    Console.WriteLine($"计算结果{res}");
}
// 函数调用时候的实参 按照循序 给 函数形参传递的
//cal(10, 20, "+");

// 函数调用时候,如果传递的实参位置 想要变化, 可以指定形参实参对应关系
// 函数名(形参:实参,....)
cal(opt: "+", n1: 10, n2: 20);
```



### 4、带返回值的函数

#### 4.1、返回值的作用

如果函数仅仅只是 `Console.WriteLine()` 打印结果，会有一个致命问题：
	内容只会显示在窗口上，然而代码确拿不到这个结果，没办法接着往下处理。那么函数就只管做事了，做完没有东西交出来。

带**返回值**函数：即函数加工完成，把结果返还给程序；函数外部拿到结果后，可以继续完成判断、计算、拼接，等后续操作。

我们很多业务场景：拿到函数结果后，还要继续完成第二步、第三步逻辑。

想要把函数计算 / 处理好的数据交给程序继续使用，就必须使用带**返回值**的函数。

函数没有结果时：

```c#
// 计算打折后价格，只能打印
void ShowDiscountPrice(double originalPrice, double discount)
{
    double price = originalPrice * discount;
    Console.WriteLine($"折后价：{price}");
}
ShowDiscountPrice(100,0.8);
```

这种函数只能看见价格。我想继续计算：运费、满减、订单总价，程序拿不到折后价，无法继续运算。

#### 4.2、返回值语法

让函数将得到的结果给出来（带返回值）： 在函数通过`retuen` 关键字给函数 返回值

语法: `类型 函数名(参数){ return 结果 }`

```c#
// 折扣函数 返回 折后价, 后续可以进行 运费满减, 订单总价计算等操作
double ShowDiscountPrice(double originalPrice, double discount)
{
    double price = originalPrice * discount;
    return price;
}

// 函数调用后可以得到 函数内返回的结果  (函数的返回值)
//double res = ShowDiscountPrice(100, 0.8);
double res = ShowDiscountPrice(125, 0.8);
//Console.WriteLine(res);

double yunPrice = 0;
//运费满减  运费是50   满100减运费
if (res >= 100) yunPrice = res;
else yunPrice = res + 50;

Console.WriteLine(yunPrice);
```

例：

没有返回值的函数：

```c#
// 登录函数
// user : "admin"  pwd : "123456"
var login = (string user, string pwd) =>
{
    if (user == "admin" && pwd == "123456")
    {
        Console.WriteLine("登录成功");
    }
    else
    {
        Console.WriteLine("用户名或密码错误");
    }

};
login("admin", "123456");
```

缺陷：程序不知道登录成功与否！我们想实现的效果是登录成功展示菜单、失败重复输入，根本无法实现。

带返回值：

```c#
//登录函数
var login = (string user, string pwd) =>
{
    if (user == "admin" && pwd == "123456")
    {
        return true;
    }
    else
    {
        return false;
    }
};

var res = login("admin", "123456");

if (res)
{
    Console.WriteLine("登录成功,展示主页菜单");
}
else
{
    Console.WriteLine("登录失败,请重试!!!");
}
```

#### 4.3、return的另外一个作用

另外，return会阻止函数中后续代码执行，也就是函数中return后面行的代码不会执行：

```c#
void fn() {
    Console.WriteLine("111");
    return;
    Console.WriteLine("222");
}
```

案例: 判断是否是质数

```C#
// 要求封装一个函数 检测输入的是否是质数(素数)
// 函数参数: 检测的数字 类型 int
// 函数的返回值: 布尔值
bool isPrime(int n)
{
    // 形参n就是要判断的数字                            
    for (int i = 1; i <= n; i++)
    {
        // 如果i是 1 或者m本省 则跳过循环
        if (i == 1 || i == n)
        {
            continue;
        }
        // 判断i能否将m整除
        if (n % i == 0)
        {
            // 代码执行到此处 说明 n就不是素数了
            return false; // return执行后 循环也结束了
        }
    }
    return true;
}

Console.WriteLine(isPrime(15));
Console.WriteLine(isPrime(16));
Console.WriteLine(isPrime(17));
```



#### 4.4、带返回值函数的类型

带返回值的函数类型：

```c#
Func<参数类型1, 参数类型2, ... 返回值类型> 函数名 = delegate(类型 参数名, 类型 参数名, ...) {
    函数代码段
    return 返回值;
};
// 或
Func<参数类型1, 参数类型2, ... 返回值> 函数名 = (类型 参数名, 类型 参数名, ...) => {
    函数代码段
    return 返回值;
}
```

总结函数定义：

```c#
var 函数名 = () => { };// 这种定义方式属于自动推导 函数的类型

返回值类型 函数名() {}  // 具名函数

// 定义没有返回值的函数的类型
Action<参数类型> 函数名 = () => {};

// 定义带返回值的函数的类型
Func<参数类型, ..., 返回值类型> 函数名 = delegate(){};
Func<参数类型, ..., 返回值类型> 函数名 = () => {};
```



#### 4.5、自定义函数类型

```c#
delegate 返回值类型 函数类型名称(参数类型 参数名, ...); // 必须放在命名空间内或类内部，不能放在方法内部
```

例：

```c#
MyFunc fn = (int a, int b) => {
    int c = a + b;
    return c;
};
Console.WriteLine(fn(2, 3));
```

![1785308554187](asset/1785308554187.png)

#### 4.6、抛出数据

我们在`int.TryParse`方法的参数中，可以使用out接收到一个结果数据，这种函数怎么定义呢？

这种从函数中抛出数据的方式，也需要在定义函数时的参数列表中进行设置：

```c#
返回值类型 函数(参数, .., out 类型 数据名) {
    给out抛出的变量进行赋值即可
}
函数(参数, ..., out 类型 变量名);
```

例：

```c#
bool PrintCollection(string[] arr, char splitChar, out string joinStr)
{
    List<string> list = arr.ToList();
    joinStr = string.Join(splitChar, list);
    return true;
}
bool isSuccess = PrintCollection(new string[] { "aa", "bb", "cc" }, '-', out string result);
Console.WriteLine(result);
Console.WriteLine(isSuccess);
```



## 二、作用域

作用域指变量定义好以后，能起到作用的区域。

在c#中，变量的作用域被固定在大括号中，例如for语句的大括号和if语句的大括号，外部都无法访问其中定义的变量，但内部却可以访问外部的变量。

```C#
//if (true)
//{
//    var i = 10; // 此处的i作用范围就是 if的{}
//}
//Console.WriteLine(i); // 无法访问到 if中的i

//for (int i = 0; i < 10; i++)
//{
//   //此处就是i的作用域
//}
//Console.WriteLine(i); // 无法访问到 for中的i

//{
//    var n = 10;
//    // 此处就是n的作用域
//}
//Console.WriteLine(n); // 法访问到 {} 的 n

//var n = 10;
//var fn = () =>
//{
//    var n = 20;
//    var ff = () =>
//    {
//        var n = 30;
//        Console.WriteLine(n); // 30
//    };
//    ff();
//};
//fn();

var n = 10;
var fn = () =>
{
    Console.WriteLine(n); // 10
    // 找到n变量的定义, 在fn中没有变量n,那么会往外找,找到了,值10

    // 找到n变量的定义, 在fn中没有变量n,那么会往外找,找到了就赋值为20
    // 此处外部的n值为20
    n = 20;
};
Console.WriteLine(n); // 10
fn();// fn函数执行完毕后 此处的n值为20
Console.WriteLine(n); // 20
```



## 三、异常处理

**异常**的现象描述，报错后，后续代码无法执行：

```c#
string numStr = "abc";
int num = int.Parse(numStr); // "abc"无法转为数字，抛出FormatException
Console.WriteLine("后面的代码不会执行！");
```

这时候就需要做异常处理，异常处理的目标：

1. 拦截异常，避免程序整体崩溃
2. 打印错误信息、记录日志，方便排查问题
3. 给用户友好提示
4. 安全释放文件、数据库、网络等占用的资源，避免错误代码占用内存

语法：

```c#
try
{
    // 可能有异常的风险代码
}
catch (异常类型 ex)
{
    // 捕获到对应类型的异常后的代码
}
finally
{
    // 可选，无论是否异常，都会执行（一般用来释放资源）
}
```

说明：

> 这三个关键字可以搭配使用：
>
> 1. `try-catch`
> 2. `try-catch-finally`
> 3. `try-finally`（不捕获异常，异常继续向外抛出，仅用来释放资源）
>
> 异常变量 `ex`：
>
> `ex.Message`：简短的错误描述文本（最常用属性）
> `ex.StackTrace`：堆栈信息，定位报错代码行（调试用）

例：单个 catch 捕获所有异常

```c#
try
{
    string str = "abc123";
    int number = int.Parse(str);
}
catch (Exception ex)
{
    Console.WriteLine("异常问题: "+ex.Message);
}

Console.WriteLine("终于到我了")
```

例：多个 catch，分类捕获不同异常

```c#
int[] arr = { 11, 22, 33 };
Console.Write("输入数组下标：");
string input = Console.ReadLine();

try
{
    int index = int.Parse(input);
    Console.WriteLine($"数组值：{arr[index]}");
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine("输入的下标超出范围" + ex.Message);
}
catch (FormatException ex)
{
    Console.WriteLine("输入的下标格式错误" + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("总是有问题!!!" + ex.Message);
}
```

测试：

1. 输入`abc` → 触发 FormatException
2. 输入`99` → 触发 IndexOutOfRangeException
3. 其他意外错误 → 进入最后的 Exception

注意：子异常写在前面，总异常写在后面，不能乱了顺序。

例：finally 使用场景 ==> 释放资源（文件流、数据库连接、网络连接、锁）

```c#
// 模拟打开文件 - 异常 - 关闭文件
try
{
    Console.WriteLine("打开文件操作a.json");
    // 主动的模拟错误
    int.Parse("abc");
}
catch (Exception ex)
{
    Console.WriteLine("处理文件操作异常,打开备用文件b.json");
}
finally
{
    Console.WriteLine("最终都要关闭文件操作");
}

```

例：try + finally（没有 catch），这时候不会捕获异常，异常继续向上抛出，程序依旧会崩溃，但是依然执行 finally 释放资源：

```c#
try
{
    Console.WriteLine("连接数据可操作");
    // 主动的模拟错误
    int.Parse("abc");
}           
finally
{
    Console.WriteLine("关闭连接");
}
```

某些情况下，我们需要手动抛出异常。

> 手动抛出异常:  `throw new 异常类型(异常提示信息)`



系统自动抛出异常（`int.Parse("abc")`、空引用）是运行时环境检测到错误。
而手动抛异常，是业务代码主动校验【业务规则不合法】。

```c#
// 计算距离退休剩余年数
static int GetRetireYear(int age)
{
    // 没有校验！如果传入负数
    return 60 - age;
}

void Main()
{
    int result = GetRetireYear(-20);
    Console.WriteLine(result); // 80，得到一个毫无意义的数字！
}
```

问题： 传入 `-20` 非法数据，函数正常返回结果，**不会报错，但是逻辑完全错误**。 调用方很难发现隐蔽 bug。

解决方案：参数校验，**手动抛出异常**，阻断非法逻辑。

场景 1：参数合法性校验（最常用）

```C#
static int GetRetireYear(int age)
{
    if (age < 0)
    {
        // 手动抛出异常，告知调用者错误原因
        throw new ArgumentException("年龄不能为负数！", nameof(age));
    }
    if (age > 120)
    {
        throw new ArgumentException("年龄超出合理范围0~120");
    }
    return 60 - age;
}

static void Main()
{
    try
    {
        GetRetireYear(-5);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"错误：{ex.Message}");
    }
}
```

场景 2：业务逻辑不满足，禁止继续执行

```c#
static void Pay(decimal balance, decimal payMoney)
{
    if (payMoney <= 0)
    {
        throw new ArgumentException("支付金额必须大于0");
    }
    if (balance < payMoney)
    {
        // 业务异常：余额不足
        throw new InvalidOperationException("账户余额不足，无法完成支付");
    }
    Console.WriteLine("支付成功");
}

static void Main()
{
    try
    {
        Pay(100, 200);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
```

场景 3：捕获异常后，包装异常向上抛出（异常传递）

```c#
static void ReadFile()
{
    try
    {
        File.ReadAllText("test.txt");
    }
    catch (FileNotFoundException ex)
    {
        
        // 捕获原始异常，包装新异常，把原始异常作为内部异常
        throw new Exception("读取配置文件失败，请检查文件路径", ex);        
    }
}
```

场景 4：预留未实现方法，强制提醒开发者

```c#
static void FutureFunction()
{
    // 功能暂未开发，调用直接报错，提醒开发人员
    throw new NotImplementedException("该功能下个版本实现");
}
```

手动抛出异常是人为定义规则，主动拦截非法数据，避免产生错误结果。

错误类型：

| 异常类型                          | 说明                                     |
| --------------------------------- | ---------------------------------------- |
| System.ArithmeticException        | 算术运算时发生的异常                     |
| System.ArrayTypeMismatchException | 数组存储元素时，元素类型与期望类型不匹配 |
| System.DivideByZeroException      | 除以0的时候                              |
| System.IndexOutOfRangeException   | 数组下标超出范围                         |
| System.InvalidCastException       | 类型转换失败                             |
| System.NullReferenceException     | 使用数据时，发现数据是null               |

## 四、Debug调试

首先打断点。

F10执行下一段代码。

F11进入方法执行。

F5跳过调试。



作业：

1. 装修房间：参数1，圆的半径，计算圆的面积，每平方米收费200元，返回装修总价。计算这个半径的圆装修一半需要多少钱？

2. 计算字符在字符串中出现的次数：参数1字符串，参数2某个字符，函数统计次数，并返回。

   ```C#
   string str = "qwerysssssqqqqwwweee";
   fn(str,"s")
   ```

   

3. 计算一个整型数组中，最小值第一次出现的下标。

   ```C#
   int[] arr = [10,20,5,30,50,6,7]
   ```

   

4. 判断一个字符串是否为回文，返回布尔值类型。

   ```C#
   string str = "abcdcba"
   ```

   



课堂案例: 

1. 用函数封装一个猜数字的小游戏，函数中生成一个随机整数（0-100）作为目标数字，不停的让用户输入数字，距离目标数字偏大，就提示用户偏大，距离目标数字偏小就输出偏小，用户有5次输入的机会，5次没有猜对，输出GAME OVER，猜对了就输出WIN！

   ```C#
   // 用函数封装一个猜数字的小游戏，函数中生成一个随机整数（0 - 100）作为目标数字，不停的让用户输入数字，距离目标数字偏大，就提示用户偏大，距离目标数字偏小就输出偏小，用户有5次输入的机会，5次没有猜对，输出GAME OVER，猜对了就输出WIN！
   var guessNum = (int n) =>
   {
       // 函数的参数,在函数内部就是一个变量
       // 获取说技术
       var random = new Random();
       var x = random.Next(0,100);
       int count = 1; // 猜测是次数
       while (true)
       {
           if (n == x)
           {
               Console.WriteLine("WIN!");
               break;// 循环结束
           }
           else if (n > x) Console.WriteLine("偏大");
           else Console.WriteLine("偏小");
           // 没猜对,继续猜
           Console.WriteLine("请输入你猜的数字");
           n = int.Parse(Console.ReadLine());
           count++;
           if (count == 5)
           {   // 游戏次数超过 
               Console.WriteLine("GAME OVER");
               break;
           }
       }
   };
   
   Console.WriteLine("请输入你猜的数字");
   int m = int.Parse(Console.ReadLine());
   guessNum(m);
   ```

   



