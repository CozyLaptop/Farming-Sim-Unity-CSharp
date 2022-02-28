using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDoor : MonoBehaviour
{
    private DialogueUI dialogueUI;
    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        UIManager.Instance.getDialogueUI().setYesNoScript("Would you like to turn in for the day?", "Sleep", "No");
    }
    //public void hideMenu()
    //{
    //    turnInMenu.SetActive(false);
    //}
}
