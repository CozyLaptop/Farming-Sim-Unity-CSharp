using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FarmTiles : MonoBehaviour
{
    //private Player player;
    private Tilemap tilemap;
    //private Tile[] tiles;
    //private Dictionary<Vector3Int, Tile> vector3FarmTileDict = new Dictionary<Vector3Int, Tile>();

    // Start is called before the first frame update
    void Start()
    {
        //player = FindObjectOfType<Player>();
        tilemap = GetComponent<Tilemap>();
        foreach(Vector3Int tilePos in tilemap.cellBounds.allPositionsWithin)
        //foreach(Tile tile in tilemap.GetTilesBlock(tilemap.cellBounds))
        {
            Tile tile = (Tile) tilemap.GetTile(tilePos);
            if (tile.name == "soil")
            {
                FarmTile ft = (FarmTile) ScriptableObject.CreateInstance(typeof(FarmTile));
                tilemap.SetTile(tilePos, ft);
                ft = (FarmTile) tilemap.GetTile(tilePos);
                ft.setVector3IntPos(tilePos);

                int randomNum = UnityEngine.Random.Range(0, 100);
                if (randomNum <= 15)
                {
                    ft.setTopObject(Resources.Load<GameObject>("Prefabs/tree1"));
                    Instantiate(Resources.Load<GameObject>("Prefabs/tree1"), ft.getPos(), Quaternion.identity);
                }
            }
            //tilemap.SetTile(vector3Pos, new FarmTile(vector3Pos));
            //vector3FarmTileDict.Add(vector3Pos, new Tile(vector3Pos));

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3Int tilePos = tilemap.WorldToCell(worldPoint);

            // Try to get a tile from cell position
            TileBase tile = tilemap.GetTile(tilePos);

            if (tile.name == "soil")
            {
                //tilemap.SetTile(tilePos, new Tile(tilePos));
            }
        }
    }
}
