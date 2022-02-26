using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TurnInMenu : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "Yes")
        {
            Debug.Log(FindObjectOfType<ShippingBox>());
            //collect funds from shipping box
            //set day to next
            //grow plants
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "No")
        {
            //hides arrow and disables window
            eventData.pointerCurrentRaycast.gameObject.GetComponent<MenuOption>().hideArrow();
            eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);

        }
    }
}
