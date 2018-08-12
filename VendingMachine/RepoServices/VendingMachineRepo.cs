using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Models;
using VendingMachine.RepoServices.Interfaces;

namespace VendingMachine.RepoServices
{
    /// <summary>
    /// This is the repository that stores all the information for vending machine
    /// </summary>
    public class VendingMachineRepo : IVendingMachineRepo
    {
        #region Properties
        private const int _maxMachineSlot = 10;
        private MachineStatus _machineStatus;
        private readonly Color[] _colors = new Color[_maxMachineSlot] {
            Color.AliceBlue,
            Color.Black,
            Color.Brown,
            Color.Chocolate,
            Color.Cyan,
            Color.DarkGray,
            Color.DarkOliveGreen,
            Color.DarkRed,
            Color.DarkTurquoise,
            Color.Indigo
        };
        #endregion

        public VendingMachineRepo()
        {
            resetAll();
        }

        #region Public methods
        public void ReStockMachine()
        {
            resetAll();
        }

        public void Purchase(int slotNumber, PaymentType paymentType)
        {
            MachineSlot slot = _machineStatus.Slots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            decimal currentTotal = _machineStatus.Total[paymentType];

            //Only process the payment when requested slot is not empty
            if(slot != null && slot.IsEmpty == false)
            {
                slot.IsEmpty = true;
                _machineStatus.Total[paymentType] = currentTotal + slot.Price;
            }
        }

        public MachineStatus GetMachineStatus()
        {
            return _machineStatus;
        }
        #endregion

        #region Private methods

        /// <summary>
        /// Reset all payment types to zero, and make sure all slots are restocked with drink again
        /// </summary>
        private void resetAll()
        {
            _machineStatus = new MachineStatus();
            for (int i = 0; i < _maxMachineSlot; i++)
            {
                _machineStatus.Slots.Add(new MachineSlot()
                {
                    Drink = new SoftDrink()
                    {
                        Name = $"Latte {i + 1}",
                        Flavour = _colors[i]
                    },
                    IsEmpty = false,
                    Price = 10.47M,
                    SlotNumber = i
                });
            }
        }
        #endregion
    }
}
