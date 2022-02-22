using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    private Inventory playerInventory;
    bool activeSlot;
    HotbarSlot[] hotbarSlots;

    private void Awake()
    {
        
    }
    void Start()
    {
        hotbarSlots = GetComponentsInChildren<HotbarSlot>();
        setHotbarNumbers();
        playerInventory = GameObject.Find("Farmer").GetComponent<Player>().getInventory();
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
    public void updateHotbar()
    {
        //playerInventory.getInventoryList().Count;
        int count = 1;
        foreach (HotbarSlot hotbarSlot in GetComponentsInChildren<HotbarSlot>())
        {
            if(playerInventory.getItemCount() == 0)
            {
                hotbarSlot.setSpriteToNone();
                hotbarSlot.removeQuantityNumber();
                UIManager.Instance.getUITooltip().OnChangeHotbar();
            }
            if (playerInventory.getItemCount() >= count)
            {
                hotbarSlot.setSprite(playerInventory.getSpriteFromIndex(count - 1));
                hotbarSlot.setQuantity(playerInventory.getIndividualItemCount(playerInventory.getItemFromIndex(count - 1)));
                count++;
                UIManager.Instance.getUITooltip().OnChangeHotbar();
            }
            else
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
        UIManager.Instance.getUITooltip().OnChangeHotbar();
        
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
