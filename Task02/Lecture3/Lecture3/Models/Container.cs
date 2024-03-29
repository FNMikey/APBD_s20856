using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
        public string SerialNumber { get;}
        public double MaxLoadCapacity { get; set; }

        public enum ContainerType
        {
            L, G, C
        };

        private static int uniqueNumber = 0;

        public Container(double ownWeight, int height, int depth, double maxLoadCapacity, ContainerType containerType)
        {
            OwnWeight = ownWeight;
            Height = height;
            Depth = depth;
            SerialNumber = GenerateSerialnumber(containerType);
            MaxLoadCapacity = maxLoadCapacity;
        }

        public string GenerateSerialnumber(ContainerType type) { 
        
            return $"KON-{type}-{++uniqueNumber}";

        }

        public virtual void LoadContainer(double loadMass)
        {
       
            if (loadMass > MaxLoadCapacity)
            {
                throw new OverfillException("Attempted to overfill the container");
            }
        
            LoadMass = loadMass;
        }

        public abstract void UnloadContainer();

        public override string? ToString()
        {
            return "Load mass: " + LoadMass  +
                   ", Height: " + Height +
                   ", Own weigh: " + OwnWeight +
                   ", Depth: " + Depth +
                   ", Serial number " + SerialNumber +
                   ", Max load capacity " + MaxLoadCapacity;
        }
    }
}