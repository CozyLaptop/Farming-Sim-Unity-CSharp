using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMerchant : MonoBehaviour
{
    private bool waitingForResponse;
    // Start is called before the first frame update
    private void OnMouseOver()
    {
        UIManager.Instance.getUITooltip().setActive();
        UIManager.Instance.getUITooltip().setSpriteToDialogue();
    }
    private void OnMouseExit()
    {
        UIManager.Instance.getUITooltip().disable();
    }
    private void OnMouseDown()
    {
        
        UIManager.Instance.getDialogueUI().setYesNoScript("Hey, it would help me out if you bought some seeds." +
            " I would really like to open up a shop one of these days.", "Buy seeds", "No thanks");
        waitingForResponse = true;
    }
    private void Update()
    {
        if (waitingForResponse)
        {
            if(UIManager.Instance.getResponse() == "Yes")
            {
                UIManager.Instance.activateSeedShop();
                waitingForResponse = false;
            }

        }
    }
}
