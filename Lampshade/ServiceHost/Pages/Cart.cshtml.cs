using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {

        public List<CartItem>? CartItems;
        public void OnGet()
        {
            var serialize = new JavaScriptSerializer();
            var value = Request.Cookies["cart-items"];
            CartItems = serialize.Deserialize<List<CartItem>>(value);

            foreach (var item in CartItems)
            {
                item.TotalItemPrice = item.UnitPrice * item.Count;
            }
        }
    }
}
