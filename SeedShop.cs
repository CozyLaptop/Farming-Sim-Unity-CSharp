using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedShop : MonoBehaviour
{
    private Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        closeButton = transform.GetChild(2).GetComponent<Button>();
        closeButton.onClick.AddListener(CloseShop);
    }
    private void CloseShop()
    {
        Debug.Log("Clicked");
        this.gameObject.SetActive(false);
    }
}
