using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedMerchant : MonoBehaviour
{
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
        UIManager.Instance.getDialogueUI().setYesNoScript("Hey, it would really help me out if you bought some seeds." +
            " I would like to open up a seed shop one of these days!", "Buy seeds", "No thanks");
    }
}
