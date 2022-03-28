using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //image.color = new Color32(226, 169, 110, 255);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = new Color32(215, 151, 85, 255);
    }
    public void OnMouseUpAsButton()
    {
        //Debug.Log("clicked");
    }
    public void OnMouseDown(PointerEventData eventData)
    {
        //Debug.Log("pressed");
        //image.color = new Color32(195, 131, 65, 255);
    }
    public void OnMouseUp(PointerEventData eventData)
    {
        //image.color = new Color32(215, 151, 85, 255);
    }
}
