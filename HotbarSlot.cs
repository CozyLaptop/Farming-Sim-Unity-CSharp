using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarSlot : MonoBehaviour
{
    private Sprite slotSprite;
    private Text quantity;
    private string slotNumber;

    // Start is called before the first frame update
    private void Awake()
    {
        slotSprite = transform.GetChild(0).gameObject.GetComponent<Image>().sprite;
        quantity = transform.GetChild(1).gameObject.GetComponent<Text>();

        quantity.text = "200";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
