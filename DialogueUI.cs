using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour, IPointerClickHandler
{
    enum DialogueState
    {
        Continue,
        Decision
    }
    DialogueState dialogueState;
    Text dialogueText;
    Image dialogueArrow;
    Text yesText;
    Image yesArrow;
    Text noText;
    Image noArrow;


    private void Awake()
    {
        dialogueText = transform.GetChild(0).GetComponent<Text>();
        dialogueArrow = dialogueText.transform.GetChild(0).GetComponent<Image>();
        yesText = transform.GetChild(1).GetChild(0).GetComponent<Text>();
        //yesArrow = transform.GetChild(1)
        noText = transform.GetChild(2).GetChild(0).GetComponent<Text>();

        setAllInactive();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name);
        if (eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == "Yes")
        {
            UIManager.Instance.setResponse("Yes");
        }
        if (eventData.pointerCurrentRaycast.gameObject.transform.parent.gameObject.name == "No")
        {
            UIManager.Instance.setResponse("No");
        }
    }
    public void setContinueScript()
    {
        gameObject.SetActive(true);

    }
    public void setYesNoScript(string dialogue, string yes, string no)
    {
        UIManager.Instance.setResponse("Waiting");
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
        //disable yes arrow
        //disable no arrow
    }
    public void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void OnDisable()
    {
        Time.timeScale = 1;
        transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
    }
}
