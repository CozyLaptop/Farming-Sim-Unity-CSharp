using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    private void Awake()
    {
        ItemManager.initializeItemDatabase();
    }
}
