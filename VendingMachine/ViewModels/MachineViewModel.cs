using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Models;

namespace VendingMachine.ViewModels
{
    /// <summary>
    /// This is the view model to hold overall information about the machine
    /// </summary>
    public class MachineViewModel
    {
        public decimal CreditTotal { get; set; }
        public decimal CashTotal { get; set; }
        public List<MachineSlotViewModel> Slots { get; set; } = new List<MachineSlotViewModel>();
        public int SelectedSlotNumber { get; set; }
        public IEnumerable<SelectListItem> DrinkItems
        {
            get { return Slots.Where(s => s.IsEmpty == false).Select(s => new SelectListItem() { Text = s.Drink.Name, Value = Convert.ToString(s.SlotId) }); }
        }

        public int SelectedPaymentType { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes
        {
            get {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Text = "Cash", Value = "1"},
                    new SelectListItem(){Text = "Credit Card", Value = "2"}
                }; }
        }

        /// <summary>
        /// This method is used to convert from machine status data object to machine view model
        /// </summary>
        /// <param name="ms">machine status data object</param>
        /// <returns></returns>
        public static MachineViewModel ConvertFromModel(MachineStatus ms)
        {
            MachineViewModel vm = new MachineViewModel();
            vm.Slots = ms.Slots.Select(s => new MachineSlotViewModel()
            {
                Drink = s.Drink,
                IsEmpty = s.IsEmpty,
                SlotId = s.SlotNumber,
                Price = s.Price
            }).ToList();
            vm.CashTotal = ms.Total[Enums.PaymentType.Cash];
            vm.CreditTotal = ms.Total[Enums.PaymentType.CreditCard];
            return vm;
        }
    }
}
