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
        //UIManager.Instance.
    }
}
