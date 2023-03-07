using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollectSystem : MonoBehaviour
{
    [Header("Money")]
    [SerializeField] GameObject moneyPrefab;
    
    [Header("Ouside References")]
    [SerializeField] CreateThingsSystem createItensReference;


     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EmptyBody")) 
        {
            StartCoroutine(EnemieEnteredHere(other.gameObject));
        }
    }
    
    IEnumerator EnemieEnteredHere(GameObject bodyEntered)
    {
        yield return new WaitForSeconds(1f);
        createItensReference.CreatePrefabObject(moneyPrefab, bodyEntered.transform);

        if(bodyEntered != null)
        {
            Destroy(bodyEntered); 
        }
        else yield return null;
        
    }
}
