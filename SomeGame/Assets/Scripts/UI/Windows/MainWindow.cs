using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class MainWindow : Window
{
    private RectTransform rectTransform;
    [SerializeField]
    private RectTransform buttons;
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private Button exitButton;

    Sequence sequence;

    private void Awake()
    {
        playButton.onClick.AddListener(PlayButton);
    }

    private void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    private void PlayButton()
    {
        UIManager.Instance.CloseWindow(this);
        UIManager.Instance.OpenWindow(WindowType.LevelSelect);
    }

    public override void Close()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOAnchorPos(new Vector2(-800, 0), 0.5f, true));
        sequence.onComplete = () => base.Close();
    }

    public override void Open()
    {
        rectTransform.DOAnchorPos(Vector2.zero, 0.5f, true);
        base.Open();
    }


}
