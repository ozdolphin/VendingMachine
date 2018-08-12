using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Models;
using VendingMachine.RepoServices.Interfaces;
using VendingMachine.ViewModels;

namespace VendingMachine.Controllers
{
    public class HomeController : Controller
    {
        private IVendingMachineRepo _vendingMachineRepo;

        public HomeController(IVendingMachineRepo vendingMachineRepo)
        {
            _vendingMachineRepo = vendingMachineRepo;
        }

        public IActionResult Index()
        {
            MachineStatus status = _vendingMachineRepo.GetMachineStatus();
            return View(MachineViewModel.ConvertFromModel(status));
        }

        [HttpPost]
        public IActionResult Index(MachineViewModel vm, string purchase, string restock)
        {
            if (!string.IsNullOrEmpty(purchase))
            {
                _vendingMachineRepo.Purchase(vm.SelectedSlotNumber, vm.SelectedPaymentType == 1 ? Enums.PaymentType.Cash : Enums.PaymentType.CreditCard);
            }
            if (!string.IsNullOrEmpty(restock))
            {
                _vendingMachineRepo.ReStockMachine();
            }

            MachineStatus status = _vendingMachineRepo.GetMachineStatus();
            return View(MachineViewModel.ConvertFromModel(status));
        }
    }
}
