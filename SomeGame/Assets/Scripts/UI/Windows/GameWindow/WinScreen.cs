using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using System;



public class WinScreen : Window 
{
    public event EventHandler<int> OnStarsChanged;

    [SerializeField]
    private TextMeshProUGUI killsText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private Text scorePoints;
    [SerializeField]
    private Image star1;
    [SerializeField]
    private Image star2;
    [SerializeField]
    private Image star3 ;

    private int stars;

    float starAnimationDuaration = 0.6f;

    public int Stars { get => stars; set => stars = value; }


    public void OneStarButton()
    {
        stars = 1;
        star1.DOColor(new Color(star1.color.r, star1.color.g, star1.color.b, 1), starAnimationDuaration);
        OnStarsChanged?.Invoke(this, stars);
    }
    public void TwoStarsButton()
    {
        stars = 2;
        OnStarsChanged?.Invoke(this, stars);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(star1.DOColor(new Color(star1.color.r, star1.color.g, star1.color.b, 1), starAnimationDuaration));
        sequence.Append(star2.DOColor(new Color(star2.color.r, star2.color.g, star2.color.b, 1), 1));
    }
    public void ThreeStarsButton()
    {
        stars = 3;
        OnStarsChanged?.Invoke(this, stars);    
        Sequence sequence = DOTween.Sequence();
        sequence.Append(star1.DOColor(new Color(star1.color.r, star1.color.g, star1.color.b, 1), starAnimationDuaration));
        sequence.Append(star2.DOColor(new Color(star2.color.r, star2.color.g, star2.color.b, 1), starAnimationDuaration));
        sequence.Append(star3.DOColor(new Color(star3.color.r, star3.color.g, star3.color.b, 1), starAnimationDuaration));
    }

    public override void Close()
    {
        LevelDataStorage levelDataStorage = new LevelDataStorage();
        levelDataStorage.Index = LevelController.Instance.LevelIndex;
        levelDataStorage.State = LevelState.Completed;
        GameDataManager.Instance.levelDataManager.UpdateLevelData(levelDataStorage);
        base.Close();
    }

    public void MainMenuButton()
    {
        UIManager.Instance.CloseWindow(this);
        Close();
    }

    private void OnEnable()
    {
        scorePoints.DOCounter(0, LevelController.Instance.ScorePoints, 3);
        killsText.text = killsText.text + LevelController.Instance.TotalKills;
        timeText.text = timeText.text + LevelController.Instance.LevelTime.ToString("t");
    }
    private void OnDisable()
    {
        LevelDataStorage levelData = new LevelDataStorage();
        levelData.Index = LevelController.Instance.LevelIndex;
        levelData.Stars = stars;
        GameDataManager.Instance.levelDataManager.UpdateLevelData(levelData);
        SceneManager.LoadScene(0);
    }

}
