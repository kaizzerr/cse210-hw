using System;

public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string Name, string productId, double Price, int Quantity)
    {
        _name = Name;
        _productId = productId;
        _price = Price;
        _quantity = Quantity;
    }

    public string Name { get { return _name; } }
    public string ProductId { get { return _productId; } }
    public double Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    public double TotalCost()
    {
        return _price * _quantity;
    }
}