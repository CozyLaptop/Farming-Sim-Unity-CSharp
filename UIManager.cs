using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Singleton
    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject uIM = new GameObject("UIManager");
                _instance = uIM.AddComponent<UIManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;

        }
    }
    private enum Response
    {
        Yes,
        No,
        Continue,
        Cancel,
        None,
        Waiting
    };
    //
    private GameObject UIElements;
    private GameObject uITooltip;
    private GameObject moneyAndTimeUI;
    private Transform dialogueUI;
    private GameObject shopUI;
    private Response response;


    //
    private void Awake()
    {
        _instance = this;
        uITooltip = Instantiate(Resources.Load<GameObject>("Prefabs/UI/uiMouseTooltip"), new Vector3(0, 0, 0), Quaternion.identity);
        uITooltip.SetActive(false);
        moneyAndTimeUI = GameObject.Find("MoneyAndTime");
        dialogueUI = transform.GetChild(1);
        shopUI = transform.GetChild(3).gameObject;
        response = (Response)Enum.Parse(typeof(Response), "None");

    }
    public UITooltip getUITooltip()
    {
        return uITooltip.GetComponent<UITooltip>();
    }
    public DialogueUI getDialogueUI()
    {
        return dialogueUI.GetComponent<DialogueUI>();
    }
    public void updateGold(int gold)
    {
        moneyAndTimeUI.transform.GetChild(0).GetComponent<Text>().text = gold.ToString();
    }
    public void disableDialogueUI()
    {
        dialogueUI.gameObject.SetActive(false);
    }
    public string getResponse()
    {
        return response.ToString();
    }
    public void setResponse(string response)
    {
        this.response = (Response)Enum.Parse(typeof(Response), response);
    }
    public void activateSeedShop()
    {
        dialogueUI.gameObject.SetActive(false);
        shopUI.SetActive(true);
    }
    public void deactivateSeedShop()
    {
        shopUI.SetActive(false);
    }
}
