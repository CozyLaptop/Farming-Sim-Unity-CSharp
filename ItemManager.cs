using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemManager
{
    private static Dictionary<int, Item> itemDatabase = new Dictionary<int, Item>();

    public static void initializeItemDatabase()
    {
        itemDatabase.Add(1, new Item(1, "Salmonberry"));
    }
    public static Item getItem(int id)
    {
        return itemDatabase[id];
    }
    public static String getItemName(int id)
    {
        return itemDatabase[id].getItemName();
    }
}
