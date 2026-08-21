using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ConsoleApp8_20.Project;

namespace ConsoleApp8_20
{
    internal class Carclass
    {
        public string path { get; } = "./car.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            // 在JSON序列化的时候中文不变
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        public string Caradd(string Card, string Type, string Price)
        {
            List<Car> list = new();
            if (File.Exists(path))
            {
                string s1= File.ReadAllText(path);
                 list=JsonSerializer.Deserialize<List<Car>>(s1);
                // 判断 车牌是否已存在 ==》使用列表的Exists
                if(list.Exists(item =>item.CarName==Card)) return "新增失败，车牌已存在";
            }
            // 将接受的数据组装成Car实例对象，然后添加到list中 ---> 序列化list---》写入json文件
            Car Caradd = new Car(list.Count + 1, Card, Type, true, double.Parse(Price), DateTime.Now.ToString());
            list.Add(Caradd);
            string s2 = JsonSerializer.Serialize(list, this.JsonOpt);
            File.WriteAllText(this.path,s2);
            
            return "添加成功";
        }
        public void  CarSearch()
        {
            List<Car> list2 = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(path);
                list2 = JsonSerializer.Deserialize<List<Car>>(s1);

            }else
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//没有文件
                return;
            }
            if(list2.Count == 0)
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//有文件但是文件内容为空
                return;
            }
            foreach (var item in list2)
            {
                string statusStr = item.CarStatus?"空闲":"已租出";
                Console.WriteLine($"id : {item.CarId} -- 车牌 : {item.CarName} -- 类型 : {item.CarType} -- 状态 : {statusStr} -- 时租费 : {item.Price} ");
            }


        }
        public void CarSearchone(int x)
        {
            List<Car> list3 = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(path);
                list3 = JsonSerializer.Deserialize<List<Car>>(s1);
            }
            else
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//没有文件
                return ;
            }
            if (list3.Count == 0)
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//有文件但是文件内容为空
                return;
            }
            
             Car list4 = list3.Find(item => item.CarId == x);
            if(list4 != null)
            {
                string statusStr = true ? "空闲" : "已租出";
                Console.WriteLine($"id : {list4.CarId} -- 车牌 : {list4.CarName} -- 类型 : {list4.CarType} -- 状态 : {statusStr} -- 时租费 : {list4.Price} ");
            }else
            {
                Console.WriteLine("车库里面没有该车");
                return; 
            }

            return ;
        }
        public void Carkong()
        {
            List<Car> list5 = new();
            if (File.Exists(path))
            {
                string s1 = File.ReadAllText(path);
                list5 = JsonSerializer.Deserialize<List<Car>>(s1);
            }
            else
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//没有文件
                return;
            }
            if (list5.Count == 0)
            {
                Console.WriteLine("车库里面没有车辆，请先添加");//有文件但是文件内容为空
                return;
            }
            List<Car> list = list5.FindAll(item => item.CarStatus  );
            if (list == null)
            {
                Console.WriteLine("车库里面没有空闲车");
                return;
            }
            foreach (var item in list)
            {
                Console.WriteLine($"id : {item.CarId} -- 车牌 : {item.CarName} -- 类型 : {item.CarType}  -- 时租费 : {item.Price} ");
            }

        }

        public double Cartime(int id)
        {
            string jsonStr = File.ReadAllText(this.path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);

            Car list = cars.Find(item => item.CarId == id);
            list.CarStatus = true;
            string res = JsonSerializer.Serialize(cars, this.JsonOpt);
            File.WriteAllText(this.path, res);

            return list.Price;
        }





    }

}
