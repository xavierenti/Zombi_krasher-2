using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonificators : MonoBehaviour
{

    public Attack attack;

    public ScoreManager scoreManager;
    public void freeCash()
    {
        scoreManager.gold += 100;
        scoreManager.AddGold();
    }

    public void x2gold()
    {
        scoreManager.goldGains = scoreManager.goldGains * 2;
    }

    public void DoubleBullet()
    {
        attack.isBought = true;
    }
}
