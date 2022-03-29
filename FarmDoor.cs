using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDoor : MonoBehaviour
{
    private DialogueUI dialogueUI;
    private bool waitingForResponse;
    private void Start()
    {
        waitingForResponse = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager.Instance.getDialogueUI().setYesNoScript("Would you like to turn in for the day?", "Sleep", "No");
        waitingForResponse =  true;
    }

    private void Update()
    {
        if (waitingForResponse)
        {
            if (UIManager.Instance.getResponse() == "Yes")
            {
                //collect funds from shipping box
                FindObjectOfType<Player>().addToGoldAndUpdateUI(FindObjectOfType<ShippingBox>().getValueOfItems());
                //set shippingbox amount to 0;
                FindObjectOfType<ShippingBox>().setValueTo0();
                //set day to next
                //grow plants

                //eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.GetComponent<MenuOption>().hideArrow();
                //eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.SetActive(false);

                UIManager.Instance.getDialogueUI().gameObject.SetActive(false);
                waitingForResponse = false;
            }
            if(UIManager.Instance.getResponse() == "No")
            {
                //eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.GetComponent<MenuOption>().hideArrow();
                UIManager.Instance.getDialogueUI().gameObject.SetActive(false);
                waitingForResponse = false;
            }
        }
    }
    //While response is none, wait for response
    //If yes, then sleep
    //if no, disable UI
}
