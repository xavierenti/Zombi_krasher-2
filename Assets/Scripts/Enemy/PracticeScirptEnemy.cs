using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScirptEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab del enemigo a generar
    public Transform spawnPoint; // Punto de generación del nuevo enemigo

    public float enemyHP;
    private void Start()
    {
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        // Suscribirse al evento de muerte del enemigo actual
        EnemyDamage ed = GetComponent<EnemyDamage>();

    }
        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Bullet"))
            {
                enemyHP--;

                if (enemyHP <= 0)
                {
                    Destroy(gameObject);
                    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddGold();



                }
            }

            if (other.CompareTag("bullet_rifle"))
            {
                enemyHP -= 2;

                if (enemyHP <= 0)
                {

                    Destroy(gameObject);
                    Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                    ScoreManager.instance.AddPoint();
                    ScoreManager.instance.AddGold();


                }
            }
        }
    }
