using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInventory playerInventory;
    private Hotbar hotbar;

    private float baseSpeed = 5.0f;
    private Vector2 movementDirection;
    private float movementSpeed;
    private Vector2 playerPosition;

    private Rigidbody2D rb;
    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;

    RaycastHit2D hitInfo;

// Start is called before the first frame update
void Start()
    {
        playerInventory = new PlayerInventory();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hotbar = GameObject.Find("Hotbar").GetComponent<Hotbar>();
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hitInfo.collider != null)
            {
                if (Vector2.Distance(transform.position, hitInfo.transform.position) < 2)
                {
                    if (hitInfo.transform.GetComponent<GroundPickableItem>())
                    {
                        int id = hitInfo.transform.GetComponent<GroundPickableItem>().id;
                        playerInventory.addToInventory(ItemManager.getItem(id), 1);
                        Destroy(hitInfo.transform.gameObject);
                    }
                }
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<DroppedItem>())
        {
            DroppedItem droppedItem = collision.gameObject.GetComponent<DroppedItem>();
            Debug.Log(ItemManager.getItem(droppedItem.id).getItemName());
            playerInventory.addToInventory(ItemManager.getItem(droppedItem.id), droppedItem.amount);
            if(playerInventory.getItemCount() <= 10)
            {
                hotbar.updateHotbar(playerInventory.getInventoryList());
            }
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    public Vector2 getPlayerPosition()
    {
        return transform.position;
    }
}