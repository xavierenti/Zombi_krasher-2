using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{

    public bool IsShopOpen = false;

    public GameObject shopMenu;
    public GameObject buttonBuyGun;
    public GameObject buttonFireRate;
    public GameObject player;
    public GameObject[] enemy;
    public ScoreManager score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (IsShopOpen)
            {
                shopMenu.SetActive(false);

                IsShopOpen = false;
            }
            else
            {
                shopMenu.SetActive(true);

                IsShopOpen = true;
            }
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        IsShopOpen = true;
        Cursor.visible = true;
    }

    public void ResumeGame(GameObject idk)
    {
        Time.timeScale = 1f;
        idk.SetActive(false);
        IsShopOpen = false;
        Cursor.visible = false;
    }

    public void buyGun(Attack attack)
    {
        if (score.gold >= 100)
        {
            Destroy(buttonBuyGun);
            attack.pistol = false;
            attack.rifle = true;
            attack.flame = false;
            ScoreManager.instance.LoseGold(100);
        }
    }

    public void buyFireRateRifle(Attack attack)
    {
        if (score.gold >= 300)
        {
            if (attack.fireRateRifle >= 0.5)
            {

                attack.fireRateRifle -= 0.1f;
                ScoreManager.instance.LoseGold(250);
            }
            else
                Destroy(buttonFireRate);

        }
    }

    public void BuyHp(PlayerHp hp)
    {
        if (score.gold >= 2000)
        {
            if (hp.playerHP <= 5)
            {
                hp.playerHP++;
                ScoreManager.instance.LoseGold(2000);
            }
        }
    }

    public void buySpeed(PlayerMovement pm)
    {
        if (score.gold >= 1500)
        {
            pm.speed += 0.25f;
            ScoreManager.instance.LoseGold(1500);
        }
    }

    public void chanceInstaKill(Attack at)
    {
        if (score.gold >= 5000)
        {
            at.criticInstaKill++;
            ScoreManager.instance.LoseGold(5000);
        }

    }

    public void BuyBulletSpeed(Attack at)
    {
        if(score.gold >= 2500)
        {
            at.bulletSpeed += 0.1f;
            ScoreManager.instance.LoseGold(2500);
        }
    }

    public void BuyDoubleShoot(Attack at)
    {
        if(score.gold >= 1)
        {
            at.isBought = true;
            ScoreManager.instance.LoseGold(1);
        }
    }
}