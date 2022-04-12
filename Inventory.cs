using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private int gold;
    private Dictionary<Item, int> inventoryDict;
    private List<Item> inventoryList;

    public Inventory()
    {
        inventoryDict = new Dictionary<Item, int>();
        inventoryList = new List<Item>();
        gold = 0;
    }
    public void addToInventory(Item item, int amount)
    {
        if (!inventoryDict.ContainsKey(item))
        {
            inventoryDict.Add(item, amount);
            inventoryList.Add(item);
        }
        else
        {
            inventoryDict[item]++;
        }
    }
    public void removeOneFromInventory(Item item)
    {
        if(inventoryDict[item] < 1)
        {
            removeFromInventory(item);
        } else
        {
            inventoryDict[item] -= 1;
        }
        if(inventoryDict[item] == 0)
        {
            removeFromInventory(item);
        }
    }
    public void removeFromInventory(Item item)
    {
        inventoryList.Remove(item);
        inventoryDict.Remove(item);
    }
    public int getItemCount()
    {
        return inventoryList.Count;
    }
    public int getIndividualItemCount(Item item)
    {
        return inventoryDict[item];
    }
    public List<Item> getInventoryList()
    {
        return inventoryList;
    }
    public Dictionary<Item, int> getInventoryDict()
    {
        return inventoryDict;
    }
    public Item getItemFromIndex(int index)
    {
        if (hasItemAtIndex(index))
        {
            return inventoryList[index];
        }
        else return null;
    }
    public Sprite getSpriteFromIndex(int index)
    {
        try
        {
            return inventoryList[index].getSprite();
        }
        catch {
            return Resources.Load<Sprite>("ItemSprites/emptySprite");
        }
    }
    public bool hasItemAtIndex(int index)
    {
        try
        {
            return (inventoryList[index] != null);
        }

        catch
        {
            return false;
        }
    }
    public void showInventory()
    {
        for(int i = 0; i < inventoryList.Count; i++)
        foreach (Item item in inventoryList)
        {
            Debug.Log(item.getItemName());
        }
    }
    public void addGold(int gold)
    {
        this.gold += gold;
    }
    public int getGoldAmount()
    {
        return this.gold;
    }

}
