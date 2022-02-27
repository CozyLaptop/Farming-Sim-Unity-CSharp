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
        //textMeshPro.text = "test";
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
    public void updateShippingAmount(int itemPrice)
    {
        shippingAmount += itemPrice;
        textMeshPro.text = shippingAmount.ToString();
        GameObject _sellUI = Instantiate(sellUI, transform.position, Quaternion.identity);
        _sellUI.transform.parent = gameObject.transform;
        _sellUI.GetComponent<TextMeshPro>().text = itemPrice.ToString();
    }
}
