using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyDamage : MonoBehaviour
{
    public float enemyHP;

    private bool damaged;

    private float timer;


    public float dmg_pistol = 1;

    public bool x2dmg_Activated;

    private SpriteRenderer spriteRenderer;

    private AudioSource audioSource;
    public AudioClip deathSound;

    public bool called;
    bool hasPatrolScript;
    [HideInInspector]
    public bool death = false;
    [HideInInspector]
    public bool decreaseSpeed;

    public GameObject bloodPrefab;

    private Rigidbody2D rb;

    private GameObject player;
    private PlayerDamage playerDamage;
     Attack attack;
    Bonificators bonificators;

    public Text text;
    public float startingKills = 0;
    public float currentKills = 0;

    public GameObject blood;

    private bool hasSanguinary;

    private Animator animator;

    [SerializeField] int experience_reward = 400;

    public GameObject X2dmgGO;
    public GameObject X2goldGO;
    public GameObject DoubleBulletGO;

    private void Start()
    {
        animator = GetComponent<Animator>();
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

            player.GetComponent<Level>().AddExpirience(experience_reward);

            audioSource.PlayOneShot(deathSound);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Bullet"))
        {

                enemyHP -= dmg_pistol;

                if (enemyHP <= 0)
                {
                    animator.SetBool("Death", true);
                    new WaitForSeconds(1f);
                    Destroy(gameObject);
                    RandomBonificator();
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddGold();



                }
           // }
        }

        if (other.CompareTag("bullet_rifle"))
        {
                enemyHP -= attack.dmb_rifle;

                if (enemyHP <= 0)
                {

                    Destroy(gameObject);
                    death = true;
                    
                    RandomBonificator();
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddGold();


                }
        }

        
    }

    void RandomBonificator()
    {
        int RandomNum = Random.Range(10, 10);

        if (RandomNum == 10)
        {
            Instantiate(X2dmgGO, transform.position, Quaternion.identity);
        }
        if(RandomNum == 20)
        {
            Instantiate(X2goldGO, transform.position, Quaternion.identity);
        }
        if(RandomNum == 30)
        {
            Instantiate(DoubleBulletGO, transform.position, Quaternion.identity);
        }
    }

}