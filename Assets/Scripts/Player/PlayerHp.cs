using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public int playerHP;

    //private bool damaged;
    private float timer;

    private int maxHP;

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
            playerHP = -1;
            if (playerHP <= 0)
            {
                SceneManager.LoadScene("DeathScene");
                Cursor.visible = true;
            }
        }
    }
}
