using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };
    public Direction direction;

    public float speed;

    public bool walking;
    [HideInInspector]
    public Vector2 playerFront;

    private float aux;
    private float aux2;

    [Header("Opciones de la camara")]
    public Camera mainCamera;
    private float normalCameraSize;
    public float sneakCameraSize;
    public float transitionSpeed;

    private Rigidbody2D rb;

    private KeyCode horizontalKeyPressed;
    private KeyCode verticalKeyPressed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        aux = speed;

        normalCameraSize = mainCamera.orthographicSize;
        aux2 = normalCameraSize;
    }

    void Update()
    {
        playerFront = Vector2.right;

        // Control de inputs
        if (Input.GetKey(KeyCode.D))
        {
            
            rb.velocity = new Vector2(speed, rb.velocity.y);
            direction = Direction.RIGHT;
            
            horizontalKeyPressed = KeyCode.D;
        }
        if (Input.GetKey(KeyCode.A))
        {
            
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            direction = Direction.LEFT;
            horizontalKeyPressed = KeyCode.A;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
            
            direction = Direction.UP;
            verticalKeyPressed = KeyCode.W;
        }
        if (Input.GetKey(KeyCode.S))
        {
           
            rb.velocity = new Vector2(rb.velocity.x, -speed);
            direction = Direction.DOWN;
            verticalKeyPressed = KeyCode.S;
        }
        // Comprobar si se ha dejado de pulsar la última tecla pulsada de cada eje
        if (Input.GetKeyUp(horizontalKeyPressed))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyUp(verticalKeyPressed))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
    }
}