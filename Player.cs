using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private Hotbar hotbar;
    private Item equippedItem;

    private float baseSpeed = 5.0f;
    private Vector2 movementDirection;
    private float movementSpeed;
    private SpriteRenderer spriteRenderer;
    private Vector2 playerPosition;
    private string lastSpriteName;
    private string currentSpriteName;
    private Item lastEquippedItem;
    private Item currentEquippedItem;

    private Rigidbody2D rb;
    private Animator anim;
    private bool attacking;
    private bool playerMoving;
    private Vector2 lastMove;


    private void Awake()
    {
        inventory = new Inventory();
        hotbar = GameObject.Find("Hotbar").GetComponent<Hotbar>();
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        equippedItem = null;
    }
    void FixedUpdate()
    {
        playerMoving = false;
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0.0f, 1.0f);
        movementDirection.Normalize();

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            rb.velocity = movementDirection * movementSpeed * baseSpeed;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            rb.velocity = movementDirection * movementSpeed * baseSpeed;
        }
        if (playerMoving == false)
        {
            rb.velocity = new Vector2(0, 0);
        }
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }
    public void setTileInFrontOfPlayerToTilled()
    {
        Tilemap tilemap = GameManager.Instance.getFarmTiles().getTilemap();
        FarmTile farmTileInFrontOfPlayer;
        switch (currentSpriteName)
        {
            case "farmerattackright_1":
                if (tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x + 1, transform.position.y, 0))).GetType() == typeof(FarmTile))
                {
                    farmTileInFrontOfPlayer = (FarmTile)tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x + 1, transform.position.y, 0)));
                    farmTileInFrontOfPlayer.setTilled(true);
                }
                break;
            case "farmerattackleft_1":
                if (tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y, 0))).GetType() == typeof(FarmTile))
                {
                    farmTileInFrontOfPlayer = (FarmTile)tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x - 1, transform.position.y, 0)));
                    farmTileInFrontOfPlayer.setTilled(true);
                }
                break;
            case "farmerattackdown_1":
                if (tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y - 1, 0))).GetType() == typeof(FarmTile))
                {
                    farmTileInFrontOfPlayer = (FarmTile)tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y - 1, 0)));
                    farmTileInFrontOfPlayer.setTilled(true);
                }
                break;
            case "farmerattackup_1":
                if (tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y + 1, 0))).GetType() == typeof(FarmTile))
                {
                    farmTileInFrontOfPlayer = (FarmTile)tilemap.GetTile(tilemap.WorldToCell(new Vector3(transform.position.x, transform.position.y + 1, 0)));
                    farmTileInFrontOfPlayer.setTilled(true);
                }
                break;
        }

    }
    private void Update()
    {
        currentSpriteName = spriteRenderer.sprite.name;

        if (attacking)
        {
            if(currentSpriteName == "farmerattackright_1" || currentSpriteName == "farmerattackleft_1"
                || currentSpriteName == "farmerattackup_1" || currentSpriteName == "farmerattackdown_1")
            {
                setTileInFrontOfPlayerToTilled();
                attacking = false;
                anim.SetBool("Attacking", false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            processNumPress(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            processNumPress(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            processNumPress(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            processNumPress(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            processNumPress(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            processNumPress(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            processNumPress(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            processNumPress(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            processNumPress(9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            processNumPress(0);
        }

        if (equippedItem != null)
        {
            if ((lastSpriteName != currentSpriteName) || (lastEquippedItem != currentEquippedItem))
            {
                Transform equippedItemTransform = transform.GetChild(1);
                SpriteRenderer equippedItemGameobjectSpriteRenderer = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();
                if(equippedItem.getItemName() == "oldHoe")
                {
                    processHoeHandPlacement(currentSpriteName, equippedItemTransform, equippedItemGameobjectSpriteRenderer);
                }
                else
                {
                    processGenericItemHandPlacement(currentSpriteName, equippedItemTransform, equippedItemGameobjectSpriteRenderer);
                }
            }
            lastEquippedItem = currentEquippedItem;
            lastSpriteName = currentSpriteName;
        }
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        //If triggered by a drop item, pick it up
        if (trigger.gameObject.GetComponent<DroppedItem>())
        {
            DroppedItem droppedItem = trigger.gameObject.GetComponent<DroppedItem>();
            pickupItem(droppedItem.id);
            Destroy(trigger.gameObject);
        }
    }
    public void pickupItem(int id)
    {
        inventory.addToInventory(ItemManager.getItem(id), 1);
        if (inventory.getInventoryList().Count <= 10)
        {
            hotbar.updateHotbar();
        }
    }
    public void processNumPress(int num)
    {
        hotbar.toggleActiveSlot(num);

        //if you have an item equipped
        if(equippedItem != null)
        {
            Item item = inventory.getItemFromIndex(num - 1);

            //if you have an item equipped and new item is null
            if(item == null)
            {
                equippedItem = null;
                transform.GetChild(1).gameObject.SetActive(false);
            }
            //if it's the same item
            else if (equippedItem.getItemName() == item.getItemName())
            {
                equippedItem = null;
                transform.GetChild(1).gameObject.SetActive(false);
            } else // if it's a different item
            {
                equippedItem = inventory.getItemFromIndex(num - 1);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
        //if you dont have an item equipped
        else
        {
            //if new item is also null
            if(inventory.getItemFromIndex(num - 1) == null)
            {
                equippedItem = null;
                transform.GetChild(1).gameObject.SetActive(false);
            }
            //if new item is an item
            else
            {
                equippedItem = inventory.getItemFromIndex(num - 1);
                transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
    public Vector2 getPlayerPosition()
    {
        return transform.position;
    }
    public Sprite getSpriteOfEquippedItem()
    {
       return inventory.getSpriteFromIndex(hotbar.getActiveSlot());
    }
    public Item getEquippedItem()
    {
        return inventory.getItemFromIndex(hotbar.getActiveSlot());
    }
    public Inventory getInventory()
    {
        return inventory;
    }
    public void addToGoldAndUpdateUI(int gold)
    {
        this.inventory.addGold(gold);
        UIManager.Instance.updateGold(this.inventory.getGoldAmount());
    }
    public void setEquippedItem(Item item)
    {
        this.equippedItem = item;
    }

    public void useLeftClick()
    {
        if (equippedItem.getItemName() == "oldHoe")
        {
            useTool();
        }
    }
    private void useTool()
    {
        attacking = true;
        anim.SetBool("Attacking", attacking);
    }
    private void processHoeHandPlacement(String currentSpriteName, Transform equippedItemTransform, SpriteRenderer equippedItemGameobjectSpriteRenderer)
    {
        equippedItemTransform.localScale = new Vector3(1f, 1f, 1f);
        switch (currentSpriteName)
        {
            case "farmerright_0":
            case "farmerright_4":
                equippedItemTransform.localPosition = new Vector3(-0.38f, 0.76f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_1":
            case "farmerright_3":
                equippedItemTransform.localPosition = new Vector3(-0.26f, 0.76f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_2":
                equippedItemTransform.localPosition = new Vector3(-0.1f, 0.88f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_5":
            case "farmerright_7":
                equippedItemTransform.localPosition = new Vector3(-0.44f, 0.76f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_6":
                equippedItemTransform.localPosition = new Vector3(-0.44f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerup_0":
            case "farmerup_4":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.57f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_1":
            case "farmerup_3":
                equippedItemTransform.localPosition = new Vector3(0.4f, 0.66f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_2":
                equippedItemTransform.localPosition = new Vector3(0.34f, 0.7f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_5":
            case "farmerup_7":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.61f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_6":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.67f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            //
            case "farmerleft_0":
            case "farmerleft_4":
                equippedItemTransform.localPosition = new Vector3(-0.17f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerleft_1":
            case "farmerleft_3":
                equippedItemTransform.localPosition = new Vector3(-0.05f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerleft_2":
                equippedItemTransform.localPosition = new Vector3(0.02f, 0.88f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerleft_5":
            case "farmerleft_7":
                equippedItemTransform.localPosition = new Vector3(-0.23f, 0.76f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerleft_6":
                equippedItemTransform.localPosition = new Vector3(-0.27f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerdown_0":
            case "farmerdown_4":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 0.75f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_1":
            case "farmerdown_3":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_2":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_5":
            case "farmerdown_7":
                equippedItemTransform.localPosition = new Vector3(-0.37f, 0.73f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_6":
                equippedItemTransform.localPosition = new Vector3(-0.3f, 0.77f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            //
            //
            case "farmerattackright_0":
                equippedItemTransform.localPosition = new Vector3(-0.17f, 1.3f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 7.22f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackright_1":
                equippedItemTransform.localPosition = new Vector3(0.36f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -142.17f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackleft_0":
                equippedItemTransform.localPosition = new Vector3(-0.17f, 1.3f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, 7.22f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackleft_1":
                equippedItemTransform.localPosition = new Vector3(-0.42f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -142.17f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackdown_0":
                equippedItemTransform.localPosition = new Vector3(-0.34f, 1.32f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -19.7f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackdown_1":
                equippedItemTransform.localPosition = new Vector3(-0.148f, 0.64f, 0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 159f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackup_0":
                equippedItemTransform.localPosition = new Vector3(.1f, 1.45f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerattackup_1":
                equippedItemTransform.localPosition = new Vector3(0f, 1.13f, 0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 180f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
        }
    }
    //
    private void processGenericItemHandPlacement(String currentSpriteName, Transform equippedItemTransform, SpriteRenderer equippedItemGameobjectSpriteRenderer)
    {
        equippedItemTransform.localScale = new Vector3(.75f, .75f, 1f);
        switch (currentSpriteName)
        {
            case "farmerright_0":
            case "farmerright_4":
                equippedItemTransform.localPosition = new Vector3(-0.2f, 0.46f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_1":
            case "farmerright_3":
                equippedItemTransform.localPosition = new Vector3(-0.1f, 0.47f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_2":
                equippedItemTransform.localPosition = new Vector3(0.04f, 0.6f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_5":
            case "farmerright_7":
                equippedItemTransform.localPosition = new Vector3(-0.3f, 0.48f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerright_6":
                equippedItemTransform.localPosition = new Vector3(-0.32f, 0.55f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerup_0":
            case "farmerup_4":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.57f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_1":
            case "farmerup_3":
                equippedItemTransform.localPosition = new Vector3(0.4f, 0.66f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_2":
                equippedItemTransform.localPosition = new Vector3(0.34f, 0.7f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_5":
            case "farmerup_7":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.61f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerup_6":
                equippedItemTransform.localPosition = new Vector3(0.43f, 0.67f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 121f, 2f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            //
            case "farmerleft_0":
            case "farmerleft_4":
                equippedItemTransform.localPosition = new Vector3(-0.33f, 0.53f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerleft_1":
            case "farmerleft_3":
                equippedItemTransform.localPosition = new Vector3(-0.26f, 0.57f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerleft_2":
                equippedItemTransform.localPosition = new Vector3(-.19f, 0.67f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerleft_5":
            case "farmerleft_7":
                equippedItemTransform.localPosition = new Vector3(-0.23f, 0.76f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerleft_6":
                equippedItemTransform.localPosition = new Vector3(-0.27f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerdown_0":
            case "farmerdown_4":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 0.75f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_1":
            case "farmerdown_3":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 0.82f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_2":
                equippedItemTransform.localPosition = new Vector3(-0.4f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_5":
            case "farmerdown_7":
                equippedItemTransform.localPosition = new Vector3(-0.37f, 0.73f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerdown_6":
                equippedItemTransform.localPosition = new Vector3(-0.3f, 0.77f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -80f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            //
            //
            case "farmerattackright_0":
                equippedItemTransform.localPosition = new Vector3(-0.17f, 1.3f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, 7.22f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackright_1":
                equippedItemTransform.localPosition = new Vector3(0.36f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 0f, -142.17f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackleft_0":
                equippedItemTransform.localPosition = new Vector3(-0.17f, 1.3f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, 7.22f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackleft_1":
                equippedItemTransform.localPosition = new Vector3(-0.42f, 1f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 180f, -142.17f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackdown_0":
                equippedItemTransform.localPosition = new Vector3(-0.34f, 1.32f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 45f, -19.7f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            case "farmerattackdown_1":
                equippedItemTransform.localPosition = new Vector3(-0.148f, 0.64f, 0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 159f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 1;
                break;
            //
            case "farmerattackup_0":
                equippedItemTransform.localPosition = new Vector3(.1f, 1.45f, 0.0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 0f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
            case "farmerattackup_1":
                equippedItemTransform.localPosition = new Vector3(0f, 1.13f, 0f);
                equippedItemTransform.eulerAngles = new Vector3(0f, 135f, 180f);
                equippedItemGameobjectSpriteRenderer.sortingOrder = 0;
                break;
        }
    }
}