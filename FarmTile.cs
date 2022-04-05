using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTile : Tile
{
    GameObject topObject;
    int soilLevel;
    int experience;
    Vector3Int vector3Pos;
    bool tilled;
    bool watered;

    public void setTopObject(GameObject topObject)
    {
        this.topObject = topObject;
        Debug.Log("Instantiating at " + vector3Pos);
        topObject = Instantiate(topObject, vector3Pos, Quaternion.identity);
    }

    public Vector3Int getPos()
    {
        return vector3Pos;
    }
    public void setVector3IntPos(Vector3Int vector3Int)
    {
        this.vector3Pos = vector3Int;
    }
    public Vector3Int getVector3Int()
    {
        return vector3Pos;
    }
}
