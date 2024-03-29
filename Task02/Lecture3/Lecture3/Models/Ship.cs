using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    internal class Ship
    {
        public List<Container> Containers { get; set; }
        public double MaxSpeed { get; set; }
        public int MaxContainerCount { get; set; }
        public double MaxLoadWeight { get; set; }

    }
}
