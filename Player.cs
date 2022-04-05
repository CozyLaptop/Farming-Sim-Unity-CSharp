using JetBrains.Annotations;
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
    private Sprite currentSprite;

    private Rigidbody2D rb;
    private Animator anim;
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
    private void Update()
    {
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
            if (equippedItem.getItemName() == "oldHoe")
            {
                string currentSpriteName = spriteRenderer.sprite.name;
                if (lastSpriteName != currentSpriteName)
                {
                    Transform equippedItemTransform = transform.GetChild(1);
                    SpriteRenderer equippedItemGameobjectSpriteRenderer = transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>();

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
                    }
                }
                lastSpriteName = currentSpriteName;
            }
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
        equippedItem = inventory.getItemFromIndex(num - 1);
        if(equippedItem != null)
        {
            if (equippedItem.getItemName() == "oldHoe")
            {
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(1).gameObject.SetActive(false);
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
}