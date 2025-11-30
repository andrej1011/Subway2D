using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public AudioSource go;
    public AudioClip go1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other){
    
        if (other.CompareTag("Prepreka"))
        {
            go.clip = go1;
            go.Play();
            GameManager.Instance.KrajIgre();
        }
        if (other.CompareTag("Novcic"))
        {
            GameManager.Instance.novcici+=GameManager.Instance.coinmultiplier;
            GameManager.Instance.novacText.text = GameManager.Instance.novcici.ToString("D4");
            //Sound kad je pokupljen novcic
            src.clip = sfx1;
            src.Play();
            Destroy(other.gameObject);
        }
    }
}
