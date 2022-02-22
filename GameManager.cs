using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;

        }
    }
    private void Awake()
    {
        _instance = this;
        Debug.Log("I'm awake");
    }
    public void testMessage()
    {
        Debug.Log("I'm working");
    }
    // implement your Awake, Start, Update, or other methods here...
}