using System;

public class Address
{
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string Street, string City, string StateOrProvince, string Country)
    {
        _street = Street;
        _city = City;
        _stateOrProvince = StateOrProvince;
        _country = Country;
    }

    public bool InUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string FullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}