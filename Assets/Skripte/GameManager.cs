using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float brzinaIgre {  get; private set; }
    public float ubrzanjeIgre = 0.1f;
    public float pocetnaBrzinaIgre = 5f;

    public AudioSource back;
    public AudioClip muzika;
    

    private Player player;
    public Spawner spawner;
    public Spawner spawner0;
    public Spawner spawner2;
    private UIMenadzer uim;
    public float skor;
    public int novcici;
    public int coinmultiplier=1;
    public int scoremultiplier=1;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI novacText;
    public TextMeshProUGUI deadScore;
    public TextMeshProUGUI deadMoney;

    public int c2;
    public int s2;
    public GameObject DugmeS2;
    public GameObject DugmeC2;
    public GameObject AlertS;
    public GameObject AlertC;
    public GameObject TextS;
    public GameObject TextC;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(Instance);
        }
    }
    private void OnDestroy()
    {
        if(Instance==this)
            Instance = null;
    }
    //struktura za pocetak igre
    private void Start()
    {
        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        uim = FindObjectOfType<UIMenadzer>();
        NovaIgra();
    }
    public void NovaIgra()   
    {
        back.clip = muzika;
        back.Play();
        back.loop = true;
        skor = 0;
        novcici = 0;
        novacText.text = novcici.ToString("D4");
        uim.EnableT();
        uim.DisableGM();
        Prepreeke[] obstacles = FindObjectsOfType<Prepreeke>();
        foreach(var  obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        spawner0.gameObject.SetActive(true);
        spawner2.gameObject.SetActive(true);
        Powerups();

    }
    public void Powerups(){
        s2 = PlayerPrefs.GetInt("s2", 0);
        c2 = PlayerPrefs.GetInt("c2", 0);
        if(s2>=1)
            DugmeS2.SetActive(true);
        if(c2>=1)
            DugmeC2.SetActive(true);
        Invoke("DisablePowerups",5);
    }
    public void DisablePowerups(){
        DugmeC2.SetActive(false);
        DugmeS2.SetActive(false);
    }

    public void DugmeC(){
        DisablePowerups();
        c2-=1;
        PlayerPrefs.SetInt("c2", c2);
        AlertC.SetActive(true);
        TextC.SetActive(true);
        coinmultiplier=2;//menja racunanje coina
        Invoke("DisableAlerts",2);
        Invoke("Disablec2x",30);//nakon 30s vraca racunanje na staro
    }
    public void Disablec2x(){
        TextC.SetActive(false);
        coinmultiplier=1;

    }

    public void DugmeS(){
        DisablePowerups();
        s2-=1;
        PlayerPrefs.SetInt("s2", s2);
        AlertS.SetActive(true);
        TextS.SetActive(true);
        scoremultiplier=2;//menja racunanje scora
        Invoke("DisableAlerts",2);
        Invoke("Disables2x",30);//nakon 30s vraca racunanje na staro
    }
    public void DisableS2x(){
        TextS.SetActive(false);
        scoremultiplier=1;

    }

    public void DisableAlerts(){
        AlertC.SetActive(false);
        AlertS.SetActive(false);
    }
    private void Update()
    {
        brzinaIgre += ubrzanjeIgre*Time.deltaTime;
        skor += (ubrzanjeIgre * Time.deltaTime*8)*scoremultiplier;
        scoreText.text = Mathf.FloorToInt(skor).ToString("D4");
    }
    private void UpdateHiScore()
    {
        float hi = PlayerPrefs.GetFloat("hiscore", 0);
        if (skor > hi)
        {
            hi = skor;
            PlayerPrefs.SetFloat("hiscore", hi);
        }
        int ukupanNovac = PlayerPrefs.GetInt("novac", 0);
        ukupanNovac += novcici;
        PlayerPrefs.SetInt("novac", ukupanNovac);

    }
    public void KrajIgre()
    {
        
        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        spawner0.gameObject.SetActive(false);
        spawner2.gameObject.SetActive(false);
        brzinaIgre = 0f;
        enabled = false;
        back.Stop();
        TextS.SetActive(false);
        TextC.SetActive(false);
       
        //prikazi score i novcice od trenutne igre
        deadMoney.text = novcici.ToString("D4");
        deadScore.text = Mathf.FloorToInt(skor).ToString("D4");
        UpdateHiScore();
        Prepreeke[] obstacles = FindObjectsOfType<Prepreeke>(); //uklanja sve prepreke kako ne bi puko program
        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        uim.DisableT();
        uim.EnableGM();


    }
}
