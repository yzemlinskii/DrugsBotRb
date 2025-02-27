﻿namespace Domain.Entities;

/// <summary>
/// Лекарственный препарат
/// </summary>
public class Drug : BaseEntity
{
    public Drug(string name, string manufacturer, string countryCodeId)
    {
        Name = name;
        Manufacturer = manufacturer;
        CountryCodeId = countryCodeId;
    }
    
    /// <summary>
    /// Название препарата.
    /// </summary>
    public string Name { get; private set; }
    
    public string Manufacturer { get; private set; }
    
    public string CountryCodeId { get; private set; }
}