using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public class GasContainer : Container, IHazardNotifier
    {
        public double Pressure { get; set; }

        public GasContainer(double ownWeight, int height, int depth, double maxLoadCapacity, double pressure)
            : base(ownWeight, height, depth, maxLoadCapacity, ContainerType.G)
        {
            Pressure = pressure;
        }

        public override void LoadContainer(double loadMass)
        {
            if (loadMass > MaxLoadCapacity)
            {
                NotifyHazard("Attempted to overload a gas container.");
                throw new OverfillException("Attempted to overfill the container");
            }
            LoadContainer(loadMass);
        }

        public override void UnloadContainer()
        {
            LoadMass = LoadMass * 0.05;
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"{message} - serial number: {SerialNumber}");
        }
    }

}
