using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static ConsoleApp8_20.Project;

namespace ConsoleApp8_20
{
    internal class Rentcar
    {
        public string path { get; } = "./rent.json";
        public string carpath { get; } = "./car.json";
        public string uerpath { get; } = "./uer.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };
        public void rentcar(int rentCar, int renUer)
        {
            if (!File.Exists(carpath))
            {
                Console.WriteLine("目前没有车辆，请先添加");
                return;
            }
            else if (!File.Exists(uerpath))
            {
                Console.WriteLine("目前没有用户信息，请先添加");
                return;
            }


            List<Rent> list = new List<Rent>();
            List<Car> list1 = new List<Car>();
            List<Uers> list2 = new List<Uers>();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(this.path);
                list = JsonSerializer.Deserialize<List<Rent>>(json);

            }

            string json1 = File.ReadAllText(carpath);
            list1 = JsonSerializer.Deserialize<List<Car>>(json1);
            string json2 = File.ReadAllText(uerpath);
            list2 = JsonSerializer.Deserialize<List<Uers>>(json2);

            Car f1 = list1.Find(item => item.CarId == rentCar);
            Uers f2 = list2.Find(item => item.UerId == renUer);

            if (f1 == null)
            {
                Console.WriteLine("该车id没有在车库里面");
                return;
            }
            if (f2 == null)
            {
                Console.WriteLine("该用户id没有在用户列表里面");
                return;
            }

            if (f1.CarStatus == false)
            {
                Console.WriteLine("该车已经被出租");
                return;
            }
            f1.CarStatus = false;
            string s3 = JsonSerializer.Serialize(list1, this.JsonOpt);
            File.WriteAllText(carpath, s3);
            Rent r = new Rent(list.Count + 1, rentCar, renUer, DateTime.Now.ToString(), "", 0);
            list.Add(r);
            string s2 = JsonSerializer.Serialize(list, this.JsonOpt);
            File.WriteAllText(this.path, s2);
            Console.WriteLine("租车成功");
        }


        public void Returncar()
        {
            Console.WriteLine("请输入租车记录ID: ");
            int id = int.Parse(Console.ReadLine());
            if (!File.Exists(this.path))
            {
                Console.WriteLine("没有租车信息");
                return;
            }
            string json = File.ReadAllText(this.path);
            List<Rent> list = JsonSerializer.Deserialize<List<Rent>>(json);
            Rent x = list.Find(item => item.RentId == id);


            string j = File.ReadAllText(carpath);
            List<Car> list1 = JsonSerializer.Deserialize<List<Car>>(j);
            Car y = list1.Find(item => item.CarId == id);




            if (x == null)
            {
                Console.WriteLine("租车记录ID有误");
                return;
            }
            if (y.CarStatus)
            {
                Console.WriteLine("该车没有被出租");
                return;
            }

            Carclass CM = new Carclass();
            double price = CM.Cartime(x.RentId);
            TimeSpan diff = DateTime.Now - DateTime.Parse(x.RentTime);
            double payMoney = (double)diff.TotalHours * price;
            x.Money = payMoney;
            x.ReturnTime = DateTime.Now.ToString();

            string jsonrrStr = JsonSerializer.Serialize(list, this.JsonOpt);
            File.WriteAllText(this.path, jsonrrStr);
            Console.WriteLine("还车成功");
            Console.WriteLine();

        }




        public void SearchAll()
        {
            if (!File.Exists(this.path))
            {
                Console.WriteLine("没有租车信息");
                return;
            }
            string j = File.ReadAllText(path);
            List<Rent> list = JsonSerializer.Deserialize<List<Rent>>(j);
            if (list.Count == 0)
            {
                Console.WriteLine("没有租车信息");
                return;
            }
            // 遍历输出
            list.ForEach(item =>
            {
                Console.WriteLine($"租车记录ID: {item.RentId} -- 车辆ID: {item.RentId} -- 客户ID: {item.RenUer} -- 租赁时间: {item.RentTime} -- 还车时间: {item.ReturnTime} -- 费用: {item.Money}");
            });
        }
    }
}
