using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour
{
    IEnumerator Start()
    {

        yield return new WaitForSeconds(3.0f);
        AsyncOperation LoadThisScene = SceneManager.LoadSceneAsync("Level_" + PlayerPrefs.GetInt("level_no"));

        if (!LoadThisScene.isDone)
        {
            yield return null;
        }
    }
}
