using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    private GameObject sellUI;
    TextMeshPro textMeshPro;
    int shippingAmount = 0;
    Inventory inventory;
    private void Awake()
    {
        inventory = new Inventory();
        textMeshPro = transform.GetComponentInChildren<TextMeshPro>();
        textMeshPro.text = shippingAmount.ToString();
        sellUI = Resources.Load<GameObject>("Prefabs/UI/ShippingBoxSellUI");
    }
    private void OnMouseEnter()
    {
        UIManager.Instance.getUITooltip().gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        UIManager.Instance.getUITooltip().gameObject.SetActive(false);
    }
    private void OnMouseDown()
    {
        try
        {
            Player player = FindObjectOfType<Player>();
            //ShippingBox shippingBox = GetComponent<ShippingBox>();
            //Add to shipping box inventory
            inventory.addToInventory(player.getEquippedItem(), 1);
            //Update shipping box amount
            addToShippingAmount(player.getEquippedItem().getSellingPrice());
            //Remove one from inventory
            player.getInventory().removeOneFromInventory(player.getEquippedItem());
            //Update hotbar to reflect new amount
            Hotbar hotbar = FindObjectOfType<Hotbar>();
            hotbar.updateHotbar();
        }
        catch
        {
            Debug.Log("Could not add item because equipped slot doesnt contain an item");
        }
    }
    public Inventory getInventory()
    {
        return inventory;
    }
    public void addToShippingAmount(int itemPrice)
    {
        shippingAmount += itemPrice;
        textMeshPro.text = shippingAmount.ToString();
        GameObject _sellUI = Instantiate(sellUI, transform.position, Quaternion.identity);
        _sellUI.transform.parent = gameObject.transform;
        _sellUI.GetComponent<TextMeshPro>().text = itemPrice.ToString();
    }
    public int getValueOfItems()
    {
        return this.shippingAmount;
    }
    public void setValueTo0()
    {
        this.shippingAmount = 0;
        textMeshPro.text = "0";
    }
}
