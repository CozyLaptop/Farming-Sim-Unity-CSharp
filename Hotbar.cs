using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        setHotbarNumbers();
    }

    private void setHotbarNumbers()
    {
        int count = 1;
        foreach (HotbarSlot hotbarSlot in GetComponentsInChildren<HotbarSlot>())
        {
            if (count != 10)
            {
                hotbarSlot.setSlotNumber(count);
                count++;
            }
            else
            {
                hotbarSlot.setSlotNumber(0);
            }
        }
    }
    public void updateHotbar(List<Item> inventoryList, Dictionary<Item, int> playerInventoryDict)
    {
        int count = 0;
        foreach (HotbarSlot hotbarSlot in GetComponentsInChildren<HotbarSlot>())
        {
            if (count < inventoryList.Count)
            {
                hotbarSlot.setSprite(inventoryList[count].getSprite());
                hotbarSlot.setQuantity(playerInventoryDict[inventoryList[count]]);
                count++;
            }
        }
    }
    public void updateHotbarSlotAmount(int index, Item item)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
