using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]public struct Spawnable
    {
        public GameObject prefab;
        [Range(0f, 1f)] public float SpawnChance;
        //za svaku prepreku odredjujemo njenu sansu pojavljivanja
    }
    public Spawnable[] objekti;

    public float minSpawnrate = 1f;
    public float maxSpawnrate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn),Random.Range(minSpawnrate, maxSpawnrate));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Spawn()
    {
        float spawnChance = Random.value;
        foreach(var obj in objekti) {
            if (spawnChance < obj.SpawnChance) { 
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.SpawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnrate, maxSpawnrate));
    }
}