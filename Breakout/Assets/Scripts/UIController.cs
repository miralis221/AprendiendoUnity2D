using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject winnerPanel;
    [SerializeField] GameObject[] livesImg;
    [SerializeField] Text gameTimeText;
    [SerializeField] AudioClip buttonPress;
    bool loadingScene;
    public enum Niveles
    {
        Level_0,
        Level_1,
        Level_2,
        Level_3,
    }

    public void ActivateLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void ActivateWinnerPanel(float gameTime)
    {
        winnerPanel.SetActive(true);
        gameTimeText.text = "Game Time: " + Mathf.Floor(gameTime) + " s";
    }

    public void RestarCurrentScene()
    {
        if (loadingScene == true)
        {
            return;
        }
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene(Niveles.Level_0.ToString));
    }

    private IEnumerator LoadNextScene(Func<string> toString)
    {
        throw new NotImplementedException();
    }

    public void NextLevel()
    {
        
        if (loadingScene == true)
        {
            return;
        }
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level_0")
        {
            FindObjectOfType<AudioController>().PlaySfx(buttonPress);
            StartCoroutine(LoadNextScene("Level_1"));
        }
        else if (scene.name == "Level_1")
        {
            FindObjectOfType<AudioController>().PlaySfx(buttonPress);
            StartCoroutine(LoadNextScene("Level_2"));
        }
        else if (scene.name == "Level_2")
        {
            FindObjectOfType<AudioController>().PlaySfx(buttonPress);
            StartCoroutine(LoadNextScene("Level_3"));
        }

    }

    public void GoToMainMenu()
    {
        if (loadingScene == true)
        {
            return;
        }
        FindObjectOfType<AudioController>().PlaySfx(buttonPress);
        StartCoroutine(LoadNextScene("MainMenu"));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        loadingScene = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateUILives(byte currentLives)
    {
        for (int i = 0; i < livesImg.Length; i++)
        {
            if (i>= currentLives)
            {
                livesImg[i].SetActive(false);
            }
        }
    }
}
