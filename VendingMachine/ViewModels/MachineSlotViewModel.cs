using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    /// <summary>
    /// This is the view model to hold the satus of each machine slot
    /// </summary>
    public class MachineSlotViewModel
    {
        public int SlotId { get; set; }
        public SoftDrink Drink { get; set; }
        public bool IsEmpty { get; set; }
        public decimal Price { get; set; }
    }
}
