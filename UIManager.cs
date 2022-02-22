using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //
    private GameObject uITooltip;

    private void Awake()
    {
        _instance = this;
        uITooltip = Instantiate(Resources.Load<GameObject>("Prefabs/UI/uiMouseTooltip"), new Vector3(0, 0, 0), Quaternion.identity);
        uITooltip.SetActive(false);
    }
    private void Start()
    {

    }

    public UITooltip getUITooltip()
    {
        return uITooltip.GetComponent<UITooltip>();
    }
}
