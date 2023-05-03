using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public int playerHP;

    public GameObject death;

    //private bool damaged;
    private float timer;

    private int maxHP;

    private void Start()
    {
        death.SetActive(false);
    }
    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
            playerHP = -1;
            if (playerHP <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0f;
                death.SetActive(true);
                Cursor.visible = true;
            }
        }
    }
}
