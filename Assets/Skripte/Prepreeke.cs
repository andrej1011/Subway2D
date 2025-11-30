using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prepreeke : MonoBehaviour
{
    private float donjaIvica;

    private void Start()
    {
        donjaIvica = Camera.main.ScreenToWorldPoint(Vector3.zero).y-3f;
    }

    // Samo treba da se pomera nadole u y-= i kad je van ekrana da nestane
    void Update()
    {
        transform.position += Vector3.down * GameManager.Instance.brzinaIgre * Time.deltaTime;
        if (transform.position.y < donjaIvica)
        {
            Destroy(gameObject);
        }
    }
}
