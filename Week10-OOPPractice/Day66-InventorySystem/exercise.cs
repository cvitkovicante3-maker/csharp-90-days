using System;
using System.Collections.Generic;

// Item class — represents a single item
class Item
{
    public string Name { get; set; }
    public int Weight { get; set; }
    public int Value { get; set; }

    public Item(string name, int weight, int value)
    {
        Name = name;
        Weight = weight;
        Value = value;
    }

    public void ShowInfo()
    {
        Console.WriteLine(Name + " | Weight: " + Weight + " | Value: " + Value);
    }
}

// Inventory class — manages a collection of items
class Inventory
{
    private List<Item> _items;
    private int _maxWeight;
    private int _currentWeight;

    public Inventory(int maxWeight)
    {
        _items = new List<Item>();
        _maxWeight = maxWeight;
        _currentWeight = 0;
    }

    public bool AddItem(Item item)
    {
        if (_currentWeight + item.Weight > _maxWeight)
        {
            Console.WriteLine("Too heavy! Cannot carry " + item.Name);
            return false;
        }

        _items.Add(item);
        _currentWeight += item.Weight;
        Console.WriteLine("Added " + item.Name + ". Weight: " + _currentWeight + "/" + _maxWeight);
        return true;
    }

    public void RemoveItem(string itemName)
    {
        Item found = _items.Find(i => i.Name == itemName);
        if (found != null)
        {
            _items.Remove(found);
            _currentWeight -= found.Weight;
            Console.WriteLine("Removed " + itemName);
        }
        else
        {
            Console.WriteLine(itemName + " not found.");
        }
    }

    public void ShowInventory()
    {
        Console.WriteLine("=== INVENTORY ===");
        Console.WriteLine("Weight: " + _currentWeight + "/" + _maxWeight);
        foreach (Item item in _items)
        {
            Console.Write("- ");
            item.ShowInfo();
        }
    }

    public int GetTotalValue()
    {
        int total = 0;
        foreach (Item item in _items)
        {
            total += item.Value;
        }
        return total;
    }
}

class Program
{
    static void Main()
    {
        Inventory backpack = new Inventory(50);

        Item sword = new Item("Iron Sword", 10, 100);
        Item potion = new Item("Health Potion", 2, 25);
        Item shield = new Item("Wooden Shield", 15, 50);
        Item armor = new Item("Plate Armor", 30, 200);

        backpack.AddItem(sword);
        backpack.AddItem(potion);
        backpack.AddItem(shield);
        backpack.ShowInventory();

        Console.WriteLine("Total value: " + backpack.GetTotalValue());

        backpack.AddItem(armor); // Should fail — too heavy
        backpack.RemoveItem("Health Potion");
        backpack.ShowInventory();
    }
}
