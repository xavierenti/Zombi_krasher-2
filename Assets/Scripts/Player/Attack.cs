using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject crosshair;

    public GameObject Player;
    
    public GameObject weapon;
    
    public GameObject Bullet;

    public GameObject flameParticle;


    private AudioSource audioSource;

    public AudioClip shootSound;

    public AudioClip flameSound;

    private Animator animator;

    private Vector3 target;

    public float fireRate;

    private float ReadyForTheNextShot;

    bool pistol = false;

    bool rifle = true;

    bool flame = false;



    private float bulletSpeed = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - Player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        Player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90);

        if(pistol)
        {
            animator.SetBool("isGun", true);
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("isGunShooting", true);
                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                fireBullet(direction, rotationZ);
                audioSource.PlayOneShot(shootSound);
                
            }

            if(Input.GetMouseButtonUp(0))
            {
                animator.SetBool("isGunShooting", false);
            }
            
        }
        if(rifle)
        {
            animator.SetBool("haveRifle", true);
            if (Input.GetMouseButton(0))
            {
                if(Time.time > ReadyForTheNextShot)
                {

                    animator.SetBool("isRiffleShooting", true);
                    ReadyForTheNextShot = Time.time + 1 / fireRate;
                    float distance = difference.magnitude;
                    Vector2 direction = difference / distance;
                    direction.Normalize();
                    fireBullet(direction, rotationZ);
                    audioSource.PlayOneShot(shootSound);
                }

                
            }
            animator.SetBool("isRiffleShooting", false);
        }
        else if (!rifle)
        {
            animator.SetBool("haveRifle", false);
        }
        if(flame)
        {
            if (Input.GetMouseButton(0))
            {

                float distance = difference.magnitude;
                Vector2 direction = difference / distance;
                direction.Normalize();
                Instantiate(flameParticle, transform.position, Quaternion.identity);
                audioSource.PlayOneShot(shootSound);
            }
        }

        if(Input.GetKeyDown(KeyCode.V))
        {
            animator.SetBool("isKnife", true);
        }

        if(Input.GetKeyUp(KeyCode.V))
        {
            animator.SetBool("isKnife", false);
        }
        
    }

    void fireBullet(Vector2 direction, float rotationZ)
    {
        GameObject b = Instantiate(Bullet) as GameObject;
        b.transform.position = weapon.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
