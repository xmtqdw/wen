using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Car
{
    // 车辆管理类===> 管理车辆信息
    internal class CarManager
    {
        // 具备的属性： 车辆数据存储位置  车辆数据序列化配置项

        // 属性的赋值器 ===> 直接给属性初始值
        private string Path { get; } = "./car.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        // 新增车辆 方法
        public string Add(string card, string type, string price)
        {

            // 定义一个空的 list 
            List<Car> cars = new();
            // 判断存储文件是否存在 ==> 存在 -----》读取文件内容，并反序列化并将得到的数据列表赋值给list
            if (File.Exists(Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
                // 判断 车牌是否已存在 ==》列表的Exists
                if (cars.Exists(item => item.Card == card)) return "新增失败，车牌已存在";
            }
            // 将接受的数据组装成Car实例对象，然后添加到list中 ---> 序列化list---》写入json文件
            Car CAdd = new Car(cars.Count + 1, card, type, true, double.Parse(price));
            // true 表示空闲 false表示已租出
            cars.Add(CAdd);
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);

            return "新增车辆成功！！！";
        }
        // 查看所有车辆信息 方法
        public void SearchAll()
        {
            // 不存在====》没有车辆信息，请先添加
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有车辆信息，请先添加");
                return;
            }
            // 判断文件是否存在===存在，读取文件，反序列化 ===遍历输出
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            foreach (Car item in cars)
            {
                string statusStr = item.Status ? "空闲" : "已出租";
                Console.WriteLine($"id : {item.Id} -- 车牌 : {item.Card} -- 类型 : {item.Type} -- 状态 : {statusStr} -- 时租费 : {item.Price} ");
            }

        }
        // 查看某辆车 方法
        public void SearchOne(int id)
        {
            // 不存在====》没有车辆信息，请先添加
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有车辆信息，请先添加");
                return;
            }
            // 判断文件是否存在===存在，读取文件，反序列化 ===》根据id查找车辆对象===》找不到则提示===》找到了就输出
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            // 使用列表的Find 实现查找
            Car carObj = cars.Find(item => item.Id == id);
            if (carObj == null)
            {
                Console.WriteLine("没有车辆信息，请先添加");
                return;
            }
            string statusStr = carObj.Status ? "空闲" : "已出租";
            Console.WriteLine($"id : {carObj.Id} -- 车牌 : {carObj.Card} -- 类型 : {carObj.Type} -- 状态 : {statusStr} -- 时租费 : {carObj.Price} ");
        }
        //查看所有空闲车辆 方法
        public void SearchFree()
        {
            // 不存在====》没有车辆信息，请先添加
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有车辆信息，请先添加");
                return;
            }
            // 判断文件是否存在===存在，读取文件，反序列化
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            // 找到空闲车辆 使用list 的FindAll      Status 是true 就是空闲的
            List<Car> carsFree = cars.FindAll(item => item.Status);
            if (carsFree.Count == 0)
            {
                Console.WriteLine("没有空闲车辆信息，请先添加");
                return;
            }

            foreach (Car item in carsFree)
            {
                Console.WriteLine($"id : {item.Id} -- 车牌 : {item.Card} -- 类型 : {item.Type} -- 时租费 : {item.Price} ");
            }
        }

        // 根据id修改车辆状态 方法
        // 返回多个值 元组  第一个是提示信息，第二个是成功与否的状态
        public (string, bool) UpdateStatus(int id)
        {
            // 不存在====》没有车辆信息，请先添加
            if (!File.Exists(this.Path)) return ("暂无车辆！！！", false);
            // 判断文件是否存在===存在，读取文件，反序列化 ===》根据id查找车辆对象===》找不到则提示
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            // 使用列表的Find 实现查找
            Car carObj = cars.Find(item => item.Id == id);
            if (carObj == null) return ("没有对应ID的车辆！！！", false);
            if (!carObj.Status) return ("该车辆已被租出！！！", false);
            // 修改车辆状态
            carObj.Status = false;
            // 将修改后的 cars列表 序列化 写回文件
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);
            return ("租车成功！！！", true);
        }

        // 修改状态并获取 时租费
        public double UpAndGetInfo(int id)
        {
            // 读文件---》 反序列化 ---》车辆列表 ---》根据id查找---》修改状态 并获取数据返回
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);

            Car carObj = cars.Find(item => item.Id == id);

            // 修改车辆状态
            carObj.Status = true;
            // 将修改后的 cars列表 序列化 写回文件
            string resStr = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.Path, resStr);

            return carObj.Price;
        }
    }
}

// 定义一个空的 list ---->
// 判断存储文件是否存在 ==》
// 不存在 --->  将接受的数据组装成Car实例对象，然后添加到list中 ---> 序列化list---》写入json文件
// 存在 -----》读取文件内容，并反序列化并将得到的数据列表赋值给list---》将接受的数据组装成Car实例对象，然后添加到list中 ---> 序列化list---》写入json文件
