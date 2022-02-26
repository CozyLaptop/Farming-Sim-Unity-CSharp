using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmDoor : MonoBehaviour
{
    public GameObject turnInMenu;
    private void Awake()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        turnInMenu.SetActive(true);
    }
    //public void hideMenu()
    //{
    //    turnInMenu.SetActive(false);
    //}
}
