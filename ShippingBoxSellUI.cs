using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShippingBoxSellUI : MonoBehaviour
{
    public float timer;
    TextMeshPro textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }
    private void FixedUpdate()
    {

    }
    public void setAmount(int amount)
    {
        this.textMeshPro.text = amount.ToString();
    }
}