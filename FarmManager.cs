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
        grid = FindObjectOfType<Grid>();
        List <Tilemap> tilemaps = new List<Tilemap>(grid.gameObject.GetComponentsInChildren<Tilemap>());
        groundTilemap = tilemaps[0];
        //change each tilemap that is soil to random chance for spawn object
        spawnFarm();
        ItemManager.initializeItemDatabase();
    }
    private void spawnFarm()
    {
        foreach (Vector3Int position in groundTilemap.cellBounds.allPositionsWithin)
        {
            Vector3 posXYZ = new Vector3Int(position.x, position.y, 0);
            TileBase tile = groundTilemap.GetTile(position);
            if(tile.name == "soil")
            {
                int randomNum = UnityEngine.Random.Range(0, 100);
                if(randomNum <= 15)
                {
                    Instantiate(tree1, grid.GetCellCenterWorld(position), Quaternion.identity);
                }
            }
        }
    }
}
