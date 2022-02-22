using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShippingBox : MonoBehaviour
{
    List<Item> items;
    Player player;

    private void Start()
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
        UIManager.Instance.getUITooltip().gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        UIManager.Instance.getUITooltip().gameObject.SetActive(false);
    }
}
