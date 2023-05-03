using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, IShopCostumer
{
    public float speed = 5f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 mousePos;

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    public void BoughtItem(Item.ItemType itemType)
    {
        Debug.Log("Compra item: " + itemType);
    }
}