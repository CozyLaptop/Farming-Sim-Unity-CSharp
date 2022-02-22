using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;
    private Hotbar hotbar;

    private float baseSpeed = 5.0f;
    private Vector2 movementDirection;
    private float movementSpeed;
    private Vector2 playerPosition;

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
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
            hotbar.toggleActiveSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            hotbar.toggleActiveSlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            hotbar.toggleActiveSlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            hotbar.toggleActiveSlot(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            hotbar.toggleActiveSlot(5);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            hotbar.toggleActiveSlot(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            hotbar.toggleActiveSlot(7);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            hotbar.toggleActiveSlot(8);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            hotbar.toggleActiveSlot(9);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            hotbar.toggleActiveSlot(0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                if (Vector2.Distance(transform.position, hitInfo.transform.position) < 3)
                {
                    if (hitInfo.transform.GetComponent<GroundPickableItem>())
                    {
                        int id = hitInfo.transform.GetComponent<GroundPickableItem>().id;
                        pickupItem(id);
                        Destroy(hitInfo.transform.gameObject);
                    }
                }
                if (Vector2.Distance(transform.position, hitInfo.transform.position) < 6)
                {
                    if (hitInfo.transform.GetComponent<ShippingBox>())
                    {
                        try
                        {
                            //Add to shipping box inventory
                            hitInfo.transform.GetComponent<ShippingBox>().getInventory().addToInventory(getEquippedItem(), 1);
                            //Remove one from inventory
                            inventory.removeOneFromInventory(getEquippedItem());
                            //Update hotbar to reflect new amount
                            hotbar.updateHotbar();
                        }
                        catch
                        {
                            Debug.Log("Could not add item because equipped slot doesnt contain an item");
                        }
                        //add to shipping box inventory
                        //currently equipped item will disapear from inventory

                    }
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DroppedItem>())
        {
            DroppedItem droppedItem = collision.gameObject.GetComponent<DroppedItem>();
            pickupItem(droppedItem.id);
            Destroy(collision.gameObject);
        }
    }
    private void pickupItem(int id)
    {
        inventory.addToInventory(ItemManager.getItem(id), 1);
        if (inventory.getInventoryList().Count <= 10)
        {
            hotbar.updateHotbar();
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
}