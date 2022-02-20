using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    private Sprite slotSprite;
    private Text quantity;
    private Text slotNumber;
    private Image imageComponent;

    private void Awake()
    {
        imageComponent = transform.GetChild(0).gameObject.GetComponent<Image>();
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
        imageComponent.enabled = true;
        imageComponent.sprite = sprite;
    }
    public Text getSlotNumber()
    {
        return slotNumber;
    }
    public void setSlotNumber(int slotNumber)
    {
        // This is set from HotBar Script
        this.slotNumber.text = slotNumber.ToString();
    }
    public string getQuantity()
    {
        return this.quantity.text;
    }
    public void setQuantity(int quantity)
    {
        this.quantity.text = quantity.ToString();
    }
}
