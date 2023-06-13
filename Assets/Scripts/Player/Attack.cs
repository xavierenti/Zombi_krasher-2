using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public Text fireRat;

    public Transform weapon;
    public Transform secondWeapon;
    
    public GameObject Bullet;

    public GameObject bullet_rifle;

    public GameObject flameParticle;

    public Pause pause;

    private AudioSource audioSource;

    public AudioClip shootSound;

    public AudioClip flameSound;

    private Animator animator;

    public int dmb_pistol = 1;
    public int dmb_rifle = 2;

    public float fireRate;

    private float ReadyForTheNextShot;

    public bool pistol = true;

    public bool rifle = false;

    public bool flame = false;

    public float fireRateRifle = 1;
    public float fireRatePistol = 0.5f;

    public float criticInstaKill = 0f;

    public bool isBought = false;


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
        fireRat.text = "Fire Rate: " + fireRate.ToString(); 
        if (!pause.IsPaused)
        {
            if (pistol)
            {
                animator.SetBool("isGun", true);
                if (Input.GetMouseButtonDown(0))
                {

                    animator.SetBool("isGunShooting", true);
                    ReadyForTheNextShot = Time.time + fireRateRifle / fireRate;
                    shoot_gun();
                    if (isBought)
                    {
                        DoubleBulletPistol();
                    }
                    audioSource.PlayOneShot(shootSound);

                }

                if (Input.GetMouseButtonUp(0))
                {
                    animator.SetBool("isGunShooting", false);
                }

            }
            if (rifle)
            {
                animator.SetBool("haveRifle", true);
                if (Input.GetMouseButton(0))
                {
                    if (Time.time > ReadyForTheNextShot)
                    {

                        animator.SetBool("haveRifle", true);
                        ReadyForTheNextShot = Time.time + fireRateRifle / fireRate;
                        shoot_rifle();
                        if (isBought)
                        {
                            DoubleBulletRifle();
                        }
                        audioSource.PlayOneShot(shootSound);
                    }


                }
                animator.SetBool("isRiffleShooting", false);
            }
            else if (!rifle)
            {
                animator.SetBool("haveRifle", false);
            }
            if (flame)
            {
                if (Input.GetMouseButton(0))
                {
                    Instantiate(flameParticle, transform.position, Quaternion.identity);
                    audioSource.PlayOneShot(shootSound);
                }
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                animator.SetBool("isKnife", true);
            }

            if (Input.GetKeyUp(KeyCode.V))
            {
                animator.SetBool("isKnife", false);
            }
        }
        
        
    }

    void shoot_gun()
    {
        GameObject bullet = Instantiate(Bullet, weapon.position, weapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.right * bulletSpeed, ForceMode2D.Impulse);
    }
    void DoubleBulletPistol()
    {
        GameObject bullet = Instantiate(Bullet, secondWeapon.position, secondWeapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(secondWeapon.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void shoot_rifle()
    {
        GameObject bullet = Instantiate(bullet_rifle, weapon.position, weapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(weapon.right * bulletSpeed, ForceMode2D.Impulse);
    }

    void DoubleBulletRifle()
    {
        GameObject bullet = Instantiate(bullet_rifle, secondWeapon.position, secondWeapon.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(secondWeapon.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
