using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    
    public Transform weapon;
    
    public GameObject Bullet;

    public GameObject bullet_rifle;

    public GameObject flameParticle;


    private AudioSource audioSource;

    public AudioClip shootSound;

    public AudioClip flameSound;

    private Animator animator;

    public float fireRate;

    private float ReadyForTheNextShot;

    public bool pistol = true;

    public bool rifle = false;

    public bool flame = false;
    public float fireRateRifle = 1f;

    public float criticInstaKill = 0f;


    public float bulletSpeed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(pistol)
        {
            animator.SetBool("isGun", true);
            if (Input.GetMouseButtonDown(0))
            {
                
                animator.SetBool("isGunShooting", true);
                shoot_gun();
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

                    animator.SetBool("haveRifle", true);
                    ReadyForTheNextShot = Time.time + fireRateRifle / fireRate;
                    shoot_rifle();
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

    void shoot_gun()
    {
        GameObject bullet = Instantiate(Bullet, weapon.position, weapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void shoot_rifle()
    {
        GameObject bullet = Instantiate(bullet_rifle, weapon.position, weapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
