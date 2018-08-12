using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Enums;

namespace VendingMachine.Models
{
    /// <summary>
    /// This class holds overall status of the vending machine
    /// </summary>
    public class MachineStatus
    {
        public List<MachineSlot> Slots { get; set; } = new List<MachineSlot>();
        public Dictionary<PaymentType, decimal> Total { get; set; } = new Dictionary<PaymentType, decimal>()
        {
            {PaymentType.Cash, 0 },
            {PaymentType.CreditCard, 0 }
        };

        public int AvailableSlots { get { return Slots.Where(s => s.IsEmpty == false).Count(); } }
    }
}
