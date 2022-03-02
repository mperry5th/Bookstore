using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bookstore.Controllers.Infrastructure;
using Bookstore.Models;

namespace Bookstore.Pages
{
    public class SummaryModel : PageModel
    {
        public IBookstoreRepository repo { get; set; }
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public SummaryModel(IBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books p = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(p, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int BookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == BookId).Book);

            return RedirectToPage( new {ReturnUrl = returnUrl});
        }
    }
}