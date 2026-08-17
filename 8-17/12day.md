---
typora-copy-images-to: img
---

# day12

## 一、回调函数

需求：我们需要定义一个函数，对一个List筛选，将满足条件的元素放在一个新的List中，筛选条件不固定。

分析：我们对于List的筛选，基于遍历，遍历出的每个元素，根据条件进行判断，如果结果为true，就将元素添加在新List中，如果条件为false，就什么也不做。   

我们想到的代码大概如下：

```c#
object Filter(List<int> arr, 条件) {
    // 定义新List
    List<int> newList = new List<int>();
    // 遍历
    foreach(var item in arr) {
        // 对item做判断
        if (条件) {
            newList.Add(item);
        }
    }
    return newList;
}
```

因为条件不固定,会变化，所以要将条件作为参数，但**这个参数需要item参与才能形成条件**，此时，我们发现这样无法实现判断。

如果参数中能让item参与的话，条件就可以灵活变化了。

那我们只能将item作为另一个函数的参数，然后让另一个函数根据item返回一个条件，就能实现这个需求了。

```c#
List<int> Filter(List<int> arr) {
    // 定义新List
    List<int> newList = new List<int>();
    // 遍历
    foreach(var item in arr) {
        // 对item做判断
        if (FilterCondition(item)) {
            newList.Add(item);  
        }
    }
    return newList;
}
bool FilterCondition(item) {
    return item > 10; // 暂时写死
}

List<int> list = [1,20,3,40,5,6,70]
var newList = p.Filter(list);
```

这样的代码大概能实现item大于10的条件筛选，但条件写死后，不适用于其他场景，我么应该让条件也能灵活变化。

条件的灵活变化，也就意味着FilterCondition函数的灵活变化，此时，这个函数就应该是临时定义的，而不是写死的。

这样就类似于函数中的某个变量要发生变化，就将他作为参数，这里也一样，函数会灵活变化，就将这个函数作为参数 ==> 这个函数也就是回调函数了。

```c#
List<int> Filter(List<int> arr, Func<int,bool> ConditionFn) {
    // 定义新List
    List<int> newList = new List<int>();
    // 遍历
    foreach(var item in arr) {
        // 对item做判断
        if (ConditionFn(item)) {
            newList.Add(item);
        }
    }
    return newList;
}

List<int> list = new List<int>() {
    1,2,30,4,5,6,70
};

// Linq方法Case可以将集合中的数据类型转成目标类型
var newList = Filter(list, (item) => {
    return item > 10;
});

```



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

通过对比，我们发现，面向对象确实要比面向对象更加高级，类似于一个屌丝跟富豪的区别。所以说面向对象是更加高级的编程思想。

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

![1786933930612](img/1786933930612.png)

## 三、访问修饰符

- public：公共的，类内部外部都能访问

- protected：受保护的，当前类里面能访问

  类外无法访问：

  protect定义属性

  ```C#	
  internal class Person
  {    
      public string Name { get; set; }
      protected int Age { get; set; }
      private double Salary {  get; set; }
  }
  ```

  protect定义的属性类外无法访问

  ![1786934924025](img/1786934924025.png)

  类内部可以访问：

  ```C#
  public void GetInfo()
  {
      Console.WriteLine($"名字: {Name}--年龄:{Age}---薪水:{Salary}");
  }
  ```

  访问结果：

  ![1786935140050](img/1786935140050.png)

- private：私有的，当前类内部能访问

  同protected

- internal：内部的，只有当前项目能访问

- static：静态的，可以配合上面几个修饰符使用，静态的属性和方法不能使用实例对象调用，只能由类名调用

注意：在普通方法中访问静态成员和在静态方法中访问普通成员（传入实例或当场实例）以及静态方法中访问静态成员的易错区（不加类名容易跟参数同名产生异常）。

## 四、构造函数

每个类，都有构造函数，我们不写，这个构造函数就是隐形的，我们也可以自己定义。

我们在实例化对象的时候，系统会自动调用构造函数。

我们可以在创建类的时候，给类添加构造函数，在构造函数中可以给属性进行初始化赋值。

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

### 实例构造函数

实例构造函数就是公开的、非静态的构造函数。我们利用这种构造函数，可以在实例化对象的时候给**属性初始赋值**。

```c#
public class Person{
    public string Name {get;set;}
    public Person(string name) {
        Name = name;
    }
}

Person zs = new Person("张三");
Console.WriteLine(zs.Name);
```

### 静态构造函数

构造函数可以设置为静态的，静态构造函数会在创建第一个实例对象对象之前执行，所以只能执行一次，不像实例构造函数，每次创建实例对象的时候都会执行，因为静态方法是属于类的，创建多个实例对象，也只有这一个类。

静态构造函数不能手动调用，系统自动调用。

```c#
internal class Animal
{
    static public string Appearance { get; set; }
    public string Name { get; set; }
    public Animal()
    {
        Name = "动物";
        //Animal.Appearance = "披毛带甲";
    }
    static Animal()
    {
        Appearance = "鳞甲群体";
    }
}

Animal Ani = new Animal();
Console.WriteLine(Ani.Name);
Console.WriteLine(Animal.Appearance);
```

当实例构造函数中不给静态属性赋值时，静态构造函数会给静态属性赋值；当实例构造函数给静态属性赋值时，会覆盖掉静态构造函数给静态属性赋的值。说明静态构造函数会在实例构造函数执行之前进行。

### 私有构造函数

构造函数可以设置为private私有的。我们在实例化对象的时候，会自动调用构造函数，而私有的构造函数会导致无法在外部创建实例对象，从而实现一个类永远只能有一个实例对象的场景（单例模式）。

在某些场景中，我们只能有一个对象进行操作，例如当我们操作visionPro的相机时，如果有一个对象在操作了，再创建对象操作的时候，就会提示设备正在被占用，此时创建第二个对象就没有了必要，反而占用了更多的内存资源，此时我们一个对象只允许创建一个对象，就不会出现这种情况了。

```c#
internal class SingleInstance
{
    static private SingleInstance Singleton;
    private SingleInstance() { }
    static public SingleInstance GetSingleton()
    {
        if (Singleton == null)
        {
            Singleton = new SingleInstance();
        }
        return Singleton;
    }
}

//SingleInstance Singleton = new SingleInstance(); // 飘红，因为构造函数是私有的
SingleInstance Singleton = SingleInstance.GetSingleton();
```

## 三、继承

假设我们的程序需要控制两台设备：相机、运动控制器，每种设备都具备一些共同的操作：

属性：

- 设备名称
- 是否连接状态

方法：

- 连接设备 
- 断开设备 

然后各自又有各自独属的功能：

- 相机：拍照 
- 运动控制器：轴运动

我们去定义2个类，实现这些功能：

```c#
//相机
public class Camera : Device
{
	public string DeviceName { get; set; }
    public bool IsConnected { get; set; }

    public virtual void Connect()
    {
        Console.WriteLine("通用设备连接逻辑");
    }
    public virtual void Disconnect()
    {
        Console.WriteLine("通用设备断开逻辑");
    }
    public void CaptureImage()
    {
        Console.WriteLine("相机拍摄图像");
    }
}

//运动控制器
public class MotionController : Device
{
	public string DeviceName { get; set; }
    public bool IsConnected { get; set; }

    public virtual void Connect()
    {
        Console.WriteLine("通用设备连接逻辑");
    }
    public virtual void Disconnect()
    {
        Console.WriteLine("通用设备断开逻辑");
    }
    public void MoveAxis()
    {
        Console.WriteLine("控制轴运动");
    }
}
```

我们发现这2个类中有很多共同的代码，都是这些设备共同的特性和行为，每次写一个类的时候都要写这些重复的代码，为了解决这个问题，C#中提供了类可以继承的语法。

被继承的类我们叫父类（基类），继承后的类叫子类（派生类）。

继承的好处：

- 代码复用
- 结构清晰
- 方便扩展

继承语法：

```c#
class 子类 : 父类 {
    
}
```

这时候我们可以将设备共同的属性和方法抽离出来形成一个设备类，然后让这2个类继承设备类，共同特性就不用重新写了，可以简便很多。

```c#
// 设备类
public class Device
{
    public string DeviceName { get; set; }
    public bool IsConnected { get; set; }

    public void Connect()
    {
        Console.WriteLine("通用设备连接逻辑");
    }
    public void Disconnect()
    {
        Console.WriteLine("通用设备断开逻辑");
    }
}

//相机
public class Camera : Device
{
    public void CaptureImage()
    {
        Console.WriteLine("相机拍摄图像");
    }
}

//运动控制器
public class MotionController : Device
{
    public void MoveAxis()
    {
        Console.WriteLine("控制轴运动");
    }
}
```

后续有PLC设备也具备这些共同的属性和方法，还有读写寄存器方法，就不用重新再写这些共同的特性了，直接继承设备类就好了：

```c#
//PLC
public class Plc : Device
{
    public void ReadRegister()
    {
        Console.WriteLine("读取PLC寄存器");
    }
}
```

注意：子类的可访问性不能低于父类，例如父类是internal，子类就不能是public，意思是父类的访问权限要更广才行。不加修饰符默认是私有的。

## 四、多态

多态表示多种形态。龙生九子，各个不同。例如：一个父类被多个子类继承，父类中有一个方法，被子类继承后，子类会对继承下来的方法重写，让每个子类都有不同的表现。

子类实例对象可以使用父类类型存储，因为子类是父类的其中一种。例如：父类是交通工具，子类是汽车，那么汽车也是交通工具。

多态的具体实现方式有两种：

1. 父类在定义方法时，使用virtual修饰，这个方法可以被子类使用override进行**重写**。当我们定义子类实例对象的时候，使用父类类型存储，这时候当我们使用这个对象调用重写方法的时候，系统会自动识别当前场景应该执行哪个子类的方法。
2. 一个类中，可以有多个同名方法，但是这几个同名方法必须是参数列表不同,方法**重载**。当实例对象调用方法的时候，根据参数列表，可以精准的执行到对应的方法。

例：多态1

```c#
// 父类 交通工具
internal class Transport
{
    public string Name { get; set; }
    public double Speed { get; set; }
    public virtual void Transportation() // 加上virtual修饰符，准备被重写
    {
        Console.WriteLine($"{Name}在运输");
    }
    public void Trans()
    {
        Console.WriteLine($"{Speed}的速度在运输");
    }
}

// 子类 船
internal class Ship : Transport
{
    public Ship(string name, double speed)
    {
        Name = name;
        Speed = speed;
    }
    public override void Transportation() // 加上override重写继承自父类的方法
    {
        Console.WriteLine($"{Name}以{Speed}的速度在运输");
    }
    public void Trans()
    {
        Console.WriteLine($"{Name}运输的速度是{Speed}");
    }
}

// 子类 车
internal class Car : Transport
{
    public Car(string name, double speed)
    {
        Name = name;
        Speed = speed;
    }
    public override void Transportation()
    {
        Console.WriteLine($"{Name}以{Speed}的速度在运输");
    }
    public void Trans()
    {
        Console.WriteLine($"{Name}运输的速度是{Speed}");
    }
}

// 调用效果;
Transport ship = new Ship("船", 80.99);
Transport car = new Car("车", 100.5);
// 没有重写的效果
ship.Trans(); // 80.99的速度在运输
car.Trans(); // 100.5的速度在运输
// 重写的多态效果
ship.Transportation(); // 船以80.99的速度在运输
car.Transportation(); // 车以100.5的速度在运输
```

例：多态2

```c#
internal class Polymorphic
{
    public void Say(string name)
    {
        Console.WriteLine($"{name}在说话");
    }
    public void Say(int count)
    {
        Console.WriteLine($"{count}个人在聊天");
    }
    public void Say(int count, string song)
    {
        Console.WriteLine($"{count}只黄鹂鸣{song}");
    }
}

// 调用效果
Polymorphic polymorphic = new Polymorphic();
polymorphic.Say("张三"); // 张三在说话
polymorphic.Say(3); // 3个人在聊天
polymorphic.Say(2, "翠柳"); // 2只黄鹂鸣翠柳
```





















作业：

定义一个类，用于处理图书管理系统的数据。

属性：

- 数据文件路径
- JSON序列化配置项

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

文件存储: book.json

1. 完善新增
2. 完成查询两个功能