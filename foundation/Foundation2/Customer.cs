using System;

public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string Name, Address address)
    {
        _name = Name;
        _address = address;
    }

    public string Name { get { return _name; } }

    public bool InUSA()
    {
        return _address.InUSA();
    }

    public string GetAddress()
    {
        return _address.FullAddress();
    }
}