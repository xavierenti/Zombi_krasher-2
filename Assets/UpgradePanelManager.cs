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

    public void OpenPanel(List<UpgradeData> upgradeDatas)
    {
        pause.PauseGame();
        panel.SetActive(true);
        for(int i = 0; i< upgradeDatas.Count; i++)
        {
            upgradeButtons[i].Set(upgradeDatas[i]);
        }
    }

    public void ClosePanel()
    {
        pause.ResumeGame(panel);
        panel.SetActive(false);
    }

}
