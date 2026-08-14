---
typora-copy-images-to: img
---

# day09

## 上节回顾

- 函数:  可以将代码封装起来,后续可以重复调用,而且调用的时候才执行其中的代码

  - 函数定义方法

    ```C#
    var 变量 = ()=>{}
    返回值类型 变量 (){}
    Action<T> 变量 = ()=>{}  // 函数没有返回值
    Func<T,..,TResult> 变量 = ()=>{}  // 函数有返回值
    Func<T,..,TResult> 变量 = delegate(){}  // 函数有返回值
    ```

  - 函数的参数: 参数->形参和实参

    - 形参是定义函数时候书写的, 可以在函数内使用的变量
    - 实参是函数调用实际给形参传递的值
    - 可选参数:  可以给形参默认值, 具有默认值的参数就是可选参数
    - 命名参数:  函数调用时候 (参数名:值,...)   此方式传参可以不按顺序

- 函数调用: 函数名()

- 函数返回值

  - 在函数内通过 `return` 可以给函数的执行一个结果
  - 函数内的`return` 会结束函数代码的执行(结束函数)

- 作用域:  变量可以使用的区域

  - 变量使用:  变量定义, 变量的访问,变量的访问
  - 在C#中 任何的 `{}` 都会限制变量的使用范围
    - 在`{}`定义的只能在这个`{}`中使用,这个`{}`就是对应的作用域
    - 当使用变量的时候, 那会现在当前作用域查找,找到了使用, 如果找不到这往上一层查找,找到了就使用,如果找不到就继续往上.....到最后还是找到就报错

- 异常捕获

  ```C#
  try{}catch(异常类型){}
  try{}catch(异常类型){}....catch(异常类型){}
  try{}catch(异常类型){}finally{一定会执行}
  
  // 手动抛出异常
  throw new 异常类型();
  ```



## 一、委托

作为老板的你，年底了想办一场年会。但是你不知道具体该请哪个明星，或者你太忙了没时间亲自去联系。
于是，你找了一个中介（经纪人）。你对这个经纪人说：‘只要符合唱歌这个标准的，你都可以帮我联系。第二天，经纪人可能给你找来周杰伦，也可能找来陈奕迅。你不在乎具体是谁，你只在乎：他得能唱歌，而且只能唱一首（**参数**和**返回值**要匹配）。

> 在 C# 里，**委托（Delegate）**就是这个经纪人或中介。它本身不干活，它只是把方法(函数)当作参数传递，或者把方法(函数)存起来以后调用。



**为什么要用委托**

在 C# 里，我们习惯了传递 `int`、`string` 这些数据。但是，函数（行为）能不能像数据一样传递呢？

比如：你要写一个排序方法。有时候你想按价格排，有时候想按名字排。难道你要写 `SortByPrice()`、`SortByName()`、`SortByAge()` ...... 要写这么多方法吗？

不，只需要一个 `Sort()`，然后把**怎么比较这个规则（方法函数）** 传进去。这就是委托的核心价值：**行为参数化**。

> 委托是一种安全地封装方法的类型，它与 C/C++ 中的函数指针类似，但它是类型安全的。



**委托概念**

1. 委托是类型：就像 `int`、`string` 一样，需要定义。
2. 委托代表方法函数：它不存数据，它存的是方法函数的引用。
3. 签名必须匹配：即返回值类型、参数个数、参数类型，必须一致。
   - 就像中介只找歌手，你不能找个厨师给他



#### 委托实现

>需要先定义委托,即定义函数类型;  然后才能声明函数使用

```C#
// 1. 定义委托(定义函数类型)
delegate void MyDelegate(string msg); // 注意不能写在方法函数中

// 2. 准备函数方法(给委托类型使用的)
void SayHello(string name){ Console.WriteLine($"Hello, {name}"); }
void SayBye(string name) { Console.WriteLine($"Bye, {name}"); }

// 3. 使用
MyDelegate del = SayHello;  // 绑定方法
del("Tom");                 // 调用

del = SayBye;               // 换人
del("Jerry");               // 调用
```

> 上面的写法是传统的写法,需要写`delegate void MyDelegate(string msg);`比较麻烦,
>
> 所以 在 C# 2.0 以后，直接用 **Action** 和 **Func**。
>
> Action<T>：有参数，没返回值。（只干活）
>
> Func<T, TResult>：有参数，有返回值。（干活＋算结果）

```C#
//  准备函数方法(给委托类型使用的)
void SayHello(string name){ Console.WriteLine($"Hello, {name}"); }
void SayBye(string name) { Console.WriteLine($"Bye, {name}"); }

//  使用
Action<string> del = SayHello;  // 绑定方法
del("Tom");                 // 调用

del = SayBye;               // 换人
del("Jerry");               // 调用
```



#### 多播

> 委托的特点
>
> 普通变量只能存一个值，但委托可以存多个方法函数。用 `+` 号连起来，一调用，全执行。

```C#
//  准备函数方法(给委托类型使用的)
void SayHello(string name){ Console.WriteLine($"Hello, {name}"); }
void SayBye(string name) { Console.WriteLine($"Bye, {name}"); }

//  使用
Action<string> del = SayHello;  // 绑定方法
del += SayBye;      // 追加         
del("Jerry");
```







## 二、值类型-引用类型

> 内存分为栈 和 堆
> 栈（Stack）：速度快，存放变量、临时数据；
> 堆（Heap）：用来存放引用类型完整对象。

### 值类型

> int、double、float、bool、char、byte、short、long、decimal、struct（结构体）等
>
> 以上类型的数据都属于值类型

**值类型的特点**

1. 变量直接保存数据，数据存在栈内存；
2. 赋值操作：完整拷贝一份数据副本；
3. 修改其中一个变量，不会影响另一个变量；
4. 重新赋值：直接覆盖当前内存里存储的数据。

```C#
int a = 100;
int b = a;   // 把a里面的数据100，复制一份给b
b = 200;     // 只修改b自己的数据
Console.WriteLine(a); // 输出：100
```



### 引用类型

> string、数组、class（自定义类）、List<T>、Dictionary<TKey,TValue> 等
>
> 以上类型的数据都属于引用类型

**引用类型的特点**

1. 栈上的变量只存地址；真正的数据，存放在堆内存；
2. 赋值操作：只复制地址，不复制整个数据；
3. 多个变量可以保存同一个地址，指向堆上同一个数据；
4. 变量重新赋值，指向堆里另一个新数据；
5. 旧数据没有任何变量指向时，等待GC垃圾回收清理。

> 注意:  string 是引用类型，但表现很特殊！
> 字符串**不可变**，一旦创建不能修改，任何 修改字符串 本质都是新建对象。

```C#
nt[] arr = [10, 20, 30];
int[] newArr = arr; // 将数组存储的地址 复制一份给了变来那个newArr
newArr[0] = 666;    // 根据newArr的地址 找到了堆内存 那个数组数据 根据索引修改数据
Console.WriteLine(arr[0]); // 666  

newArr = [100, 200, 300];  // 在堆内存中开辟一个空间存储[100, 200, 300] 数组数据, 并将地址赋值给newArr变量
Console.WriteLine(newArr[0]);// 100

string str1 = "ABCD";
str1 = "efgh";
```

> 代码内存示意图

![1786591709675](img/1786591709675.png)

## 三、函数参数

### 可选参数

>  定义函数时给参数设置默认值，调用时可以不传这个参数，自动使用默认值。
>
> 函数参数书写注意事项:  必选参数 只能在 可选参数之前



### 命名参数

>  调用函数时直接写`参数名：值`，不用严格遵守参数顺序传参。



### 可变数量参数

> `params` 可变参数：允许调用方法时，传入任意个数同类型参数，编译器自动把这些参数打包成数组。
>
> 语法:  函数名(params 类型[] 变量)
>
> 注意: params 必须写在参数列表的最后一位, 且只能有一个

```C#
// 定义函数 可以实现任意个数字的求和
 var getSum = (params int[] args) =>
 {
     int sum = 0;
     foreach (var item in args) sum += item;
     return sum;
 };

 Console.WriteLine(getSum(1));
 Console.WriteLine(getSum(1, 2));
 Console.WriteLine(getSum(1, 2, 3));
 Console.WriteLine(getSum(1, 2, 3, 4));

 var fn = (int n1, int n2, params int[] args) =>
 {
     //Console.WriteLine(n1 + n2);
     foreach (var item in args) Console.Write(item + " ");
     Console.WriteLine();
 };

 fn(10, 20);
 fn(10, 20, 30);
 fn(10, 20, 30, 40);
```



### ref  和 out

#### ref 引用传递参数

##### 什么是引用传递参数

C# 默认方法参数是**按值传递**，传递的是数据副本，方法内修改副本，不会影响外部原始变量。

```csharp
void DoubleIt(int x)
{
    x = x * 2; 
}
int num = 5;
DoubleIt(num);
Console.WriteLine(num); 
```

在参数前添加 `ref`，代表**按引用传递**：
方法接收外部变量的内存地址，参数 `x` 和外部变量 `num` 指向**同一块内存**，方法内修改参数，直接改动外部原始变量。

```csharp
void DoubleIt(ref int x)
{
    x = x * 2; 
}
int num = 5;
DoubleIt(ref num); 
Console.WriteLine(num); 
```

> 通俗总结：**不带ref传副本；带ref传变量本体，修改互通。**

##### ref 常用场景

- 允许方法修改外部变量

```csharp
// 交换两个数字
void Swap(ref int a, ref int b)
{
    int tmp = a;
    a = b;
    b = tmp;
}

int n = 10;
int m = 100;
Swap(ref n, ref m);
Console.WriteLine(n);
Console.WriteLine(m);
```

##### 引用类型参数 + ref 

- 引用类型按值传递

```csharp
void ModifyList(List<int> list)
{
    list.Add(999);               // 修改堆中对象内容，外部可见
    list = new List<int>();      // 仅仅修改内部副本的地址，外部不受影响
    list.Add(888);
}
var myList = new List<int> { 1, 2, 3 };
ModifyList(myList);
Console.WriteLine(string.Join(", ", myList));
// 输出：1, 2, 3, 999
```

- 引用类型参数加上 `ref` 之后

  > 传递的是**外部变量的地址**，方法内可以直接修改外部变量保存的地址，让外部变量指向全新对象。

```csharp
void ModifyList(ref List<int> list)
{
    list.Add(999);
    list = new List<int>();      // 直接修改外部myList的指向
    list.Add(888);
}
var myList = new List<int> { 1, 2, 3 };
ModifyList(ref myList);
Console.WriteLine(string.Join(", ", myList));
// 输出：888
```



> 注意：string 是特殊引用类型，字符串不可变，任何“修改字符串”都会生成新对象，表现近似值类型。



#### out 输出参数

##### 什么是 out 参数

`out` 和 `ref` 机制类似，都是传递变量地址，允许方法修改外部变量。
定位：**专门用来从方法输出多个返回值**。
编译器强制约定：参数是用来向外输出数据，**方法内部必须给out参数赋值**。

基础示例：

```csharp
void GetNameAndAge(out string name, out int age)
{
    name = "小明"; 
    age = 20;
}

string n;
int a;
GetNameAndAge(out n, out a); 
Console.WriteLine($"{n} 的年龄是 {a}");
```

##### ref VS out 核心对比表

| 对比特性     | ref                                  | out                            |
| ------------ | ------------------------------------ | ------------------------------ |
| 调用前变量   | **必须初始化赋值**                   | 可以不初始化                   |
| 方法内部赋值 | 不强制，可以只读、只改               | **强制必须赋值**               |
| 数据流向     | 双向（有进有出：数据传入，也可传出） | 单向（只出不进，侧重输出结果） |
| 典型用途     | 双向交互、交换变量、大型结构体优化   | 实现方法返回多个结果           |

##### 小结

ref：带进去，还能改回来，进出两用；
out：只管往外输出，方法里面一定要赋值。



## 四、lambda表达式

>  Lambda 表达式就是用来快速创建匿名委托的极简语法。它的本质还是委托，只是写法更酷、更简洁了。
>
>  Lambda 表达式：  (参数) => {函数体  }  所以也叫 箭头函数

#### 极致的简写规则

> C# 允许你把 Lambda 缩写到极致，但必须遵守以下规则:

   	1. 只有一个参数时，可以省略小括号
   	2. 方法体只有一行时，可以省略大括号和 return
   	3. 如果函数体有多行，大括号和 return不能省略

```C#
// lambda表达式  也叫箭头函数 ===> 对匿名函数的简写
// delegate 创建匿名函数, 现在可以使用箭头函数 简写(改写)
// 箭头函数:   (参数) => {函数体  }
//var fn = delegate () { };
//var fn = () => { };

//var ff = (int n, int m) =>
//{
//    return n + m;
//};
//Console.WriteLine(ff(10, 20));

//var f1 = (int n) =>
//{
//    return n + 10;
//};
// 简写1 省略小括号(只有一个参数)
//Func<int, int> f1 = n =>
//{
//    return n + 10;
//};
//Console.WriteLine(f1(10));
// 简写2 省略大括号和return (前提函数代码只有一样,且这行就是返回值)
//Func<int, int> f1 = n => n + 10;
//Console.WriteLine(f1(10));

//Func<int, int> f1 = n =>
//{
//    int m = n + 100;
//    return m + 10;
//};
```





## 五、元组

> 它是**轻量级、高性能**的数据结构
>
> 作用：**把多个不同/相同类型的值打包成一个复合对象**。
> 优势：不需要专门定义 class / struct，书写简洁，可读性强。



### 基础声明、访问

####  创建访问

```csharp
// 打包4个不同类型数据
var a = (1, true, 3.14, "C#");

// 使用 Item序号 访问成员
Console.WriteLine(a.Item1); // 1
Console.WriteLine(a.Item4); // C#
```

> 元组是可变的（可修改）

```csharp
a.Item1 = 99;
Console.WriteLine(a.Item1); // 99
```



#### 单个元素的元组特殊写法

```csharp
var singleTuple = new ValueTuple(1);  
var justNumber = (1);    // 仅仅是数字1，不是元组
```



#### 元组元素命名

可以给元组每一项自定义名字，不再依靠 Item1、Item2。
方式1：字面量直接命名

```csharp
var person = (Id: 101, Name: "李逵", Age: 33);
Console.WriteLine(person.Id);
Console.WriteLine(person.Name);
Console.WriteLine(person.Age);
```

方式2：显式声明元组类型+名称

```csharp
(int Id, string Name) product = (205, "Apple");
Console.WriteLine(product.Name);
```



### 元组最常用四大场景

#### 场景1：函数方法返回多个值（最经典用途）

> C# 中 `return` 默认只能返回1个结果；
> 元组可以轻松实现**一个方法返回多组数据**，替代老旧的 out/ref 参数。

```csharp
// 返回：年龄、性别、是否成年
(int age, string gender, bool isAdult) GetPersonInfo()
{
    Console.Write("请输入年龄：");
    int age = int.Parse(Console.ReadLine());
    Console.Write("请输入性别：");
    string gender = Console.ReadLine();
    bool isAdult = age >= 18;
    return (age, gender, isAdult);
}
```



#### 场景2：解构赋值

> 把元组快速拆分，赋值给多个独立变量。

```csharp
// 接收元组，直接解构
var (age, gender, isAdult) = GetPersonInfo();
Console.WriteLine($"年龄:{age},性别:{gender},是否成年:{isAdult}");
```

> 占位符 `_` 忽略不需要的数据

```csharp
var (age, _, isAdult) = GetPersonInfo();
// 不需要gender，使用下划线舍弃
```

普通元组也可以直接解构：

```csharp
var (x, y) = (1, 2);
Console.WriteLine($"x={x}, y={y}");
```



#### 场景3：元组作为方法参数

```csharp
// 参数类型：命名元组
void PrintPerson((string Name, int Age) person)
{
    Console.WriteLine($"姓名：{person.Name}，年龄：{person.Age}");
}
// 调用
PrintPerson(("赵六", 22));
```



#### 场景4：配合集合 List / Dictionary 使用

> 适合存储一组简易关联数据，不用新建类。

```csharp
// 集合存放命名元组
List<(string Name, int Score)> students = new List<(string Name, int Score)>
{
    ("小明", 95),
    ("小红", 87),
    ("小刚", 76)
};
students.Add(("小王", 90));

// 遍历同时解构
foreach (var (Name, Score) in students)
{
    Console.WriteLine($"{Name}: {Score}");
}
```







函数补充：

Func给函数定义类型时，这个函数不可以使用out将数据从参数传到函数外面。

```c#
// Func和out参数传递结果数据
Func<double, double, double, double, double> GetScore = delegate (double score1, double score2, double score3, out double sum) // 飘红，说参数不能使用out
{
    // 计算总分
    double a = score1 + score2 + score3;
    // 计算平均分
    double avg = a / 3;
    // 将结果返回 ==> 平均分
    sum = a;
    return avg;
};
var avg = GetScore(11, 12, 13, out double sum); // 飘红，参数不能使用out
Console.WriteLine(avg);
Console.WriteLine(sum);
```

如果既要返回值又要out传递数据的时候，就使用函数的另一种定义方式：

```c#
// Func和out参数传递结果数据
double GetScore (double score1, double score2, double score3, out double sum)
{
    // 计算总分
    sum = score1 + score2 + score3;
    // 计算平均分
    double avg = sum / 3;
    // 将结果返回 ==> 平均分
    return avg;
};
var avg = GetScore(11, 12, 13, out double sum);
Console.WriteLine(avg);
Console.WriteLine(sum);
```

## 六、回调函数

回调函数：函数是可以传递参数的，参数可以是任意数据类型，函数也有类型，可以把函数理解成变量，函数也可以作为另一个函数的参数。作为参数使用的这个函数 ==> 回调函数。

```c#
Func<int, int, int> Sum = delegate (int a, int b)
{
    int c = a + b;
    return c;
};

Func<int, int, int, Func<int, int, int>, double> Avg = delegate (int a, int b, int count,Func<int, int, int> sumFunc) {
    int sum = sumFunc(a ,b);
    double avg = (double)sum / count;
    return avg;
};
double avg = Avg(1, 3, 2, Sum);
Console.WriteLine(avg);
```





## 七、List高级方法

Find：找第一个满足条件的元素

```c#
结果 = List.Find((item) => { // item表示遍历出来的每个元素
    return 条件; // return一个布尔值 
});
// 结果是条件第一次为true的时候的item
```

例：

```c#
// Find方法返回值: 找第一个满足条件的元素
// 要求传入的函数比如有 返回 布尔值(条件判断) 
//   - 如果找到了满足条件的元素则 传入的函数不在继续执行
List<int> list2 = [100, 200, 300, 400, 500, 300];
int res = list2.Find(item =>
{
    //Console.WriteLine("find");
    //return 条件;
    //return item == 200;
    //return item > 200;
    return item > 2000;
});
Console.WriteLine(res);
```

FindLast：找最后一个满足条件的元素

语法：

```c#
结果 = List.FindLast(item => 条件);
```

例：

```c#
// 传入的函数会 按照list元素从后往前依次执行
List<int> list3 = [100, 200, 300, 400, 500, 600];
int res = list3.FindLast(item =>
{
    //Console.WriteLine(item);                
    //return item == 200;
    return item > 200;
    //return item > 2000;
});
```

FindAll：找所有满足条件的元素

语法：

```c#
结果 = List.FindAll(item => 条件); // 结果的类型跟原List一样
```

例：

```c#
// 返回值是找到满足条件的所有元素组成的list 类型和原list一样
List<int> list4 = [100, 200, 300, 400, 300, 400, 600];
var res = list4.FindAll(item =>
                        {
                            return item > 200;
                        });
Console.WriteLine(JsonSerializer.Serialize(res));
```



FindIndex：找第一个满足条件的元素下标

语法：

```c#
int 下标 = List.FindIndex(item => 条件);
// 找不到就返回-1
```

例：

```c#
List<int> list5 = [100, 200, 300, 400, 300, 400, 600];

var resIndex = list5.FindIndex(item =>
{
    //return item > 300;
    return item > 3000;

});
Console.WriteLine(resIndex);
```



FindLastIndex：找最后一个满足条件的下标

语法：

```c#
int 下标 = List.FindLastIndex(item => 条件);
// 找不到就得到-1
```

例：

```c#
List<int> list6 = [100, 200, 300, 400, 300, 400, 600];
var resIndex2 = list5.FindLastIndex(item =>
{
    return item < 400;                
});
Console.WriteLine(resIndex2);
```



Exists：判断是否有满足条件的元素

语法：

```c#
bool 结果 = List.Exists(item => 条件);
// 只要有一个元素满足条件，就会得到true，一个都没有就得到false
```

例：

```c#
 List<int> list7 = [100, 200, 300, 400, 300, 400, 600];
 bool resBool = list7.Exists(item =>
 {
     //Console.WriteLine(item);
     return item > 200;
     //return item < 200;
     //return item > 500;
     //return item > 700;
 });
 Console.WriteLine(resBool);
```

TrueForAll：判断是否所有元素都满足条件

语法：

```c#
bool 结果 = List.TrueForAll(item => 条件);
// 当所有元素都满足条件是才会得到True，只要有一个不满足条件就会得到False
```

例：

```c#
List<int> list8 = [100, 200, 300, 400, 300, 400, 600];
bool resBool2 = list8.TrueForAll(item =>
{
    Console.WriteLine(item);
    return item < 300;
    //return item < 5000;
});
Console.WriteLine(resBool2);
```

ForEach：遍历

语法：

```c#
List.ForEach(item => {
    
})
```

例：

```c#
//list.ForEach(函数)
//list.ForEach((item) =>
// {
//     遍历 逐次执行传入的这个函数, 并且会将list中的数据依次作为这个函数的参数传递
// })
List<int> list1 = [100, 200, 300, 400, 500, 300];
Action<int> fn = n => Console.WriteLine(n);
list1.ForEach(fn);

list1.ForEach(n => Console.WriteLine(n));
```

ConvertAll：将List中每个元素都返回新元素组成新List

语法：

```c#
新的list = 原本list.ConvertAll(item => 处理item，返回新的item);
```

例：

```c#
// ConvertAll: 会根据list中的数据 依次执行传入的函数,并将每次函数执行的返回值 作为新list的元素
List<int> list9 = [100, 200, 300, 400];
List<int> newList = list9.ConvertAll(item =>
{
 //Console.WriteLine(item);
return item/2;
});
Console.WriteLine(string.Join(",",newList));
```

RemoveAll：删除所有满足条件的元素，返回删掉的个数, 删除原list

语法：

```c#
List.RemoveAll(item => 条件); 
```

例：

```c#
List<int> list10 = [100, 200, 300, 400];
//var resCount = list10.RemoveAll(item => item > 200);
var resCount = list10.RemoveAll(item => item > 300);
Console.WriteLine(resCount);
Console.WriteLine(string.Join(",", list10));
```

Sort：排序

```c#
list.Sort((a, b) => a["age"] - b["age"]);
```

例：

```c#
list11.Sort((int n, int m) => { return n - m; });
Console.WriteLine(string.Join(",", list11));
list11.Sort((int n, int m) => { return m - n; });
Console.WriteLine(string.Join(",", list11));
```

IndexOf：元素第一次出现的下标

LastIndexOf：元素最后一次出现的下标

```c#
List<Dictionary<string, dynamic>> list = new() {
    new Dictionary<string, dynamic>(){
        ["name"] = "zs",
        ["age"] = 29,
        ["isMan"] = true,
        ["isSingle"] = true,
        ["salary"] = 4200
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "ls",
        ["age"] = 20,
        ["isMan"] = false,
        ["isSingle"] = true,
        ["salary"] = 3400
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "ww",
        ["age"] = 19,
        ["isMan"] = true,
        ["isSingle"] = false,
        ["salary"] = 6000
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "zl",
        ["age"] = 14,
        ["isMan"] = false,
        ["isSingle"] = true,
        ["salary"] = 2000
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "sq",
        ["age"] = 35,
        ["isMan"] = true,
        ["isSingle"] = false,
        ["salary"] = 7000
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "zb",
        ["age"] = 27,
        ["isMan"] = false,
        ["isSingle"] = true,
        ["salary"] = 2900
    },
};

// 作业1
// Find: 要求查找年龄小于20的

// FindLast: 要求查找年龄大于25的

// FindAll: 找出性别男的

// FindIndex: 找出薪水大于5000

// FindLastIndex: 找出薪水小于3000

// Exists: 判断是否有薪水大于5000

// ForEach: 输出每个的 名字-年龄-薪水

// ConvertAll: 映射得到一个所以薪水的list

//TrueForAll: 判断是否都成年

// IndexOf

// LastIndexOf
```

 作业2:  封装一个函数 接收一个字符串; 返回一个字典,键是字符串的每个字符,键值是这个字符在字符串中出现的次数







## 八、IO操作

### 1、文件操作

```c#
// 读取全部文本
string text = File.ReadAllText("book.json");

// 写入全部文本（覆盖）
File.WriteAllText("book.json", jsonStr);

// 追加文本，不会覆盖原有内容
File.AppendAllText("log.txt", "新增日志");

// 判断文件是否存在
bool exist = File.Exists("book.json");

// 删除文件
File.Delete("test.txt");

// 复制文件
File.Copy("a.txt","b.txt");

// 移动/重命名文件
File.Move("old.txt","new.txt");
```

例：

```c#
// IO文件操作            
// 文件路劲: 绝对路径和相对路径
// 绝对路径:  按照文件在计算机中存储的位置,根据盘符一直到文件所在位置
// 相对路径:  程序执行所在位置目录 相对去找到的文件路径
//  相对路径中:
//      ./  表示在当前目录下的
//      ../ 表示在上一级目录下的
//      ../../  ====> 上一级的上一级目录
// 路径中的路径   \ 和 /
// winodws系统下 \
// unix/linux 下的  /
// 字符串中的  \ 具有转义作用: 可以将一些字符转义为具有特殊含义的字符 比如: \t  \n
// 在字符换串前使用@ 修饰  那么字符中的\就不会转义
//Console.WriteLine("aaaanbbbb");
//Console.WriteLine("aaaa\nbbbbcccddd");
//Console.WriteLine(@"aaaa\nbbbbcccddd");

// 读文件,参数  文件路径; 以字符串的形式 返回读取的内容
// 如果找不到文件则报错
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\test.log";
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\test666.log";
//var path1 = "./test.log";
//var res = File.ReadAllText(path1);
//Console.WriteLine(res);
//Console.ReadLine();

// WriteAllText写文件==> 向文件中写入数据(覆盖式写入)
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\test.log";
//File.WriteAllText(path1,"hello");

// 如果文件不存在则会创建文件  并写入内容
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\day10.log";
//File.WriteAllText(path1,"hello");

// 如果目录不存在 则报错
//var path1 = @"C:\Users\leon\Desktop\10\04-\day10.log";
//File.WriteAllText(path1,"hello");

// AppendAllText 追加文件内容, 不会覆盖
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\day10.log";
//File.AppendAllText(path1,"C# is very good! \n");

// 如果文件不存在,会创建然后写入
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\error.log";
//File.AppendAllText(path1, "C# is very good! \n");


// Exists判断文件是否存在
//File.Exists(文件路径)
//bool res = File.Exists(@"C:\Users\leon\Desktop\10day\04-资料\error.log");
//bool res = File.Exists(@"C:\Users\leon\Desktop\10day\04-资料\error66.log");
//Console.WriteLine(res);

// Copy 复制文件 (如果复制后的文件已经存在,则报错)(同名报错)
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\error.log";
////var newpath = @"C:\Users\leon\Desktop\10day\04-资料\err.log";
//var newpath = @"C:\Users\leon\Desktop\10day\04-资料\err666.log";
//File.Copy(path1,newpath);

// Delete 删除文件
//var path2 = @"C:\Users\leon\Desktop\10day\04-资料\err666.log";
//File.Delete(path2);

// Move 移动文件
//var path1 = @"C:\Users\leon\Desktop\10day\04-资料\err.log";
//var path2 = @"C:\Users\leon\Desktop\10day\04-资料\data\err999.log";
//File.Move(path1, path2);

// 书写函数 实现写入日志操作, 日志内容: 输入内容+日期

```



### 2、目录操作

```c#
// 判断文件夹是否存在
Directory.Exists("Data");
// 创建文件夹
Directory.CreateDirectory("Data");
// 删除文件夹
Directory.Delete("Data");
// 获取文件夹内所有文件路径
string[] files = Directory.GetFiles("Data");
// 获取文件下所有目录
string[] dirs = Directory.GetDirectories(path);
// 获取文件下所有目录（包括子目录）
string[] allDirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
```

参数2：

```c#
// 匹配所有文件夹
GetDirectories(path, "*", ...);

// 匹配名字以book开头的文件夹，例如 book01、bookdata
GetDirectories(path, "book*", ...);

// 匹配名称一共4位，前三位是log，后面任意2字符：log01、logaabb
GetDirectories(path, "log??", ...);

// 例：
// 文件夹筛选
Directory.GetDirectories(path, "data*", SearchOption.TopDirectoryOnly);
// 文件筛选
Directory.GetFiles(path, "*.json", SearchOption.TopDirectoryOnly);

```

参数3：`SearchOption.TopDirectoryOnly` 默认值：只查找一级目录

例:

```C#
// 目录操作(文件夹)
// 判断目录是否存在
//bool isExists = Directory.Exists("./data");
//Console.WriteLine(isExists);

// 创建文件夹
//Directory.CreateDirectory("./data");
//Directory.CreateDirectory("./log/data");

// 删除文件夹
//Directory.Delete("./log/data");
//Directory.Delete("./log");

// 第二个参数为true 则不管是是否空文件夹 都删除
//Directory.Delete("./log",true);

// 获取文件夹下的所有文件
//string[] files = Directory.GetFiles("./");
//foreach (string file in files) Console.WriteLine(file);

// 获取文件夹下的所有文件夹
//string[] dirs = Directory.GetDirectories("./");
//foreach (string file in dirs) Console.WriteLine(file);

//获取文件夹下的所有文件夹(包括子目录中)
//string[] dirs = Directory.GetDirectories("./","*",SearchOption.AllDirectories);
//foreach (string file in dirs) Console.WriteLine(file);

// 参数2 是匹配规则
//string[] dirs = Directory.GetDirectories("./","log*");
//foreach (string file in dirs) Console.WriteLine(file);

//string[] dirs = Directory.GetDirectories("./", "log??");
//foreach (string file in dirs) Console.WriteLine(file);

// 参数3：SearchOption.TopDirectoryOnly 默认值：只查找一级目录
// SearchOption.AllDirectories  表示查找所有(所有后代目录)


// 获取文件夹下的文件 也有多个参数
//string[] files = Directory.GetFiles("./","day*",SearchOption.AllDirectories);
//foreach (string file in files) Console.WriteLine(file);
```



案例：判断一个路径是文件还是文件夹

```c#
// 定义一个函数, 一个参数(接收路径), 返回值0 表示啥也不是,1是文件,2是文件夹
Func<string, int> isFileOrDir = path =>
{
    // 说明path是文件
    if (File.Exists(path)) return 1;
    // 说明path是目录
    if (Directory.Exists(path)) return 2;
    return 0;
};
string[] resArr = ["啥也不是", "是文件", "是文件夹"];
//int res = isFileOrDir("./");
//int res = isFileOrDir("./abc");
//int res = isFileOrDir("./content.log");
//string path1 = @"D:\demo\day10\day10\bin\Debug\net8.0";
//string path1 = @"D:\demo\day10\day10\bin\Debug\net8.0\abcder";
//int res = isFileOrDir(path1);
//Console.WriteLine(resArr[res]);
```



案例：获取目录下所有目录和文件（一级）

```c#
// 封装一个函数 一个参数(接收路径), 返回值 List<string>
Func<string, List<string>> getFileAndDir = path =>
{
    List<string> resList = [];
    // 判断路径是否是 目录 ===> 使用刚刚书写的函数
    //  如果不是目录则 手动抛出一个异常
    if (isFileOrDir(path) != 2) throw new Exception("传递的参数有误,必须要是目录路径");
    // 获取目录下的所有文件
    string[] files = Directory.GetFiles(path);
    // 将得到 files数组添加到 list中
    resList.AddRange(files);

    // 获取所有的目录
    string[]  dirs = Directory.GetDirectories(path);
    resList.AddRange(dirs);
    return resList;
};

//var res = getFileAndDir("./");
//var res = getFileAndDir(@"D:\视觉02");
//foreach (var item in res) Console.WriteLine(item);

// getFileAndDir 返回值优化: 获取的文件夹和文件区分开
Func<string, Dictionary<string, string[]>> getFileAndDir = path =>
{
    var resDic = new Dictionary<string, string[]>();
    if (isFileOrDir(path) != 2) throw new Exception("传递的参数有误,必须要是目录路径");
    // 获取目录下的所有文件
    string[] files = Directory.GetFiles(path);
    resDic["files"] = files;

    // 获取所有的目录
    string[] dirs = Directory.GetDirectories(path);
    resDic["dirs"] = dirs;
    return resDic;
};

var res = getFileAndDir("./");
foreach (var item in res)
{
    Console.WriteLine(item.Key);
    foreach (var item2 in item.Value) Console.WriteLine(item2);
    Console.WriteLine("-----------------------");
}
```

### 3、路径处理

```c#
// 拼接路径（自动适配Windows斜杠，不要自己手写 \ /）
string fullPath = Path.Combine(folder,"book.json");

// 获取文件名
Path.GetFileName(@"D:\a\book.json"); // book.json

// 获取后缀
Path.GetExtension("book.json"); // .json

// 获取文件夹目录
Path.GetDirectoryName(@"D:\a\book.json");
```

例：

```c#
// 拼接路径  自动适配Windows斜杠，不要自己手写 \ /
//var res = Path.Combine(@"D:\a\b", "c", "book.json");
//Console.WriteLine(res);

// 获取路径中 完整的文件名
//var path = @"D:/demo/ab/ef/book.json";
//var res = Path.GetFileName(path);
//Console.WriteLine(res); // book.json

// 获取路径中 文件后缀
//var path = @"D:/demo/ab/ef/book.json";
//var res = Path.GetExtension(path);
//Console.WriteLine(res); // .json

// 获取路径中的 目录路径
var path = @"D:/demo/ab/ef/book.json";
var res = Path.GetDirectoryName(path);
Console.WriteLine(res); // D:\demo\ab\ef
```

