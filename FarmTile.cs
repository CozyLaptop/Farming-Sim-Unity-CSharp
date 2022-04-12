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
        this.topObject = Instantiate(topObject, vector3Pos, Quaternion.identity);
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
    public void setSprite(Sprite sprite)
    {
        this.sprite = sprite;
    }
    public override void RefreshTile(Vector3Int position, ITilemap tilemap)
    {
        base.RefreshTile(position, tilemap);
    }
    public bool isTilled()
    {
        return tilled;
    }
    public void setTilled(bool tilled)
    {
        this.tilled = tilled;
        if (tilled)
        {
            sprite = Resources.Load<Sprite>("TileSprites/tilledSoil");
        } else
        {
            sprite = Resources.Load<Sprite>("TileSprites/soil");
        }
        Tilemap tilemap = FindObjectOfType<FarmTiles>().getTilemap();
        tilemap.RefreshTile(this.vector3Pos);
    }
}
