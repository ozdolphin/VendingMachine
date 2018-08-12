using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Enums;
using VendingMachine.Models;

namespace VendingMachine.RepoServices.Interfaces
{
    /// <summary>
    /// Interface for vending machine repository
    /// </summary>
    public interface IVendingMachineRepo
    {
        /// <summary>
        /// Restock machine should reset everything all machine status
        /// </summary>
        void ReStockMachine();

        /// <summary>
        /// This method will mark given machine slot as empty and add puchase amount to relevant payment type 
        /// </summary>
        /// <param name="slotNumber"></param>
        /// <param name="paymentType"></param>
        void Purchase(int slotNumber, PaymentType paymentType);

        /// <summary>
        /// Returns the latest machine status
        /// </summary>
        /// <returns></returns>
        MachineStatus GetMachineStatus();
    }
}
