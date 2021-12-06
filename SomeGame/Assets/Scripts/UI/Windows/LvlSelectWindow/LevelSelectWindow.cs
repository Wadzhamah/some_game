using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Windows.LvlSelectWindow
{
    public class LevelSelectWindow : Window
    {
        [SerializeField]
        private Button exitButton;
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private List<LevelView> levelsView;
        [SerializeField]
        private GameObject loadingScreen;


        private void Start()
        {
            rectTransform = gameObject.GetComponent<RectTransform>();
            print(GameDataManager.Instance.levelDataManager.levelDatas[1].Stars);
        }

        public void StartLevelButton(int levelIndex)
        {
            loadingScreen.SetActive(true);
            StartLevelData.LevelIndex = levelIndex;

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
}