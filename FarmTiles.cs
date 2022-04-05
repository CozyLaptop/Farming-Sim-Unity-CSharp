using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTiles : MonoBehaviour
{
    private Tilemap tilemap;
    //private Dictionary<Vector3Int, Tile> vector3FarmTileDict = new Dictionary<Vector3Int, Tile>();

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        foreach(Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin)
        {
            Tile tile = (Tile) tilemap.GetTile(tilePos);
            if (tile.name == "soil")
            {
                FarmTile ft = (FarmTile) ScriptableObject.CreateInstance(typeof(FarmTile));
                tilemap.SetTile(tilePos, ft);
                ft = (FarmTile) tilemap.GetTile(tilePos);
                ft.setVector3IntPos(tilePos);
                ft.setSprite(Resources.Load<Sprite>("TileSprites/soil"));
                ft.setTilled(false);
                ft.name = ft.getVector3Int().x + ", " + ft.getVector3Int().y;

                int randomNum = UnityEngine.Random.Range(0, 100);
                if (randomNum <= 15)
                {
                    ft.setTopObject(Resources.Load<GameObject>("Prefabs/tree1"));
                }
            }
            tilemap.RefreshTile(tilePos);
        }
    }

    public Tilemap getTilemap()
    {
        return tilemap;
    }
    public TileBase getTile(Vector3Int tilePos)
    {
        return tilemap.GetTile(tilePos);
    }
}
