using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    private string itemName;
    private Sprite sprite;

    public Item(int id, string name)
    {
        this.id = id;
        this.itemName = name;
        this.sprite = Resources.Load<Sprite>("ItemSprites/" + itemName);
    }

    public Item(int id)
    {
        this.id = id;
        this.itemName = ItemManager.getItemName(id);
        this.sprite = Resources.Load<Sprite>("ItemSprites/" + itemName);
    }
    public string getItemName()
    {
        return itemName;
    }
    public int getId()
    {
        return id;
    }
    public Sprite getSprite()
    {
        return this.sprite;
    }
}
