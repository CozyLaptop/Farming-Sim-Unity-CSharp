using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private Dictionary<Item, int> playerInventoryAmounts;
    private List<Item> playerInventoryOrder;

    public PlayerInventory()
    {
        playerInventoryAmounts = new Dictionary<Item, int>();
        playerInventoryOrder = new List<Item>();
    }

    public void addToInventory(Item item, int amount)
    {
        //If player inventory does not have item in inventory
        //Add key and amount
        if (!playerInventoryAmounts.ContainsKey(item))
        {
            Debug.Log("Picked up " + item.getItemName());
            playerInventoryAmounts.Add(item, amount);
            playerInventoryOrder.Add(item);
        }
        //If player has item, add to amount
        else
        {
            playerInventoryAmounts[item]++;
            Debug.Log("You now have " + playerInventoryAmounts[item] + " " + item.getItemName());
        }
    }
    public void showInventory()
    {
        foreach (Item item in playerInventoryOrder)
        {
            Debug.Log(item.getItemName());
        }
    }
    public int getItemCount()
    {
        return playerInventoryOrder.Count;
    }
    public List<Item> getInventoryList()
    {
        //return playerInventoryOrder.GetRange(0,10);
        return playerInventoryOrder;
    }
    public List<Item> getInventoryList10()
    {
        return playerInventoryOrder.GetRange(0,10);
    }
    public Dictionary<Item, int> getPlayerInventoryAmounts()
    {
        return playerInventoryAmounts;
    }
}
