# day10

## 上节回顾

委托:  将函数(行为)当做变量存储    是一种函数类型

- delegate 返回值类型 函数类型名称(参数类型 参数,....);
  - 函数类型 变量 = 函数
  - 函数类型 变量 += 函数
- `Action<T>  变量 = 函数`    没有返回值
- `Func<T,TResult>  变量 = 函数`   必须有返回值

值类型-引用类型

- 值类型: `int,double,bool,char.....`
  - 数据存储在栈内存空间
  - 值类型变量之间的赋值 是 值本身复制一份的赋值
- 引用类型: `字典,列表,字符串,数组`
  - 数据存储在堆空间
  - 引用类型变量之间的赋值, 是地址的赋值

函数参数

- 命名参数:  函数调用调用时候可以不按顺序传递参数  参数名: 值
- 可变数量参数: (params 类型[] 变量)  函数内接受到多个参数组成的数组
- `ref` 修饰的形参 ====> 引用传递  (函数内的形参和 外部的实参变量的地址保持一致)
  - ref的外部变量必须初始化
  - 目标: 希望向函数内传递数据,但是保持引用传递
- out  输出函数内的数据(抛出函数内的数据)
  - 函数内必须要给改参数赋值 
- Func函数不允许 使用out和ref参数

箭头函数:  就是对匿名函数的简写  (参数,...) => {函数体}

- 一个参数的时候可以省略小括号
- 函数体只有一行的时候,可以省略{}和return; 而且函数会将这一行作为函数的返回值

元组: 将多个数据打包在一起的对象

- (类型,.....) 变量 = (数据,数据,数据);
  - 访问: 变量.Item1

- 命名: (名称:数据,名称:数据,名称:数据....);
  - 访问: 变量.名称
- 解构:    var (变量,变量) = (数据,数据,...)
  - var (变量,_,变量) = (数据,数据,...)
- 最多的使用场景: 作为函数的返回值(函数多个返回值)

回调函数: 函数作为其他函数的参数传入,并在函数内执行了该函数

List的高级方法

- Find
- FindAll
- FindLast
- ForEach
- FindIndex
- FindLastIndex
- Exists
- TrueForAll
- ConvertAll
- Sort((n,m)=>n-m))
- RemoveAll

​	

## 一、LinQ

全称：Language Integrated Query。语言集成查询。

查询数据库、文件内容、List、。。。。

通用的查询语言。支持链式调用写法，  .Where().Select()...

### 1、常用方法

#### 1.1、数据 

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
```

#### 1.2、方法

- Where条件


```c#
var res = list.Where(item => item["isSingle"]);
foreach (var item in res)
{
    Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}--isSingle={item["isSingle"]}");   
}
```

- Select筛选、转类型、创建新内容


```c#
 //var res1 = list.Select(item => {
 //    return new Dictionary<string, dynamic>()
 //    {
 //        ["name"] = item["name"],
 //        ["age"] = item["age"],
 //    };
 //});            
 //foreach (var item in res1) Console.WriteLine($"name={item["name"]}--age={item["age"]}");

 //var res1 = list.Select(item => {
 //    return item["name"];
 //});
 //foreach (var item in res1) Console.WriteLine(item);

 //var res1 = list.Select(item => {
 //    return item["name"] + item["age"];
 //});
 //foreach (var item in res1) Console.WriteLine(item);
```

Where+Select配合使用：

```c#
 //var res1 = list.Where(item => item["age"]>=18).Select(item => {
 //    return new Dictionary<string, dynamic>()
 //    {
 //        ["name"] = item["name"],
 //        ["age"] = item["age"],
 //    };
 //});            
 //foreach (var item in res1) Console.WriteLine($"name={item["name"]}--age={item["age"]}");
```

- OfType按类型过滤


```c#
 List<object> objs = [10, 20, "abc", true, 10, 12.3];
 var res = objs.OfType<int>();
 foreach (var item in res) Console.WriteLine(item);
```

- OrderBy升序


```c#
var res = list.OrderBy(item=>item["age"]);
foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");
```

- OrderByDescending降序


```c#
 var res = list.OrderByDescending(item => item["age"]);
 foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");
```

- ThenBy第一次排序完成后，再次使用其他键对新数据做排序

  ```c#
  List<Dictionary<string, dynamic>> arr = new() { 
      new Dictionary<string, dynamic>() {
          ["name"] = "zs",
          ["age"] = 19,
          ["salary"] = 3888
      },
      new Dictionary<string, dynamic>() {
          ["name"] = "ls",
          ["age"] = 14,
          ["salary"] = 3500
      },
      new Dictionary<string, dynamic>() {
          ["name"] = "ww",
          ["age"] = 14,
          ["salary"] = 3000
      },
      new Dictionary<string, dynamic>() {
          ["name"] = "zl",
          ["age"] = 22,
          ["salary"] = 4000
      },
  };
  var res = arr.OrderBy(item => item["age"]).ThenBy(item => item["salary"]);
  foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}--salary={item["salary"]}");
  ```

  

- DistinctBy去重


```c#
var res = arr.DistinctBy(item => item["age"]);
foreach (var item in res) Console.WriteLine($"name={item["name"]}--age={item["age"]}");
```

- GroupBy分组


```c#
List<Dictionary<string, dynamic>> arr = new() { 
    new Dictionary<string, dynamic>(){
        ["name"] = "手机",
        ["type"] = "电子产品"
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "香蕉",
        ["type"] = "水果"
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "苹果",
        ["type"] = "水果"
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "平板",
        ["type"] = "电子产品"
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "耳机",
        ["type"] = "电子产品"
    },
    new Dictionary<string, dynamic>(){
        ["name"] = "水蜜桃",
        ["type"] = "水果"
    },
};
var res = arr1.GroupBy(item => item["type"]);
// 结果是第一个字典, 水果一组,电子产品一组                        
foreach (var item in res)
{
    Console.WriteLine(item.Key);
    foreach (var i in item) Console.WriteLine($"{i["type"]}--{i["name"]}");
}
```

- FirstOrDefault找第一个满足条件的数据


```c#
var res = list.FirstOrDefault(item => item["age"] > 18);
Console.WriteLine($"name:{res["name"]}--age:{res["age"]}");
```

- LastOrDefault找最后一个


```c#
 var res = list.LastOrDefault(item => item["age"] > 18);
 Console.WriteLine($"name:{res["name"]}--age:{res["age"]}");
```

- Any是否至少有一个


```c#
bool r = list.Any(item => item["age"] < 10);
Console.WriteLine(r);
```

- All是否全部满足


```c#
  bool r = list.All(item => item["salary"] > 3800);
  Console.WriteLine(r);
```

### 2、聚合函数

- Count总数量


```c#
int count = list.Count();
Console.WriteLine(count); // 6
```

- Sum求和


```c#
 int sum = list.Sum(item => item["salary"]);
 Console.WriteLine(sum); // 25500
```

- Average平均数


```c#
double avg = list.Average(item => item["salary"]);
Console.WriteLine(avg); // 4250
```

- Max最大值


```c#
double max = list.Max(item => item["salary"]);
Console.WriteLine(max); // 7000
```

- Min最小值


```c#
double min = list.Min(item => item["salary"]);
Console.WriteLine(min); // 2000
```





作业:  使用读写文件配合命令行窗口  模拟实现注册功能

 要求输入用户名和密码,完成注册; (注册的用户信息记录在user.txt文件中,一行一个用户信息 数据之间通过===分隔)





## 二、面向对象

### 1、概念

面向对象编程，简称OOP（Object-Oriented Programming），他具有3大特性：封装性、继承性、多态。

我们之前的编程习惯，属于面向过程编程，简称POP（Procedure-Oriented Programming），每实现一个功能，我们更加注重其中实现的过程。

面向对象编程，让我们从宏观上思考整个项目，不再局限于实现每个功能。是一种编程思想的升华，是一种超脱的、高级的编程思想。

例：

面向过程思想：

下班回家，我们需要吃饭，想吃土豆丝，我们就去菜店买土豆，然后先削皮，用菜刀切成片，再切成丝，然后用水洗一洗，洗到没有淀粉，然后烧过起油，放入佐料葱姜蒜，撒点十三香，佐料爆出香味，倒入土豆丝，翻炒到所有土豆丝发热后，撒盐，翻炒到干锅，倒入酱油，继续翻炒到土豆丝软化，撒入少许白糖，翻炒到有些粘性了，撒些鸡精，翻炒到鸡精消融，出锅。开吃。

总结：要吃到美味的土豆丝，需要自己亲力亲为，重点把握做菜的每个细节。

面向对象思想：

下班回家，我们需要吃饭，想吃土豆丝，告诉保姆，我要吃土豆丝。等保姆做好以后，开吃。

总结：要吃到美味的土豆丝，不用亲力亲为，重点找好保姆即可。

通过对比，我们发现，面向对象确认要比面向对象更加高级，类似于一个屌丝跟富豪的区别。所以说面向对象是更加高级的编程思想。

我们之前的编程思想：当做一个案例的时候，需要根据结果，分析实现效果的每个步骤，重点关注每个步骤的实现过程以及其中的逻辑。

面向对象编程思想：当做一个案例的时候，找到对应的对象，使用其中的数据，调用其中的方法即可。

### 2、类的创建

学习面向对象编程，首先需要认识类。类是一种数据结构，他可以包含数据成员和函数成员。数据成员包括各种类型的数据；函数成员包括函数、运算符、方法、属性等。这就体现了面向对象编程的封装性。

类是一种数据类型，代表现实生活中的种类，类是对一群具有相同特性或者行为的事物的一个统称，是抽象的，不能直接使用，他里面的特征叫属性，行为叫方法。类相当于一个事物的的模板，负责创建整个对象。

语法：

```c#
public class 类名{
    
}
```

类中声明属性：

```c#
public class 类名{
    public 类型 名称{get; set;}
}
```

如果属性中有get关键字，说明可以获取这个属性的值，如果属性中有set关键字，说明可以给这个属性赋值。

类中声明方法：

```c#
public class 类名{
    public 返回值类型 名称(参数类型 名称){
        
    }
}
```

例：

```c#
internal class Animal
{
    public string Name { get; set; }
    public string Description { get;  }
    public void Run()
    {
        Console.WriteLine($"{Name}在跑，描述：{Description}");
    }
}
```



### 3、实例化

类和对象是两个不同的概念，类决定了对象的类型和模板，但不是对象本身。我们可以将对象看作是基于类创建的实体，所以对象也称为类的实例。

使用new关键字进行实例化，一个类可以实例化多个对象，对象可以访问类中定义的属性和方法。

```c#
Animal Bird = new Animal();
Console.WriteLine(Bird.Name); // 初始没有值
Bird.Name = "鸟";
Console.WriteLine(Bird.Name); // 鸟
Bird.Run(); // 鸟在跑，描述：

Animal Cat = new Animal();
Console.WriteLine(Cat.Name); // 初始没有值
Cat.Name = "猫";
Console.WriteLine(Cat.Name); // 猫
Cat.Run(); // 猫在跑，描述：
```

属性访问器：我们在定义类的时候给Description只设置了get，没有设置set，那这个属性就没有办法给他赋值



## 三、访问修饰符

- public：公共的，类内部外部都能访问

- protected：受保护的，当前类里面能访问

  类外无法访问：

  protect定义属性

  protect定义的属性类外无法访问

  类内部可以访问：

  访问结果：

- private：私有的，当前类内部能访问

  同protected

- internal：内部的，只有当前项目能访问

- static：静态的，可以配合上面几个修饰符使用，静态的属性和方法不能使用实例对象调用，只能由类名调用

注意：在普通方法中访问静态成员和在静态方法中访问普通成员（传入实例或当场实例）以及静态方法中访问静态成员的易错区（不加类名容易跟参数同名产生异常）。

## 四、构造函数

每个类，都有构造函数，我们不写，这个构造函数就是隐形的，我们也可以自己定义。

我们在实例化对象的时候，系统会自动调用构造函数。

我们可以在创建类的时候，给类添加构造函数，给属性进行初始化赋值。

构造函数的名称跟类名相同，没有返回值：

```c#
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Person
    {
        public string Name { get; set; }
        protected int Age { get; }
        private double Height { get; set; }
        public bool IsMan { get; }
        // 有了构造函数就可以在实例化的时候给这俩数据赋值了
        public Person(string name, int age, double height, bool isMan)
        {
            Age = age;
            Height = height;
            Name = name;
            IsMan = isMan;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"姓名{Name}，年龄{Age}，身高{Height}，男{IsMan}");
        }
    }
}
```

实例化的时候就可以通过参数给属性赋值：

```c#
Person zs = new Person("张三", 12, 178, true);
zs.PrintInfo(); // 姓名张三，年龄12，身高178，男True
```

如果不定义构造函数，也可以在实例化的时候在大括号中给公开的属性赋值：

```c#
Person zs = new Person()
{
    Name = "张三"
};
zs.PrintInfo(); // 姓名张三，年龄0，身高0，男False
```

这种赋值，无法给protected和private修饰的属性以及没有set访问器的属性赋值。

我们不手动写构造函数，系统会默认给这个类隐式的创建一个没有参数的构造函数，这个构造函数会在实例化对象时为类中的成员属性设置默认值，例如整型默认为0，布尔值默认为false。



作业：

定义一个类，用于处理图书管理系统的数据。

属性：

- 数据文件路径

方法：

- 新增数据：强制要求 ==> 将list写入文件中
- 编辑数据
- 删除数据
- 查询所有数据
- 根据图书名称查询当前图书数据：强制要求

图书数据：

```c#
List<Dictionary<string, dynamic>> data = new List<Dictionary<string, dynamic>>(){
    new Dictionary<string, dynamic>(){
        ["name"] = "三国演义",
        ["author"] = "罗贯中",
        ["isBorrow"] = true/false, // false表示还在书库中，true表示外借
        ["id"] = 0~1之间的随机小数,
        ["mark"] = "言情、武侠",
        ["price"] = 56.09 // 价格
    },
    。。。
};
```

