using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    public abstract class Container
    {
        public double LoadMass { get; protected set; }
        public int Height { get; set; }
        public double OwnWeight { get; set; }
        public int Depth { get; set; }
        public string SerialNumber { get; set; }
        public double MaxLoadCapacity { get; set; }

        public Container(double ownWeight, int height, int depth, string serialNumber, double maxLoadCapacity)
        {
            OwnWeight = ownWeight;
            Height = height;
            Depth = depth;
            SerialNumber = serialNumber;
            MaxLoadCapacity = maxLoadCapacity;
        }

        public virtual void LoadContainer(double loadMass)
        {
            if (loadMass > MaxLoadCapacity)
                throw new Exception("OverfillException");
            LoadMass = loadMass;
        }

        public void UnloadContainer() {

            LoadMass = 0;

        }
    }
}