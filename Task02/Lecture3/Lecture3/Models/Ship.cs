using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class Ship
    {
        public List<Container> Containers { get; private set; }
        public double MaxSpeed { get; set; }
        public int MaxContainerCount { get; set; }
        public double MaxLoadWeight { get; set; }

        public Ship(double maxSpeed, int maxContainerCount, double maxLoadWeight)
        {
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxLoadWeight = maxLoadWeight;
            Containers = new List<Container>();
        }

        public void AddContainer(Container container)
        {
            if (Containers.Count >= MaxContainerCount)
            {
                throw new InvalidOperationException("Cannot add more containers: maximum capacity reached.");
            }

            double totalWeight = Containers.Sum(c => c.LoadMass + c.OwnWeight);
            if (totalWeight > MaxLoadWeight)
            {
                throw new InvalidOperationException("Cannot add the container: exceeding maximum load weight.");
            }

            Containers.Add(container);
        }

        public bool RemoveContainer(string serialNumber)
        {
            var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (container != null)
            {
                Containers.Remove(container);
                return true;
            }

            return false;
        }

        public bool ReplaceContainer(string serialNumber, Container newContainer)
        {
            int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
            if (index != -1)
            {
                Containers[index] = newContainer;
                return true;
            }

            return false;
        }



        public void PrintShipInfo()
        {
            Console.WriteLine($"Informacje o statku:");
            Console.WriteLine($"Maksymalna prędkość: {MaxSpeed}");
            Console.WriteLine($"Maksymalna liczba kontenerów: {MaxContainerCount}");
            Console.WriteLine($"Maksymalna waga ładunku: {MaxLoadWeight}");
            Console.WriteLine($"Aktualna liczba kontenerów: {Containers.Count}");
            Console.WriteLine($"Aktualna waga ładunku: {Containers.Sum(c => c.LoadMass + c.OwnWeight)}");

            Console.WriteLine($"Lista kontenerów:");

            if (Containers.Count == 0)
            {
                Console.WriteLine("Brak kontenerów na statku.");
                return;
            }

            foreach (var container in Containers)
            {
                Console.WriteLine(container.ToString());
            }
        }
    }

}
