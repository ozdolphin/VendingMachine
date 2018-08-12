using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    /// <summary>
    /// This class holds information for each individual soft drink
    /// </summary>
    public class SoftDrink
    {
        public string Name { get; set; }
        public Color Flavour { get; set; }
    }
}
