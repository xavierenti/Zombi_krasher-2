using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerNextMap : MonoBehaviour
{

    [SerializeField] int min, seg;
    [SerializeField] Text time;

    private float restante;
    private bool enMarcha;

    public bool IsPaused = false;
    public GameObject winMenu;

    private void Awake()
    {
        restante = (min * 60) + seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enMarcha)
        {
            restante -= Time.deltaTime;
            if(restante < 1)
            {
                enMarcha = true;
            }

            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);  
            time.text = string.Format("{00:00}:{01:00}", tempMin    , tempSeg);
        }

        if(restante <= 1)
        {
            Time.timeScale = 0f;
            winMenu.SetActive(true);

        }
    }
}
