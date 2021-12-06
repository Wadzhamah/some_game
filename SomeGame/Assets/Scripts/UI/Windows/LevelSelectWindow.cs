using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelSelectWindow : Window
{
    [SerializeField]
    private Button exitButton;
    [SerializeField]
    private Button startLevelButton;
    [SerializeField]
    private GameObject loadingScreen;

    private RectTransform rectTransform;
    
    List<LevelView> levelViews = new List<LevelView>();

    private void Awake()
    {
        exitButton.onClick.AddListener(ExitButton);
        startLevelButton.onClick.AddListener(StartLevelButton);
    }

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void StartLevelButton()
    {
        loadingScreen.SetActive(true);
    }
    public void ExitButton()
    {
        UIManager.Instance.CloseWindow(this);
        UIManager.Instance.OpenWindow(WindowType.Main);
    }

    public override void Open()
    {
        base.Open();
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPos(Vector2.zero, 0.5f, true).From(new Vector2(800, 0)));
    }
    public override void Close()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPos(new Vector2(800, 0), 0.5f, true));
        sequence.onComplete = () => base.Close();
    } 
}
