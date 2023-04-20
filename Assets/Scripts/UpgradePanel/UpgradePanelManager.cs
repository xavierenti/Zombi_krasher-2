using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    Pause pause;

    [SerializeField] List<UpgradeButton> upgradeButtons;
    
    private void Awake()
    {
        pause = GetComponent<Pause>();
    }

    private void Start()
    {
        HideButtons();
    }

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        Clean();
        pause.PauseGame();
        panel.SetActive(true);

        

        for(int i = 0; i< upgradeDatas.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void Clean()
    {
        for(int i = 0; i< upgradeButtons.Count; i++)
        {
            upgradeButtons[i].Clean();
        }
    }


    public void Upgrade(int presserdButtonID)
    {
    //    GameManager.instance.playerTransform.GetComponent<Level>().Upgrade(presserdButtonID);
        ClosePanel();
    }

    public void ClosePanel()
    {
        HideButtons();

        pause.ResumeGame(panel);
        panel.SetActive(false);
    }

    public void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

}
