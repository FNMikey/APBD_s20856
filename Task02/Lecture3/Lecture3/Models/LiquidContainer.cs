using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    internal class LiquidContainer : Container, IHazardNotifier
    {

        public bool IsHazardous { get; set; }

        public LiquidContainer(double ownWeight, int height, int depth, string serialNumber, double maxLoadCapacity, bool isHazardous)
            : base(ownWeight, height, depth, serialNumber, maxLoadCapacity)
        {
            IsHazardous = isHazardous;
        }

        public override void LoadContainer(double loadMass)
        {
            double capacityLimit = IsHazardous ? MaxLoadCapacity * 0.5 : MaxLoadCapacity * 0.9;
            if (loadMass > capacityLimit)
            {
                NotifyHazard("Attempted to overload liquid container.");
                throw new Exception("OverfillException");
            }
            base.LoadContainer(loadMass);
        }

        public void NotifyHazard(string message)
        {
            Console.WriteLine($"Hazard Notification for {SerialNumber}");
        }

    }
}
