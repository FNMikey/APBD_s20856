namespace Lecture3;

public class Program
{
    public static void Main(string[] args)
    {
        Subject s = new Subject();
        s.Name="MAD";
        
        Subject s2 = new Subject();
        s2.Name = "APBD";

        Console.WriteLine(s2.Name);

        //Collections/generics
        
        //ArrayList
        List<int> numbers = new List<int>();

        //Set
        HashSet<string> names = new HashSet<string>();
        names.Add("John");
      
        if (names.Contains("John"))
        {
            //...
        }
        
        //Dictionary/Map
        Dictionary<string, double> grades = new Dictionary<string, double>();
        grades.Add("s1345", 4.5);
        

    }
}
