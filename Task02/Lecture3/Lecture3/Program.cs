using Lecture3.Models;

namespace Lecture3;

public class Program
{
    public static void Main(string[] args)

    {

        Ship ship = new Ship(100, 4, 30000);

        CooledContainer cooledContainer = new CooledContainer(100, 100, 100 , 1000, CooledContainer.ProductType.Butter);
        Console.WriteLine(cooledContainer.ToString());

        GasContainer gasContainer = new GasContainer(100, 100, 100, 10, 10);
        Console.WriteLine(gasContainer.ToString());

        LiquidContainer liquidContainer = new LiquidContainer(100, 100, 100, 100, true);
        Console.WriteLine(liquidContainer.ToString());

        ship.AddContainer(gasContainer);
        ship.AddContainer(liquidContainer);
        ship.AddContainer(cooledContainer);

        ship.PrintShipInfo();


      }
}
