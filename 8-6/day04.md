---
typora-copy-images-to: assets
---

# day04-循环

## 上节回顾

关系运算符:  `> >= < <=`

相等运算符: `== !=`

逻辑运算符: `&& || ! & |`  

​	&&短路运算符:   表达式1&&表达式2 ===> 表达式1的结果是false,表达式2不会执行

​       ||短路运算符:   表达式1||表达式2 ===> 表达式1的结果是true,表达式2不会执行

​       & | 短路写法==> 不会短路

分支结构:

​	 if语句: 

​		单分支=> if(){}

​		双分支=> if(){}else{}

​		多分支=> if(){}else if(){}.....else{}

 	switch-case语句:

​		switch(变量){

​			case 值: 代码;break;

​                	case 关系模式表达式: 代码;break;

​			case >值: 代码;break;

​                        // and or  not  逻辑模式

​                        case >值 and <值: 代码;break; 

​			default: 代码; break

​                 }

​       switch表达式:   

​	var 变量 = 变量 switch {

​		值 => 结果,

​		>值 => 结果,

​       	_ =>结果 // default

​       }

​      三元运算符 其实就是对 if双分支的简写:   var 变量 = 表达式?代码1:代码2;



引入：操场一圈是400米，在运动会的时候，2000米的跑步比赛，我们需要绕操场跑5圈，如下图：

![1564369792589](assets/1564369792589.png) 

这就是一个循环，那么，在这个过程中，其实我们动作只是跑一圈，剩下的过程只是在重复。从计算机的角度来想，我们可不可以设定一个程序，让他自动跑5圈呢？可以的，用咱们今天要学习的循环结构。循环结构的意义就是让代码重复执行。

## 一、while循环结构

### 1、语法

```shell
while(条件语句){
	条件成立重复执行的代码
}	
```

例：对女朋友说5句我爱你

```c#
// 既然是循环，咱们需要设定几个条件，首先是从哪开始，每完成一次要进行计数，完成多少次停止。
int i = 1;
while(i <= 5)
{
    Console.WriteLine("我爱你!");
    i++; // i = i+1   
}
```

while循环结构的具体流程：

![1784725305951](assets/1784725305951.png) 

拆解步骤：

1. 开始
2. 初始化：`i = 1`
3. 判断条件 `i <= 5` ✅ 成立 → 执行循环体 ❌ 不成立 → 循环结束
4. 打印 “我爱你！”
5. `i++`（i 自增 1）
6. 回到第 3 步，再次判断条件

### 2、案例

例：利用while循环中的变量输出数字1~5

```c#
// 利用while输出1-5
while (i <= 5)
{
    Console.WriteLine(i);
    i++;  
}
// i => 6
Console.WriteLine($"i => {i}");
```

例：将1-5相加

```c#
// 让1-5相加
int i = 1;
int sum = 0; // 存储累加数

//sum = sum + i;
//i++; // i=> 2

//sum = sum + i;
//i++; // i => 3

//sum = sum + i;
//i++; // i => 4

//sum = sum + i;
//i++; // i => 5

//sum = sum + i;
//i++;
while (i <= 5)
{
    sum = sum + i;
    i++;
}
// 循环结束
Console.WriteLine($"总和sum :{sum},i: {i}");
```

例：将1-10相加

```c#
// 1-10的和
int i = 1;
int sum = 0;
while (i <= 10) {                
    sum += i; // sum = sum + i;
    i++;
}
Console.WriteLine(sum);
```

例：将1-10之间的奇数加起来

```c#
int i = 1;
int sum = 0;
while (i <= 10)
{
    // 判断循环中i的值是否是奇数
    if(i%2 != 0) sum += i; // sum = sum + i;
    i++;
}
Console.WriteLine(sum);
```

例：输出50以内所有能被3整除且能被5整除的数字

```c#
int i = 1;
while (i<=50)
{
    // 判断循环中i的值 是否符合要求(能被3整除且能被5整除)
    // 能被3整除 i%3 == 0 
    // 能被5整除 i%5 == 0 
    if (i % 3 == 0 && i % 5 == 0) Console.WriteLine(i);
    i++;
}
```

例：1-5相乘

```c#
int i = 1;
int ji = 1; // 累计乘法结果
while (i <= 5)
{
    ji = ji * i;
    i++;
}
Console.WriteLine(ji);
```

例：逢7就过的游戏中，100以内所有喊过的数字

```c#
// 遇见7的倍数 就 喊 过
int i = 1;
while (i <= 100)
{
    // 判断i是否是7的倍数
    if(i%7 == 0) Console.WriteLine(i);
    //Console.WriteLine(i);
    i++;
}
```

例：求100~1000之间所有的水仙花数

> 其百位、十位、个位上的数字的 3次方之和 恰好等于这个数本身

```c#
int i = 100;
while (i < 1000)
{
    // 判断i是否是水仙花数 ===> 获取i的个十百位数字
    int ge = i % 10;
    int shi = (i / 10) % 10;
    int bai = i/100;
    if(Math.Pow(ge,3) + Math.Pow(shi , 3) + Math.Pow(bai , 3) == i)
    {
        Console.WriteLine(i);
    }
    i++;
}
```



## 二、do while循环结构

> do while 循环是while循环的变异体。
>
> 循环流程相似，唯一不同的地方在于do while循环会**先执行一次**，不管条件是否成立，先执行一次，后面的流程和while循环一样。

例：先运行后判断

```c#
int i = 1;
do {
    Console.WriteLine(i);
    i++;
} while (i > 10);
```

例：输出1-5

```c#
int i = 1;
do
{
    Console.WriteLine(i);
    i++;
}
while (i <= 5);
```

## 三、for循环结构

### 1、语法和过程

```shell
for(声明变量并赋初始值; 条件表达式; 每重复一次后变量的变化规律){
    重复执行的代码块
}
# 在语法中的声明变量并赋初始值；条件表达式可以限定重复在什么时候停止（当条件不成立的时候）；通过每次重复变量的变化和条件表达式可以知道要重复多少次
```

例：输出5句“我爱你”

```c#
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine("我爱你");
    // Console.WriteLine($"循环中 i : {i}");
}
```

执行的流程：

```txt
开始
  ↓
i = 1
  ↓
判断 i <= 5 ?
├─ false → 结束
└─ true  → 输出"我爱你"
             ↓
            i++
             ↓
          返回判断
```

如图所示：

![1784761210471](assets/1784761210471.png) 

### 2、语法扩展

#### 2.1、初始值和变化

for循环中的初始值和变化可以不放在小括号中。

```c#
// 将循环变量初始赋值 放到外部
//int i = 1;
//for (; i <= 5; i++)
//{
//    Console.WriteLine("我爱你");                
//}
//Console.WriteLine($"循环结束 i : {i}");

// 将循环变量的变化 放到 循环体中
int i = 1;
for (; i <= 5; )
{
    Console.WriteLine("我爱你");
    i++;
}
Console.WriteLine($"循环结束 i : {i}");
```

执行流程是一样的，只是写法不一样。

#### 2.2、变化规律

在循环中，变量i的变化规律可以不是递增，也可以递减，也可以不是递增1。。。总而言之，变量i的变化规律可以自定义。

```c#
for (int i = 5; i >= 1; i--)
{
    Console.WriteLine("我爱你");                
}

/*
  i = 5  ==> 条件判断 true ==> 执行输出 i-- ==> i : 4
  i = 4  ==> 条件判断 true ==> 执行输出 i-- ==> i : 3
  i = 3  ==> 条件判断 true ==> 执行输出 i-- ==> i : 2
  i = 2  ==> 条件判断 true ==> 执行输出 i-- ==> i : 1
  i = 1  ==> 条件判断 true ==> 执行输出 i-- ==> i : 0
  i = 0  ==> 条件判断 false 循环结束             
 */
```

例：倒着输出1-10

```c#
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}
```

例：输出1-10之间的偶数

```c#
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0) Console.WriteLine(i);
}

// 最小的偶数是2   连续的偶数之间相差2
for (int i = 2; i <= 10; i+=2)
{
     Console.WriteLine(i);
}
```



### 3、案例

例：while的例子

例：入职薪水10K，每年涨幅5%，50年后工资多少？

```c#
double money = 10;

// 后一年的薪水 公式
//money = money + money * 0.05;
int year = 1;            
while (year <= 50)
{
    money = money + money * 0.05;                
    //money *= 1.05;
    year++;
}
Console.WriteLine($"50年后的工资{money}");
```

例：遍历List

```c#
//遍历List：每一个都经历一次
List<string> strList = new()
{
    "aa",
    "bb",
    "ccc",
    "dd",
    "eee"
};
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(strList[i]);
}
```

例：求int型List的所有数据之和

```c#
//求int型List的所有数据之和
List<int> intList = new()
{
    3,
    5,
    7,
    2,
    9
};
int sum = 0;// 存储和
for (int i = 0; i < intList.Count; i++)
{
    //intList[i] 循环过程中 去到每一个集合数据 
    sum += intList[i];
}
Console.WriteLine(sum);
```

提醒：遍历List的时候，条件小于List的数量即可（`List.Count`），这样不用肉眼数List中数据的个数。

## 四、循环中的关键字

在循环有两个关键字可以改变循环执行的流程。

### 1、continue

continue关键字，可以跳过当前这次的循环，进入下一次的循环。

```c#
// 循环控制 continue
for (var i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        continue; // 跳过本次循环
    }
    Console.WriteLine(i);
}
```

continue执行的流程：

![1784761969687](assets/1784761969687.png) 

例：判断一个数是否是素数 (素数，就是除了1和自己本身，不能被别的数整除)

```c#
// 判断一个数是否是素数 (素数，就是除了1和自己本身，不能被别的数整除)
// 素数，就是除了1和自己本身，不能被别的数整除
int m = 11; // 判断m是否是素数
string s = "黑色"; // 开关
// 循环1~9的每个数字, 并判断是否可以将m整除, 如果可以 则将s 改为"白色"
for (int i = 1; i <= m; i++)
{
    // 如果i是 1 或者m本省 则跳过循环
    if (i == 1 || i ==m) {
        continue;
    }
    // 判断i能否将m整除
    if(m % i == 0)
    {
        s = "白色";
    }
}
// 循环结束后 ==> 判断s的值, 如果是 "黑色" 说明m是素数
// 如果s 是 白色 说明m不是素数
if(s == "黑色")
{
    Console.WriteLine($"{m}是素数");
}
```



### 2、break

break关键字，可终止循环，让整个循环结束。

```c#
 for (var i = 1; i <= 5; i++)
 {
     if (i == 3)
     {
         break; // 结束整个循环===>for的后续循环结束
     }
     Console.WriteLine(i);
 }
```

break执行的流程：

![1784762033722](assets/1784762033722.png) 

## 五、foreach循环结构

专门遍历数组、List。

语法：

```c#
foreach(元素类型 变量 in 集合)
{
    代码段;
}
```

例：

```c#
//foreach 遍历数组
//int[] intArr = { 10, 20, 30, 40};
//foreach (int item in intArr)
//{
//    // item表示 每次循环 从intArr中拿到的数据
//    Console.WriteLine(item);
//}

// 数组数据求和
//int[] intArr = { 10, 20, 30, 40 };
//int sum = 0;
//foreach (int item in intArr)
//{
//    // item表示 每次循环 从intArr中拿到的数据
//    //Console.WriteLine(item);
//    sum += item;
//}
//Console.WriteLine(sum);


// foreach 遍历 List集合
//List<string> strList = new List<string>() { "h", "e", "l", "l", "o" };
//foreach (string a in strList) {
//    Console.WriteLine(a);
//}

// 拼接 strList集合的数据
//List<string> strList = new List<string>() { "h", "e", "l", "l", "o" };
//string res = "";
//foreach (string a in strList)
//{
//    //Console.WriteLine(a);
//    res += a;
//}
//Console.WriteLine(res);

// foreach 遍历字典
//Dictionary<string, dynamic> userInfo = new Dictionary<string, dynamic>()
//{
//    ["name"] = "Tom",
//    ["age"] = 5,
//    ["gender"] = 1,
//    ["hobby"] = "jerry",
//};
//foreach (var item in userInfo)
//{
//    // item 是每组数据
//    Console.WriteLine(item);
//}
```



## 六、循环嵌套

代码段中可以写循环代码，就会形成循环嵌套。

例：5个人，每个人都跑5圈

```c#
for (int j = 1; j <= 5; j++)
{
    //Console.WriteLine($"第{j}个人");
    for (int i = 1; i <= 5; i++)
    {
        Console.WriteLine($"第{j}个人 跑第{i}圈");
    }
}
```

例：输出5行星号，每行5个

```c#
for (int j = 1; j <= 5; j++)
{
    for (int i = 1; i <= 5; i++)
    {
        Console.Write("*"); // 一行输出的*
    }
    Console.WriteLine(); // 一行结束 (换行)
}
```

例：用星号输出直角三角形

```c#
// 用星号输出直角三角形
for (int j = 1; j <= 5; j++)
{
    //Console.Write(j+ "  ");
    for (int i = 1; i <= j; i++) // 内层循环控制了这一行输出的个数(循环次数)
    {
        Console.Write("*"); // 一行输出的*
    }
    Console.WriteLine(); // 一行结束 (换行)
}
```

例：输出九九乘法表

```c#
for (int j = 1; j <= 9; j++)
{
    //Console.Write(j+ "  ");
    for (int i = 1; i <= j; i++) // 内层循环控制了这一行输出的个数(循环次数)
    {
        Console.Write($"{i}*{j}={i*j}\t"); // 一行输出的*
    }
    Console.WriteLine(); // 一行结束 (换行)
}
```

## 七、作业

1. 计算100以内偶数的和

2. 显示出1000-2000年中所有的闰年，并以每行四个数的形式输出

3. 输出一个倒三角形，如下

   ![左上半三角形](https://upload-images.jianshu.io/upload_images/12363089-3df1e9ac5ab8b02c.png?imageMogr2/auto-orient/strip|imageView2/2/w/159/format/webp) 

4. 用循环计算下面的结果

   ```c#
   1 - 1/2 + 1/3 - 1/4 + ... - 1/100
   ```

5. 求20以内所有数字的阶乘的和

6. 篮球从5米高的地方掉下来，每次弹起的高度是原来的30%，经过几次弹起，篮球的高度小于0.1米。

7. 有一个棋盘，有64个方格，在第一个方格里面放1粒芝麻重量是0.00001kg，第二个里面放2粒，第三个里面放4，棋盘上放的所有芝麻的重量

8. 某人在银行有50000元存款。银行每月都要收取服务费，存款大于5000元时每个月收取总额的5%，总额不大于5000元的时候不收服务费；假设这个人存了以后从来都不用，用循环计算银行要扣这个人的手续费能扣多少次？每次扣取后剩余多少钱？

9. 猴子摘桃，猴子摘了x个桃，每天吃一半，再多吃一个，第7天吃的时候剩下一个了，猴子摘了多少桃子？

10. 有个皮球，每次落地弹起都是高度的一半，如果从10米高的地方丢下，第十次弹起时，皮球总过经历了多少距离。


