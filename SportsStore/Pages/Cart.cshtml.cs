using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

namespace SportsStore.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository repository;

        public CartModel(IStoreRepository repository, Cart cart)
        {
            this.repository = repository;
            Cart = cart;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnGetRemove(long productId, string returnUrl)
        {
            var line = Cart.Lines.FirstOrDefault(cl => cl.Product.ProductID == productId);
            if (line != null)
            {
                if (line.Quantity > 1)
                {
                    line.Quantity--;
                }
                else
                {
                    Cart.RemoveLine(line.Product);
                }

                if (Cart is SessionCart sessionCart)
                {
                    sessionCart.Session?.SetJson("Cart", sessionCart);
                }
            }
            return RedirectToPage(new { returnUrl });
        }

    }
}