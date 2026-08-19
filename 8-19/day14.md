# day14 

## 上节回顾

#### 抽象类

- 这种类只能被继承，不能实例对象
- 使用abstract修饰的类就是抽象类，在类中使用abstract修饰的属性或方法(没有实现的方法) 抽象属性 抽象方法
  - 子类必须使用抽象类中的抽象属性、方法
  - 如果子类的抽象类则可以不实现
- 一般会将 多个类中的公共属性或方法抽离到抽象类中，让其他子类继承

#### 静态类

- 使用static修饰的类 就是静态类； 类中属性和方法都是静态的（static修饰）； 不能实例化对象
  - 使用的时候 直接 类名.方法()/属性
- 比如静态类  `Math`

#### 密封类

- 不想继承的类使用 sealed 修饰就成为 密封类
  - 密封方法： sealed只能修饰 override 从写的方法， 密封方法不能被重写

#### 接口

- 接口是限定 类的一种规范方式， 主要限定类的 属性，方法等

  - 接口中的属性和方法不能写修饰符， 默认都是public

  ```C#
  interface 名称{
      类型 属性名{get;set;}
      返回值类型 方法名(类型 参数,....);
  }
  ```

- 实现接口的类 必须实现对应接口中的方法和属性（修饰符保持一致）

#### this

- 在类内部(方法中)使用this关键字， 代表了当前执行方法时候的 实例对象

#### 访问器

```C#
// 在类内部 书写属性的时候
修饰符 类型 属性名{
    get{
        // 当实例对象访问这个属性的时候会执行此处的 代码
        // 必须要有返回值， 返回值就是 这个属性的访问那结果
        // 可以在此方法中 给访问结果 格式化
    }
    set{
       // 当实例对象给属性赋值的时候会执行此处的 代码
       // 此处的代码中默认的value变量值就是 给这个属性赋的值
       this.属性名 = 值
    }
    
}

// 对象.属性名 = 值
```





## 一、命名空间

我们在Main中实例化对象时，不需要导入其他文件，就能将其他文件中的类直接实例化。说明我们项目在运行的时候，编译的是整个项目，而不是单个文件。

那么当我们在不同文件中有同名的类时，就会造成冲突了，所以我们项目中有了命名空间的语法。

命名空间就是给类、接口等代码添加一个`隔离区域`，解决同名的冲突。

语法：

```c#
namespace 空间名称{
    被隔离的代码
}

```

当我们在使用某个命名空间下的类时，语法：

```c#
Vision.Device.Camera cam = new Vision.Device.Camera();

```

为了简化使用代码，我们可以使用using进行导入命名空间：

```c#
using Vision.Device;
// 此时在使用命名空间下的类，就不用写那么长了
Camera cam = new Camera();

```

## 二、结构体

结构体跟类很像，不同的地方在于结构体是值类型，类是引用类型；结构体不能继承别的类，也不能被别的类继承。

语法使用struct定义：

```c#
// 坐标结构体
struct Point
{
    // 字段
    public int X;
    public int Y;

    // 普通方法
    public void Move(int offsetX, int offsetY)
    {
        X += offsetX;
        Y += offsetY;
    }

    // 返回数据的方法
    public double GetDistance()
    {
        return Math.Sqrt(X * X + Y * Y);
    }
}
```

使用方式跟类一样，进行实例化，调用属性和方法。

## 三、异步代码

当我们在执行一段比较耗时耗资源的代码时，后续代码会一直等待，就会让程序卡死等待很长时间。这样给用户的体验感非常不友好。为了解决整个问题，c#中设计了异步代码，可以让程序在执行耗时耗资源的代码时，同时可以进行一些其他代码的执行。

例：

```c#
static async Task Main(string[] args)
{
    // 同步读取3个文件内容
    // 开始计时
    Stopwatch stopwatch1 = Stopwatch.StartNew();
    string aContent = File.ReadAllText("./a.txt");
    string bContent = File.ReadAllText("./b.txt");
    string cContent = File.ReadAllText("./c.txt");
    stopwatch1.Stop();
    Console.WriteLine($"同步读取耗时：{stopwatch1.ElapsedMilliseconds} ms");
    // 异步同时读取
    // 开始计时
    Stopwatch stopwatch2 = Stopwatch.StartNew();
    Task<string> aTask = File.ReadAllTextAsync("a.txt");
    Task<string> bTask = File.ReadAllTextAsync("b.txt");
    Task<string> cTask = File.ReadAllTextAsync("c.txt");
    // 结束计时
    string[] res = await Task.WhenAll(aTask, bTask, cTask);
    stopwatch2.Stop();
    Console.WriteLine($"异步同时读取耗时：{stopwatch2.ElapsedMilliseconds} ms");
}
/*
Stopwatch => 高精度计时器
	用来测量一段代码执行耗时，比 DateTime 计时更精准。
Stopwatch sw = Stopwatch.StartNew(); 直接创建并立刻启动计时器（最常用）
sw.Start(); 启动
sw.Stop(); 停止
获取耗时属性: 
sw.ElapsedMilliseconds：总毫秒数 long
sw.Elapsed：返回 TimeSpan（时分秒毫秒）
*/
```

从输出的效果上看，异步读取相当于3个读取同时进行，用时比依次读取要快。

但也有一些异步代码。相互之间有依赖关系，我们为了让多个异步任务按照顺序执行，需要给方法名前面添加**async**，异步任务前添加**await**，等待最终异步代码执行有了结果后，再向下执行。

```c#
static async Task Main(string[] args)
	string aContent = await File.ReadAllTextAsync("a.txt");
}
```

我们一般在处理异步代码的时候，都要给方法加上async，异步代码前面加上await。等待结果接受，才会执行后续操作



## 四、枚举类型

如果我们使用数字存储性别，1代表男，2代表女，那这个数据的类型会使用int。但int的范围太广，我们完全可以存入3，这会导致逻辑错误。如果有一种类型直接将数据写死，我们存储的数据只能是1或者2，那就可以避免这个问题了，这个类型可以使用枚举类型。

枚举类型使用enum定义，默认值是从0开始的int：

```c#
enum Gender
{
    Man,
    Woman
}
static void Main(string[] args)
{
    Gender s = Gender.Man;
    Console.WriteLine(s); // Man ==> 底层存储的是数字，给人看的时候，会自动调用ToString方法，看到字符串形式
    Console.WriteLine(s == 0); // True，说明这个值本质是数字0
}
```

注意：enum不能定义在方法内部。

如果有某个类型的值给定了int，后续会根据这个数字自增：

```c#
enum Week
{
    Sunday = 11,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

Week w = Week.Monday;
Console.WriteLine(w); // Monday
Console.WriteLine((int)w == 1); // False
Console.WriteLine((int)w == 12); // True
```



## 五、网络请求

API地址：[随机一言](https://uapis.cn/api/v1/saying )、[获取当前ip](https://uapis.cn/api/v1/network/myip) 、[历史上的今天](https://uapis.cn/api/v1/history/programmer/today)、[qq信息查询](https://uapis.cn/api/v1/social/qq/userinfo?qq=qq号)、[答案之书](https://uapis.cn/api/v1/answerbook/ask?question=问题) 

发起请求步骤：

- 创建请求对象

  ```c#
  HttpClient _httpClient = new HttpClient();
  ```

  

- 调用方法发起请求

  ```c#
  await _httpClient.GetAsync(url);
  await _httpClient.PostAsync(url, 数据);
  await _httpClient.PutAsync(url, 数据);
  await _httpClient.DeleteAsync(url);
  await client.SendAsync(请求对象);
  ```

  

- 读取响应内容

  ```c#
  string result = await response.Content.ReadAsStringAsync();
  ```

  

- post请求可以是表单数据，也可以是json数据，也可以是上传文件数据

  ```c#
  // 表单数据
  var form = new FormUrlEncodedContent(formData);
  HttpResponseMessage response = await _httpClient.PostAsync(url, form);
  
  // json数据
  string json = System.Text.Json.JsonSerializer.Serialize(jsonBody);
  var content = new StringContent(json, Encoding.UTF8, "application/json");
  HttpResponseMessage response = await _httpClient.PostAsync(url, content);
  
  // 上传文件的数据
  MultipartFormDataContent multiContent = new MultipartFormDataContent();
  ileStream fileStream = File.OpenRead(filePath);
  StreamContent fileContent = new StreamContent(fileStream);
  formContent.Add(fileContent, "file", Path.GetFileName(filePath)); // 数据流 字段名 文件原名，可以同样的代码再来一行，上传多文件
  // 还可以在上传文件的同时添加一些普通数据
  formContent.Add(new StringContent("张三"), "username");
  formContent.Add(new StringContent("18"), "age");
  HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uploadUrl);
  request.Content = formContent;
  ```

  

- 下载图片或文件的请求

  ```c#
  // 返回字节数组
  byte[] fileBytes = await _httpClient.GetByteArrayAsync("https://xxx/image.png");
  // 写入本地文件
  File.WriteAllBytes(@"D:\test.png", fileBytes);
  ```

- 设置请求头

  ```c#
  using HttpRequestMessage request = new HttpRequestMessage(method, url);
  // 方式1：全局头（所有请求生效）
  client.DefaultRequestHeaders.Add("key","value");
  // 方式2：单次请求头（推荐！互不干扰，不污染全局）
  request.Headers.Add("key","value");
  ```

  

例：

```c#
// get请求
static void Main(string[] args)
{
    request("https://uapis.cn/api/v1/saying").Wait();
}
static async Task request(string url)
{
    var client = new HttpClient();
    var response = await client.GetAsync(url);
    var result = await response.Content.ReadAsStringAsync();
    var result1 = JsonSerializer.Deserialize<Dictionary<string, string>>(result);
    Console.WriteLine(result1["text"]);
}

// 下载图片
var client = new HttpClient();
// 返回字节数组
byte[] fileBytes = await client.GetByteArrayAsync("https://ts1.tc.mm.bing.net/th/id/OIP-C.EE8WtoIvwLKYO083qZIo8AAAAA?r=0&rs=1&pid=ImgDetMain&o=7&rm=3");
// 写入本地文件
File.WriteAllBytes(@"D:\test.png", fileBytes);
```



## 六、泛型

当我们希望参数类型不是固定死的，而是当我们在调用方法时，传递的实参类型作为实际的类型，这时候就需要使用泛型。

意思是我们定义方法，类型可以不固定，可以动态设置类型。

例：我们之前封装查看列表数据的函数

```c#
static void ShowListData<T>(List<T> list)
{
    foreach(T item in list)
    {
        Console.WriteLine(item);
    }
}

List<int> list1 = new List<int>()
{
    1,2,3,4
};
ShowListData<int>(list1);

List<string> list2 = new List<string>()
{
    "aa", "bb", "cc", "dd"
};
ShowListData<string>(list2);
```

方法可以使用泛型，类也可以使用泛型。

```c#
// 经典例子：键值对 （模拟的底层 字典类）
class Dictionary<TKey,TValue> 
{
    
}

Dictionary<int,string> pair = new Dictionary<int,string>();
```



## 七、项目发布

我们项目做好后，需要发给别人使用，就需要将项目进行打包发布，步骤如下：

解决方案资源管理器 → 控制台项目 → 右键 → 发布

目标选择：文件夹 → 下一步

指定输出文件夹（比如 `bin\Release\publish`）

部署模式：独立：自带运行库，推荐给普通用户

目标运行时：Windows 电脑选：win-x64

文件夹选项：

> 生成单个文件
>
> 启用 ReadyToRun（可选，加快启动速度）

配置 → 发布模式：Release（发行版，优化、去掉调试信息）

发布完成后打开输出目录，你会看到单独一个 xxx.exe，直接发给别人运行。

