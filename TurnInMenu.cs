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
            //collect funds from shipping box
            FindObjectOfType<Player>().addToGoldAndUpdateUI(FindObjectOfType<ShippingBox>().getValueOfItems());
            //set shippingbox amount to 0;
            FindObjectOfType<ShippingBox>().setValueTo0();
            //set day to next
            //grow plants

            eventData.pointerCurrentRaycast.gameObject.GetComponent<MenuOption>().hideArrow();
            eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "No")
        {
            //hides arrow and disables window
            eventData.pointerCurrentRaycast.gameObject.GetComponent<MenuOption>().hideArrow();
            eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);

        }
    }
}
