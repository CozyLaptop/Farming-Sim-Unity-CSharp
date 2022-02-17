using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    private Sprite slotSprite;
    private Text quantity;
    private Text slotNumber;

    private void Awake()
    {
        slotSprite = transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
        quantity = transform.GetChild(1).gameObject.GetComponent<Text>();
        slotNumber = transform.GetChild(2).gameObject.GetComponent<Text>();
    }

    public Sprite getSprite()
    {
        return slotSprite;
    }
    public void setSprite(Sprite sprite)
    {
        this.slotSprite = sprite;
    }
    public Text getSlotNumber()
    {
        return slotNumber;
    }
    private void setSlotNumber(int slotNumber)
    {
        // This should be set from HotBar Script
        this.slotNumber.text = slotNumber.ToString();
    }
    private void setQuantity(int quantity)
    {
        this.quantity.text = quantity.ToString();
    }
}
