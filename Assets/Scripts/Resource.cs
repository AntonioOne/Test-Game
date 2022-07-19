using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Resource
{
    public enum Type
    {
        Energy, Wood, Stone, 
    }
    public TextMeshPro text;
    public string Name { get; private set; }

    public bool Unlocked { get; }

    public Resource(string name)
    {
        Name = name;
    }

    public virtual Type ResourceType { get; }
    
    private double quantity = 0.0;
    public double Quantity
    {
        get => quantity;
        set
        {
            quantity = value;
            UpdateUI();
        }
    }

    public Action UpdateUIAction { get; set; }
    
    void UpdateUI()
    {
        if (text == null) return;
        text.gameObject.SetActive(Unlocked);
        if (Unlocked)
            text.text = string.Concat(Name, ": ", quantity.ToString(CultureInfo.InvariantCulture));
    }
}
