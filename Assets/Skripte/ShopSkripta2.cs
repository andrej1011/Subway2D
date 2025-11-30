using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShopSkripta2 : MonoBehaviour
{
    public TextMeshProUGUI NovacText;
    public TextMeshProUGUI C2Text;
    public TextMeshProUGUI S2Text;
    int ukupanNovac=0;
    int c2;
    int s2;
    // Start is called before the first frame update
    void Start()
    {
        ukupanNovac = PlayerPrefs.GetInt("novac", 0);
        NovacText.text = ukupanNovac.ToString("D4");
        s2 = PlayerPrefs.GetInt("s2", 0);
        c2 = PlayerPrefs.GetInt("c2", 0);
        S2Text.text = s2.ToString();
        C2Text.text = c2.ToString();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VratiSe()
    {
        SceneManager.LoadScene(0);
    }
    public void HESOYAM(){
        ukupanNovac=1000;
        NovacText.text = ukupanNovac.ToString("D4");
        PlayerPrefs.SetInt("novac", ukupanNovac);
        c2 = 0;
        PlayerPrefs.SetInt("c2", c2);
        C2Text.text = c2.ToString();
        s2 = 0;
        PlayerPrefs.SetInt("s2", s2);
        S2Text.text = s2.ToString();
    }
    public void KupiCoins(){
         //skida sa racuna
        if(ukupanNovac>=30){
            ukupanNovac-=30;
            PlayerPrefs.SetInt("novac", ukupanNovac);
            NovacText.text = ukupanNovac.ToString("D4");
            //dodaje powerup coinsbooster
            c2+=1;
            PlayerPrefs.SetInt("c2", c2);
            C2Text.text = c2.ToString();
        }
        
    }
    public void KupiScore(){
         //skida sa racuna
        if(ukupanNovac>=40){
            ukupanNovac-=40;
            PlayerPrefs.SetInt("novac", ukupanNovac);
            NovacText.text = ukupanNovac.ToString("D4");
            //dodaje powerup scorebooster
            s2+=1;
            PlayerPrefs.SetInt("s2", s2);
            S2Text.text = s2.ToString();
        }
    }
}
