﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3.Models
{
    internal interface IHazardNotifier
    {
        void NotifyHazard(string serialNumber);
    }
}
