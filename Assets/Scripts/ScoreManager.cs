using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    
    public Text scoreText;
    public Text highscroeText;
    public Text goldText;

    int score = 0;
    int highscore = 0;
   public int gold = 0;
    public int goldGains = 10;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Points: " + score.ToString() ;
        highscroeText.text = "Highscore: " + highscore.ToString();
        goldText.text = "Gold: " + gold.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " Points";
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        
    }
    public void AddGold()
    {
        gold += goldGains;
        goldText.text = "Gold: " + gold.ToString();
        
    }

    public void LoseGold(int cost)
    {
        gold -= cost;
        goldText.text = "Gold: " + gold.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
