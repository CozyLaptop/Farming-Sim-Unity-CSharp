using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    public Sprite sprite;
    private Texture2D icon;

    void OnGUI()
    {
        icon = sprite.texture;
        GUI.Box(new Rect(10, 10, 20, 20), new GUIContent("1", icon));
        //GUI.Label(new Rect(10, 40, 100, 20), GUI.tooltip);
    }
}
