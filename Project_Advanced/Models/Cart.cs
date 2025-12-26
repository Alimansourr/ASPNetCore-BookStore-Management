
using Project_Advanced.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Project_Advanced.Models
 {       
    public class Cart
    {
        private readonly ApplicationDbContext _context; //interact with the database. 

        public Cart(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Id { get; set; }
        public List<CartItem> CartItems { get; set; }

        public static Cart GetCart(IServiceProvider services)
        { //access http session , unique cart asscvoiated by curent user
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString(); //store it here

            session.SetString("Id", cartId);

            return new Cart(context) { Id = cartId }; //return new one cartid uniuqe depns on session of userf
        }

        public CartItem GetCartItem(Book book) 
        {
            return _context.CartItems.SingleOrDefault(ci =>
                ci.Book.Id == book.Id && ci.CartId == Id);
        }

        public void AddToCart(Book book, int quantity)
        {
            var cartItem = GetCartItem(book);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Book = book,
                    Quantity = quantity,
                    CartId = Id
                };

                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public int ReduceQuantity(Book book)
        {
            var cartItem = GetCartItem(book);
            var remainingQuantity = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    remainingQuantity = --cartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(cartItem); //eza mara wehde mawjood
                }
            }
            _context.SaveChanges();

            return remainingQuantity;
        }

        public int IncreaseQuantity(Book book)
        {
            var cartItem = GetCartItem(book);
            var remainingQuantity = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 0)
                {
                    remainingQuantity = ++cartItem.Quantity;
                }
            }
            _context.SaveChanges();

            return remainingQuantity;
        }

        public void RemoveFromCart(Book book)
        {
            var cartItem = GetCartItem(book);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
            }
            _context.SaveChanges();
        }

        public void ClearCart()
        {
            var cartItems = _context.CartItems.Where(ci => ci.CartId == Id);

            _context.CartItems.RemoveRange(cartItems);

            _context.SaveChanges();
        }

        public List<CartItem> GetAllCartItems() //retr all cartitems for cur user
        {
            return CartItems ?? // hay betkhaline mesh kell mara jeeb data men db deghre men cached data
                (CartItems = _context.CartItems.Where(ci => ci.CartId == Id)
                    .Include(ci => ci.Book)
                    .ToList());
        }

        public int GetCartTotal()
        {
            return _context.CartItems
                .Where(ci => ci.CartId == Id)
                .Select(ci => ci.Book.price * ci.Quantity)
                .Sum();
        }
    }
}