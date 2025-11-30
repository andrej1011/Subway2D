using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VozneSine : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = GameManager.Instance.brzinaIgre/30;
        meshRenderer.material.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
    }
}
