using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    private Player player;
    private Hotbar hotbar;
    private FarmTiles farmTiles;

    private void Awake()
    {
        _instance = this;
    }
    private void Start()
    {
        ItemManager.initializeItemDatabase();
        player = FindObjectOfType<Player>();
        hotbar = FindObjectOfType<Hotbar>();
        farmTiles = FindObjectOfType<FarmTiles>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int tilePos = farmTiles.getTilemap().WorldToCell(worldPoint);

            if(farmTiles.getTile(tilePos).GetType() == typeof(FarmTile))
            {
                FarmTile clickedFarmTile = (FarmTile) farmTiles.getTile(tilePos);
                if (!clickedFarmTile.isTilled() && player.getEquippedItem().getItemName() == "oldHoe")
                {
                    Debug.Log("You've tilled the soil!");
                    //Set Sprite to tilled soil
                    clickedFarmTile.setTilled(true);
                    farmTiles.getTilemap().RefreshTile(tilePos);
                }
            }
            TileBase tile = farmTiles.getTile(tilePos);

            if (hitInfo.collider != null)
            {
                if (Vector2.Distance(transform.position, hitInfo.transform.position) < 3)
                {
                    if (hitInfo.transform.GetComponent<GroundPickableItem>())
                    {
                        int id = hitInfo.transform.GetComponent<GroundPickableItem>().id;
                        player.pickupItem(id);
                        Destroy(hitInfo.transform.gameObject);
                    }
                }

                if (Vector2.Distance(transform.position, hitInfo.transform.position) < 6)
                {
                }
            }
        }
    }

}