using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Windows;
using System.Collections;

public class PlayerHp : MonoBehaviour
{
    public int playerHP;

    public GameObject death;

    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;
    public Image Image5;
    public Image Blod1;


    bool inmortal = false;
    float duracion = 100000000f;

    //private bool damaged;
    private float timer;

    private int maxHP;

    private void Start()
    {
        Blod1.enabled = false;
        Time.timeScale = 1f;    
        death.SetActive(false);
    }
    void Update()
    {
        if (playerHP == 0)
        {
            Image1.enabled = false;
            Image2.enabled = false;
            Image3.enabled = false;
            Image4.enabled = false;
            Image5.enabled = false;

        }
        if (playerHP == 1)
        {
            Image1.enabled = true;
            Image2.enabled = false;
            Image3.enabled = false;
            Image4.enabled = false;
            Image5.enabled = false;
        }
        if (playerHP == 2)
        {
            Image1.enabled = true;
            Image2.enabled = true;
            Image3.enabled = false;
            Image4.enabled = false;
            Image5.enabled = false;
        }
        if (playerHP == 3)
        {
            Image1.enabled = true;
            Image2.enabled = true;
            Image3.enabled = true;
            Image4.enabled = false;
            Image5.enabled = false;
        }
        if (playerHP == 4)
        {
            Image1.enabled = true;
            Image2.enabled = true;
            Image3.enabled = true;
            Image4.enabled = true;
            Image5.enabled = false;
        }
        if (playerHP == 5)
        {
            Image1.enabled = true;
            Image2.enabled = true;
            Image3.enabled = true;
            Image4.enabled = true;
            Image5.enabled = true;
        }

            



        //if (damaged)
        //{
        //    // Tiempo de invulnerabilidad del jugador
        //    timer += Time.deltaTime;
        //    if (timer > 0.1f)
        //    {
        //        damaged = false;
        //        timer = 0;
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {

                playerHP = playerHP - 1;
                inmortality(duracion);
               
            if (playerHP <= 0)
                {
                    Destroy(gameObject);
                    Time.timeScale = 0f;
                    death.SetActive(true);
                    Cursor.visible = true;
                    
                }         
        }


    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            Blod1.enabled = false;
        }
    }
    private void inmortality(float invencibiliti)
    {
        
        Blod1.enabled = true;
        new WaitForSeconds(invencibiliti);
        


    }

}
