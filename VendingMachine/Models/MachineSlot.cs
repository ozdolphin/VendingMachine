using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Models
{
    /// <summary>
    /// This class defines the status of each machine slot
    /// </summary>
    public class MachineSlot
    {
        public int SlotNumber { get; set; }
        public bool IsEmpty { get; set; }
        public SoftDrink Drink { get; set; }
        public decimal Price { get; set; }
    }
}
