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
            player.useLeftClick();

            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

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
    public FarmTiles getFarmTiles()
    {
        return farmTiles;
    }
}