using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    public GameObject sellUI;
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
