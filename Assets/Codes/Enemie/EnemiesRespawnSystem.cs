using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesRespawnSystem : MonoBehaviour
{
    [Header("Enemies Models")]
    [SerializeField] GameObject[] allPossibleEnemiesPrefab;

    [Header("All Spawn Places")]
    [SerializeField] Transform[] spawnPoints;

    [Header("Spawn Time")]
    [SerializeField] float waitTime;


    public void BeginRespawn() => StartCoroutine(SpawnAnEnemie());
    

    IEnumerator SpawnAnEnemie()
    {
        int randomEnemie = Random.Range(0, allPossibleEnemiesPrefab.Length - 1);
        int randomRespawnPos = Random.Range( 0, spawnPoints.Length - 1);
        yield return new WaitForSeconds(waitTime);
        GetComponent<CreateThingsSystem>().CreatePrefabObject(allPossibleEnemiesPrefab[randomEnemie], spawnPoints[randomRespawnPos]);
        Invoke("BeginRespawn",1f);
    }
  
}
