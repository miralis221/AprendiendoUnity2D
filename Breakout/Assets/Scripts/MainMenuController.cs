using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    bool loadingScene;
    // Start is called before the first frame update
    public void StartGame()
    {
        if (loadingScene)
        {
            return;
        }
        StartCoroutine(LoadNextScene("Level_0"));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        loadingScene = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
