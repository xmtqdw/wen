internal class Program
{
    private static void Main(string[] args)
    {
        List<string> name = new List<string> ()
        {
            
            "张三","李四","王五"
        };
        //list.AddRange(["Z"]);
        //list.AddRange([ "q","e","w" ]);
        //list.Insert(2, "X");
        //Console.WriteLine(list.Count);
        //Console.WriteLine(list[4]);
        Random r = new Random();
        int mun = r.Next(3);
        Console.WriteLine(name[mun]);
        
    }
}

