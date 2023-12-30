﻿namespace Basket.Application.Responses;

public class ShoppingCartResponse
{
    public ShoppingCartResponse()
    {
    }


    public ShoppingCartResponse(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }

    public List<ShoppingCartItemResponse> Items { get; set; }


    public decimal TotalPrice
    {
        get { return Items.Sum(item => item.Quantity * item.Price); }
    }
}