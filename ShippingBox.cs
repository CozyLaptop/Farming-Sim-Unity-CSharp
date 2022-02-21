using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    List<Item> items;
    Player player;
    private GameObject uiPopup;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        items = new List<Item>();
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        player.setUIEnabled();
    }
    private void OnMouseExit()
    {
        player.setUIDisable();
    }
    public void OnHotbarChange()
    {
        uiPopup.GetComponent<UITooltip>().setSprite(player.getSpriteOfEquippedItem());
    }
    public GameObject getUITooltip()
    {
        return uiPopup;
    }
}
