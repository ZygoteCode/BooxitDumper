using System.Collections.Generic;

public class BooxitMerchantManager
{
    private List<BooxitMerchant> _booxitMerchants;

    public BooxitMerchantManager()
    {
        _booxitMerchants = new List<BooxitMerchant>();
    }

    public BooxitMerchant GetBooxitMerchantByName(string name)
    {
        foreach (BooxitMerchant booxitMerchant in _booxitMerchants)
        {
            if (booxitMerchant.Name.Equals(name))
            {
                return booxitMerchant;
            }
        }

        return null;
    }

    public bool IsBooxitMerchantExisting(string name)
    {
        foreach (BooxitMerchant booxitMerchant in _booxitMerchants)
        {
            if (booxitMerchant.Name.Equals(name))
            {
                return true;
            }
        }

        return false;
    }

    public void AddBooxitMerchant(BooxitMerchant booxitMerchant)
    {
        _booxitMerchants.Add(booxitMerchant);
    }
}