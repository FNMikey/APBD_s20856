using Lecture3.Models;

namespace Lecture3;

public class Program
{
    public static void Main(string[] args)

    {

        Ship ship = new Ship(100, 4, 30000);

        CooledContainer cooledContainer = new CooledContainer(100, 100, 100 , 1000, CooledContainer.ProductType.Butter);

        GasContainer gasContainer = new GasContainer(100, 100, 100, 100, 100);

        LiquidContainer liquidContainer = new LiquidContainer(100, 100, 100, 100, true);

        LiquidContainer liquidContainer2 = new LiquidContainer(100, 100, 100, 100, true);

        cooledContainer.LoadContainer(50);

        gasContainer.LoadContainer(10);


        ship.AddContainer(gasContainer);
        ship.AddContainer(liquidContainer);
        ship.AddContainer(liquidContainer2);
        ship.AddContainer(cooledContainer);

        ship.RemoveContainer(liquidContainer2);
        ship.RemoveContainer(liquidContainer2);

        ship.PrintShipInfo();


      }
}
