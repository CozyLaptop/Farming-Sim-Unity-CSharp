using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    bool activeSlot;
    HotbarSlot[] hotbarSlots;
    // Start is called before the first frame update
    void Start()
    {
        hotbarSlots = GetComponentsInChildren<HotbarSlot>();
        //setEquippedSlot(1);
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
            hotbarSlot.removeQuantityNumber();
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
            } else
            {
                hotbarSlot.removeQuantityNumber();
            }
        }
    }
    public void updateHotbarSlotAmount(int index, Item item)
    {

    }
    public void toggleActiveSlot(int slot)
    {
        if(slot == 0)
        {
            slot = 9;
        } else
        {
            slot -= 1;
        }

        if(hotbarSlots[slot].isActive())
        {
            hotbarSlots[slot].setInactive();
            activeSlot = false;
        }
        else
        {
            deactivateAllSlots();
            hotbarSlots[slot].setActive();
            activeSlot = true;
        }
    }
    public void deactivateAllSlots()
    {
        foreach(HotbarSlot slot in hotbarSlots)
        {
            slot.setInactive();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
