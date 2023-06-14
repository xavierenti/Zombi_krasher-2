using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonificators : MonoBehaviour
{

    public float currentTime_gold;
    public float currentTime_bullet;
    private float maxTime = 10f;

    public bool x2gold_activated = false;
    public bool doubleBullet_activated = false;

    public Attack attack;

    public ScoreManager scoreManager;

    private void Start()
    {
        currentTime_bullet = maxTime;
        currentTime_gold = maxTime;
    }

    private void Update()
    {
        
        

        if(x2gold_activated)
        {
            x2gold();
        }
        
        if (doubleBullet_activated)
        {
            
            DoubleBullet();
        }

    }
    public void freeCash()
    {

        scoreManager.gold += 100;
        scoreManager.AddGold();
        
    }

    public void x2gold()
    {

        currentTime_gold -= Time.deltaTime;
        scoreManager.goldGains = 50;
        if (currentTime_gold <= 0)
        {
            scoreManager.goldGains = 25;
            x2gold_activated = false;
            currentTime_gold = maxTime;
        }
    }

    public void DoubleBullet()
    {
        
        currentTime_bullet -= Time.deltaTime;
        attack.isBought = true;
        if (currentTime_bullet <= 0)
        {
            attack.isBought = false;
            doubleBullet_activated = false;
            currentTime_bullet = maxTime;
        }
        
    }
}
