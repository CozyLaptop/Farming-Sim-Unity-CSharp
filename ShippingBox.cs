using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    List<Item> items;
    Player player;
    private UITooltip uITooltip;

    private void Start()
    {
        uITooltip = FindObjectOfType<UITooltip>();
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
        uITooltip.setActive();
        //player.setUIEnabled();
    }
    private void OnMouseExit()
    {
        uITooltip.disable();
    }
}
