using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    
    public bool IsShopOpen = false;

    public GameObject shopMenu;
    public GameObject buttonBuyGun;
    public GameObject player;
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
        if(score.gold >= 100)
        {
            Destroy(buttonBuyGun);
            attack.pistol = false;
            attack.rifle = true;
            attack.flame = false;
            ScoreManager.instance.LoseGold(100);
        }
    }
}
