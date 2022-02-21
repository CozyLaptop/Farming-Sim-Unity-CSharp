using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITooltip : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Vector3 worldPosition;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        spriteRenderer.sprite = player.getSpriteOfEquippedItem();
    }
    public void OnChangeHotbar()
    {
        spriteRenderer.sprite = player.getSpriteOfEquippedItem();
    }
    public void setSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    // Update is called once per frame
    void Update()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        transform.position = worldPosition;
    }
}
