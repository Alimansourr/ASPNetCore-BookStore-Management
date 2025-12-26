using Microsoft.AspNetCore.Mvc;

using Project_Advanced.Data;
using Project_Advanced.Models;
using Microsoft.AspNetCore.Authorization;
using System;



namespace Project_Advanced.Controllers
{
        [Authorize]
        //d.i in constructor
        public class OrderController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly Cart _cart;

            public OrderController(ApplicationDbContext context, Cart cart)
            {
                _context = context;
                _cart = cart;
            }

            public IActionResult Checkout()
            {
                return View();
            }
        //get all the cartitems form the cart , then create order and clear the cart
            [HttpPost]
            public IActionResult Checkout(Order order)
            {
                var cartItems = _cart.GetAllCartItems();
                _cart.CartItems = cartItems;

                if (_cart.CartItems.Count == 0)
                {
                    ModelState.AddModelError("", "Cart is empty, please add a book first.");
                }

                if (ModelState.IsValid)
                {
                    CreateOrder(order);
                    _cart.ClearCart();
                    return View("CheckoutComplete", order);
                }

                return View(order);
            }

            public IActionResult CheckoutComplete(Order order)
            {
                return View(order);
            }
        // take date now , create order by taking info from cartitem and save them n ordr
            public void CreateOrder(Order order)
            {
                order.OrderPlaced = DateTime.Now;

                var cartItems = _cart.CartItems;

                foreach (var item in cartItems)
                {
                    var orderItem = new OrderItem()
                    {
                        Quantity = item.Quantity,
                        BookId = item.Book.Id,
                        OrderId = order.Id,
                        Price = item.Book.price * item.Quantity
                    };
                    order.OrderItems.Add(orderItem);
                    order.OrderTotal += orderItem.Price;
                }
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
        }
    }
