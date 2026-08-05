---
typora-copy-images-to: assets
---

# 条件分支

## 一、上节回顾

数学对象:

```c#
Math.PI
Math.Abs()
Math.Round()
Math.Ceiling()
Math.Floor()
Math.Max()
Math.Min()
Math.Sin()
Math.Cos()
Math.Pow()
Math.Sqrt()
```

类型推导:  `var 变量 = 值`

任意类型: `dynamic 变量 = 任意值`

匿名类: `new {键名=键值}`

集合:

- 数据字典: `Dictionary<键名类型,键值类型> 变量名 = new Dictionary<键名类型,键值类型> (){...}`

```C#
Dictionary<键名类型,键值类型> 变量名 = new Dictionary<键名类型,键值类型> (){...}
// 访问
变量名[键名]
// 修改
变量名[键名] = 值
// 新增
变量名.add()
变量名[键名] = 值
// 删除
变量名.Remove(键名)
// 获取数量
变量名.Count
// 了解
变量名.TryGetValue(键名,out dynamic val) 
// 清空
变量名.Clear()    
```

- 数组: 固定长度的容器,可以存储多个同类型的数据
  - 访问修改,通过下标
  - 不可以新增删除
- list集合:  增强型数组
  - List<元素类型> 
  - 通过下标访问修改
  - list方法
    - Add  向末位新增一个数据
    - AddRange  向末位新增多个数据
    - Insert(下标,数据)
    - Remove(数据)
    - RemoveAt(下标)
    - RemoveRange(下标,个数)
    - Clear 清空
    - IndexOf(数据)  查找在list第一次出现的,返回下标, 如果不存在则返回-1
    - LastIndexOf(数据)  查找在list最后一次出现的,返回下标, 如果不存在则返回-1
    - Contain(数据) 
    - GetRange(下标,个数)
    - Reverse() 翻转

## 二、运算符

### 1、关系运算

符号：`> >= < <= == !=`

也叫比较运算符,关系运算的结果是**布尔值**

```c#
// 关系运算符,比较运算符 ===> 运算结果一定是布尔值
// > >= < <= == !=
Console.WriteLine("请输入第一个数字");
int n1 = int.Parse(Console.ReadLine());
Console.WriteLine("请输入第二个数字");
int n2 = int.Parse(Console.ReadLine());
//bool res = n1 > n2;
//bool res = n1 < n2;
//bool res = n1 >= n2;
//bool res = n1 <= n2;
//bool res = n1 == n2; // 两值相等才为true
bool res = n1 != n2;  // 不相等才为true

Console.WriteLine(res);
```

### 2、逻辑运算

符号：`&& || ! & |`

短路运算和非短路运算的区别。

`&&`表示并且，连接两个条件，表示两个条件同时成立，整体才算是成立

例：小红想做车模，车模条件年龄16~22

```c#
 Console.WriteLine("请输入的年龄");
 int age = int.Parse(Console.ReadLine());
 bool res = age > 16 && age < 22;
 Console.WriteLine(res);
```

`||`表示或者，连接两个条件，表示两个条件只要有1个成立，整体就算成立

例：小明择偶标准：要么资产在300w以上，要么颜值大于9.5。输入小红的资产和颜值

```c#
Console.WriteLine("请输入资产");
int money = int.Parse(Console.ReadLine());
Console.WriteLine("请输入颜值");
double yz = double.Parse(Console.ReadLine());
bool res = money > 300 || yz > 9.5;
Console.WriteLine(res);
```

并且和或者总结：

| 符号 | 含义 | 左边  | 右边  | 整体结果 |
| ---- | ---- | ----- | ----- | -------- |
| `&&` | 并且 | True  | True  | True     |
| `&&` | 并且 | True  | False | False    |
| `&&` | 并且 | False | True  | False    |
| `&&` | 并且 | False | False | False    |
| `||` | 或者 | True  | True  | True     |
| `||` | 或者 | True  | False | True     |
| `||` | 或者 | False | True  | True     |
| `||` | 或者 | False | False | False    |

`!`取反/非：true变false，false变true

例：小明是真男人，去了一趟泰国，回来就反了

```c#
// !取反 
bool isMan = false;
isMan = !isMan;
Console.WriteLine(isMan);
```

扩展：符号的应用

```c#
// 取反应用
//Console.WriteLine("请输入的年龄");
//int age = int.Parse(Console.ReadLine());
//bool res = !(age < 16 || age > 22);
//Console.WriteLine(res);
```

扩展：短路运算

`&&`的短路运算：因为并且连接的两个条件，当左边为true的情况时，没有办法得到最终的结果，所以一定会执行右边的条件；当左边为false的时候，已经可以得到最终的结果了，右边的条件就不会执行了。

```c#
// && 短路运算
// 表达式1 && 表达式2 ===> 只要有一个是false 结果就是false
// 先执行表达式1, 如果表达式1是false,整体结果就是false 那么表达式2不会执行
int n = 0;
int num = 1;
bool res = n > num && n < num++;
// n > num 执行为false, res就是false;那么 n < num++ 不会执行
// bool res = n < num && n > num++;
//  n < num 执行为true;此时需要继续执行 n < num++
Console.WriteLine(res);
Console.WriteLine(num); // 2
```

`||`的短路运算：因为或者连接的两个条件，当左边为true的时候，已经可以得到最终的结果了，所以右边的条件就不会去执行了；当左边为false的时候，不能得到最终的结果，才会去执行右边的条件。

``` c#
// || 的短路运算
// 表达式1 || 表达式2 ===> 只要有一个是true 结果就是true
// 如果表达式1执行是true; 整体结果就是true, 那么表达式2不会执行
int n = 0;
int num = 1;
//bool res = n > num || n < num++;
//// n > num 执行为false,需要继续执行 n < num++;
bool res = n < num || n < num++;
// n < num 执行为true,不会执行 n < num++;
Console.WriteLine(num);
```

不断路的并且：`&`

```c#
// &不断路
int n = 0;
int num = 1;
bool res = n > num & n < num++;
Console.WriteLine(res);
Console.WriteLine(num);
```

不断路的或者：`|`

```c#
// |不断路
int n = 0;
int num = 1;
bool res = n < num | n < num++;
Console.WriteLine(res);
Console.WriteLine(num);
```



## 三、分支语句

### 1、分支介绍

> 我们在日常生活中，有很多事情是需要做判断的
>
> 比如说，去服装城买衣服，你看中一件衣服，老板要300元，你立马就会想，这个价格是否贵了，判断的结果只有两种可能，一是贵，二是不贵，贵了你就不买了，不贵你就买了。
>
> 再比如去网吧，网管也要判断你是否满18岁，结果也只有两种，是和否，是就上网，不是就看别人上网，
>
> 再比如，学校根据考试成绩对每个人进行评级，如果成绩大于60就合格，否则就不合格，如果成绩大于90，就优秀等等。。。
>
> 在咱们的代码中，也会有很多判断，比如咱们做的练习，小红满足条件了，就能嫁人了，不满足条件就不能嫁人。
>
> 
>
> 咱们刚才只是能看到一个布尔值，并没有进行下一步的操作，通过今天的学习就可以进行下一步的操作了，咱们今天学习的主要内容就是判断，也叫做**逻辑分支**。

判断也会有很多种，比如：

- 考试成绩大于60，及格
- 考试成绩大于60，及格，否则，不及格
- 考试成绩如果大于60并且小于80，及格，如果大于80并且小于90，良好，如果大于90，优秀

根据上述几种情况，我们把判断分为三种，根据结果只做一个件事情的，叫**单分支**，做两件事情的，叫做**双分支**，做多件事情的，叫**多分支**。

### 2、单分支

语法：

```c#
if(条件表达式){
	当条件表达式的结果为true的时候要执行的代码
}
```

例：

```c#
// 单分支
Console.WriteLine("请输入年龄");
int age = int.Parse(Console.ReadLine());
if (age >= 18)
{
    Console.WriteLine("成年了");
}

```

### 3、双分支

语法：

```c#
if(条件表达式){
	当条件表示式的结果为true的时候要执行的代码
}else{
	当条件表达式的结果为false的时候要执行的代码   
}
```

例：

```c#
// 双分支
Console.WriteLine("请输入年龄");
int age = int.Parse(Console.ReadLine());
if (age >= 18)
{
    Console.WriteLine("成年了");
}
else
{
    Console.WriteLine("未成年");
}
```

案例：输入年份，判断是否是闰年(普通闰年：能被4整除但不能被100整除/世纪闰年：可以被400整除)

```c#
Console.WriteLine("请输入年份：");
int year = int.Parse(Console.ReadLine());
Console.WriteLine("请输入年份");
int year = int.Parse(Console.ReadLine());
if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
{
    Console.WriteLine($"闰年:{year}");
}
else
{
    Console.WriteLine($"{year}不是闰年");
}
```

### 4、多分支

语法：

```c#
if(条件表达式1){
	当条件表达式1的结果为true的时候，要执行的代码
}else if(条件表达式2){
	当条件表达式2的结果为true的时候，要执行的代码
}else if(条件表达式3){
	当条件表达式3的结果为true的时候，要执行的代码
}
。。。

}else{

}
// 多分支可以有若干个else if，else根据需要可以有也可以没有
```

例：根据输入的成绩判断是不及格(小于60),及格(大于60小于80), 良好(大于80小于90),优秀(大于90小于100)

```c#
// 多分支
Console.WriteLine("请输入考试成绩(1~100)：");
double score = double.Parse(Console.ReadLine());
// 判断
if (score < 60)
{
    Console.WriteLine($"{score} - 不及格");
}
else if (score < 80)
{
    Console.WriteLine($"{score} - 及格");
}
else if (score < 90)
{
    Console.WriteLine($"{score} - 良好");
}
else if (score <= 100)
{
    Console.WriteLine($"{score} - 优秀");
}
else
{
    Console.WriteLine("重新输入(1~100)分数");
}
```

### 5、分支结构的简写方式

如果单分支或双分支以及多分支的大括号中只有一行代码的时候，大括号可以省略。

例：

```c#
// 分支结构简写
// 一般当 条件判断后需要执行的代码只有一行的时候可以简写====> 省略大括号
Console.WriteLine("请输入考试成绩(1~100)：");
double score = double.Parse(Console.ReadLine());
//判断
//if (score < 60) Console.WriteLine("不及格");
//else Console.WriteLine("及格");
if (score < 60) Console.WriteLine("不及格");
else if (score < 80) Console.WriteLine("及格");
else if (score < 90) Console.WriteLine("良好");
else if (score <= 100) Console.WriteLine("优秀");
else Console.WriteLine("请输入正确的分数");
```

### 6、分支结构的嵌套

例：定义三个变量，求出三个值中的最大值。

```c#
// 分支结构的嵌套
//定义三个变量，求出三个值中的最大值。
// 分支嵌套求3个数的最大值
int a = 5;
int b = 4;
int c = 10;
// 先比较a和b
if (a > b)
{
    // 比较a和c
    if (a > c) Console.WriteLine($"最大的是{a}");
    else Console.WriteLine($"最大的是{c}");

}
else
{
    // 比较b和c
    if (b > c) Console.WriteLine($"最大的是{b}");
    else Console.WriteLine($"最大的是{c}");

}
```

补充：if条件的结果是布尔值，所以可以将布尔值当做条件放入if的小括号中

例：

```c#
if(true){
   Console.WriteLine("真的");
}else{
    Console.WriteLine("假的");
}
```

## 四、switch分支

### 1、switch多路判断

语法：

```c#
switch(变量){
    case 值1:
        执行的代码块
    break;
    case 值2:
        执行的代码块
    break;
    。。。
    default:
        执行代码块
    break;
}
```

使用说明：

1. break表示当前分支执行后就结束switch的运行，后续swtich中的代码不再运行
2. default可以理解为判断语句中的else
3. case理解为if来判断这个变量是否等于某个值

例：输出星期几

```c#
// switch语句
// 输出星期几
Console.WriteLine("请输入1-7");
int n = int.Parse(Console.ReadLine());
switch (n)
{
    case 1:
        Console.WriteLine("星期一");
        break;
    case 2:
        Console.WriteLine("星期二");
        break;
    case 3:
        Console.WriteLine("星期三");
        break;
    case 4:
        Console.WriteLine("星期四");
        break;
    case 5:
        Console.WriteLine("星期五");
        break;
    case 6:
        Console.WriteLine("星期六");
        break;
    case 7:
        Console.WriteLine("星期天");
        break;
    default:
        Console.WriteLine("输入有误");
        break;
}
```

### 2、switch 穿透写法

如果某个case跟另一个case执行的代码是相同的，就可以省略中间执行的代码和break，将两个case执行的代码合并在一起。

例子：

```c#
// switch的穿透  ===> 当变量和值 比对为true的时候,执行代码,但是找到break,则会向下继续执行代码,直到找到break则 switch才结束
// 输出星期几  6-7输出周末
Console.WriteLine("请输入1-7");
int n = int.Parse(Console.ReadLine());
switch (n)
{
    case 1: Console.WriteLine("星期一"); break;
    case 2: Console.WriteLine("星期二"); break;
    case 3: Console.WriteLine("星期三"); break;
    case 4: Console.WriteLine("星期四"); break;
    case 5: Console.WriteLine("星期五"); break;
    case 6: // 穿透
    case 7: Console.WriteLine("周末"); break;
    default: Console.WriteLine("输入有误"); break;
}

```

当day的值为6和7的时候，使用同一段代码。

这时候可以利用switch的这个特性，简写一些代码：

输入一个月份，判断并输出这个月有多少天？

```c#
// 1,3,5,7,8,10,12 31天
// 2  ===> 28天
// 4,6,9,11 30天
Console.WriteLine("请输入月份1~12");
int month = int.Parse(Console.ReadLine());
switch (month)
{
    case 1: 
    case 3: 
    case 5: 
    case 7: 
    case 8: 
    case 10: 
    case 12: Console.WriteLine("31天"); break;
    case 2: Console.WriteLine("28天"); break;
    case 4: 
    case 6: 
    case 9: 
    case 11: Console.WriteLine("30天"); break;
    default: Console.WriteLine("输入有误"); break;
}
```

### 3、switch简写

```c#
Console.WriteLine("输入成绩：");
double score = double.Parse(Console.ReadLine());
if (score >0 && score <=100) {
    string res = score switch
    {
        //表达式 => 结果,  // 表达式中变量省略
        // _ => 结果  _ 表示default
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        >= 60 => "D",
        _ => "F"
    };
    Console.WriteLine(res);
}
else
{
    Console.WriteLine("输入有误");

}
```



## 五、三元运算

if双分支有一种简写方式：

```c#
条件?条件成立时得到的结果:条件不成立时结果;
```

例：

```c#
// 三元运算
int a = 1;
int b = 2;
int max = 0;
//if (a > b) {  max = a; } else { max = b; }
//Console.WriteLine(max);

max = a > b ? a : b;
Console.WriteLine(max);
```

这种表达双分支的方式叫做三元运算，也叫做三元表达式。

三元运算有个特点：整个表达式是一个值，可以赋值给一个变量，也可以输出

例：

```c#
// 用三元运算简写
//Console.WriteLine("请输入年龄：");
//int age = int.Parse(Console.ReadLine());
//// 判断 成年了/ 未成年
////if (age > 18) { Console.WriteLine("成年了"); } else { Console.WriteLine("未成年"); }
//string res = age > 18 ? "成年了" : "未成年";
//Console.WriteLine(res);

// 判断 闰年(能被4整除但不能被100整除,能被400整除) 平年
Console.WriteLine("请输入年份：");
int year = int.Parse(Console.ReadLine());
//if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0)
//{
//    Console.WriteLine($"{year}是闰年");
//}
//else
//{
//    Console.WriteLine($"{year}是平年");
//}
string result = year % 4 == 0 && year % 100 != 0 || year % 400 == 0 ? "闰年" : "平年";
Console.WriteLine($"{year}是{result}");

```

案例：

- 奇数偶数判断
- 是否在线
- 文件大小单位不同（1024以下kb/以上MB）
- 数学运算计算器：让用户输入两个数字，再输入一个运算符(+ - * /)，判断输入的运算符是什么，对两个数字进行对应的数学运算，将结果输出
- 不同血型不同性格：输入血型，当血型为A时，输出"细心稳重"；当血型为B时，输出"乐观自由"；当血型为AB时，输出"思维多变"；当血型为O时，输出"热情外向"



作业：

- 账号密码验证（练习分支嵌套）：账号规定是"admin"，密码规定是"123456"。让用户输入账号和密码，判断账号和密码是否正确，账号和密码都正确就输出登入成功；账号不对，就输出账号不存在；密码不对，就输出密码错误。
- 选择菜单（add/edit/del）执行操作（练习多分支和switch）：提示用户选择菜单（add/edit/del），判断输入的是add，就输出新增成功；输入的是edit，就输出编辑成功；输入的是del，就输出删除成功。
- 会员打折满1000打9折，普通用户满2000打9.5折（练习多分支和分支嵌套）：让用户输入自己的类型（VIP/USER）和消费金额，如果是VIP，判断消费金额是否达到1000，如果达到了，就输出他应该支付的金额，如果没有达到，也输出他应该支付的金额；如果是USER，判断消费金额是否达到2000，如果达到了和没有达到，都输出他应该支付的金额。
- 通过月份判断季节（练习switch的穿透写法）：用户输入月份，判断月份如果是3、4、5月份，就输出这是春季；如果是6、7、8月份，就输出这是夏季；如果是9、10、11月份，就输出这是秋季，如果是12、1、2月份，就输出这是冬季。
- 快递运费（练习多分支）：输入快递重量，单位是Kg，如果重量小于1Kg，输出快递费10元；如果重量在1Kg~5Kg之间，就输出快递费20元；如果重量超过5Kg，就输出快递费50元。
- 会员等级优惠（练习多分支和switch）：输入会员等级，等级是3~5的整数，判断等级如果是5，输出终身免运费；等级是4，输出每月可领优惠券；等级是3，输出购物打9折，否则没有福利。
- 自动售货机选商品（练习多分支和switch）：输入商品编号整数，1就输出已购买可乐；2输出已购买雪碧；3输出已购买矿泉水；否则输出无此商品。
- 速度分级（练习多分支）：输入当前速度，如果在0~30，输出低速通过；30~60输出中速通过；60~100输出高速通过；100~120输出超速通过。