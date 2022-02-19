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
    public void updateHotbar(List<Item> items)
    {
        int count = 0;
        foreach (HotbarSlot hotbarSlot in GetComponentsInChildren<HotbarSlot>())
        {
            if (count < items.Count)
            {
                hotbarSlot.setSprite(items[count].getSprite());
            }
            count++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
