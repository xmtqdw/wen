using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8_20
{
    internal class Project
    {
        internal class Car
        {
            public string CarName { get; }
            public int CarId { get; }
            public bool CarStatus { get; set; }
            public string CarType { get; set; }
            public double Price { get; set; }
            public string Time {  get;}
             public Car(int CarId, string CarName, string CarType, bool CarStatus,  double Price,string Time)
            {
                this.CarId = CarId;
                this.CarName = CarName;
                this.CarStatus = CarStatus;
                this.CarType = CarType;
                this.Price = Price;
                this.Time = Time;
            }
        }
        internal class Uers 
        {
            public int UerId { get; }
            public string UerName { get;set; }
            public string UerCard { get; }
            public string Time {  get;}
            public string UerPhone { get; set; }
            public string Gender { get; set; }
            public string Motto { get; set; }

            public Uers(int uerId, string uerName, string uerCard, string time, string uerPhone, string gender, string motto)
            {
                this.UerId = uerId;
                this.UerName = uerName;
                this.UerCard = uerCard;
                this.Time = time;
                this.UerPhone = uerPhone;
                this.Gender = gender;
                this.Motto = motto;
            }
        }
        internal class Rent
        {
            public int RentId { get; }
            public int RentCar { get;}
            public int RenUer { get; }
            public string RentTime { get; }
            public string ReturnTime { get; set; }
            public double Money { get; set; }

            public Rent (int rentId, int rentCar, int renUer, string rentTime,string ReturnTime ,double Money)
            {
                this.RentId = rentId;
                this.RentCar = rentCar;
                this.RenUer = renUer;
                this.RentTime = rentTime;
                this.ReturnTime = ReturnTime;
                this.Money = Money;
            }
        }

    }
}
