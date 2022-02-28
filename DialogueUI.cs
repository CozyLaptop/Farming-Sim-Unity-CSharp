using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour, IPointerClickHandler
{
    Text dialogueText;
    Image dialogueArrow;
    Text yesText;
    Text noText;

    enum DialogueState{
        Continue,
        Decision
    }
    private void Awake()
    {
        dialogueText = transform.GetChild(0).GetComponent<Text>();
        dialogueArrow = dialogueText.transform.GetChild(0).GetComponent<Image>();
        yesText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        noText = transform.GetChild(2).GetChild(0).GetComponent<Text>();

        setAllInactive();
    }
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
    public void setContinueScript()
    {
        gameObject.SetActive(true);

    }
    public void setYesNoScript(string dialogue, string yes, string no)
    {
        gameObject.SetActive(true);

        this.dialogueText.gameObject.SetActive(true);
        this.dialogueText.text = dialogue;
        this.dialogueArrow.gameObject.SetActive(false);
        //
        this.yesText.gameObject.SetActive(true);
        this.yesText.text = yes;
        //
        this.noText.gameObject.SetActive(true);
        this.noText.text = no;
        //
    }
    public void setAllInactive()
    {
        dialogueArrow.gameObject.SetActive(false);
        yesText.gameObject.SetActive(false);
        noText.gameObject.SetActive(false);
    }
    public void test()
    {
        Debug.Log("test test");
    }
}
