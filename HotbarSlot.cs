using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    bool activeSlot;
    Color32 inactiveSlotColor = new Color32(159, 97, 47,255);
    Color32 activeSlotColor = new Color32(130, 85, 48, 255);
    Sprite inactiveSlotSprite;
    Sprite activeSlotSprite;


    private Text quantity;
    private Text slotNumber;
    private Image imageComponentForSprite;
    private Image imageComponent;

    private void Awake()
    {
        activeSlot = false;
        imageComponent = gameObject.GetComponent<Image>();
        imageComponentForSprite = transform.GetChild(0).gameObject.GetComponent<Image>();
        quantity = transform.GetChild(1).gameObject.GetComponent<Text>();
        slotNumber = transform.GetChild(2).gameObject.GetComponent<Text>();
        inactiveSlotSprite = Resources.Load<Sprite>("UISprites/emptyhotbarslot");
        activeSlotSprite = Resources.Load<Sprite>("UISprites/activehotbarslot");
    }

    public Sprite getSprite()
    {
        return imageComponentForSprite.sprite;
    }
    public void setSprite(Sprite sprite)
    {
        imageComponentForSprite.enabled = true;
        imageComponentForSprite.sprite = sprite;
    }
    public void setSpriteToNone()
    {
        imageComponentForSprite.enabled = false;
    }
    public int getSlotNumber()
    {
        if(slotNumber.text == "0")
        {
            return 9;
        } else
        return int.Parse(slotNumber.text) - 1;
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
        if(quantity == 1)
        {
            this.quantity.text = "";
        }
        else
        {
            this.quantity.text = quantity.ToString();
        }
    }
    public void removeQuantityNumber()
    {
        this.quantity.text = "";
    }
    public void setActive()
    {
        this.activeSlot = true;
        imageComponent.sprite = activeSlotSprite;
    }
    public void setInactive()
    {
        this.activeSlot = false;
        imageComponent.sprite = inactiveSlotSprite;
    }
    public bool isActive()
    {
        return activeSlot;
    }
}
