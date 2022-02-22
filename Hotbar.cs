using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    UITooltip uITooltip;
    bool activeSlot;
    HotbarSlot[] hotbarSlots;

    private void Awake()
    {
        
    }
    void Start()
    {
        uITooltip = UIManager.Instance.getUITooltip().GetComponent<UITooltip>();
        hotbarSlots = GetComponentsInChildren<HotbarSlot>();
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
        //Change ui popup sprite to the equipped item, blank if none
        uITooltip.gameObject.GetComponent<UITooltip>().OnChangeHotbar();
        
    }
    public void deactivateAllSlots()
    {
        foreach(HotbarSlot slot in hotbarSlots)
        {
            slot.setInactive();
        }
    }
    public int getActiveSlot()
    {
        int activeSlotNumber = 99;
        if (activeSlot)
        {
            foreach (HotbarSlot slot in hotbarSlots)
            {
                if (slot.isActive())
                {
                    activeSlotNumber = slot.getSlotNumber();
                }
            }
        }
        return activeSlotNumber;
    }
}
