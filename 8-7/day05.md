---
typora-copy-images-to: assets
---

# day05

## 上节回顾

while循环

```C#
while(条件){
    条件为true执行;    
    if() break;
}
```

do-while循环: 先执行一次循环代码, 然后条件判断

```C#
do{
    条件为true执行;  
}while(条件)
```

for循环

```C#
for(初始值;条件判断;值改变){ 循环代码}

初始值
for(;条件判断;){ 循环代码; 值改变}
```

循环控制关键字

```C#
continue:  跳过本次循环
break:     结束整体循环 (注意: 一般 因为是break结束的循环,所以循环变量组成条件判断其实还是true)
```

foreach循环

```C#
foreach(类型 变量 in 集合){
    // 变量===> 集合中的元素数据    
}
```

循环嵌套: 在循环代码中执行循环

```C#	
外层循环执行那个一次, 内层完成整个循环
```



## 一、数组的定义方式

### 1、先声明后赋值

```c#
// 声明长度为5的int数组，元素默认0
int[] arr1 = new int[5];
arr1[0] = 10;
```

### 2、声明并初始化

```c#
int[] arr2 = new int[4]{ 1, 2, 3, 4 };
```

### 3、省略长度

```c#
int[] arr3 = new int[]{ 10, 20, 30 };
```

### 4、简写

```c#
int[] arr4 = { 1, 3, 5, 7 };
```

### 5、新版本语法

`c#`12新增的集合语法，使用中括号：

```c#
int[] a = [1,2,3];
```

不止数组可以用，List也可以：

```c#
List<int> list = [10, 20, 30];
```

## 二、字典方法

```c#
Dictionary<string, dynamic> dic = new ()
{
    ["name"] = "张三",
    ["age"] = 12
};
```

- Add增加键值对

  ```C#
   dic.Add("height", 180);
   Console.WriteLine(dic["height"]);
   dic.Add("name", "李四"); // 报错, 不能添加同名键名
  ```

- ContainsKey/ContainsValue

  ```C#
  //ContainsKey / ContainsValue  判断键或值是否存在
  Console.WriteLine(dic.ContainsKey("name")); // True
  Console.WriteLine(dic.ContainsKey("gender")); // False
  Console.WriteLine(dic.ContainsValue("张三")); // True
  Console.WriteLine(dic.ContainsValue("李四")); // False
  ```

  

- Remove通过指定的键将键值对从字典中删除

  ```C#
  dic.Remove("name");
  foreach(dynamic item in dic) Console.WriteLine(item);
  // [age, 12]
  // [height, 180]
  ```

  

- Clear清空字典中的键值对

  ```C#
  dic.Clear();
  Console.WriteLine(dic.Count);
  ```

  

- Count获取字典长度

  ```C#
  Console.WriteLine(dic.Count); // 3
  ```

  

- Keys获取字典中所有键的集合

  ```C#
  var dicKyes = dic.Keys;
  //Console.WriteLine(dicKyes);
  //string[] keyArr = dicKyes.ToArray(); // 将键集合转为数组
  //foreach (string key in keyArr) Console.WriteLine(key);
  List<string> keylist = dicKyes.ToList(); // 将键集合转为list集合
  foreach (string key in keylist) Console.WriteLine(key);
  ```

  

- Values获取字典中所有值的集合

  ```C#
  var dicValues = dic.Values; // 获取所有字典中 键值 的集合
  //dynamic[] valArr = dicValues.ToArray(); // 将键值集合转为数组
  //foreach (dynamic val in valArr) Console.WriteLine(val);
  
  //List<dynamic> vallist = dicValues.ToList(); // 将键值集合转为list集合
  //foreach (dynamic val in vallist) Console.WriteLine(val);
  ```

  

- TryAdd ==> 不存在才添加，存在了就添加失败，但不报错

  ```C#
   Console.WriteLine(dic.TryAdd("gender", true)) ; // 添加成功则返回True
   Console.WriteLine(dic.TryAdd("name", "adsa")) ; // 添加失败则返回False
   foreach (dynamic item in dic) Console.WriteLine(item);
  ```

  


遍历：

```c#
// 遍历字典
// 方式1：遍历 KeyValuePair
foreach (dynamic item in dic)
{
    //Console.WriteLine(item);
    //Console.WriteLine(item.Key); // 获取对应的键名
    Console.WriteLine(item.Value); // 获取对应的键值
}

// 方式2：遍历所有键
foreach (dynamic item in dic.Keys)
{
    Console.WriteLine(item); // 键名
    //Console.WriteLine(dic[item]); // 键值
}

// 方式3：遍历所有值
foreach (dynamic item in dic.Values)
{
    Console.WriteLine(item);
}
```

## 三、List去重

List中的数据是可以重复的，去重就是将重复的数据删掉，让List中保留唯一的数据。

`List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];`

思路1：遍历每个元素，让这个元素跟他后面的每一个元素都做比较，相等就删掉

```C#
for (int i = 0; i < ints.Count; i++)
{
    // ints[i]
    // 从 i + 1 开始循环
    for (int j = i + 1; j < ints.Count; j++)
    {
        // 判断 ints[i] 和ints[j] 如果相同则删除
        if (ints[i] == ints[j])
        {
            ints.RemoveAt(j);
            j--; // 解决删除后 索引塌陷问题
        }
    }
}
// 验证去重效果
foreach (int n in ints) Console.WriteLine(n);
```



思路2：找元素最后一次出现的下标，跟第一次出现的下标是否相等，相等就表示元素没有重复，不相等就表示有重复，要删除掉最后一个重复元素。

```C#
for (int i = 0; i < ints.Count; i++)
{
    // ints[i]    // 第一个
    while (true)
    {
        int index = ints.LastIndexOf(ints[i]); // 查找ints[i] 最后一次出现的下标
        if (ints.LastIndexOf(ints[i]) != i)
        {
            ints.RemoveAt(index);
        }
        else {
            break; // 如果找到的就是本身 说明重复的就删完了
        }
    }
}
// 验证去重效果
foreach (int n in ints) Console.WriteLine(n);
```



思路3：利用字典中的键是唯一的，将List中每个数据都作为字典的键，最终在字典中的键都是唯一的，将所有键放在一个新的List中

```C#
//创建一个字典
Dictionary<int, dynamic> tmpDic = new();
foreach (int item in ints)
{
    // 遍历ints 将 其中的数据 作为 tmpDic的键名, 键值无所谓
    tmpDic[item] = "无所谓";
}

// 取出字典中的键 转为List
List<int> newList = tmpDic.Keys.ToList();
// 验证去重效果
foreach (int n in newList) Console.WriteLine(n);
```



思路4：创建一个新的List，遍历原本的List，原本List中的每一个元素，放在新的List中进行判断是否存在，如果不存在就添加到新的List中，如果存在就不添加

```C#
List<int> newInts = [];
// 遍历原本的List
foreach (int item in ints)
{
    // 判断 item在 newInsts中是否存在
    if (!newInts.Contains(item)) {
        newInts.Add(item);
    }
}
// 验证去重效果
foreach (int n in newInts) Console.WriteLine(n);
```





## 四、冒泡排序

概念：让每相邻的两个元素比较大小，如果不满足顺序，就交换他俩的位置。

```c#
List<int> ints = [5, 3, 4, 6, 7, 8, 9, 1, 2];
for (int j = 0; j < ints.Count - 1; j++)
{
    for (int i = 0; i < ints.Count - 1 - j; i++)
    {
        if (ints[i] > ints[i + 1])
        {
            int tmp = ints[i];
            ints[i] = ints[i + 1];
            ints[i + 1] = tmp;
        }
    }
}

foreach (int n in ints) Console.WriteLine(n);
```

例子：商品按照价格排序：

```c#
List<Dictionary<string, dynamic>> goodsList = new List<Dictionary<string, dynamic>>
{
    new Dictionary<string, dynamic>
    {
        {"name", "机械键盘"},
        {"price", 299.99},
        {"code", "G001"},
        {"stock", 120}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "无线鼠标"},
        {"price", 89.50},
        {"code", "G002"},
        {"stock", 356}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "27寸显示器"},
        {"price", 1299.00},
        {"code", "G003"},
        {"stock", 48}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "电竞耳机"},
        {"price", 199.00},
        {"code", "G004"},
        {"stock", 85}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "电脑支架"},
        {"price", 69.90},
        {"code", "G005"},
        {"stock", 210}
    }
};

// 按照价格做排序
for (int j = 0; j < goodsList.Count - 1; j++)
{
    for (int i = 0; i < goodsList.Count - 1 - j; i++)
    {
        if (goodsList[i]["price"] > goodsList[i + 1]["price"])
        {
            dynamic tmp = goodsList[i];
            goodsList[i] = goodsList[i + 1];
            goodsList[i + 1] = tmp;
        }
    }
}
foreach (dynamic item in goodsList) Console.WriteLine($"{item["name"]}--{item["price"]}");

```



## 五、案例

1、通过歌手查找歌曲集合

```c#
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
    },
    new Dictionary<string, dynamic>
    {
        {"singerId", 1004},
        {"singerName", "薛之谦"},
        {"genre", "抒情流行"}
    },
    new Dictionary<string, dynamic>
    {
        {"singerId", 1005},
        {"singerName", "毛不易"},
        {"genre", "民谣流行"}
    }
};

List<Dictionary<string, dynamic>> songList = new List<Dictionary<string, dynamic>>
{
    new Dictionary<string, dynamic>
    {
        {"songId", 10001},
        {"singerId", 1001},
        {"songName", "青花瓷"},
        {"duration", 239}
    },
    new Dictionary<string, dynamic>
    {
        {"songId", 10002},
        {"singerId", 1001},
        {"songName", "发如雪"},
        {"duration", 253}
    },
    new Dictionary<string, dynamic>
    {
        {"songId", 10003},
        {"singerId", 1001},
        {"songName", "东风破"},
        {"duration", 215}
    },
    new Dictionary<string, dynamic>
    {
        {"songId", 1004},
        {"singerId", 3002},
        {"songName", "不为谁而作的歌"},
        {"duration", 296}
    },
    new Dictionary<string, dynamic>
    {
        {"songId", 1005},
        {"singerId", 1002},
        {"songName", "背对背拥抱"},
        {"duration", 262}
    }
};
 // 用户输入歌手姓名：周杰伦/林俊杰 ==> 通过这个姓名将这个人唱的所有歌曲都找出来
 Console.WriteLine("请输入歌手姓名：");
 string singer = Console.ReadLine(); // 周杰伦
 // 先根据歌手名字 找到对应的 字典
 int singerId = 0; // 歌手ID

 // 遍历歌手集合  根据歌手名字 获取歌手ID
 foreach (Dictionary<string, dynamic> item in singerList)
 {
     // item 就是循环中 歌手列表的 数据字典
     if (item["singerName"] == singer) singerId = item["singerId"];
 }

 // 遍历歌曲集合  根据拿到的歌手id 去判断获取对应的歌曲字典并 存储到新list中
 var singerSongs = new List<Dictionary<string, dynamic>>();
 foreach (Dictionary<string, dynamic> item in songList)
 {
     if (item["singerId"] == singerId) singerSongs.Add(item);
 }

 // 遍历歌手的歌曲
 foreach (dynamic item in singerSongs) {
     Console.WriteLine(item["songName"]);
 }
```



## 六、作业: 

### 排序训练

```C#
// 商品数据
List<Dictionary<string, dynamic>> goodsList = new List<Dictionary<string, dynamic>>
{
    new Dictionary<string, dynamic>
    {
        {"name", "机械键盘"},
        {"price", 299.99},
        {"code", "G001"},
        {"stock", 120}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "无线鼠标"},
        {"price", 89.50},
        {"code", "G002"},
        {"stock", 356}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "27寸显示器"},
        {"price", 1299.00},
        {"code", "G003"},
        {"stock", 48}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "电竞耳机"},
        {"price", 199.00},
        {"code", "G004"},
        {"stock", 85}
    },
    new Dictionary<string, dynamic>
    {
        {"name", "电脑支架"},
        {"price", 69.90},
        {"code", "G005"},
        {"stock", 210}
    }
};
// 提示输入的 是price还是stock  排序类型 
// 提示输入的是 ASC 还是DSC     排序顺序(ASC升序,DSC降序)
// 根据输入完成数据排序
```

### 查询练习

```C#
// 数据使用案例中的数据

// 通过歌曲查找歌手
Console.WriteLine("输入歌曲名称：");
string song = Console.ReadLine();
```





