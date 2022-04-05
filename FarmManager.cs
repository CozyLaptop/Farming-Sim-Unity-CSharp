using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmManager : MonoBehaviour
{
    private Grid grid;
    private Tilemap groundTilemap;
    public GameObject tree1;
    private void Awake()
    {

    }
    private void Start()
    {
        //Get grid and tilemap ready
        //grid = FindObjectOfType<Grid>();
        //List<Tilemap> tilemaps = new List<Tilemap>(grid.gameObject.GetComponentsInChildren<Tilemap>());
        //groundTilemap = tilemaps[0];

        //Setup item database

        //Spawn random objects on the farm
        spawnFarm();
    }
    private void spawnFarm()
    {
        foreach (Vector3Int position in groundTilemap.cellBounds.allPositionsWithin)
        {
            Vector3 posXYZ = new Vector3Int(position.x, position.y, 0);
            TileBase tile = groundTilemap.GetTile(position);
            if(tile.name == "soil")
            {

            }
        }
    }
}
