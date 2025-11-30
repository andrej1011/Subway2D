using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenadzer : MonoBehaviour
{
    public GameObject GameOverObject;
    public GameObject TopObject;
    public GameObject Pauza;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI novacText;
    
    public void EnableGM()
    {
        GameOverObject.SetActive(true);
        novacText.text = GameManager.Instance.novcici.ToString("D4");
        scoreText.text = Mathf.FloorToInt(GameManager.Instance.skor).ToString("D4");
    }

    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
    public void DisableGM()
    {
        GameOverObject.SetActive(false);
    }
    public void EnableT()
    {
        TopObject.SetActive(true);
    }
    public void DisableT()
    {
        TopObject.SetActive(false);
    }
    public void Pauziraj()
    {
        Time.timeScale = 0;
        DisableT();
        GameManager.Instance.back.Pause();
        Pauza.SetActive(true);

        
    }
    public void Nastavi()
    {
        Time.timeScale = 1;
        Pauza.SetActive(false);
        GameManager.Instance.back.UnPause();
        EnableT();
    }
    public void Odustani()
    {
        Time.timeScale = 1;
        Pauza.SetActive(false);
        GameManager.Instance.KrajIgre();
        DisableGM();
        SceneManager.LoadScene(0);

    }
}
