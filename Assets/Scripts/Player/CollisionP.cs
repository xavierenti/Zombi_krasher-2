using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionP : MonoBehaviour
{
    public Bonificators bonificator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bon_freecash"))
        {
            bonificator.freeCash();
            
        }

        if (collision.CompareTag("bonificator_x2gold"))
        {
            bonificator.x2gold_activated = true;
            bonificator.currentTime_gold = 10f;
        }

        if(collision.CompareTag("bon_doubleBullet"))
        {
            bonificator.doubleBullet_activated = true;
            bonificator.currentTime_bullet = 10f;
        }
    }
}