using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyDamage : MonoBehaviour
{
    public int enemyHP;

    private bool damaged;

    private float timer;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    public AudioClip deathSound;

    public bool called;
    bool hasPatrolScript;
    [HideInInspector]
    public bool death;
    [HideInInspector]
    public bool decreaseSpeed;

    private Rigidbody2D rb;

    private GameObject player;
    private PlayerDamage playerDamage;

    public Text text;
    public float startingKills = 0;
    public float currentKills = 0;  

    private bool hasSanguinary;

    private void Start()
    {

        audioSource = GetComponent<AudioSource>();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();


        player = GameObject.Find("Player");
        playerDamage = player.GetComponent<PlayerDamage>();

        currentKills = startingKills;
    }

    private void Update()
    {
        if (damaged)
        {
            timer += Time.deltaTime;
            if (timer > 0.025f)
            {
                damaged = false;
                timer = 0;
            }
        }
        if (called)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                called = false;
                timer = 0;
            }
        }
        if (decreaseSpeed)
        {
            timer += Time.deltaTime;
            if (timer > 1.5f)
            {
                decreaseSpeed = false;
                rb.velocity = Vector2.zero;
                timer = 0;
            }
        }
        if (death || enemyHP <= 0)
        {
            spriteRenderer.enabled = false;
            
            timer += Time.deltaTime;

            currentKills = +1;
            Destroy(gameObject);
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bullet"))
        {
            enemyHP--;
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                ScoreManager.instance.AddPoint();
            }
        }
    }
}
