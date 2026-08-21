using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Car
{
    // 车辆类 ====> 车辆数据类型 
    // 存储车辆信息时 的数据类型
    internal class Car
    {
        public int Id { get; } // id
        public string Card { get; } // 车牌号
        public string Type { get; set; } // 车辆类型
        public bool Status { get; set; } // 车辆状态
        public double Price { get; set; } // 小时非费用
        // 书写构造函数 ===》 方便实例化的时候设置属性值
        public Car(int Id, string Card, string Type, bool Status, double Price)
        {
            this.Id = Id;
            this.Card = Card;
            this.Type = Type;
            this.Status = Status;
            this.Price = Price;
        }
    }

    // Dictionary<string,dynamic>  ==序列化==> json字符串
    // ---反序列化--->Dictionary<string,dynamic>
    // 键值的类型因为是dynamic， 反序列化的时候 无法识别具体类型===>会转为 JSONElement类型
    // 之前所有的dynamic 的值 只能转为 JsonElement类型 需要根据方法转为目标类型 
    // 操作比较麻烦---->可以自己定义好类型 =====>类

    // 客户类
    internal class User
    {
        public int Id { get; }
        public string Name { get; set; }
        public string IdCard { get; }
        public string RegTime { get; }
        public string Gender { get; set; }
        public string PhoneNo { get; set; }
        public string Motto { get; set; }
        public User(int Id, string Name, string IdCard, string RegTime, string Gender, string PhoneNo, string Motto)
        {
            this.Id = Id;
            this.Name = Name;
            this.IdCard = IdCard;
            this.RegTime = RegTime;
            this.Gender = Gender;
            this.PhoneNo = PhoneNo;
            this.Motto = Motto;
        }
    }

    // 租还车记录类
    internal class RentReturn
    {
        public int Id { get; set; }  
        public int CarId { get; set; }  
        public int UserId { get; set; }  
        public string RentTime { get; set; }
        public string ReturnTime { get; set; }
        public double PayMoney { get; set; }
        public RentReturn(int Id, int CarId, int UserId, string RentTime, string ReturnTime, double PayMoney)
        {
            this.Id = Id;
            this.CarId = CarId;
            this.UserId = UserId;
            this.RentTime = RentTime;
            this.ReturnTime = ReturnTime;
            this.PayMoney = PayMoney;
        }
    }

}
