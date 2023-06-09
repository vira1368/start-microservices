﻿namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
        }

        public ShoppingCart(string username)
        {
            Username = username;
        }

        public string Username { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                Items.ForEach(item => totalPrice += item.Price * item.Quantity);
                return totalPrice;
            }
        }
    }
}
