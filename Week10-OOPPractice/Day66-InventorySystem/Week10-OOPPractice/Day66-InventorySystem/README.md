# Day 66: Inventory System

## 📚 Concept
Build an Item class and an Inventory class that manages items with weight limits, adding, removing, and using items.

## 💻 My Code
```csharp
using System;
using System.Collections.Generic;

class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Value { get; set; }

    public Item(string n, int w, int v) { Name = n; Weight = w; Value = v; }
    public void ShowInfo() { Console.WriteLine(Name + " | W:" + Weight + " | V:" + Value); }
}

class Inventory
{
    private List&lt;Item&gt; _items;
    private int _maxWeight;
    private int _currentWeight;

    public Inventory(int maxWeight)
    {
        _items = new List&lt;Item&gt;();
        _maxWeight = maxWeight;
        _currentWeight = 0;
    }

    public bool AddItem(Item item)
    {
        if (_currentWeight + item.Weight &gt; _maxWeight)
        {
            Console.WriteLine("Too heavy!");
            return false;
        }
        _items.Add(item);
        _currentWeight += item.Weight;
        return true;
    }

    public void RemoveItem(string itemName)
    {
        Item found = _items.Find(i =&gt; i.Name == itemName);
        if (found != null)
        {
            _items.Remove(found);
            _currentWeight -= found.Weight;
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("Weight: " + _currentWeight + "/" + _maxWeight);
        foreach (Item i in _items) i.ShowInfo();
    }

    public int GetTotalValue()
    {
        int total = 0;
        foreach (Item i in _items) total += i.Value;
        return total;
    }
}
