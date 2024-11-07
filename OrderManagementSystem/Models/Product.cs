﻿namespace OrderManagementSystem.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}