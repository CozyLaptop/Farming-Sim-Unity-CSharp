using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private Dictionary<int, Item> itemDatabase;
    public ItemManager()
    {
        itemDatabase = new Dictionary<int, Item>();
    }

    public Item getItem(int id)
    {
        Item item = itemDatabase.TryGetValue(id);
        return item;
    }
}
