using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private float highscore;
    public TextMeshProUGUI HighScoreText;
    public TextMeshProUGUI NovacText;

    public void Start()
    {
        highscore = PlayerPrefs.GetFloat("hiscore", 0);
        HighScoreText.text =
            Mathf.FloorToInt(highscore).ToString("D4");
        int ukupanNovac = PlayerPrefs.GetInt("novac", 0);
        NovacText.text = ukupanNovac.ToString("D4");


    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenShop()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Debug.Log("kvit");
        Application.Quit();
    }
}
