using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonificators : MonoBehaviour
{
    Attack attack;
    public EnemyDamage enemyDamage;
    ScoreManager scoreManager;

    private void Start()
    {
        attack = GetComponent<Attack>();
        enemyDamage = GetComponent<EnemyDamage>();
    }

    public void x2dmg()
    {
        enemyDamage.dmg_pistol = 100;
        enemyDamage.x2dmg_Activated = true;
        attack.dmb_rifle = 4;
    }

    public void x2gold()
    {
        scoreManager.goldGains = scoreManager.goldGains * 2;
    }

    public void DoubleBullet()
    {

    }
}
