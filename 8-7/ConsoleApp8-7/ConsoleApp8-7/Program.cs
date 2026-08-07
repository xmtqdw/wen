using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

namespace ConsoleApp8_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Dictionary<string, dynamic> map = new Dictionary<string, dynamic>() 
            //{
            //    ["name"]= "马成功",
            //    ["age"] =19,
            //    ["hight"]=360 
            //};
            //map.Add("home", "jia");
            //Console.WriteLine(map["home"]);
            //Console.WriteLine(map.ContainsKey("name"));
            //Console.WriteLine(map.ContainsKey("aaa"));
            //Console.WriteLine(map.ContainsValue(19));
            //Console.WriteLine(map.ContainsValue(22));
            //map.Remove("home");
            //foreach(dynamic job in map) Console.WriteLine(job);
            //map.Clear();
            //Console.WriteLine(map.Count);

            //List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];
            //思路1：遍历每个元素，让这个元素跟他后面的每一个元素都做比较，相等就删掉
            //for (int i = 0; i < ints.Count; i++)
            //{

            //    for (int j = i+1; j <ints.Count ; j++)
            //    {
            //        if(ints[i] == ints[j])
            //        {
            //            ints.RemoveAt(j);
            //            j--;
            //        }

            //    }
            //}
            //foreach (int n in ints) Console.WriteLine(n);

            //思路2：找元素最后一次出现的下标，跟第一次出现的下标是否相等，相等就表示元素没有重复，不相等就表示有重复，要删除掉最后一个重复元素。
            //for (int i = 0; i < ints.Count; i++)
            //{
            //    while (true)
            //    {
            //        int x = ints.LastIndexOf(ints[i]);
            //        if (ints.LastIndexOf(ints[i]) != i)
            //        {
            //            ints.RemoveAt(x);

            //        }
            //        else
            //        {
            //            break;
            //        }
            //    }
            //}
            //    foreach (int n in ints) Console.WriteLine(n);

            //思路3：利用字典中的键是唯一的，将List中每个数据都作为字典的键，最终在字典中的键都是唯一的，将所有键放在一个新的List中
           // List<int> ints = [1, 3, 3, 3, 3, 4, 5, 6, 7, 7, 8, 6, 4, 2, 3];
           // Dictionary<int,dynamic> result = new ();
           // foreach (int arg in ints) {
           //     result[arg] = "ww";
           // }
           // List<int>newlist= result.Keys.ToList ();
           //foreach (int n in newlist) Console.WriteLine(n);


            //冒泡排序
            //List<int> ints = [1, 4, 5, 6, 7, 9, 8, 2, 3];
            //for (int i = 0; i < ints.Count-1; i++)
            //{
            //    for (int j = 0; j < ints.Count-1-i; j++)
            //    {
            //        if (ints[j] > ints[j + 1])
            //        {
            //            int tmp = ints[j];
            //            ints[j ] = ints[j+1];
            //            ints[j+1] = tmp;
            //        }
            //    }
            //}
            //foreach (int x in ints) Console.WriteLine(x);



            //作业1
            //            List<Dictionary<string, dynamic>> goodsList = new List<Dictionary<string, dynamic>>
            //{
            //                new Dictionary<string, dynamic>
            //                {
            //                    {"name", "机械键盘"},
            //                    {"price", 299.99},
            //                    {"code", "G001"},
            //                    {"stock", 120}
            //                },
            //                new Dictionary<string, dynamic>
            //                {
            //                    {"name", "无线鼠标"},
            //                    {"price", 89.50},
            //                    {"code", "G002"},
            //                    {"stock", 356}
            //                },
            //                new Dictionary<string, dynamic>
            //                {
            //                    {"name", "27寸显示器"},
            //                    {"price", 1299.00},
            //                    {"code", "G003"},
            //                    {"stock", 48}
            //                },
            //                new Dictionary<string, dynamic>
            //                {
            //                    {"name", "电竞耳机"},
            //                    {"price", 199.00},
            //                    {"code", "G004"},
            //                    {"stock", 85}
            //                },
            //                new Dictionary<string, dynamic>
            //                {
            //                    {"name", "电脑支架"},
            //                    {"price", 69.90},
            //                    {"code", "G005"},
            //                    {"stock", 210}
            //                }
            //            };
            //            Console.WriteLine("请输入你要排序的的内容（是price还是stock）");
            //            string x = Console.ReadLine();
            //            Console.WriteLine("请输入你选择的排序方式（是 ASC 还是DSC）");
            //            string y = Console.ReadLine();
            //            if(x == "price")
            //            {
            //                if (y == "ASC")
            //                {
            //                    for (int i = 0; i < goodsList.Count - 1; i++)
            //                    {
            //                        for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                        {
            //                            if (goodsList[j]["price"] > goodsList[j + 1]["price"])
            //                            {
            //                                Dictionary<string, dynamic> tmp = goodsList[j];
            //                                goodsList[j] = goodsList[j + 1];
            //                                goodsList[j + 1] = tmp;
            //                            }
            //                        }
            //                    }
            //                    foreach (Dictionary<string, dynamic> n in goodsList) Console.WriteLine($"{n["name"]}--{n["price"]}");
            //                }
            //                else if (y == "DSC")
            //                {
            //                    for (int i = 0; i < goodsList.Count - 1; i++)
            //                    {
            //                        for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                        {
            //                            if (goodsList[j]["price"] < goodsList[j + 1]["price"])
            //                            {
            //                                Dictionary<string, dynamic> tmp = goodsList[j];
            //                                goodsList[j] = goodsList[j + 1];
            //                                goodsList[j + 1] = tmp;
            //                            }
            //                        }
            //                    }
            //                    foreach (Dictionary<string, dynamic> n in goodsList) Console.WriteLine($"{n["name"]}--{n["price"]}");
            //                }
            //            }
            //            else if (x =="stock")
            //            {
            //                if (y == "ASC")
            //                {
            //                    for (int i = 0; i < goodsList.Count - 1; i++)
            //                    {
            //                        for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                        {
            //                            if (goodsList[j]["stock"] > goodsList[j + 1]["stock"])
            //                            {
            //                                Dictionary<string, dynamic> tmp = goodsList[j];
            //                                goodsList[j] = goodsList[j + 1];
            //                                goodsList[j + 1] = tmp;
            //                            }
            //                        }
            //                    }
            //                    foreach (Dictionary<string, dynamic> n in goodsList) Console.WriteLine($"{n["name"]}--{n["stock"]}");
            //                }
            //                else if (y == "DSC")
            //                {
            //                    for (int i = 0; i < goodsList.Count - 1; i++)
            //                    {
            //                        for (int j = 0; j < goodsList.Count - 1 - i; j++)
            //                        {
            //                            if (goodsList[j]["stock"] < goodsList[j + 1]["stock"])
            //                            {
            //                                Dictionary<string, dynamic> tmp = goodsList[j];
            //                                goodsList[j] = goodsList[j + 1];
            //                                goodsList[j + 1] = tmp;
            //                            }
            //                        }
            //                    }
            //                    foreach (Dictionary<string, dynamic> n in goodsList) Console.WriteLine($"{n["name"]}--{n["stock"]}");
            //                }
            //            }


            //作业2
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
           
            // 通过歌曲查找歌手
            Console.WriteLine("输入歌曲名称：");
            string song = Console.ReadLine();
            int songid = 0;
            foreach (Dictionary<string,dynamic>  gqu in songList)
            {
                if (gqu["songName"] == song) songid = gqu["singerId"];
            }
            
            foreach (Dictionary<string, dynamic> gqu in singerList)
            {
                if (songid == gqu["singerId"]) Console.WriteLine(gqu["singerName"]);
                //break;
            }

        }
    }
}
