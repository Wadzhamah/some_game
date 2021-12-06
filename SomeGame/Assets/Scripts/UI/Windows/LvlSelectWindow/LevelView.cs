using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelView : MonoBehaviour
{
    [SerializeField]
    private int index;
    [SerializeField]
    private GameObject closedImage;
    [SerializeField]
    private GameObject oneStarImage;
    [SerializeField]
    private GameObject twoStarsImage;
    [SerializeField]
    private GameObject threeStarsImage;
    public int Index { get => index; set => index = value; }

    private void Start()
    {
        print($"Level:{Index}\nStars:{GameDataManager.Instance.levelDataManager.levelDatas[index - 1].Stars}");
       Button button = GetComponent<Button>();

       if (GameDataManager.Instance.levelDataManager.levelDatas[index - 1].State == LevelState.Closed)
        {
            button.interactable = false;
            closedImage.gameObject.SetActive(true);
        }
       
       if(GameDataManager.Instance.levelDataManager.levelDatas[index - 1].Stars == 1)
        {
            oneStarImage.gameObject.SetActive(true);
        }
        if (GameDataManager.Instance.levelDataManager.levelDatas[index - 1].Stars == 2)
        {
            twoStarsImage.gameObject.SetActive(true);
        }
        if (GameDataManager.Instance.levelDataManager.levelDatas[index - 1].Stars == 3)
        {
            threeStarsImage.gameObject.SetActive(true);
        }
    }
}
