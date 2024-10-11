using System;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double TotalCost()
    {
        double _total = 0;
        foreach (Product product in _products)
        {
            _total += product.TotalCost();
        }
        double shipping = _customer.InUSA() ? 5.0 : 35.0;
        return _total + shipping;
    }

    public string PackingLabel()
    {
        string _label = "Packing Label:\n";
        foreach (Product product in _products)
        {
            _label += $"{product.Name} ({product.ProductId})\n";
        }
        return _label;
    }

    public string ShippingLabel()
    {
        return $"Shipping Label:\n{_customer.Name}\n{_customer.GetAddress()}";
    }
}