using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    [SerializeField]
    private Text killsText;
    [SerializeField]
    private Timer timer;


    private void Start()
    {
       timer.gameObject.SetActive(true);
       LevelController.Instance.OnKillsChanged += Instance_OnKillsChanged;
       killsText.text = LevelController.Instance.TotalKills.ToString();
    }

    private void Instance_OnKillsChanged(object sender, int kills)
    {
        killsText.text = kills.ToString();
        if (kills == EnemyManager.Instance.Enemies.Length)
        {
            UIManager.Instance.CloseWindow(WindowType.Game);
            UIManager.Instance.OpenWindow(WindowType.Win);
        }
    }

    public void AtackButton() 
    {
       FindObjectOfType<Enemy>()?.TakeDamage();   
    }

    public void HealButton()
    {
        FindObjectOfType<Enemy>()?.TakeHeal();
    }

    public override void Close()
    {
        LevelController.Instance.LevelTime = Timer.CurrentTime;
        timer.gameObject?.SetActive(false);


        base.Close();
    }

    
}
