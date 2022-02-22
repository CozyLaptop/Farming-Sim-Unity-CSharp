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
        //Get grid and tilemap ready
        grid = FindObjectOfType<Grid>();
        List <Tilemap> tilemaps = new List<Tilemap>(grid.gameObject.GetComponentsInChildren<Tilemap>());
        groundTilemap = tilemaps[0];



        //Setup item database
        ItemManager.initializeItemDatabase();

        //Spawn random objects on the farm
        spawnFarm();
    }
    private void Start()
    {
        //Setup UI Tooltip and disable
        GameObject uITooltip = Instantiate(Resources.Load<GameObject>("Prefabs/UI/uiMouseTooltip"), new Vector3(0, 0, 0), Quaternion.identity);
        uITooltip.SetActive(false);
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
