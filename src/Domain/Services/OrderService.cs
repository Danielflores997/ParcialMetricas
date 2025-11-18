using System;
using System.Collections.Generic;

namespace Domain.Services;

using Domain.Entities;
using System.Collections.Immutable;

public static class OrderService
{
    public static ImmutableList<Order> LastOrders = ImmutableList<Order>.Empty;

    public static Order CreateTerribleOrder(string customer, string product, int qty, decimal price)
    {
        var o = new Order { Id = new Random().Next(1, 9999999), CustomerName = customer, ProductName = product, Quantity = qty, UnitPrice = price };
        LastOrders = LastOrders.Add(o);
        Infrastructure.Logging.Logger.Log("Created order " + o.Id + " for " + customer);
        return o;
    }
}
