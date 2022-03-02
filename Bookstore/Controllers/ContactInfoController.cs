using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Bookstore.Controllers
{
    public class ContactInfoController : Controller
    {
        private IContactInfoRepository repo { get; set; }
        private Basket basket { get; set; }
        public ContactInfoController (IContactInfoRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        [HttpGet]
        public IActionResult Contact()
        {
            return View(new ContactInfo());
        }
        [HttpPost]
        public IActionResult Contact(ContactInfo Contact)
        {
            if (basket.Items.Count() == 0)
            {
                //ModelState.TryAddModelError("Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                Contact.Lines = basket.Items.ToArray();
                repo.SaveContactInfo(Contact);
                basket.ClearBasket();

                return RedirectToPage("/ContactInfoCompleted");
            }

            else
            {
                return View();
            }
        }
    }
}
