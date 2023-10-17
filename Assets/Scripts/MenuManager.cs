using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI level_label_text;

    private void Start()
    {
        level_label_text.text = "Level " + (PlayerPrefs.GetInt("level_no") + 1) ;
    }

    public void LoadNextScene()
    {
        PlayerPrefs.SetInt("level_no", PlayerPrefs.GetInt("level_no") + 1);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation LoadThisScene = SceneManager.LoadSceneAsync("Level_" + PlayerPrefs.GetInt("level_no"));

        if (!LoadThisScene.isDone)
        {
            yield return null;
        }
    }

    public void RestartScene()
    {
        PlayerPrefs.SetInt("level_no", PlayerPrefs.GetInt("level_no"));
        StartCoroutine(LoadScene());
    }
}
