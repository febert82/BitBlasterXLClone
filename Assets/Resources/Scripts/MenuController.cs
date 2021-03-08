using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Text highscoreText;
    public int highscoreInt;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("highscore"))
        {
            this.highscoreInt = PlayerPrefs.GetInt("highscore");
        }
        else
        {
            this.highscoreInt = 0;
            PlayerPrefs.SetInt("highscore", 0);
        }

        this.highscoreText.text = "Highscore: " + this.highscoreInt.ToString();
    }

    public void OnPlayClick()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
