using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LoadLevel : MonoBehaviour
{
    public static int sceneToLoadBuildIndex = 1;

    [SerializeField]
    private Image progressBar;
    [SerializeField]
    private GameObject loadingScreen;

    private float fillProgres;

    private void OnEnable()
    {
        Load();
    }

    public void Load()
    {
        loadingScreen.SetActive(true);
        
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("TestGameLevel");
        asyncLoad.allowSceneActivation = false;

        bool barIsDone = false;
        while (!barIsDone)
        {
            progressBar.fillAmount += 0.1f;
            yield return new WaitForSeconds(1);
            if(progressBar.fillAmount == 1)
            {
                barIsDone = true;
            }
        }
        asyncLoad.allowSceneActivation = true;
    }
}
