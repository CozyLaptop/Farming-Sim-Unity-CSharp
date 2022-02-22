using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory();
    }

    private void OnMouseEnter()
    {
        UIManager.Instance.getUITooltip().gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        UIManager.Instance.getUITooltip().gameObject.SetActive(false);
    }
    public Inventory getInventory()
    {
        return inventory;
    }
}
