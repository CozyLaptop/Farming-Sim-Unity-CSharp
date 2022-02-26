using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuOption : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        showArrow();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hideArrow();
    }

    public void showArrow()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void hideArrow()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
